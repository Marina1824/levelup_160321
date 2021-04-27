using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tasks.Management.Commands;
using Tasks.Management.Data;
using Tasks.Management.Locator;
using Tasks.Management.Service;

namespace Tasks.Management
{
    class Program
    {

        private static void SomeCalc()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Another thread!");
            Thread.Sleep(2000);
        }

        static object object1 = new object();
        static object object2 = new object();

        public static void ObliviousFunction()
        {
            lock (object1)
            {
                Thread.Sleep(1000); // Wait for the blind to lead
                lock (object2)
                {
                    
                }
            }
        }

        public static void BlindFunction()
        {
            lock (object2)
            {
                Thread.Sleep(1000); // Wait for oblivion
                lock (object1)
                {

                }
            }
        }

        public static async Task<int> FooAsync(int i, CancellationToken cancellationToken, bool captureOnContext = false)
        {
            Thread.Sleep(200000);

            if (cancellationToken.IsCancellationRequested)
            {
                throw new OperationCanceledException(cancellationToken);
            }

            await Task.CompletedTask.ConfigureAwait(captureOnContext);

            return 1;
        }


        static async Task Main(string[] args)
        {
            CancellationTokenSource source = CancellationTokenSource.CreateLinkedTokenSource();

            int i = await FooAsync(100, source.Token);
            
            int i2 = await FooAsync(100, CancellationToken.None);

            source.Cancel();


            Thread thread1 = new Thread((ThreadStart)ObliviousFunction);
            Thread thread2 = new Thread((ThreadStart)BlindFunction);

            try
            {
                thread1.Start();
                thread2.Start();

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

            

            while (true)
            {
                
            }
        }


        /*static void Main(string[] args)
        {
            Thread thread = new Thread((ThreadStart) SomeCalc);
            thread.Start();


            Console.WriteLine("Hello %username%!");

            PersistenceService persistenceService = new PersistenceService();

            List<BaseCommand> commands = new List<BaseCommand>()
            {
                new LoadTaskCommand(persistenceService),
                new SaveTaskCommand(persistenceService),
                new NewTaskCommand()
            };

            List<UserTask> tasks = new List<UserTask>();

            if (args.Length > 0)
            {
                string firstArg = args[0];

                foreach (BaseCommand command in commands)
                {
                    if (command.CanHandle(firstArg))
                    {
                        command.Process(tasks);

                        break;
                    }
                }
            }
        }*/
        }

    public class Foo
    {
        private List<object> _objects = null;

        public Foo()
        {
            _objects = new List<object>();

            GC.Collect();
            GC.Collect();
        }

        public void Calculate()
        {

        }
    }
}
