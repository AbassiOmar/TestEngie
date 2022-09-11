using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegExApi.Singleton
{
    public sealed   class SingletonService
    {
        //private static SingletonService instance;
        private static readonly Lazy<SingletonService> instance = new Lazy<SingletonService>(() => new SingletonService()); 
        public List<string> messages=new List<string>(0);
        // rendre la classe singleton  thread-safe
        // private static readonly object lockInstance = new object();
        static int instanceCounter = 0;
        private SingletonService()
        {
            instanceCounter++;
            messages.Add("Instances created " + instanceCounter);
        }
        public static SingletonService Instance
        {
            get
            {
                return instance.Value;
            }
        }

        // rendre la classe singleton  thread-safe
        //public static SingletonService Instance
        //{
        //    get{
        //        lock (lockInstance)
        //        {
        //            if (instance == null)
        //            {
        //                instance = new SingletonService();
        //            }
        //        }
        //        return instance.Value;
        //    }
        //}

        public void SertMessage(string message)
        {
            messages.Add(message);
        }
    }
}
