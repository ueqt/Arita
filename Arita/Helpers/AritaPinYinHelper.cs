using Microsoft.International.Converters.PinYinConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Arita.Helpers
{
    /// <summary>
    /// 拼音帮助类
    /// </summary>
    public static class AritaPinYinHelper
    {
        #region 公有方法

        #region  获取汉字首字母包含多音如 “奇” 返回 new List<string>{"Q","J"};  

        /// <summary>  
        /// 获取汉字首字母包含多音  
        /// </summary>  
        /// <param name="input"></param>  
        /// <returns></returns>  
        public static List<string> GetPinYinInitialList(string input)
        {            
            return GetPinYinInitialList(GetPinYinList(input));
        }

        /// <summary>  
        /// 获取汉字首字母包含多音  
        /// </summary>  
        /// <param name="pyList">传入GetPY这个方法返回的对象</param>  
        /// <returns></returns>  
        public static List<string> GetPinYinInitialList(List<string> pyList)
        {
            List<string> list = new List<string>();
            foreach (string py in pyList)
            {
                string[] strs = py.Split('$');
                StringBuilder sb = new StringBuilder();
                foreach (string s in strs)
                {
                    if (s.Length > 0)
                    {
                        sb.Append(s.Substring(0, 1));
                    }
                }
                list.Add(sb.ToString());
            }
            return list;
        }

        #endregion

        #region 获取拼音包含多音,如"奇"返回new List<string>{"QI","JI"};  
        /// <summary>  
        /// 获取拼音包含多音  
        /// </summary>  
        /// <param name="pyList">传入GetPinYin这个方法返回的对象</param>  
        /// <returns></returns>  
        public static List<string> GetPinYinFullList(List<string> pyList)
        {
            List<string> list = new List<string>();
            foreach (string py in pyList)
            {
                list.Add(py.Replace("$", ""));
            }
            return list;
        }
        /// <summary>  
        /// 获取拼音包含多音  
        /// </summary>  
        /// <param name="input"></param>  
        /// <returns></returns>  
        public static List<string> GetPinYinFullList(string input)
        {            
            return GetPinYinFullList(GetPinYinList(input));
        }
        #endregion

        #region 获取汉字的拼音包含多音字用"$"连接,如 "奇怪" 返回 new List<string>{"QI$GUAI","JI$GUAI"};  
        /// <summary>  
        /// 获取汉字的拼音包含多音字用"$"连接  
        /// </summary>  
        /// <param name="pinYinList"></param>  
        /// <param name="input"></param>  
        /// <param name="isFirst"></param>  
        /// <returns></returns>  
        public static List<string> GetPinYinList(string input, List<string> pinYinList = null, bool isFirst = true)
        {
            if (pinYinList == null)
            {
                pinYinList = new List<string>();
            }
            if (input.Length > 1)
            {
                string tmp = input.Substring(0, 1);
                string remain = input.Substring(1);
                List<string> tmpList = GetPinYinAll(tmp);
                if (isFirst)
                {
                    pinYinList.AddRange(tmpList);
                    pinYinList = GetPinYinList(remain, pinYinList, false);
                }
                else
                {
                    pinYinList = GetPinYinList(remain, CombinationList(pinYinList, tmpList), false);
                }
            }
            else
            {
                if (pinYinList.Count > 0)
                {
                    pinYinList = CombinationList(pinYinList, GetPinYinAll(input));
                }
                else
                {
                    pinYinList.AddRange(GetPinYinAll(input));
                }
            }
            return pinYinList;
        }
        #endregion       

        #endregion 公有方法

        #region 私有方法

        #region 组合2个List
        /// <summary>  
        /// 组合2个List  
        /// </summary>  
        /// <param name="list1"></param>  
        /// <param name="list2"></param>  
        /// <returns></returns>  
        private static List<string> CombinationList(List<string> list1, List<string> list2)
        {
            List<string> result = new List<string>();
            foreach (string i in list1)
            {
                foreach (string j in list2)
                {
                    result.Add(i + "$" + j);
                }
            }
            return result;
        }
        #endregion

        #region 获取全拼,包含多音
        /// <summary>  
        /// 获取全拼,包含多音  
        /// </summary>  
        /// <param name="input"></param>  
        /// <returns>返回一个多音集合</returns>  
        private static List<string> GetPinYinAll(string input)
        {
            var result = new List<string>();
            char[] chars = input.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (Regex.IsMatch(chars[i].ToString(), @"^[\u4e00-\u9fa5]+$"))
                {
                    // 汉字
                    var chineseChar = new ChineseChar(chars[i]);
                    // 循环生成首字母的笛卡尔积,存储到临时拼音列表                      
                    foreach (var item in chineseChar.Pinyins)
                    {
                        if (item != null)
                        {
                            string temp = item.Remove(item.Length - 1, 1);
                            if (!result.Contains(temp))
                            {
                                result.Add(temp);
                            }
                        }
                    }
                }
                else
                {
                    // 非汉字
                    result.Add(chars[i].ToString().ToUpper());
                }
            }
            return result;
        }
        #endregion

        #endregion 私有方法
    }
}
