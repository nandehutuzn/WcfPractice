using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ZN.Core.WcfServiceLib
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IMyDupleService”。
    [ServiceContract(CallbackContract = typeof(ICallBack))]
    public interface IMyDupleService
    {
        [OperationContract]
        void DoWork(string name);
    }

    public interface ICallBack
    {
        [OperationContract(IsOneWay=true)]
        void SayHello(string mes);
    }
}
