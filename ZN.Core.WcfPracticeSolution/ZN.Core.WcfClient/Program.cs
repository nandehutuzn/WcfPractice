using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyContractProxy.MyContractClient client = new MyContractProxy.MyContractClient();
            //string s = client.GetData(4);
            //Console.WriteLine(s);
            //client.Close();
            //Console.ReadKey();

            MyDupleServiceProxy.IMyDupleServiceCallback callback = new MyCallBack();
            InstanceContext context = new InstanceContext(callback);
            MyDupleServiceProxy.MyDupleServiceClient client = new MyDupleServiceProxy.MyDupleServiceClient(context);
            client.DoWork("张三");
            Console.ReadKey();
        }
    }
}
