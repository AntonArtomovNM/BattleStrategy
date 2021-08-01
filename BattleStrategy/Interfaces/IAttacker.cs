using System;
using System.Collections.Generic;
using System.Text;

namespace BattleStrategy.Interfaces
{
    /// <summary>
    /// Helps making battle unit
    /// </summary>
    /// <typeparam name="T">Type of attackable enemy</typeparam>
    public interface IAttacker<T> where T : class
    {
        /// <summary>
        /// Shows if attacker itself alive and ready for attack
        /// </summary>
        public bool IsAlive { get; }
        /// <summary>
        /// Attacks another attacker
        /// </summary>
        /// <param name="target">Target to be attacked</param>
        public void Attack(T target);
    }
}
