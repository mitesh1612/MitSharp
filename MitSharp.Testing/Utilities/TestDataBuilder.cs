namespace MitSharp.Testing.Utilities
{
    // Blatantly stolen from: https://blog.ploeh.dk/2017/08/21/generalised-test-data-builder/
    public class TestDataBuilder<T>
    {
        private readonly T item;

        public TestDataBuilder(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            
            this.item = item;
        }

        public TestDataBuilder<T1> Select<T1>(Func<T, T1> modifyFunc)
        {
            var newItem = modifyFunc(item);
            return new TestDataBuilder<T1>(newItem);
        }

        public T Build()
        {
            return this.item;
        }
        public override bool Equals(object obj)
        {
            var other = obj as TestDataBuilder<T>;
            if (other == null)
                return base.Equals(obj);

            return object.Equals(this.item, other.item);
        }

        public override int GetHashCode()
        {
            return this.item.GetHashCode();
        }

        public static TestDataBuilder<T> CreateWithDefault(T item)
        {
            return new TestDataBuilder<T>(item);
        }
    }
}
