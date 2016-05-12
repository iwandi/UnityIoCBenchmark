#if ENABLE_ZENJECT
using System;

using Zenject;

namespace IoCBenchmark.Adapter
{
    public class ZenjectAdapter : IoCBenchmark.IContainerProvider
    {
        public string Name { get { return "Zenject"; } }

        public IContainer Create()
        {
            return new ZenjectContainer();
        }
    }

    public class ZenjectContainer : IoCBenchmark.IContainer
    {
        public bool SupportsFunctionRegistration { get { return true; } }
        public bool SupportsSubContainer { get { return true; } }

        DiContainer container;

        public ZenjectContainer()
        {
            container = new DiContainer();
        }

        public ZenjectContainer(DiContainer container)
        {
            this.container = container;
        }

        public void Register(Type t, ContainerFactoryDelegate func)
        {
            container.Bind(t).ToMethod(t, (ctx) =>
            {
                return func(this);
            });
        }

        public void Register(Type t, Type impl, RegistrationOption option, object instance)
        {
            if(instance == null)
            {
                if(option == RegistrationOption.Singleton)
                {
                    container.Bind(t).ToSingle(impl);
                }
                else
                {
                    container.Bind(t).ToTransient(impl);
                }
            }
            else
            {
                container.Bind(t).ToInstance(impl, instance);
            }
        }

        public object Resolve(Type t)
        {
            return container.Resolve(t);
        }

        public void Inject(Type t, object instance)
        {
            container.Inject(instance);
        }

        public IContainer CreateContainer()
        {
            return new ZenjectContainer(new DiContainer(container));
        }
    }
}
#endif