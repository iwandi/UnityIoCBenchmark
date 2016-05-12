#if ENABLE_TINYIOC
using System;

using TinyIoC;

namespace IoCBenchmark.Adapter
{
    public class TinyIoCAdapter : IoCBenchmark.IContainerProvider
    {
        public string Name { get { return "TinyIoC"; } }

        public IContainer Create()
        {
            return new TinyIoCContainer();
        }
    }

    public class TinyIoCContainer : IoCBenchmark.IContainer
    {
        public bool SupportsFunctionRegistration { get { return true; } }
        public bool SupportsSubContainer { get { return false; } }

        TinyIoC.TinyIoCContainer container;

        public TinyIoCContainer()
        {
            container = new TinyIoC.TinyIoCContainer();
        }

        public void Register(Type t, ContainerFactoryDelegate func)
        {
            container.Register(t, (ctx, param) =>
            {
                return func(this);
            });
        }

        public void Register(Type t, Type impl, RegistrationOption option, object instance)
        {
            if (instance == null)
            {
                if (option == RegistrationOption.Singleton)
                {
                    container.Register(t, impl).AsSingleton();
                }
                else
                {
                    container.Register(t, impl).AsMultiInstance();
                }
            }
            else
            {
                container.Register(t, instance);
            }
        }

        public object Resolve(Type t)
        {
            return container.Resolve(t);
        }

        public void Inject(Type t, object instance)
        {
            container.BuildUp(instance);
        }

        public IContainer CreateContainer()
        {
            return null;
        }
    }
}
#endif