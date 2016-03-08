using System;
using System.Collections.Generic;

namespace RelationsComputing
{
    public enum Relation
    {
        None,   // default
        Equal,  // =
        Lower,  // <
        Greater // >
    }


    /// <summary>
    /// Relationship table template.
    /// Familiar to dictionary, but has two keys like a matrix
    /// </summary>
    /// <typeparam name="TKey">First and second key type</typeparam>
    /// <typeparam name="TValue">Value type</typeparam>
    public class Table<TKey, TValue> : Dictionary<Tuple<TKey, TKey>, TValue>
    {
        public bool Reassignable { get; set; }

        public TValue this[TKey row, TKey column]
        {
            get
            {
                try
                {
                    return this[Tuple.Create(row, column)];
                }
                catch (KeyNotFoundException)
                {
                    return default(TValue);
                }
            }
            set
            {
                if (!Reassignable && !this[row, column].Equals(default(TValue)) && !this[row, column].Equals(value))
                    throw new RelationException<TKey, TValue>(row, column, this[row, column], value);
                this[Tuple.Create(row, column)] = value;
            }
        }
    }
}
