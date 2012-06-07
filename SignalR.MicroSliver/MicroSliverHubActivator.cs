using SignalR.Hubs;

namespace SignalR.MicroSliver
{
    public class MicroSliverHubActivator : IHubActivator
    {
        private readonly IDependencyResolver _resolver;

        public MicroSliverHubActivator(IDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public IHub Create(HubDescriptor descriptor)
        {
            if (descriptor.Type == null)
            {
                return null;
            }
            object hub = _resolver.Resolve(descriptor.Type);
            return hub as IHub;
        }
    }
}
