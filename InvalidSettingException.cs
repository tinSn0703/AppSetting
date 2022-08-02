using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Setting
{
	/// <summary>無効な設定であった場合に発生するエラーを表す</summary>
	[Serializable()]
	public class InvalidSettingException : Exception
	{
		//--------------------------------------------------------------------------------------------------//
		/// <summary>新しいインスタンスを初期化します。</summary>
		public InvalidSettingException() : base("Setting is an invalid value.") {}

		//--------------------------------------------------------------------------------------------------//
		/// <summary>指定した設定名を使用して、新しいインスタンスを初期化します。</summary>
		/// <param name="_settingName">設定名</param>
		public InvalidSettingException(string _settingName) : this(_settingName, "") {}

		//--------------------------------------------------------------------------------------------------//
		/// <summary>指定した設定名とエラーメッセージを使用して、新しいインスタンスを初期化します。</summary>
		/// <param name="_settingName">設定名</param>
		/// <param name="message">エラーメッセージ</param>
		public InvalidSettingException(string _settingName, string message) : base("Setting [" + _settingName + "] " + (string.IsNullOrWhiteSpace(message) ? "is an invalid value." : message))  { }

		//--------------------------------------------------------------------------------------------------//
		/// <summary>指定したエラー メッセージおよびこの例外の原因となった内部例外への参照を使用して、新しいインスタンスを初期化します。</summary>
		/// <param name="message">エラーメッセージ</param>
		/// <param name="innerException">現在の例外の原因である例外</param>
		public InvalidSettingException(string message, Exception innerException) : base(message, innerException) {}

		//--------------------------------------------------------------------------------------------------//
		protected InvalidSettingException(SerializationInfo info, StreamingContext context) : base(info, context) {}

		//--------------------------------------------------------------------------------------------------//
	}
}
