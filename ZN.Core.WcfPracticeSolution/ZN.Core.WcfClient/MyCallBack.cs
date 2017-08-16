using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.WcfClient
{
    class MyCallBack : MyDupleServiceProxy.IMyDupleServiceCallback
    {
        public void SayHello(string mes)
        {
            Console.WriteLine("客户端收到信息：{0}",mes);
        }
    }
}
