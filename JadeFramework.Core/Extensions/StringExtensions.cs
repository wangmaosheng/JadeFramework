using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace JadeFramework.Core.Extensions
{
    /// <summary>
    /// 字符串方法扩展
    /// </summary>
    public static class StringExtentions
    {

        #region 字符转换操作

        /// <summary>
        /// 驼峰命名
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToHump(this string text)
        {
            string[] array = text.Split('_');
            string res = string.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                res += array[i].ToUpperHead();
            }
            return res;
        }

        /// <summary>
        /// 驼峰命名（不移除 _ ）
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToOnlyHump(this string text)
        {
            string[] array = text.Split('_');
            List<string> newarray = new List<string>();
            for (int i = 0; i < array.Length; i++)
            {
                newarray.Add(array[i].ToUpperHead());
            }
            return newarray.Join("_");
        }

        /// <summary>
        /// 转拼音
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToPinYin(this string text)
        {
            return PinYin.PinYin.GetPinyin(text);
        }

        /// <summary>
        /// 换为首字母大写的字符串
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <returns>首字母大写的字符串</returns>
        public static string ToUpperHead(this string str)
        {
            if (str.IsNullOrEmptyOrWhiteSpace() || (str[0] >= 'A' && str[0] <= 'Z'))
            {
                return str;
            }
            if (str.Length == 1)
            {
                return str.ToUpper();
            }
            return string.Format("{0}{1}", str[0].ToString().ToUpper(), str.Substring(1).ToLower());
        }

        /// <summary>
        /// 删除字符串头部和尾部的回车/换行/空格
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>清除回车/换行/空格之后的字符串</returns>
        public static string TrimBlank(this string str)
        {
            if (str.IsNullOrEmpty())
            {
                throw new NullReferenceException("字符串不可为空");
            }
            return str.TrimLeft().TrimRight();
        }

        /// <summary>
        /// 删除字符串尾部的回车/换行/空格
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>清除回车/换行/空格之后的字符串</returns>
        public static string TrimRight(this string str)
        {
            if (!str.IsNullOrEmpty())
            {
                int i = 0;
                while ((i = str.Length) > 0)
                {
                    if (!str[i - 1].Equals(' ') && !str[i - 1].Equals('\r') && !str[i - 1].Equals('\n'))
                    {
                        break;
                    }
                    str = str.Substring(0, i - 1);
                }
            }
            return str;
        }

        /// <summary>
        /// 删除字符串头部的回车/换行/空格
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>清除回车/换行/空格之后的字符串</returns>
        public static string TrimLeft(this string str)
        {
            if (!str.IsNullOrEmpty())
            {
                while (str.Length > 0)
                {
                    if (!str[0].Equals(' ') && !str[0].Equals('\r') && !str[0].Equals('\n'))
                    {
                        break;
                    }
                    str = str.Substring(1);
                }
            }
            return str;
        }

        /// <summary>
        /// 相同字符串的数量
        /// </summary>
        /// <param name="source">字符串</param>
        /// <param name="pattern">相比较字符串</param>
        /// <returns></returns>
        public static int MatchesCount(this string source, string pattern)
        {
            var result = source.IsNullOrEmpty() ? 0 : Regex.Matches(source, pattern).Count;
            return result;
        }

        /// <summary>
        /// 获取字符串长度，按中文2位，英文1位进行计算
        /// </summary>
        /// <param name="source">字符串</param>
        /// <returns></returns>
        public static int CharCodeLength(string source)
        {
            var n = 0;
            foreach (var c in source.ToCharArray())
                if (c < 128)
                    n++;
                else
                    n += 2;
            return n;
        }

        /// <summary>
        /// 字符串转换成bool类型
        /// </summary>
        /// <param name="source">字符串</param>
        /// <returns></returns>
        public static bool ToBoolean(this string source)
        {
            bool reValue;
            bool.TryParse(source, out reValue);
            return reValue;
        }
        /// <summary>
        /// 转化为Byte型
        /// </summary>
        /// <returns>Byte</returns>
        public static Byte ToByte(this string source)
        {
            Byte reValue;
            Byte.TryParse(source, out reValue);
            return reValue;
        }
        /// <summary>
        /// 转化为Short型
        /// </summary>
        /// <returns>Short</returns>
        public static short ToShort(this string source)
        {
            short reValue;
            short.TryParse(source, out reValue);
            return reValue;
        }
        /// <summary>
        /// 转化为Short型
        /// </summary>
        /// <returns>Short</returns>
        public static short ToInt16(this string source)
        {
            short reValue;
            short.TryParse(source, out reValue);
            return reValue;
        }
        /// <summary>
        /// 转化为int32型
        /// </summary>
        /// <returns>int32</returns>
        public static int ToInt32(this string source)
        {
            int reValue;
            Int32.TryParse(source, out reValue);
            return reValue;
        }
        /// <summary>
        /// 转化为int64型
        /// </summary>
        /// <returns>int64</returns>
        public static long ToInt64(this string source)
        {
            long reValue;
            Int64.TryParse(source, out reValue);
            return reValue;
        }
        /// <summary>
        /// 转化为Double型
        /// </summary>
        /// <returns>decimal</returns>
        public static Double ToDouble(this string source)
        {
            Double reValue;
            Double.TryParse(source, out reValue);
            return reValue;
        }
        /// <summary>
        /// 转化为decimal型
        /// </summary>
        /// <returns>decimal</returns>
        public static decimal ToDecimal(this string source)
        {
            decimal reValue;
            decimal.TryParse(source, out reValue);
            return reValue;
        }

        /// <summary>
        /// 转化为数字类型的日期
        /// </summary>
        /// <returns>DateTime</returns>
        public static decimal ToDateTimeDecimal(this string source)
        {
            DateTime reValue;
            return DateTime.TryParse(source, out reValue) ? reValue.ToString("yyyyMMddHHmmss").ToDecimal() : 0;
        }

        /// <summary>
        /// HDF
        /// 2009-3-12
        /// 将时间转换成数字
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static decimal ToDateTimeDecimal(this DateTime source)
        {
            return source.ToString("yyyyMMddHHmmss").ToDecimal();
        }

        /// <summary>
        /// 转换成TextArea保存的格式；（textarea中的格式保存显示的时候会失效）
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToTextArea(this string @source)
        {
            return source.IsNullOrEmpty() ? source : source.Replace("\n\r", "<br/>").Replace("\r", "<br>").Replace("\t", "　　");
        }

        #region Substring扩展

        /// <summary>
        /// SubString方法扩展
        /// </summary>
        /// <param name="str">截取字符串</param>
        /// <param name="length">要截取的长度</param>
        /// <returns>string</returns>
        public static string Substring(this string str, int length)
        {
            if (string.IsNullOrEmpty(str) || str.Length <= length)
            {
                return str;
            }
            return str.Substring(0, length);
        }

        /// <summary>
        /// 截取字符并显示...符号
        /// </summary>
        /// <param name="str">截取字符串</param>
        /// <param name="length">要截取的长度</param>
        /// <returns>string</returns>
        public static string SubstringToSx(this string str, int length)
        {
            if (string.IsNullOrEmpty(str) || str.Length <= length)
            {
                return str;
            }
            return str.Substring(0, length) + "...";
        }

        /// <summary>
        /// 根据某个字符截取
        /// </summary>
        /// <param name="text">要截取的字符串</param>
        /// <param name="delimiter">字符</param>
        /// <returns></returns>
        public static string SubstringUpToFirst(this string text, char delimiter)
        {
            if (text == null)
            {
                return null;
            }
            var num = text.IndexOf(delimiter);
            if (num >= 0)
            {
                return text.Substring(0, num);
            }
            return text;
        }

        #endregion

        /// <summary>
        /// 字符串拼接成的数组转换成集合
        /// </summary>
        /// <param name="arrStr">要转换的字符串</param>
        /// <param name="splitchar">分离字符(默认,)</param>
        /// <returns></returns>
        public static List<int> ToIntList(this string arrStr, char splitchar = ',')
        {
            if (arrStr.IsNullOrEmpty())
            {
                return new List<int>();
            }
            else
            {
                try
                {
                    return arrStr.Split(splitchar).Select(m => m.ToInt32()).ToList();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
            }
        }

        /// <summary>
        /// 将字符串转换成int类型的数组
        /// </summary>
        /// <param name="arrStr">要转换的字符串</param>
        /// <param name="splitchar">分离字符(默认,)</param>
        /// <returns></returns>
        public static int[] ToIntArray(this string arrStr, char splitchar = ',')
        {
            if (arrStr.IsNullOrEmpty())
            {
                return new int[0];
            }
            try
            {
                int[] array = arrStr.Split(splitchar).Select(m => m.ToInt32()).ToArray();
                return array;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// 反射获取属性值
        /// </summary>
        /// <typeparam name="T">匿名对象</typeparam>
        /// <param name="t">匿名对象集合</param>
        /// <param name="propertyname">属性名</param>
        /// <returns></returns>
        public static string GetPropertyValue<T>(this T t, string propertyname)
        {
            Type type = typeof(T);
            PropertyInfo property = type.GetProperty(propertyname);

            if (property == null) return string.Empty;

            object o = property.GetValue(t, null);

            if (o == null) return string.Empty;

            return o.ToString();
        }

        #endregion

        #region 字符串判断/验证

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="source">字符串</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="source">字符串</param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty(this string source)
        {
            return !string.IsNullOrEmpty(source);
        }

        /// <summary>
        /// 指示指定的字符串是 null、空还是仅由空白字符组成
        /// </summary>
        /// <param name="source">要测试的字符串</param>
        /// <returns>如果 value 参数为 null 或 System.String.Empty，或者如果 value 仅由空白字符组成，则为 true。</returns>
        public static bool IsNullOrWhiteSpace(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }

        /// <summary>
        /// 字符串是否为Null或Empty或WhiteSpace
        /// </summary>
        /// <param name="source">字符串</param>
        /// <returns>是否为Null或Empty或WhiteSpace</returns>
        public static bool IsNullOrEmptyOrWhiteSpace(this string source)
        {
            return string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source);
        }

        /// <summary>
        /// 是否匹配相等
        /// </summary>
        /// <param name="source">字符串</param>
        /// <param name="pattern">相比较字符串</param>
        /// <returns></returns>
        public static bool IsMatch(this string source, string pattern)
        {
            return !source.IsNullOrEmpty() && Regex.IsMatch(source, pattern);
        }

        /// <summary>
        /// 相同的字符串
        /// </summary>
        /// <param name="source">字符串</param>
        /// <param name="pattern">相比较字符串</param>
        /// <returns>相同的字符串</returns>
        public static string Match(this string source, string pattern)
        {
            string result = source.IsNullOrEmpty() ? "" : Regex.Match(source, pattern).Value;
            return result;
        }

        /// <summary>
        /// 是否是url地址
        /// </summary>
        /// <param name="checkStr">字符串</param>
        /// <returns></returns>
        public static bool IsUrlAddress(this string checkStr)
        {
            return !checkStr.IsNullOrEmpty() && Regex.IsMatch(checkStr, @"[a-zA-z]+://[^s]*", RegexOptions.Compiled);
        }

        /// <summary>
        /// 判断是否是正确的电子邮件格式
        /// </summary>
        /// <param name="source">字符串</param>
        /// <returns>bool</returns>
        public static bool IsEmail(this string source)
        {
            return Regex.IsMatch(source, @"^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$", RegexOptions.Compiled);
        }
        /// <summary>
        /// 判断是否是正确的身份证编码格式
        /// </summary>
        /// <param name="source">字符串</param>
        /// <returns>bool</returns>
        public static bool IsIdCard(this string source)
        {
            return Regex.IsMatch(source, @"^\d{17}(\d|x)$|^\d{15}$", RegexOptions.Compiled);
        }
        /// <summary>
        /// 判断是否是15位身份证号
        /// </summary>
        /// <param name="id">身份证号</param>
        /// <param name="mesage">返回结果信息</param>
        /// <returns></returns>
        public static bool IsIdCard15(this string id, out string mesage)
        {
            long n = 0;
            if (long.TryParse(id, out n) == false || n < Math.Pow(10, 14))
            {
                mesage = "不是有效的身份证号";
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(id.Remove(2)) == -1)
            {
                mesage = "省份不合法";
                return false;//省份验证
            }
            string birth = id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                mesage = "生日不合法";
                return false;//生日验证
            }
            mesage = "正确";
            return true;//符合15位身份证标准
        }
        /// <summary>
        /// 判断是否是正确的邮政编码格式
        /// </summary>
        /// <param name="source">字符串</param>
        /// <returns></returns>
        public static bool IsPostcode(this string source)
        {
            return Regex.IsMatch(source, @"^[1-9]{1}(\d){5}$", RegexOptions.Compiled);
        }
        /// <summary>
        /// 判断是否是正确的中国移动或联通电话
        /// </summary>
        /// <param name="source">字符串</param>
        /// <returns></returns>
        public static bool IsMobilePhone(this string source)
        {
            return Regex.IsMatch(source, @"^(86)*0*13\d{9}$", RegexOptions.Compiled);
        }
        /// <summary>
        /// 判断是否是正确的中国固定电话
        /// </summary>
        /// <param name="source">字符串</param>
        /// <returns></returns>
        public static bool IsTelephone(this string source)
        {
            return Regex.IsMatch(source, @"^((\d{3,4})|\d{3,4}-|\s)?\d{8}$", RegexOptions.Compiled);
        }
        /// <summary>
        /// 包含html标签
        /// </summary>
        /// <param name="source">字符串</param>
        /// <returns></returns>
        public static bool IsHasHtml(this string source)
        {
            Regex reg = new Regex(@"<|>");
            return reg.IsMatch(source);
        }
        /// <summary>
        /// 是否匹配正则表达式，匹配返回true，否则false
        /// </summary>
        /// <param name="source">字符串</param>
        /// <param name="regex">正则表达式</param>
        /// <returns></returns>
        public static bool IsMatchRegex(this string source, string regex)
        {
            Regex r = new Regex(regex);
            return r.IsMatch(source);
        }
        /// <summary>
        /// 判断字符串是否是IP，如果是返回True，不是返回False
        /// </summary>
        /// <param name="source">字符串</param>
        /// <returns></returns>
        public static bool IsIp(this string source)
        {
            Regex regex = new Regex(@"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])"
                + @"\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$", RegexOptions.Compiled);
            return regex.Match(source).Success;
        }
        /// <summary>
        /// 是否包含中文或全角字符
        /// </summary>
        /// <param name="checkStr">字符串</param>
        /// <returns></returns>
        public static bool IsHasChinese(this string checkStr)
        {
            ASCIIEncoding n = new ASCIIEncoding();
            byte[] b = n.GetBytes(checkStr);
            for (int i = 0; i <= b.Length - 1; i++)
                if (b[i] == 63) return true;  //判断是否(T)为汉字或全脚符号 
            return false;
        }
        /// <summary>
        /// 是否是中文
        /// </summary>
        /// <param name="checkStr">字符串</param>
        /// <returns></returns>
        public static bool IsAllChinese(this string checkStr)
        {
            checkStr = checkStr.Trim();
            if (checkStr == string.Empty) return false;
            Regex reg = new Regex(@"^([\u4e00-\u9fa5]*)$", RegexOptions.Compiled);
            return reg.IsMatch(checkStr);
        }
        /// <summary>
        /// 是否为正整数
        /// </summary>
        /// <param name="intStr">字符串</param>
        /// <returns></returns>
        public static bool IsInt(this string intStr)
        {
            Regex regex = new Regex("^\\d+$", RegexOptions.Compiled);
            return regex.IsMatch(intStr.Trim());
        }
        /// <summary>
        /// 非负整数
        /// </summary>
        /// <param name="intStr">字符串</param>
        /// <returns></returns>
        public static bool IsIntWithZero(this string intStr)
        {
            return Regex.IsMatch(intStr, @"^\\d+$", RegexOptions.Compiled);
        }
        /// <summary>
        /// 是否是数字
        /// </summary>
        /// <param name="checkStr">字符串</param>
        /// <returns></returns>
        public static bool IsNumber(this string checkStr)
        {
            return Regex.IsMatch(checkStr, @"^[+-]?[0123456789]*[.]?[0123456789]*$", RegexOptions.Compiled);
        }
        /// <summary>
        /// 是否是Decimal类型数据
        /// </summary>
        /// <param name="checkStr">字符串</param>
        /// <returns></returns>
        public static bool IsDecimal(this string checkStr)
        {
            return Regex.IsMatch(checkStr, @"^[0-9]+/.?[0-9]{0,2}$", RegexOptions.Compiled);
        }
        /// <summary>
        /// 是否是DateTime类型数据
        /// </summary>
        /// <param name="checkStr">字符串</param>
        /// <returns></returns>
        public static bool IsDateTime(this string checkStr)
        {
            return Regex.IsMatch(checkStr, @"^[ ]*[012 ]?[0123456789]?[0123456789]{2}[ ]*[-]{1}[ ]*[01]?[0123456789]{1}[ ]*[-]{1}[ ]*[0123]?[0123456789]"
                + @"{1}[ ]*[012]?[0123456789]{1}[ ]*[:]{1}[ ]*[012345]?[0123456789]{1}[ ]*[:]{1}[ ]*[012345]?[0123456789]{1}[ ]*$", RegexOptions.Compiled);
        }
        /// <summary>
        /// 判断是否是XML 1.0允许的字符
        /// </summary>
        /// <param name="character">字符串</param>
        /// <returns></returns>
        private static bool IsLegalXmlChar(this int character)
        {
            return
            (
                 character == 0x9 /* == '\t' == 9   */        ||
                 character == 0xA /* == '\n' == 10  */        ||
                 character == 0xD /* == '\r' == 13  */        ||
                (character >= 0x20 && character <= 0xD7FF) ||
                (character >= 0xE000 && character <= 0xFFFD) ||
                (character >= 0x10000 && character <= 0x10FFFF)
            );
        }
        /// <summary>
        /// 判断是否是合法的 XML 1.0标准允许的字符串 true：标准 false：包含不标准的字符
        /// </summary>
        /// <param name="xml">xml</param>
        /// <returns></returns>
        public static bool IsLegalXmlChar(this string xml)
        {
            return string.IsNullOrEmpty(xml) || xml.All(c => IsLegalXmlChar(c));
        }
        #endregion

        private static string[] strs =
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v","w", "x", "y", "z",
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V","W", "X", "Y", "Z"
        };
        /// <summary>
        /// 创建伪随机字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strleg">长度</param>
        /// <returns></returns>
        public static string CreateNonce(this string str, long strleg = 15)
        {
            Random r = new Random();
            StringBuilder sb = new StringBuilder();
            var length = strs.Length;
            for (int i = 0; i < strleg; i++)
            {
                sb.Append(strs[r.Next(length - 1)]);
            }
            return sb.ToString();
        }

        private static string[] nums =
        {
            "0","1","2","3","4","5","6","7","8","9"
        };

        /// <summary>
        /// 创建伪随机数字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="numleg"></param>
        /// <returns></returns>
        public static string CreateNumberNonce(this string str, int numleg = 4)
        {
            Random r = new Random();
            StringBuilder sb = new StringBuilder();
            var length = nums.Length;
            for (int i = 0; i < numleg; i++)
            {
                sb.Append(nums[r.Next(length - 1)]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 移除换行
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveLine(this string str)
        {
            if (str.IsNullOrEmpty())
            {
                return str;
            }
            return str.Replace("\r", "").Replace("\n", "");
        }
    }
}