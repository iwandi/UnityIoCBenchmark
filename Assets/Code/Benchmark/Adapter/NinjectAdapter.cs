#if ENABLE_NINJECT
using System;

using Ninject;

namespace IoCBenchmark.Adapter
{
    public class NinjectAdapter : IoCBenchmark.IContainerProvider
    {
        public string Name { get { return "Ninject"; } }

        public IContainer Create()
        {
            return new NinjectContainer();
        }
    }

    public class NinjectContainer : IoCBenchmark.IContainer
    {
        public bool SupportsFunctionRegistration { get { return true; } }
        public bool SupportsSubContainer { get { return false; } }

        IKernel container;

        public NinjectContainer()
        {
            container = new StandardKernel(new UnityNinjectSettings(), new Ninject.Modules.INinjectModule[] { } );
        }

        public void Register(Type t, ContainerFactoryDelegate func)
        {
            container.Bind(t).ToMethod((ctx) =>
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
                    container.Bind(t).To(impl).InSingletonScope();
                }
                else
                {
                    container.Bind(t).To(impl);
                }
            }
            else
            {
                container.Bind(t).ToConstant(instance);
            }
        }

        public object Resolve(Type t)
        {
            return container.Get(t);
        }

        public void Inject(Type t, object instance)
        {
            container.Inject(instance);
        }

        public IContainer CreateContainer()
        {
            return null;
        }
    }
}
#endif