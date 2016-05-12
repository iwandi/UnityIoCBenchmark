#if ENABLE_STRANGEIOC
using System;
using IoCBenchmark;

using strange;
using strange.framework.impl;
using strange.extensions.injector.impl;

namespace IoCBenchmark.Adapter
{
    public class StrangeIoCAdapter : IoCBenchmark.IContainerProvider
    {
        public string Name { get { return "StrangeIoC"; } }

        public IContainer Create()
        {
            return new StrangeIoCContainer();
        }
    }

    public class StrangeIoCContainer : IoCBenchmark.IContainer
    {
        public bool SupportsFunctionRegistration { get { return false; } }
        public bool SupportsSubContainer { get { return false; } }

        InjectionBinder container;

        public StrangeIoCContainer()
        {
            container = new InjectionBinder();
        }

        public void Register(Type t, ContainerFactoryDelegate func)
        {
            // NOT SUPPORTED
            throw new NotImplementedException();
        }

        public void Register(Type t, Type impl, RegistrationOption option, object instance)
        {
            if(instance == null)
            {
                if (option == RegistrationOption.Singleton)
                {
                    container.Bind(t).To(impl).ToSingleton();
                }
                else
                {
                    container.Bind(t).To(impl);
                }
            }
            else
            {
                container.Bind(t).ToValue(instance);
            }

        }

        public object Resolve(Type t)
        {
            return container.GetInstance(t);
        }

        public void Inject(Type t, object instance)
        {
            container.injector.Inject(instance);
        }

        public IContainer CreateContainer()
        {
            // TODO : handle sub container
            throw new NotImplementedException();
        }
    }
}
#endif
