using System;
using Haep.AOP.ErrorHanding;
using Haep.AOP.ErrorHanding.ErrorHandInfo;
using Haep.AOP.Logging;
using Haep.Core;
using Haep.Core.IOC;
using WebAPI;

namespace Stub
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = HaepContainer.Get<ILog>();
            log.Debug("test", DateTime.Now.ToString("yyyy-MM-dd"));

            var error = HaepContainer.Get<IErrorHandler>();
            log.Debug("ArgumentException", error.ShowException(new ArgumentException("ArgumentException")));

            Console.ReadKey();
        }

        public OrdersResult Get(OrdersPara para)
        {
            BaseWhere<OrdersPara> where = new BaseWhere<OrdersPara>();
            where.CommanHead.Method = "qryOrders";
            where.Body.userId = para.userId;
            where.Body.pageIdx = para.pageIdx;
            where.Body.numPerPage = para.numPerPage;

            Response<OrdersResult> result = WebApi<OrdersResult>.Post(where);
            return result.body;
        }
    }
}
