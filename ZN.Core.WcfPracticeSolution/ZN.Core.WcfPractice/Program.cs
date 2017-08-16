using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZN.Core.WcfService;
using System.ServiceModel;
using System.ServiceModel.Channels;
using ZN.Core.WcfServiceLib;
using System.ServiceModel.Description;

namespace ZN.Core.WcfPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //ServiceHost host = new ServiceHost(typeof(MyContract));
            //Binding wsBinding = new WSHttpBinding();
            //host.AddServiceEndpoint(typeof(IMyContract), wsBinding, "http://localhost:8000/MyContract");
            //Console.WriteLine("服务启动。。。");
            //host.Open();
            //Console.WriteLine("回车关闭服务。。。");
            //Console.ReadKey();
            //host.Close();
            Uri baseAddress = new Uri("http://localhost:8001/MyDupleService");
            using (ServiceHost host = new ServiceHost(typeof(MyDupleService), baseAddress))
            {
                host.AddServiceEndpoint(typeof(IMyDupleService), new WSDualHttpBinding(), "");
                host.Opening += (o, e) => Console.WriteLine("服务开启：{0}", DateTime.Now.ToString());

                ////将HttpGetEnabled属性设置为true 才能发布元数据
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                host.Description.Behaviors.Add(smb);

                host.Open();
                Console.WriteLine("quit 退出, 其他键向客户端发送消息");
                string command = Console.ReadLine();
                while (command != "quit")
                {
                    lock (MyDupleService.CallBackList)
                    {
                        MyDupleService.CallBackList.ForEach(o => o.SayHello(string.Format("Hello, 我是服务器 {0}", DateTime.Now.ToString())));
                    }
                    Console.WriteLine("quit 退出, 其他键向客户端发送消息");
                    command = Console.ReadLine();
                }
                host.Close();
            }
        }
    }
}
