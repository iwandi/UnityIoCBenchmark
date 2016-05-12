using UnityEngine;
using System;
using IoCBenchmark;

namespace IoCBenchmark.Classes
{
    public interface IFirstService
    {
    }
    
    public class FirstService : IFirstService
    {
        public FirstService()
        {
        }
    }
    
    public interface ISecondService
    {
    }
    
    public class SecondService : ISecondService
    {
        public SecondService()
        {
        }
    }

    public interface IThirdService
    {
    }
    
    public class ThirdService : IThirdService
    {
        public ThirdService()
        {
        }
    }

    public interface ISubObjectOne
    {
    }
    
    public class SubObjectOne : ISubObjectOne
    {
        public SubObjectOne(IFirstService firstService)
        {
            if (firstService == null)
            {
                throw new ArgumentNullException();
            }
        }
    }

    public interface ISubObjectTwo
    {
    }
    
    public class SubObjectTwo : ISubObjectTwo
    {
        public SubObjectTwo(ISecondService secondService)
        {
            if (secondService == null)
            {
                throw new ArgumentNullException();
            }
        }
    }

    public interface ISubObjectThree
    {
    }
    
    public class SubObjectThree : ISubObjectThree
    {
        public SubObjectThree(IThirdService thirdService)
        {
            if (thirdService == null)
            {
                throw new ArgumentNullException();
            }
        }
    }

    public interface IServiceA
    {
    }
    
    public class ServiceA : IServiceA
    {
        public ServiceA()
        {
        }
    }

    public interface IServiceB
    {
    }

    public class ServiceB : IServiceB
    {
        public ServiceB()
        {
        }
    }

    public interface IServiceC
    {
    }

    public class ServiceC : IServiceC
    {
        public ServiceC()
        {
        }
    }
}
