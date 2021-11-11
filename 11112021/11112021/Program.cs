using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _11112021
{
    class Program
    {
        static private List<string> _list = new List<string>();
        static void Add()
        {
            lock(_list) _list.Add("item " + _list.Count);
            lock(_list) foreach (var item in _list) Console.WriteLine(item);
        }

        static async Task Main(string[] args)
        {

            Thread thread1 = new Thread(Add);
            Thread thread2 = new Thread(Add);

            thread1.Start();
            thread2.Start();




            //Thread thread1 = new Thread(ShowA);
            //Thread thread2 = new Thread(ShowB);

            //thread2.Start();

            //thread1.Start();

            //for (int i = 0; i < 1000; i++)
            //{
            //    Console.Write("C");
            //}


            //var task = Task.Run(() =>
            //{
            //    Console.WriteLine("Hello, World!");
            //});

            //var task = GetGoogleSource().ContinueWith(x => Console.WriteLine("Finsihed"));




            //await ShowGoogleSource();


            //for (int i = 0; i < 2000; i++)
            //{
            //    Console.WriteLine("Continue..");
            //}

            //while (!task.IsCompleted)
            //{
            //    Console.WriteLine("loading..");
            //}
            //Console.WriteLine("finished");

            Console.ReadLine();
        }

        static Task<string> GetGoogleSource()
        {
            HttpClient httpClient = new HttpClient();
            var task =   Task.Run(() =>
            {
                return httpClient.GetStringAsync("https://google.com");
            });
            return task;
        }

        static async Task ShowGoogleSource()
        {
            HttpClient httpClient = new HttpClient();
            var str = await httpClient.GetStringAsync("https://google.com");
            Console.WriteLine(str);
        }

        static void ShowA()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("A ");
            }
        }

        static void ShowB()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("B ");
            }
        }
    }
}
