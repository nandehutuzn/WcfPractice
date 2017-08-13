using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZN.Core.WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MyContractProxy.MyContractClient client = new MyContractProxy.MyContractClient();
            string s = client.GetData(4);
            client.Close();

        }
    }
}
