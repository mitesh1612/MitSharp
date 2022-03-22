namespace MitSharp.Utilities.ObjectModels
{
    /// <summary>
    /// Generic Maybe class representing an object that "maybe" contains a value of type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    public class Maybe<T>
    {
        public static readonly Maybe<T> None = new Maybe<T>();

        private Maybe()
        {
            this.HasValue = false;
        }

        private Maybe(T value)
        {
            this.Value = value;
            this.HasValue = true;
        }

        public bool HasValue { get; private set; } = false;

        public T Value { get; private set; }

        public static Maybe<T> Of(T value)
        {
            return new Maybe<T>(value);
        }

        public bool IsNone()
        {
            return this == Maybe<T>.None;
        }
    }
}
