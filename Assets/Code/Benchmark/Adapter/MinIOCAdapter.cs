#if ENABLE_MINIOC
using System;

using minioc;
using minioc.context.bindings;

namespace IoCBenchmark.Adapter
{
    public class MinIOCAdapter : IoCBenchmark.IContainerProvider
    {
        public string Name { get { return "MinIOC"; } }

        public IContainer Create()
        {
            return new MinIOCContainer();
        }
    }

    public class MinIOCContainer : IoCBenchmark.IContainer
    {
        public bool SupportsFunctionRegistration { get { return true; } }
        public bool SupportsSubContainer { get { return true; } }

        MiniocContext container;

        public MinIOCContainer()
        {
            container = new MiniocContext();
        }

        public MinIOCContainer(MiniocContext container)
        {
            this.container = container;
        }

        public void Register(Type t, ContainerFactoryDelegate func)
        {
            container.Register(Bindings.ForType(t).ImplementedBy(() =>
            {
                return func(this);
            }).SetInstantiationMode(InstantiationMode.MULTIPLE));
        }

        public void Register(Type t, Type impl, RegistrationOption option, object instance)
        {
            if(instance == null)
            {
                InstantiationMode instMode = option == RegistrationOption.Singleton ? InstantiationMode.SINGLETON : InstantiationMode.MULTIPLE;
                container.Register(Bindings.ForType(t).ImplementedBy(impl).SetInstantiationMode(instMode));
            }
            else
            {
                container.Register(Bindings.ForType(t).ImplementedByInstance(instance));
            }
        }

        public object Resolve(Type t)
        {
            return container.Resolve(t);
        }

        public void Inject(Type t, object instance)
        {
            container.InjectDependencies(instance);
        }

        public IContainer CreateContainer()
        {
            return new MinIOCContainer(new MiniocContext(container));
        }
    }
}
#endif