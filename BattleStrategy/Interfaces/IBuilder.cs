using System;
using System.Collections.Generic;
using System.Text;

namespace BattleStrategy.Interfaces
{
    /// <summary>
    /// Helps making builder for objects
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBuilder<T>
    {
        /// <summary>
        /// Resets builder result to empty
        /// </summary>
        public void Reset();
        /// <summary>
        /// Returns ready object
        /// </summary>
        /// <returns>Builded <typeparamref name="T"/> object</returns>
        internal T GetResult();
    }
}
