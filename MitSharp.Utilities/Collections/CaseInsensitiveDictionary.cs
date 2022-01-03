using System;
using System.Collections.Generic;

namespace MitSharp.Utilities.Collections
{
    /// <summary>
    /// A Dictionary where keys are case-insensitive strings.
    /// </summary>
    /// <typeparam name="TValue">The type of the value in the dictionary.</typeparam>
    public class CaseInsensitiveDictionary<TValue> : Dictionary<string, TValue>
    {
        /// <summary>
        /// Get an empty dictionary.
        /// </summary>
        public static readonly CaseInsensitiveDictionary<TValue> Empty = new CaseInsensitiveDictionary<TValue>();

        /// <summary>
        /// Initializes a new instance of <see cref="CaseInsensitiveDictionary{TValue}"/> class.
        /// </summary>
        public CaseInsensitiveDictionary()
            : base(StringComparer.InvariantCultureIgnoreCase)
        {}

        /// <summary>
        /// Initializes a new instance of <see cref="CaseInsensitiveDictionary{TValue}"/> class with given initial capacity.
        /// </summary>
        /// <param name="capacity">Initial Capacity for the Dictionary.</param>
        public CaseInsensitiveDictionary(int capacity)
            : base(capacity, StringComparer.InvariantCultureIgnoreCase)
        {}

        /// <summary>
        /// Initializes a new instance of <see cref="CaseInsensitiveDictionary{TValue}"/> class with given existing dictionary.
        /// </summary>
        /// <param name="dictionary">Existing dictionary to use.</param>
        public CaseInsensitiveDictionary(IDictionary<string, TValue> dictionary)
            : base(dictionary, StringComparer.InvariantCultureIgnoreCase)
        {}
    }
}
