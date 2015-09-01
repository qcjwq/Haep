using System;

namespace WebAPI
{
    /// <summary>
    /// 返回报文报文头参数
    /// <para>
    /// 用于与接口通讯，接收返回数据的容器
    /// 数据访问层使用
    /// </para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T> where T : new()
    {
        /// <summary>
        /// 公共头部
        /// </summary>
        public headBaseResult head { get; set; }

        /// <summary>
        /// 私有主体
        /// </summary>
        public T body { get; set; }
    }

    public class headBaseResult
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }
    }
}