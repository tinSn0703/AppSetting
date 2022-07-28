using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Setting
{
	public class SettingFileXmlController : SettingFileController
	{
		//--------------------------------------------------------------------------------------------------//
		// field
		//--------------------------------------------------------------------------------------------------//

		private const string ROOT_ELEMENT_NAME = "settings";

		private string _setting_file_path = "";
		private XDocument _setting_xml;
		private XElement _root;

		//--------------------------------------------------------------------------------------------------//
		// method
		//--------------------------------------------------------------------------------------------------//

		public SettingFileXmlController() { }
		public SettingFileXmlController(in string _path) { this.Open(_path); }

		//--------------------------------------------------------------------------------------------------//
		/// <summary>設定ファイルを開く</summary>
		/// <param name="_path"></param>
		public override void Open(in string _path)
		{
			if (string.IsNullOrWhiteSpace(_path)) throw new ArgumentException("No path entered.", nameof(_path));
			//if (System.IO.Path.GetFileName(_path).IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) >= 0) throw new ArgumentException("The path [" + _path + "] contains invalid chars..", nameof(_path));

			if (System.IO.File.Exists(_path))
			{
				try {
					this._setting_xml = XDocument.Load(_path);
					_root = _setting_xml.Root;
				}
				catch (System.Xml.XmlException)	{	this.CreateXmlDocument(_path);	}
				
				if (_root.Name != ROOT_ELEMENT_NAME) throw new Exception("A setting file [" + _path + "] different from this application was entered.");

				this._setting_file_path = _path;
			}
			else
			{
				if (System.IO.Directory.Exists(_path)) throw new System.IO.DirectoryNotFoundException("Not found [" + _path + "].");

				try	{	System.IO.File.Create(_path).Close();	}
				catch (Exception e) { throw new Exception("Failed create file [" + _path + "].", e); }

				this.CreateXmlDocument(_path);
			}
		}

		//--------------------------------------------------------------------------------------------------//
		/// <summary>設定ファイルに設定を書き込む</summary>
		/// <param name="_stream">書き込みたい設定を登録したストリーム</param>
		public override void WriteSetting(SettingStream _stream)
		{
			if (!(_stream is SettingStream)) throw new ArgumentException("Invalid type inputed. Input type: [" + _stream.GetType().Name + "].", nameof(_stream));
			this.WriteSetting(_stream as SettingStreamXml);
		}

		//--------------------------------------------------------------------------------------------------//
		/// <summary>設定ファイルに設定を書き込む</summary>
		/// <param name="_stream">書き込みたい設定を登録したストリーム</param>
		public void WriteSetting(SettingStreamXml _stream)
		{
			if (_root is null) throw new InvalidOperationException("[" + nameof(_root) + "] is undefined.");
			if (_stream is null) throw new ArgumentNullException(nameof(_stream));

			XElement _temp = null;	_stream.Read(out _temp);
			if (_temp is null) throw new Exception("Couldn't get [" + _stream.ElementName + "].");

			XElement _element = _root.Element(_stream.ElementName);
			if (_element is null)	_root.Add(_temp);
			else					_element.ReplaceWith(_temp);
		}

		//--------------------------------------------------------------------------------------------------//
		/// <summary>設定ファイルから設定を読み出す</summary>
		/// <param name="_stream">読み出したい設定を登録したストリーム</param>
		public override void ReadSetting(SettingStream _stream)
		{
			if (!(_stream is SettingStream)) throw new ArgumentException("Invalid type inputed. Input type: [" + _stream.GetType().Name + "].", nameof(_stream));
			this.ReadSetting(_stream as SettingStreamXml);
		}

		//--------------------------------------------------------------------------------------------------//
		/// <summary>設定ファイルから設定を読み出す</summary>
		/// <param name="_stream">読み出したい設定を登録したストリーム</param>
		public void ReadSetting(SettingStreamXml _stream)
		{
			if (_root is null) throw new InvalidOperationException("[" + nameof(_root) + "] is undefined.");
			if (_stream is null) throw new ArgumentNullException(nameof(_stream));

			XElement _element = _root.Element(_stream.ElementName);
			if (_element is null) throw new Exception("The element [" + _stream.ElementName + "] doesn't exist in the setting file.");

			_stream.Write(_root.Element(_stream.ElementName));
		}

		//--------------------------------------------------------------------------------------------------//
		/// <summary>設定ファイルをセーブする</summary>
		public override void Save()
		{
			if (_setting_xml is null) throw new InvalidOperationException("[" + nameof(_setting_xml) + "] is undefined.");

			try { _setting_xml.Save(this._setting_file_path); }
			catch (Exception e) { throw new Exception("Failed save file [" + this._setting_file_path + "].", e); }
		}

		//--------------------------------------------------------------------------------------------------//
		/// <summary>設定ファイル閉じる</summary>
		public override void Close()
		{
			_root = null;
			_setting_xml = null;
		}

		//--------------------------------------------------------------------------------------------------//
		// private method
		//--------------------------------------------------------------------------------------------------//

		private void CreateXmlDocument(in string _path)
		{
			_root = new XElement(ROOT_ELEMENT_NAME);
			_setting_xml = new XDocument(_root);

			try { _setting_xml.Save(_path); }
			catch (Exception e) { throw new Exception("Failed save file [" + _path + "].", e); }

			this._setting_file_path = _path;
		}

		//--------------------------------------------------------------------------------------------------//
		// public property
		//--------------------------------------------------------------------------------------------------//
		/// <summary>設定ファイルへのパス</summary>
		public override string SettingFilePath => _setting_file_path;
		/// <summary>デフォルトの設定ファイル名</summary>
		public override string DefaultFileName { get; set; } = "setting.xml";

		//--------------------------------------------------------------------------------------------------//
	}
}
