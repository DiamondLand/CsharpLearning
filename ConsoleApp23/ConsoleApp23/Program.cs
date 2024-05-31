using System;
using static System.Console;

namespace ConsoleApp23
{
    // BasedDouble(), BasedInt(), BasedChar()
    class Based
    {
        public void BasedDouble(double value)
        {
            WriteLine("Based.BasedDouble(), value = {0}", value);
        }

        public void BasedInt(int value)
        {
            WriteLine("Based.BasedInt(), value = {0}", value);
        }

        public void BasedChar(char value)
        {
            WriteLine("Based.BasedChar, value = {0}", value);
        }
    }

    interface ITarget
    {
        void ClientDouble(double value);
        void ClientInt(int value);
        void ClientChar(char value);
    }

    // реализует интерфейс ITarget.
    class Adapter : Based, ITarget
    {
        private Based obj;
        public Adapter(Based obj)
        {
            this.obj = obj;
        }

        public void ClientDouble(double value)
        {
            obj.BasedDouble(value);
        }

        public void ClientInt(int value)
        {
            obj.BasedInt(value * 2);
        }

        public void ClientChar(char value)
        {
            for (int i = 0; i < 5; i++)
                obj.BasedChar(value);
        }
    }

    class Client
    {
        private ITarget client; // ссылка на интерфейс ITarge

        // Конструктор
        public Client(ITarget _client)
        {
            client = _client;
        }

        public void Show()
        {
            client.ClientDouble(2.88);
            client.ClientInt(39);
            client.ClientChar('Z');
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Based obj = new Based();
            Adapter adapter = new Adapter(obj);
            Client client = new Client(adapter);
            client.Show();
        }
    }
}