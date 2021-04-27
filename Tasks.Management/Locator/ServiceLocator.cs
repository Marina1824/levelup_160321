using System;
using System.Collections.Generic;

namespace Tasks.Management.Locator
{
    public class Foo
    {

    }

    public static class ServiceLocator
    {
        private static readonly IDictionary<Type, object> _index = new Dictionary<Type, object>();

        public static void Foo()
        {
            AddAsFunc<Foo>(() => new Foo());
        }

        public static void AddAsFunc<TAbstraction>(Func<TAbstraction> creator)
            where TAbstraction : class
        {
            TAbstraction abstraction = creator.Invoke();
        }

        public static void AddAsSingleton<TAbstraction, TInstance>()
            where TAbstraction : class
            where TInstance : class, TAbstraction, new()
        {
            TAbstraction item = new TInstance();

            Type abstraction = typeof(TAbstraction);

            _index.Add(abstraction, item);
        }

        public static void AddAsSingleton<TAbstraction, TInstance>(TInstance instance)
            where TAbstraction : class
            where TInstance : class, TAbstraction
        {
            Type abstraction = typeof(TAbstraction);

            _index.Add(abstraction, instance);
        }

        public static TAbstraction Get<TAbstraction>()
            where TAbstraction : class
        {
            Type abstraction = typeof(TAbstraction);

            if (_index.ContainsKey(abstraction))
            {
                object item = _index[abstraction];

                return (TAbstraction) item;
            }

            return null;
        }
    }
}