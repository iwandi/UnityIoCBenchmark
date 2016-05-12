#if ENABLE_DRYIOC
using System;

using DryIoc;

namespace IoCBenchmark.Adapter
{
    public class DryIocAdapter : IoCBenchmark.IContainerProvider
    {
        public string Name { get { return "DryIoc"; } }

        public IContainer Create()
        {
            return new DryIocContainer();
        }
    }

    public class DryIocContainer : IoCBenchmark.IContainer
    {
        public bool SupportsFunctionRegistration { get { return true; } }
        public bool SupportsSubContainer { get { return false; } }

        DryIoc.IContainer container;

        public DryIocContainer()
        {
            container = new Container(Rules.Default, null);
        }

        public DryIocContainer(DryIoc.IContainer container)
        {
            this.container = container;
        }

        public void Register(Type t, ContainerFactoryDelegate func)
        {
            container.RegisterDelegate(t, (ctx) =>
            {
                return func(this);
            });
        }

        public void Register(Type t, Type impl, IoCBenchmark.RegistrationOption option, object instance)
        {
            if (instance == null)
            {
                if (option == IoCBenchmark.RegistrationOption.Singleton)
                {
                    container.Register(t, impl, reuse: Reuse.Singleton);
                }
                else
                {
                    container.Register(t, impl);
                }
            }
            else
            {
                container.RegisterInstance(t, instance);
            }
        }

        public object Resolve(Type t)
        {
            return container.Resolve(t);
        }

        public void Inject(Type t, object instance)
        {
            container.InjectPropertiesAndFields(instance);
        }

        public IContainer CreateContainer()
        {
            return new DryIocContainer(container.OpenScope());
        }
    }
}
#endif