using Infrastructure.Services;
using System;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public class AllServices
    {
        private Dictionary<Type, IService> _services;

        public AllServices() =>
            _services = new();

        public void Register<TService>(TService instance) where TService : IService =>
            _services.Add(typeof(TService), instance);

        public TService GetService<TService>() where TService : class, IService
        {
            if (_services.ContainsKey(typeof(TService)))
                return _services[typeof(TService)] as TService;
            else
                throw new ArgumentNullException($"Service {typeof(TService)} does not exist!");
        }
    }
}
