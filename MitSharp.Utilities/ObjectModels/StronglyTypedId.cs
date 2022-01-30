using System;
using System.Collections.Generic;
using System.Text;

namespace MitSharp.Utilities.ObjectModels
{
    /// <summary>
    /// Abstract class to create a strongly typed id from a primitive id type.
    /// Blatantly stolen from: https://andrewlock.net/using-strongly-typed-entity-ids-to-avoid-primitive-obsession-part-2/
    /// </summary>
    /// <typeparam name="T">Primitive Id Type. Should implement IComparable.</typeparam>
    public abstract class StronglyTypedId<T> : IComparable<StronglyTypedId<T>>, IEquatable<StronglyTypedId<T>>
        where T : IComparable
    {
        protected T Value { get; }

        public StronglyTypedId(T val)
        {
            Value = val;
        }

        public bool Equals(StronglyTypedId<T> other) => this.Value.Equals(other.Value);

        public int CompareTo(StronglyTypedId<T> other) => Value.CompareTo(other.Value);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is StronglyTypedId<T> other && Equals(other);
        }

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value.ToString();

        public static bool operator ==(StronglyTypedId<T> a, StronglyTypedId<T> b) => a.CompareTo(b) == 0;
        
        public static bool operator !=(StronglyTypedId<T> a, StronglyTypedId<T> b) => !(a == b);

        // TODO: Add the JsonConverter code
    }
}
