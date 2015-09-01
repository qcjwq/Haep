using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI
{
    /// <summary>
    /// 公共头部
    /// <para>
    /// 用于与接口通讯，发送请求数据的容器
    /// 数据访问层使用
    /// </para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseWhere<T> where T : new()
    {
        /// <summary>
        /// 公共头部
        /// </summary>
        public CommanHead CommanHead { get; set; }

        /// <summary>
        /// 私有主体
        /// </summary>
        public T Body { get; set; }
    }
}
