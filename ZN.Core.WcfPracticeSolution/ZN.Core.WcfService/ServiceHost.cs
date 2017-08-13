using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;

namespace ZN.Core.WcfService
{
    public class ServiceHost<T> : ServiceHost
    {
        public ServiceHost()
            : base(typeof(T))
        { }

        public ServiceHost(params string[] baseAddress)
            : base(typeof(T), baseAddress.Select(address => new Uri(address)).ToArray())
        { }

        public ServiceHost(params Uri[] baseAddress)
            : base(typeof(T), baseAddress)
        { }
    }
}