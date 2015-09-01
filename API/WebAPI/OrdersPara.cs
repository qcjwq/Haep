using System.Collections.Generic;

namespace WebAPI
{
    /// <summary>
    /// 订单列表（请求实体）
    /// </summary>
    public class OrdersPara
    {
        public string userId { get; set; }

        public int numPerPage { get; set; }

        public int pageIdx { get; set; }
    }

    /// <summary>
    /// 订单列表（响应实体）
    /// </summary>
    public class OrdersResult
    {
        private IList<Order> _orders = new List<Order>();

        public int pageCount { get; set; }
        public int pageIdx { get; set; }
        public IList<Order> orders { get { return _orders; } set { _orders = value; } }
    }

    public class Order
    {
        //private IList<OrderDetail> _detail = new List<OrderDetail>();

        public string orderNo { get; set; }
        public decimal orderPrice { get; set; }
        public string orderTime { get; set; }
        public int status { get; set; }
        public int orderStatus { get; set; }
        public int activityID { get; set; }
        public string mobileNo { get; set; }
    }
}