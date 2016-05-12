using UnityEngine;
using System.Collections.Generic;

namespace IoCBenchmark
{
    public class Timer
    {
        TimeNode root;
        TimeNode current;
        Stack<TimeNode> stack;

        public Timer()
        {
            root = new TimeNode
            {
                Name = "Root",
            };
            current = root;
            stack = new Stack<TimeNode>();
            stack.Push(root);
        }

        public void Begin(string name)
        {
            TimeNode node = new TimeNode
            {
                Name = name,
            };
            current.AddChild(node);
            stack.Push(current);

            current = node;
            current.Begin();
        }

        public void End()
        {
            current.End();
            current = stack.Pop();
        }

        public string ToLog()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            root.ToLog(sb, 0);
            return sb.ToString();
        }

        class TimeNode
        {
            public string Name { get; set; }

            List<TimeNode> children;
            System.Diagnostics.Stopwatch watch;

            public TimeNode()
            {
                children = new List<TimeNode>();
                watch = new System.Diagnostics.Stopwatch();
            }

            public void AddChild(TimeNode node)
            {
                children.Add(node);
            }

            public void Begin()
            {
                watch.Start();
            }

            public void End()
            {
                watch.Stop();
            }

            public void ToLog(System.Text.StringBuilder sb, int layer)
            {
                Indent(sb, layer);
                sb.Append(Name);
                sb.Append(":");

                string timeString = watch.ElapsedMilliseconds.ToString("#,##0");
                int spaceCount = 30 - layer - Name.Length - timeString.Length;
                for(int i = 0; i < spaceCount; i++)
                {
                    sb.Append(" ");
                }

                sb.Append(timeString);
                sb.AppendLine();
                layer++;
                foreach (TimeNode child in children)
                {
                    child.ToLog(sb, layer);
                }
                if (children.Count > 0)
                {
                    sb.AppendLine();
                }
            }

            void Indent(System.Text.StringBuilder sb, int layer)
            {
                for(int i = 0; i < layer; i++)
                {
                    sb.Append(" ");
                }
            }
        }
    }
}
