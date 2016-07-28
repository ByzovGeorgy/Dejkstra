using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dejkstra
{
    class Program
    {
        public static List<List<KeyValuePair<int,int>>> edges=new List<List<KeyValuePair<int, int>>>();
        public static int[] parents;
        public static int[] distance;
        public static bool[] marks;
        public static int count;
        public static int start;
        public static int finish;
        public static List<KeyValuePair<int, int>> mark=new List<KeyValuePair<int, int>>();
        static void Main(string[] args)
        {
            Reader();
            Dijkstra();
            List<int> ii=new List<int>();
            ii.Add(finish+1);
            int k = finish;
            StreamWriter writer=new StreamWriter("out.txt");
            if (distance[finish] == int.MaxValue)
            {
                writer.WriteLine("N");
                writer.Close();
                return;              
            }
            writer.WriteLine("Y");
            while (true)
            {
                k = parents[k];
                ii.Add(k+1);
                if(k==start)
                    break;
            }
            ii.Reverse();
            foreach (var i in ii)
            {
                writer.Write(i+" ");
            }
            writer.WriteLine();
            writer.WriteLine(distance[finish]);
            writer.Close();
        }

        public static int[] arr;
        public static void Dijkstra()
        {
            arr=new int[count];
            parents[start] = start;
            distance[start] = 0;
            for (int i = 0; i < count; i++)
            {
                if (i != start)
                    distance[i] = int.MaxValue;
                mark.Add(new KeyValuePair<int, int>(distance[i],i));
            }
            while (mark.Count>0)
            {
                KeyValuePair<int, int> cur = FindMin();
                mark.Remove(cur);
                if(cur.Key==int.MaxValue || cur.Key>distance[finish])
                    return;
                for (int i = 0; i < edges[cur.Value].Count; i++)
                {
                    if (distance[edges[cur.Value][i].Key] > cur.Key + edges[cur.Value][i].Value)
                    {
                        mark.Remove(new KeyValuePair<int, int>(distance[edges[cur.Value][i].Key], edges[cur.Value][i].Key));
                        distance[edges[cur.Value][i].Key] = cur.Key + edges[cur.Value][i].Value;
                        mark.Add(new KeyValuePair<int, int>(distance[edges[cur.Value][i].Key], edges[cur.Value][i].Key));
                        parents[edges[cur.Value][i].Key] = cur.Value;
                    }
                }
            }
        }

        public static KeyValuePair<int, int> FindMin()
        {
            int t = int.MaxValue;
            int tt = 0;
            for (int i = 0; i < mark.Count; i++)
            {
                if (mark[i].Key < t)
                {
                    t = mark[i].Key;
                    tt = i;
                }
            }
            return mark[tt];
        }
        private static void Reader()
        {
            StreamReader reader = new StreamReader("in.txt");
            count = int.Parse(reader.ReadLine());
            parents=new int[count];
            distance=new int[count];
            marks=new bool[count];
            string[] s;
            for (int i = 0; i < count; i++)
            {
                s = reader.ReadLine().Split(' ').ToArray();
                edges.Add(new List<KeyValuePair<int, int>>());
                for (int j = 0; j < s.Length; j+=2)
                {
                    if(!s[j].Equals("32767") && !s[j].Equals("0"))
                        edges[i].Add(new KeyValuePair<int, int>(int.Parse(s[j]) - 1,int.Parse(s[j+1])));
                }
            }
            start = int.Parse(reader.ReadLine()) - 1;
            finish = int.Parse(reader.ReadLine())-1;
        }
    }
}
