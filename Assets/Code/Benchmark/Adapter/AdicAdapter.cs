#if ENABLE_ADIC
using System;

using Adic;
using Adic.Injection;

namespace IoCBenchmark.Adapter
{
    public class AdicAdapter : IoCBenchmark.IContainerProvider
    {
        public string Name { get { return "Adic"; } }

        public IContainer Create()
        {
            return new AdicContainer();
        }
    }

    // TODO : instance singletons on demand and not on first access
    public class AdicContainer : IoCBenchmark.IContainer 
    {

        public bool SupportsFunctionRegistration { get { return true; } }
        public bool SupportsSubContainer { get { return false; } }

        InjectionContainer container;

        public AdicContainer()
        {
            container = new InjectionContainer();
        }

        public void Register(Type t, ContainerFactoryDelegate func)
        {
            container.Bind(t).ToFactory(new FuncFactory(this, func));
        }

        public void Register(Type t, Type impl, IoCBenchmark.RegistrationOption option, object instance)
        {
            if (instance == null)
            {
                if(option == IoCBenchmark.RegistrationOption.Singleton)
                {
                    container.Bind(t).ToSingleton(impl);
                }
                else
                {
                    container.Bind(t).To(impl);
                }
            }
            else
            {
                container.Bind(t).To(impl, instance);
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
            // TODO : handle sub container
            throw new NotImplementedException();
        }

        class FuncFactory : IFactory
        {
            IContainer container;
            ContainerFactoryDelegate func;

            public FuncFactory(IContainer container, ContainerFactoryDelegate func)
            {
                this.container = container;
                this.func = func;
            }

            public object Create(InjectionContext context)
            {
                return func(container);
            }
        }
    }
}
#endif 