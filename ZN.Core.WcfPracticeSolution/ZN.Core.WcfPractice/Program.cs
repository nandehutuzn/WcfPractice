using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZN.Core.WcfService;
using System.ServiceModel;

namespace ZN.Core.WcfPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(MyContract));
            Console.WriteLine("服务启动。。。");
            host.Open();
            Console.WriteLine("回车关闭服务。。。");
            Console.ReadKey();
            host.Close();
        }
    }
}
