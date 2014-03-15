using System;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace DBUtility
{
	/// <summary>
	/// iniClass ��ժҪ˵����
	/// </summary>
	// TODO: �ڴ˴���ӹ��캯���߼�
	public class iniClass
	{
		public string inipath;
		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section,string key,string val,string filePath);
		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section,string key,string def,StringBuilder retVal,int size,string filePath);
		/// <summary>
		/// ���췽��
		/// </summary>
		/// <param name="INIPath">�ļ�·��</param>
		public iniClass(string INIPath)
		{
			inipath = INIPath;
		}
		/// <summary>
		/// д��INI�ļ�
		/// </summary>
		/// <param name="Section">��Ŀ����(�� [TypeName] )</param>
		/// <param name="Key">��</param>
		/// <param name="Value">ֵ</param>
		public void IniWriteValue(string Section,string Key,string Value)
		{
			WritePrivateProfileString(Section,Key,Value,this.inipath);
		}
		/// <summary>
		/// ����INI�ļ�
		/// </summary>
		/// <param name="Section">��Ŀ����(�� [TypeName] )</param>
		/// <param name="Key">��</param>
		public string IniReadValue(string Section,string Key)
		{
			StringBuilder temp = new StringBuilder(500);
			int i = GetPrivateProfileString(Section,Key,"",temp,500,this.inipath);
			return temp.ToString();
		}
		/// <summary>
		/// ��֤�ļ��Ƿ����
		/// </summary>
		/// <returns>����ֵ</returns>
		public bool ExistINIFile()
		{
			return File.Exists(inipath);
		}
	}

	//

}
