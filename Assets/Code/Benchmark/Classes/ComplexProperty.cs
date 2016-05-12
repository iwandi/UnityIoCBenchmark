using UnityEngine;
using System;
using IoCBenchmark;

namespace IoCBenchmark.Classes
{
    public interface IComplexPropertyObject1
    {
        void Verify(string containerName);
    }
    
    public interface IComplexPropertyObject2
    {
        void Verify(string containerName);
    }
    
    public interface IComplexPropertyObject3
    {
        void Verify(string containerName);
    }

    public interface ISubObjectA
    {
        void Verify(string containerName);
    }

    public class SubObjectA : ISubObjectA
    {
        [Adic.Inject]
        [Zenject.Inject]
        [minioc.attributes.AutoInject]
        [strange.Inject]
        public ISubObjectA ServiceA { get; set; }

        public void Verify(string containerName)
        {
            if (this.ServiceA == null)
            {
                throw new Exception("ServiceC was null for SubObjectC for container " + containerName);
            }
        }
    }

    public interface ISubObjectB
    {
        void Verify(string containerName);
    }

    public class SubObjectB : ISubObjectB
    {
        [Adic.Inject]
        [Zenject.Inject]
        [minioc.attributes.AutoInject]
        [strange.Inject]
        public ISubObjectB ServiceB { get; set; }

        public void Verify(string containerName)
        {
            if (this.ServiceB == null)
            {
                throw new Exception("ServiceC was null for SubObjectC for container " + containerName);
            }
        }
    }

    public interface ISubObjectC
    {
        void Verify(string containerName);
    }

    public class SubObjectC : ISubObjectC
    {
        [Adic.Inject]
        [Zenject.Inject]
        [minioc.attributes.AutoInject]
        [strange.Inject]
        public IServiceC ServiceC { get; set; }

        public void Verify(string containerName)
        {
            if (this.ServiceC == null)
            {
                throw new Exception("ServiceC was null for SubObjectC for container " + containerName);
            }
        }
    }

    public class ComplexPropertyObject1 : IComplexPropertyObject1
    {
        private static int counter;

        public ComplexPropertyObject1()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        [Adic.Inject]
        [Zenject.Inject]
        [minioc.attributes.AutoInject]
        [strange.Inject]
        public IServiceA ServiceA { get; set; }

        [Adic.Inject]
        [Zenject.Inject]
        [minioc.attributes.AutoInject]
        [strange.Inject]
        public IServiceB ServiceB { get; set; }

        [Adic.Inject]
        [Zenject.Inject]
        [minioc.attributes.AutoInject]
        [strange.Inject]
        public IServiceC ServiceC { get; set; }

        [Adic.Inject]
        [Zenject.Inject]
        [minioc.attributes.AutoInject]
        [strange.Inject]
        public ISubObjectA SubObjectA { get; set; }

        [Adic.Inject]
        [Zenject.Inject]
        [minioc.attributes.AutoInject]
        [strange.Inject]
        public ISubObjectB SubObjectB { get; set; }

        [Adic.Inject]
        [Zenject.Inject]
        [minioc.attributes.AutoInject]
        [strange.Inject]
        public ISubObjectC SubObjectC { get; set; }

        public void Verify(string containerName)
        {
            if (this.ServiceA == null)
            {
                throw new Exception("ServiceA is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.ServiceB == null)
            {
                throw new Exception("ServiceB is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.ServiceC == null)
            {
                throw new Exception("ServiceC is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.SubObjectA == null)
            {
                throw new Exception("SubObjectA is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectA.Verify(containerName);

            if (this.SubObjectB == null)
            {
                throw new Exception("SubObjectB is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectB.Verify(containerName);

            if (this.SubObjectC == null)
            {
                throw new Exception("SubObjectC is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectC.Verify(containerName);
        }
    }
    
    public class ComplexPropertyObject2 : IComplexPropertyObject2
    {
        private static int counter;

        public ComplexPropertyObject2()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        [Adic.Inject]
        [Zenject.Inject]
        [minioc.attributes.AutoInject]
        [strange.Inject]
        public IServiceA ServiceA { get; set; }

        [Adic.Inject]
        [Zenject.Inject]
        [minioc.attributes.AutoInject]
        [strange.Inject]
        public IServiceB ServiceB { get; set; }

        [Adic.Inject]
        [Zenject.Inject]
        [minioc.attributes.AutoInject]
        [strange.Inject]
        public IServiceC ServiceC { get; set; }

        [Adic.Inject]
        [Zenject.Inject]
        [minioc.attributes.AutoInject]
        [strange.Inject]
        public ISubObjectA SubObjectA { get; set; }

        [Adic.Inject]
        [Zenject.Inject]
        [minioc.attributes.AutoInject]
        [strange.Inject]
        public ISubObjectB SubObjectB { get; set; }

        [Adic.Inject]
        [Zenject.Inject]
        [minioc.attributes.AutoInject]
        [strange.Inject]
        public ISubObjectC SubObjectC { get; set; }

        public void Verify(string containerName)
        {
            if (this.ServiceA == null)
            {
                throw new Exception("ServiceA is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.ServiceB == null)
            {
                throw new Exception("ServiceB is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.ServiceC == null)
            {
                throw new Exception("ServiceC is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.SubObjectA == null)
            {
                throw new Exception("SubObjectA is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectA.Verify(containerName);

            if (this.SubObjectB == null)
            {
                throw new Exception("SubObjectB is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectB.Verify(containerName);

            if (this.SubObjectC == null)
            {
                throw new Exception("SubObjectC is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectC.Verify(containerName);
        }
    }
    
    public class ComplexPropertyObject3 : IComplexPropertyObject3
    {
        private static int counter;

        public ComplexPropertyObject3()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        [Adic.Inject]
        [Zenject.Inject]
        [minioc.attributes.AutoInject]
        [strange.Inject]
        public IServiceA ServiceA { get; set; }

        [Adic.Inject]
        [Zenject.Inject]
        [minioc.attributes.AutoInject]
        [strange.Inject]
        public IServiceB ServiceB { get; set; }

        [Adic.Inject]
        [Zenject.Inject]
        [minioc.attributes.AutoInject]
        [strange.Inject]
        public IServiceC ServiceC { get; set; }

        [Adic.Inject]
        [Zenject.Inject]
        [minioc.attributes.AutoInject]
        [strange.Inject]
        public ISubObjectA SubObjectA { get; set; }

        [Adic.Inject]
        [Zenject.Inject]
        [minioc.attributes.AutoInject]
        [strange.Inject]
        public ISubObjectB SubObjectB { get; set; }

        [Adic.Inject]
        [Zenject.Inject]
        [minioc.attributes.AutoInject]
        [strange.Inject]
        public ISubObjectC SubObjectC { get; set; }

        public void Verify(string containerName)
        {
            if (this.ServiceA == null)
            {
                throw new Exception("ServiceA is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.ServiceB == null)
            {
                throw new Exception("ServiceB is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.ServiceC == null)
            {
                throw new Exception("ServiceC is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.SubObjectA == null)
            {
                throw new Exception("SubObjectA is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectA.Verify(containerName);

            if (this.SubObjectB == null)
            {
                throw new Exception("SubObjectB is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectB.Verify(containerName);

            if (this.SubObjectC == null)
            {
                throw new Exception("SubObjectC is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectC.Verify(containerName);
        }
    }

}
