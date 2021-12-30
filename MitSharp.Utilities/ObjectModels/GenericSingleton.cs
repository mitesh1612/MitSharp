namespace MitSharp.Utilities.ObjectModels
{
    /// <summary>
    /// Generic testable singleton class for concrete type <typeparamref name="TCon"/> implementing interface <typeparamref name="TInt"/>.
    /// </summary>
    /// <typeparam name="TInt">Interface Type.</typeparam>
    /// <typeparam name="TCon">Concrete Type for given interface type.</typeparam>
    public class GenericSingleton<TInt, TCon>
        where TCon : TInt, new()
    {
        private static TInt _instance;

        public static void SetInstance(TInt newInstance)
        {
            _instance = newInstance;
        }

        public static TInt Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TCon();
                }

                return _instance;
            }
        }
    }
}
