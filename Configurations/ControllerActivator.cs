

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

public class ControllerActivator : IHttpControllerActivator
{
    protected ServiceProvider _serviceProvider;

    public ControllerActivator(ServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
    {
        var scope = _serviceProvider.CreateScope();
        request.RegisterForDispose(scope);
        return (IHttpController)scope.ServiceProvider.GetRequiredService(controllerType);
    }
}