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
        /// Shows the attacker's name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Shows if attacker themself are alive and ready to attack
        /// </summary>
        public bool IsAlive { get; }
        /// <summary>
        /// Attacks another attacker
        /// </summary>
        /// <param name="target">Target to be attacked</param>
        public void Attack(T target);
    }
}
