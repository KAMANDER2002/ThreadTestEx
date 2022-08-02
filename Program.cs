using System;
using System.Threading;


namespace TestEx2
{
    internal class Program
    {
        private void MyEventHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Вход в обработчик");
            Thread.Sleep(1000);
            Console.WriteLine("Выход из обработчика");
        }

        private void Run()
        {
            EventHandler h = new EventHandler(MyEventHandler);
            AsynсCaller ac = new AsynсCaller();
            ac.AsyncCaller(h);
            if (ac.Invoke(5000, this, EventArgs.Empty))
                Console.WriteLine("Завершенно успешно");
            else
                Console.WriteLine("Timeout occured");
        }

        static void Main(string[] args)
        {
            new Program().Run();
            Console.WriteLine("Выполнено.");
            Console.ReadKey();
        }
    }
       public class AsynсCaller
        {
            EventHandler eventHandler;
            public void AsyncCaller(EventHandler eventHandler)
            {
                this.eventHandler = eventHandler;
            }

            public bool Invoke(int timeOut, object sender, EventArgs e)
            {
                Thread thread = new Thread(() => { eventHandler.Invoke(sender, e); });
                thread.Start();
                return thread.Join(timeOut);
            }
        }
}
