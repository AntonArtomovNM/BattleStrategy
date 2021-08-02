using System;
using System.Collections.Generic;
using System.Text;

namespace BattleStrategy.Interfaces
{
    /// <summary>
    /// Helps in creating stracture of units for battling
    /// </summary>
    /// <typeparam name="T">Type of structure elements</typeparam>
    /// <typeparam name="U">Type of attackable enemy</typeparam>
    public interface IBattleStructure<T, U> : IEnumerable<T>, IAttacker<U> where U : class
    {
        /// <summary>
        /// Shows the amount of structure elements
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Gets structure element at specific index
        /// </summary>
        /// <param name="index">Index of structure element</param>
        /// <returns>Element located at this index</returns>
        public T this[int index] { get; }

        /// <summary>
        /// Removes unalive units from the structure
        /// </summary>
        /// <returns>True if any unit was remove, false if not</returns>
        public bool RemoveDead();
    }
}
