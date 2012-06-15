using System;
using MicroSliver;
using SignalR.Hubs;

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

    public interface IHubContextProxy
    {
        IHubContext HubContext { get; set; }
    }

    public class HubContextProxy<T> : IHubContextProxy where T : IHub
    {
        public IHubContext HubContext { get; set; }

        public HubContextProxy()
        {
            HubContext = GlobalHost.ConnectionManager.GetHubContext<T>();
        }
    }

}
