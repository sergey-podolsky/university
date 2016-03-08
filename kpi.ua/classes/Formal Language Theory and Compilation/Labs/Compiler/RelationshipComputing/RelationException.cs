using System;

namespace RelationsComputing
{
    /// <summary>
    /// Relation Exception
    /// </summary>
    /// <typeparam name="TKey">Type of Key</typeparam>
    /// <typeparam name="TValue">Type of Relation</typeparam>
    [Serializable]
    public class RelationException<TKey, TValue> : Exception
    {
        public RelationException(TKey row, TKey column, TValue oldRelation, TValue newRelation)
            : this("There is more than only one Wirth-Weber precedence relation between\n" + row + " and " + column + ".\nOld value:\t" + oldRelation + "\nNew value:\t" + newRelation)
        { }

        public RelationException(string message) : base(message) { }
    }
}
