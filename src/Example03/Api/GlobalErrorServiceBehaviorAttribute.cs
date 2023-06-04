using System.Collections.ObjectModel;
using CoreWCF.Dispatcher;

namespace Api;

[AttributeUsage(AttributeTargets.Class)]
public sealed class GlobalErrorServiceBehaviorAttribute : Attribute, IServiceBehavior
{
    public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    {
    }

    public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
    {
    }

    public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    {
        foreach (var channelDispatcherBase in serviceHostBase.ChannelDispatchers)
        {
            var channelDispatcher = channelDispatcherBase as ChannelDispatcher;
            channelDispatcher?.ErrorHandlers.Add(new GlobalErrorHandler());
        }
    }
}