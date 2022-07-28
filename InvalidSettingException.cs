using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Setting
{
	/// <summary>設定</summary>
	[Serializable()]
	public class InvalidSettingException : Exception
	{
		public InvalidSettingException() {}

		public InvalidSettingException(string _setting_name) : base("Setting [" + _setting_name + "] is an invalid value") {}

		public InvalidSettingException(string _setting_name, string message) : base("Setting [" + _setting_name + "] " + message) { }

		public InvalidSettingException(string message, Exception innerException) : base(message, innerException) {}

		protected InvalidSettingException(SerializationInfo info, StreamingContext context) : base(info, context) {}
	}
}
