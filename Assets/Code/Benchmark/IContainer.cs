using System;
using System.Collections.Generic;

namespace IoCBenchmark
{
    public interface IContainer
    {
        bool SupportsFunctionRegistration { get; }
        bool SupportsSubContainer { get; }

        void Register(Type t, ContainerFactoryDelegate func);
        void Register(Type t, Type impl, RegistrationOption option, object instance);
        object Resolve(Type t);
        void Inject(Type t, object instance);

        IContainer CreateContainer();

        //void Optimize();
    }

    public delegate object ContainerFactoryDelegate(IContainer container);

    public enum RegistrationOption
    {
        None = 0,
        Singleton = 1,
    }

    public static class ContainerUtl
    {
        public static void Register<T>(this IContainer container, ContainerFactoryDelegate func)
        {
            Type type = typeof(T);
            container.Register(type, func);
        }

        public static void Register<T>(this IContainer container)
        {
            Type type = typeof(T);
            container.Register(type, type, RegistrationOption.None, null);
        }

        public static void Register<T>(this IContainer container, RegistrationOption option)
        {
            Type type = typeof(T);
            container.Register(type, type, option, null);
        }

        public static void Register<T>(this IContainer container, T instance)
        {
            Type type = typeof(T);
            container.Register(type, type, RegistrationOption.None, instance);
        }

        public static void Register<T>(this IContainer container, RegistrationOption option, T instance)
        {
            Type type = typeof(T);
            container.Register(type, type, RegistrationOption.None, instance);
        }

        public static void Register<T, TImpl>(this IContainer container) where TImpl : T
        {
            Type type = typeof(T);
            Type typeImpl = typeof(TImpl);
            container.Register(type, typeImpl, RegistrationOption.None, null);
        }

        public static void Register<T, TImpl>(this IContainer container, RegistrationOption option) where TImpl : T
        {
            Type type = typeof(T);
            Type typeImpl = typeof(TImpl);
            container.Register(type, typeImpl, option, null);
        }

        public static void Register<T, TImpl>(this IContainer container, TImpl instance) where TImpl : T
        {
            Type type = typeof(T);
            Type typeImpl = typeof(TImpl);
            container.Register(type, typeImpl, RegistrationOption.None, instance);
        }

        public static void Register<T, TImpl>(this IContainer container, RegistrationOption option, TImpl instance) where TImpl : T
        {
            Type type = typeof(T);
            Type typeImpl = typeof(TImpl);
            container.Register(type, typeImpl, option, instance);
        }

        public static void RegisterSingleton<T>(this IContainer container)
        {
            Type type = typeof(T);
            container.Register(type, type, RegistrationOption.Singleton, null);
        }

        public static void RegisterSingleton<T>(this IContainer container, T instance)
        {
            Type type = typeof(T);
            container.Register(type, type, RegistrationOption.Singleton, null);
        }

        public static void RegisterSingleton<T, TImpl>(this IContainer container) where TImpl : T
        {
            Type type = typeof(T);
            Type typeImpl = typeof(TImpl);
            container.Register(type, typeImpl, RegistrationOption.Singleton, null);
        }

        public static void RegisterSingleton<T, TImpl>(this IContainer container, TImpl instance) where TImpl : T
        {
            Type type = typeof(T);
            Type typeImpl = typeof(TImpl);
            container.Register(type, typeImpl, RegistrationOption.Singleton, instance);
        }

        public static T Resolve<T>(this IContainer container)
        {
            Type type = typeof(T);
            return (T)container.Resolve(type);
        }

        public static void Inject<T>(this IContainer container, T instance)
        {
            Type type = typeof(T);
            container.Inject(type, instance);
        }

        public static void InjectAll<T>(this IContainer container, IEnumerable<T> list)
        {
            Type type = typeof(T);
            foreach(T instance in list)
            {
                container.Inject(type, instance);
            }
        }
    }
}
