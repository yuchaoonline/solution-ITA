using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Text.RegularExpressions;

namespace ITAMngApp.ApplicationFun
{
    public class RegexHelper
    {
        /// <summary>
        /// �Ƿ�����
        /// </summary>
        /// <param name="p_value"></param>
        /// <returns></returns>

        public static bool IsofInt(string p_value)
        {
            string _Match = ConfigurationSettings.AppSettings["RegIntMatch"];
            Regex _regex = new Regex(_Match);
            return _regex.IsMatch(p_value);
        }

        /// <summary>
        /// �Ƿ�������
        /// </summary>
        /// <param name="p_value"></param>
        /// <returns></returns>
        public static bool IsofPositiveInt(string p_value)
        {
            string _Match = ConfigurationSettings.AppSettings["RegPositiveIntMatch"];
            Regex _regex = new Regex(_Match);
            return _regex.IsMatch(p_value);
        }
        /// <summary>
        /// �Ƿ�Ǹ�����
        /// </summary>
        /// <param name="p_value"></param>
        /// <returns></returns>
        public static bool IsofNotNegtiveInt(string p_value)
        {
            string _Match = ConfigurationSettings.AppSettings["RegNotNegtiveIntMatch"];
            Regex _regex = new Regex(_Match);
            return _regex.IsMatch(p_value);
        }
        /// <summary>
        /// �Ƿ�����
        /// </summary>
        /// <param name="p_value"></param>
        /// <returns></returns>
        public static bool IsofNegtiveInt(string p_value)
        {
            string _Match = ConfigurationSettings.AppSettings["RegNegtiveIntMatch"];
            Regex _regex = new Regex(_Match);
            return _regex.IsMatch(p_value);
        }
        /// <summary>
        /// �Ƿ��������
        /// </summary>
        /// <param name="p_value"></param>
        /// <returns></returns>
        public static bool IsofNotPositiveInt(string p_value)
        {
            string _Match = ConfigurationSettings.AppSettings["RegNotPositiveIntMatch"];
            Regex _regex = new Regex(_Match);
            return _regex.IsMatch(p_value);
        }
        public static bool IsofMintoMaxInt(string p_value, int p_min, int p_max)
        {
            if (IsofPositiveInt(p_value) == true)
            {
                if (int.Parse(p_value) < p_min || int.Parse(p_value) > p_max) return false;
                else return true;
            }
            else return false;
        }
        /// <summary>
        /// �Ƿ񸡵���
        /// </summary>
        /// <param name="p_value"></param>
        /// <returns></returns>
        public static bool IsofDouble(string p_value)
        {
            string _Match = ConfigurationSettings.AppSettings["RegDoubleMatch"];
            Regex _regex = new Regex(_Match);
            return _regex.IsMatch(p_value);
        }
        /// <summary>
        /// �Ƿ���������
        /// </summary>
        /// <param name="p_value"></param>
        /// <returns></returns>
        public static bool IsofPositiveDouble(string p_value)
        {
            string _Match = ConfigurationSettings.AppSettings["RegPositiveDoubleMatch"];
            Regex _regex = new Regex(_Match);
            return _regex.IsMatch(p_value);
        }
        /// <summary>
        /// �Ƿ�Ǹ�������
        /// </summary>
        /// <param name="p_value"></param>
        /// <returns></returns>
        public static bool IsofNotNegtiveDouble(string p_value)
        {
            string _Match = ConfigurationSettings.AppSettings["RegNotNegtiveDoubleMatch"];
            Regex _regex = new Regex(_Match);
            return _regex.IsMatch(p_value);
        }

        public static bool IsofMintoMaxDouble(string p_value,double p_min,double p_max)
        {
            if (IsofDouble(p_value) == true)
            {
                if (double.Parse(p_value) < p_min || double.Parse(p_value) > p_max) return false;
                else return true;
            }
            else return false;
        }
        /// <summary>
        /// �Ƿ����������
        /// </summary>
        /// <param name="p_value"></param>
        /// <returns></returns>
        public static bool IsofNotPositiveDouble(string p_value)
        {
            string _Match = ConfigurationSettings.AppSettings["RegNotPositiveDoubleMatch"];
            Regex _regex = new Regex(_Match);
            return _regex.IsMatch(p_value);
        }
        /// <summary>
        /// �Ƿ񸺸�����
        /// </summary>
        /// <param name="p_value"></param>
        /// <returns></returns>
        public static bool IsofNegtiveDouble(string p_value)
        {
            string _Match = ConfigurationSettings.AppSettings["RegNegtiveDoubleMatch"];
            Regex _regex = new Regex(_Match);
            return _regex.IsMatch(p_value);
        }
        /// <summary>
        /// �Ƿ�Ӣ����ĸ
        /// </summary>
        /// <param name="p_value"></param>
        /// <returns></returns>
        public static bool IsofLetters(string p_value)
        {
            string _Match = ConfigurationSettings.AppSettings["RegLettersMatch"];
            Regex _regex = new Regex(_Match);
            return _regex.IsMatch(p_value);
        }
        /// <summary>
        /// �Ƿ�Ӣ�Ĵ�д��ĸ
        /// </summary>
        /// <param name="p_value"></param>
        /// <returns></returns>
        public static bool IsofUperLetters(string p_value)
        {
            string _Match = ConfigurationSettings.AppSettings["RegUperLettersMatch"];
            Regex _regex = new Regex(_Match);
            return _regex.IsMatch(p_value);
        }
        /// <summary>
        /// �Ƿ�Ӣ��Сд��ĸ
        /// </summary>
        /// <param name="p_value"></param>
        /// <returns></returns>
        public static bool IsofLowerLetters(string p_value)
        {
            string _Match = ConfigurationSettings.AppSettings["RegLowerLettersMatch"];
            Regex _regex = new Regex(_Match);
            return _regex.IsMatch(p_value);
        }
        /// <summary>
        /// �Ƿ���ĸ������
        /// </summary>
        /// <param name="p_value"></param>
        /// <returns></returns>
        public static bool IsofLettersANDNumbers(string p_value)
        {
            string _Match = ConfigurationSettings.AppSettings["RegLettersANDNumbersMatch"];
            Regex _regex = new Regex(_Match);
            return _regex.IsMatch(p_value);
        }
        /// <summary>
        /// �Ƿ���ĸ�����֡��»���
        /// </summary>
        /// <param name="p_value"></param>
        /// <returns></returns>
        public static bool IsofLettersANDNumbersANDDownlines(string p_value)
        {
            string _Match = ConfigurationSettings.AppSettings["RegLettersANDNumbersANDDownlinesMatch"];
            Regex _regex = new Regex(_Match);
            return _regex.IsMatch(p_value);
        }
        /// <summary>
        /// �Ƿ���-��-��
        /// </summary>
        /// <param name="p_value"></param>
        /// <returns></returns>

        public static bool IsofYYMMDD(string p_value)
        {
            string _Match = ConfigurationSettings.AppSettings["RegYYMMDDMatch"];
            Regex _regex = new Regex(_Match);
            return _regex.IsMatch(p_value);
        }
        /// <summary>
        /// �Ƿ�绰����
        /// </summary>
        /// <param name="p_value"></param>
        /// <returns></returns>
        public static bool IsofPhoneNumber(string p_value)
        {
            string _Match = ConfigurationSettings.AppSettings["RegPhoneNumberMatch"];
            Regex _regex = new Regex(_Match);
            return _regex.IsMatch(p_value);
        }
        /// <summary>
        /// �Ƿ�IP��ַ
        /// </summary>
        /// <param name="p_value"></param>
        /// <returns></returns>
        public static bool IsofIPAddress(string p_value)
        {
            string _Match = ConfigurationSettings.AppSettings["RegIPAddressMatch"];
            Regex _regex = new Regex(_Match);
            return _regex.IsMatch(p_value);
        }

    }
}
