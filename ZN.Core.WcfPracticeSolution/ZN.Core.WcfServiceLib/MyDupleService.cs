using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ZN.Core.WcfServiceLib
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“MyDupleService”。
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class MyDupleService : IMyDupleService, IDisposable
    {
        public static List<ICallBack> CallBackList { get; set; }

        public MyDupleService()
        {
            CallBackList = new List<ICallBack>();
        }

        public void DoWork(string name)
        {
            ICallBack callback = OperationContext.Current.GetCallbackChannel<ICallBack>();
            CallBackList.Add(callback);

            string sessionId = OperationContext.Current.SessionId;
            Console.WriteLine("{0} is register", sessionId);
            OperationContext.Current.Channel.Closing += (o, e) =>
                {
                    lock (CallBackList)
                    {
                        CallBackList.Remove(callback);
                        Console.WriteLine("{0} is remove", sessionId);
                    }
                };
        }

        public void Dispose()
        {
            CallBackList.Clear();
        }
    }
}
