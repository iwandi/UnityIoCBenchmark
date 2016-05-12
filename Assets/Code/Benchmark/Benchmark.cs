using UnityEngine;
using System.Collections.Generic;

//using IoCBenchmark.Adapter;
using IoCBenchmark.Classes;

namespace IoCBenchmark
{
    public interface IContainerProvider
    {
        string Name { get; }

        IContainer Create();
    }

    public class Benchmark : MonoBehaviour
    {
        [SerializeField]
        Font font;

        int cycles = 10000;
        List<TestBase> testList;
        List<IContainerProvider> providerList;

        string guiText = "";

        Rect windowRect = new Rect(20, 20, 1024, 50);
        Vector2 windowScroll = new Vector2();

        void Start()
        {
            testList = CreateTestList();
            providerList = CreateProviderList();

            //RunBenchmark();
        }

        public List<TestBase> CreateTestList()
        {
            List<TestBase>  list = new List<TestBase>();
            list.Add(new TestSingleton());
            list.Add(new TestTransient());
            list.Add(new TestCombined());
            list.Add(new TestComplex());
            list.Add(new TestFactory());

            return list;
        }

        public List<IContainerProvider> CreateProviderList()
        {
            List<IContainerProvider> list = new List<IContainerProvider>();

#if ENABLE_ADIC
            list.Add(new IoCBenchmark.Adapter.AdicAdapter());
#endif
#if ENABLE_ZENJECT
            list.Add(new IoCBenchmark.Adapter.ZenjectAdapter());
#endif
#if ENABLE_MINIOC
            list.Add(new IoCBenchmark.Adapter.MinIOCAdapter());
#endif
#if ENABLE_STRANGEIOC
            list.Add(new IoCBenchmark.Adapter.StrangeIoCAdapter());
#endif
#if ENABLE_TINYIOC
            list.Add(new IoCBenchmark.Adapter.TinyIoCAdapter());
#endif
#if !UNITY_IPHONE
#if ENABLE_DRYIOC
            list.Add(new IoCBenchmark.Adapter.DryIocAdapter());
#endif
#if ENABLE_NINJECT
            list.Add(new IoCBenchmark.Adapter.NinjectAdapter());
#endif
#endif // !UNITY_IPHONE

            return list;
        }

        void RunBenchmark()
        {
            Timer time = new Timer();

            Run(providerList, time);

            Debug.Log(time.ToLog());
        }

        System.Collections.IEnumerator RunBenchmarkWorker()
        {
            Timer time = new Timer();
            
            yield return StartCoroutine(RunWorker(providerList, time));

            Debug.Log(time.ToLog());
        }

        public void Run(List<IContainerProvider> providerList, Timer timer)
        {
            foreach(IContainerProvider provider in providerList)
            {
                Run(provider, timer);
            }
        }

        System.Collections.IEnumerator RunWorker(List<IContainerProvider> providerList, Timer timer)
        {
            foreach (IContainerProvider provider in providerList)
            {
                yield return StartCoroutine(RunWorker(provider, timer));
            }
        }

        public void Run(IContainerProvider provider, Timer timer)
        {
            ResetGC();
            timer.Begin(provider.Name);
            Worker(provider, timer);
            timer.End();
        }

        System.Collections.IEnumerator RunWorker(IContainerProvider provider, Timer timer)
        {
            ResetGC();           
            timer.Begin(provider.Name);
            yield return null;
            yield return StartCoroutine(WorkerCoroutine(provider, timer));
            timer.End();
        }

        public void Worker(IContainerProvider provider, Timer timer)
        {
            foreach (TestBase test in testList)
            {
                IContainer container = provider.Create();
                if (test.Supported(container))
                {
                    test.Prepare(container);
                    timer.Begin(test.Name);
                    for (int i = 0; i < cycles; i++)
                    {
                        test.Run(container);
                    }
                    timer.End();

                    bool valid = test.Validate(cycles);
                    if (!valid)
                    {
                        Debug.LogError("Validation Failed:" + test.Name + ", " + provider.Name);
                    }
                }
            }
        }

        System.Collections.IEnumerator WorkerCoroutine(IContainerProvider provider, Timer timer)
        {
            foreach (TestBase test in testList)
            {
                IContainer container = provider.Create();
                if (test.Supported(container))
                {
                    test.Prepare(container);
                    timer.Begin(test.Name);
                    for (int i = 0; i < cycles; i++)
                    {
                        test.Run(container);
                    }
                    timer.End();

                    bool valid = test.Validate(cycles);
                    if (!valid)
                    {
                        Debug.LogError("Validation Failed:" + test.Name + ", " + provider.Name);
                    }
                    UpdateGuiDisplay(timer);
                }
                yield return null;
            }
            UpdateGuiDisplay(timer);
        }

        void ResetGC()
        {
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            System.GC.Collect();
        }

        private static System.Random rng = new System.Random();

        public static void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        void RunBenchmarkCoroutine()
        {
            StartCoroutine(RunBenchmarkWorker());
        }  
        
        void UpdateGuiDisplay(Timer timer)
        {
            guiText = timer.ToLog();
            windowScroll.y = windowScroll.y + 1000;
        }      

        void OnGUI()
        {
            windowRect = GUILayout.Window(0, windowRect, OnGUIBenchmark, "Benchmark", GUILayout.Width(Screen.width - 100), GUILayout.Height(Screen.height - 100));
        }

        void OnGUIBenchmark(int windowID)
        {
            if (font != null)
            {
                GUI.skin.label.font = GUI.skin.box.font = GUI.skin.button.font = font;
            }
            GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = 20;

            if (GUILayout.Button("Run"))
            {
                RunBenchmarkCoroutine();
            }

            //GUILayout.TextArea(guiText);
            windowScroll = GUILayout.BeginScrollView(windowScroll);
            GUILayout.Label(guiText);
            GUILayout.EndScrollView();
        }
    }
}
