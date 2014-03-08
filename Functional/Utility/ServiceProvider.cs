using System;
using System.Collections.Generic;

namespace Functional.Utility {
    public class ServiceProvider : IServiceProvider {
        private readonly IDictionary<Type, object> services = new Dictionary<Type, object>();
        public void AddService(Type type, object service) {
            if (!type.IsAssignableFrom(service.GetType())) throw new ArgumentException("the service is not the type");
            // TODO: check for collision
            this.services.Add(type, service);
        }
        public object GetService(Type type) {   
            return this.services[type]; // TODO verify that it's there first, throw if it isn't
        }
        public void RemoveService(Type type) {
            this.services.Remove(type); // TODO verify that it's there first, throw if it isn't
        }
    }
}