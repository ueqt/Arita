using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Arita.Helpers
{
    /// <summary>
    /// 类型转换帮助
    /// </summary>
    public static class AritaConvertHelper
    {

        #region 公有方法

        #region 扩展方法

        /// <summary>
        /// byte数组转结构体
        /// </summary>
        /// <param name="bytes">byte数组</param>
        /// <returns>转换后的结构体</returns>
        public static T ToStruct<T>(this byte[] bytes)
        {
            // 得到结构体的大小
            int size = Marshal.SizeOf(typeof(T));
            object obj = default(T);
            // byte数组长度小于结构体的大小
            if (size > bytes.Length)
            {
                // 返回空
                return (T)obj;
            }
            // 分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            try
            {
                // 将byte数组拷到分配好的内存空间
                Marshal.Copy(bytes, 0, structPtr, size);
                // 将内存空间转换为目标结构体
                obj = Marshal.PtrToStructure(structPtr, typeof(T));
                // 返回结构体
                return (T)obj;
            }
            catch
            {
                // 如果出现内存不能访问的错误，请检查struct的定义是不是出错了，可以看看obj里什么是null，数组要定义数组大小的
                return (T)obj;
            }
            finally
            {
                // 释放内存空间
                Marshal.FreeHGlobal(structPtr);
            }
        }

        /// <summary>
        /// 结构体转byte数组
        /// </summary>
        /// <param name="structObj">要转换的结构体</param>
        /// <returns>转换后的byte数组</returns>
        public static byte[] StructToBytes(this object structObj)
        {
            // 得到结构体的大小
            int size = Marshal.SizeOf(structObj);
            // 创建byte数组
            byte[] bytes = new byte[size];
            // 分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            try
            {
                // 将结构体拷到分配好的内存空间
                Marshal.StructureToPtr(structObj, structPtr, false);
                // 从内存空间拷到byte数组
                Marshal.Copy(structPtr, bytes, 0, size);
                // 返回byte数组
                return bytes;
            }
            catch
            {
                return null;
            }
            finally
            {
                // 释放内存空间
                Marshal.FreeHGlobal(structPtr);
            }
        }

        /// <summary>
        /// 根据UTC时间的时间戳获取本地时间
        /// </summary>
        /// <param name="span">UTC时间戳</param>
        /// <returns></returns>
        public static DateTime GetLocalTimeFromUtcTimeSpan(this uint span)
        {
            // UTC基准时间
            DateTime epochStart = new DateTime(1970, 1, 1);

            // UTC时间戳是从1970年1月1日开始的秒数
            return epochStart.AddSeconds(span);
        }

        /// <summary>
        /// 根据UTC时间的时间戳获取本地时间
        /// </summary>
        /// <param name="span">UTC时间戳</param>
        /// <returns></returns>
        public static DateTime GetLocalTimeFromUtcTimeSpan(this int span)
        {
            // UTC基准时间
            DateTime epochStart = new DateTime(1970, 1, 1);

            // UTC时间戳是从1970年1月1日开始的秒数
            return epochStart.AddSeconds(span);
        }

        #endregion

        #endregion

    }
}
