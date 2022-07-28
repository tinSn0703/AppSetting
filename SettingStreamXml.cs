using System.Xml.Linq;

namespace Setting
{
	/// <summary>XML形式からの設定オブジェクトへの入出力を行う</summary>
	public abstract class SettingStreamXml : SettingStream
	{
		//--------------------------------------------------------------------------------------------------//
		// method
		//--------------------------------------------------------------------------------------------------//

		public SettingStreamXml() {}

		//--------------------------------------------------------------------------------------------------//
		/// <summary>XML形式の設定を、登録された設定オブジェクトへ書き込む</summary>
		/// <param name="_element">XML形式の設定</param>
		public abstract void Write(in XElement _element);

		//--------------------------------------------------------------------------------------------------//
		/// <summary>設定オブジェクトを登録し、XML形式の設定から内容を書き込む</summary>
		/// <param name="_setting">設定オブジェクト</param>
		/// <param name="_element">XML形式の設定</param>
		public abstract void Write(in Setting _setting, in XElement _element);

		//--------------------------------------------------------------------------------------------------//
		/// <summary>登録された設定オブジェクトから、XML形式の設定を読み出す</summary>
		/// <param name="_element">XML形式の設定の出力</param>
		public abstract void Read(out XElement _element);

		//--------------------------------------------------------------------------------------------------//
		/// <summary>設定オブジェクト登録し、XML形式の設定を読み出す</summary>
		/// <param name="_setting">設定オブジェクト</param>
		/// <param name="_element">XML形式の設定の出力</param>
		public abstract void Read(in Setting _setting, out XElement _element);

		//--------------------------------------------------------------------------------------------------//
		// property
		//--------------------------------------------------------------------------------------------------//
		/// <summary>操作する設定名</summary>
		public abstract string ElementName { get; }

		//--------------------------------------------------------------------------------------------------//
	}
}
