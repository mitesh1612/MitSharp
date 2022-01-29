using System;
using System.Collections.Generic;
using System.Text;

namespace MitSharp.Utilities.ObjectModels
{
    /// <summary>
    /// Generic testable singleton class for concrete type using Lazy Initialization <typeparamref name="TCon"/> implementing interface <typeparamref name="TInt"/>.
    /// </summary>
    /// <typeparam name="TCon"></typeparam>
    /// <typeparam name="TInt">Interface Type.</typeparam>
    public class GenericLazySingleton<TCon, TInt>
        where TCon : TInt, new()
    {
        private static Lazy<TInt> instance = new Lazy<TInt>(new TCon());

        private static Func<TInt> instanceFactory;

        public static void SetInstanceFactory(Func<TInt> newInstanceFactory)
        {
            instanceFactory = newInstanceFactory;
            instance = new Lazy<TInt>(instanceFactory);
        }

        public static TInt Instance
        {
            get
            {
                return instance.Value;
            }
        }
    }
}
