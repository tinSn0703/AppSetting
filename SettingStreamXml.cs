using System.Xml.Linq;

namespace Setting
{
	/// <summary>XML形式からの設定オブジェクトへの入出力を行う</summary>
	public abstract class SettingStreamXml : SettingStream
	{
		//--------------------------------------------------------------------------------------------------//
		// public method
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
		// protected method
		//--------------------------------------------------------------------------------------------------//
		/// <summary>xml属性をint型で読む</summary>
		/// <param name="_element">対象のxnl要素</param>
		/// <param name="_name">属性名</param>
		/// <returns>読み取った値</returns>
		/// <exception cref="System.NullReferenceException">指定した属性が、要素内に存在しませんでした</exception>
		/// <exception cref="InvalidSettingException">属性の値を、int型に変換できませんでした</exception>
		protected int ReadAttributeAsInt(in XElement _element, in string _name)
		{
			try { return (int)(_element.Attribute(_name) ?? throw new System.NullReferenceException("Attribute [" + _name + "] didn't exist.")); }
			catch (System.FormatException e) { throw new InvalidSettingException("Couldn't convert [" + _name + "] value to int. value = [" + _element.Attribute(_name).Value + "]", e); }
		}

		//--------------------------------------------------------------------------------------------------//
		/// <summary>xml属性をshort型で読む</summary>
		/// <param name="_element">対象のxnl要素</param>
		/// <param name="_name">属性名</param>
		/// <returns>読み取った値</returns>
		/// <exception cref="System.NullReferenceException">指定した属性が、要素内に存在しませんでした</exception>
		/// <exception cref="InvalidSettingException">属性の値を、short型に変換できませんでした</exception>
		protected short ReadAttributeAsShort(in XElement _element, in string _name)
		{
			try { return (short)(_element.Attribute(_name) ?? throw new System.NullReferenceException("Attribute [" + _name + "] didn't exist.")); }
			catch (System.FormatException e) { throw new InvalidSettingException("Couldn't convert [" + _name + "] value to short. value = [" + _element.Attribute(_name).Value + "]", e); }
		}

		//--------------------------------------------------------------------------------------------------//
		/// <summary>xml属性をbool型で読む</summary>
		/// <param name="_element">対象のxnl要素</param>
		/// <param name="_name">属性名</param>
		/// <returns>読み取った値</returns>
		/// <exception cref="System.NullReferenceException">指定した属性が、要素内に存在しませんでした</exception>
		/// <exception cref="InvalidSettingException">属性の値を、bool型に変換できませんでした</exception>
		protected bool ReadAttributeAsBool(in XElement _element, in string _name)
		{
			try { return (bool)(_element.Attribute(_name) ?? throw new System.NullReferenceException("Attribute [" + _name + "] didn't exist.")); }
			catch (System.FormatException e) { throw new InvalidSettingException("Couldn't convert [" + _name + "] value to bool. value = [" + _element.Attribute(_name).Value + "]", e); }
		}

		//--------------------------------------------------------------------------------------------------//
		/// <summary>xml属性をstring型で読む</summary>
		/// <param name="_element">対象のxnl要素</param>
		/// <param name="_name">属性名</param>
		/// <returns>読み取った値</returns>
		/// <exception cref="System.NullReferenceException">指定した属性が、要素内に存在しませんでした</exception>
		protected string ReadAttributeAsString(in XElement _element, in string _name)
		{
			var _value = _element.Attribute(_name) ?? throw new System.NullReferenceException("Attribute [" + _name + "] didn't exist.");
			return _value.Value;
		}

		//--------------------------------------------------------------------------------------------------//
		// property
		//--------------------------------------------------------------------------------------------------//
		/// <summary>操作する設定名</summary>
		public abstract string ElementName { get; }

		//--------------------------------------------------------------------------------------------------//
	}
}
