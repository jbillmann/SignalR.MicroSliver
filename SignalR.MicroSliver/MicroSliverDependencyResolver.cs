using System;
using MicroSliver;

namespace SignalR.MicroSliver {
    public class MicroSliverDependencyResolver : DefaultDependencyResolver{

        private readonly IIoC _ioc;
        public MicroSliverDependencyResolver(IIoC ioc) 
        {
            if (ioc == null)
            {
                throw new ArgumentNullException("ioc");
            }
            _ioc = ioc;
        }

        public override object GetService(Type serviceType) 
        {
            return _ioc.TryGetByType(serviceType) ?? base.GetService(serviceType);
        }
    }
}
