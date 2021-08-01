using System;
using System.Collections.Generic;
using System.Text;

namespace BattleStrategy.Interfaces
{
    /// <summary>
    /// Helpsin making creator for objects using builder
    /// </summary>
    /// <typeparam name="T">Type of objects to be created</typeparam>
    /// <typeparam name="U">Type of builder used for creation</typeparam>
    public interface ICreator<T, U> where U : IBuilder<T>
    {
        /// <summary>
        /// Create a certain type of object, classified by builder
        /// </summary>
        /// <param name="builder">Concrete object builder</param>
        /// <returns>Object created with builder</returns>
        public T Create(U builder);
    }
}
