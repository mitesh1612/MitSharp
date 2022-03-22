using System;

namespace MitSharp.Utilities.ObjectModels
{
    /// <summary>
    /// Stolen from https://tyrrrz.me/blog/return-type-inference
    /// It’s a container that encapsulates a single value (or absence thereof) and allows us to perform various operations on the content without actually observing its state.
    /// </summary>
    /// <typeparam name="T">Type of the value to encapsulate.</typeparam>
    public class Option<T>
    {
        private readonly T _value;

        private readonly bool _hasValue;

        private Option(T value, bool hasValue)
        {
            _value = value;
            _hasValue = hasValue;
        }

        public Option(T value)
            : this(value, true)
        { }

        public Option()
        {
            _value = default(T);
            _hasValue = false;
        }

        public TOut Match<TOut>(Func<T, TOut> some, Func<TOut> none) =>
            _hasValue ? some(_value) : none();

        public void Match(Action<T> some, Action none)
        {
            if (_hasValue)
            {
                some(_value);
            }
            else
            {
                none();
            }
        }

        public Option<TOut> Select<TOut>(Func<T, TOut> map) =>
            _hasValue ? new Option<TOut>(map(_value)) : new Option<TOut>();

        public Option<TOut> Bind<TOut>(Func<T, Option<TOut>> bind) =>
            _hasValue ? bind(_value) : new Option<TOut>();
    }
}
