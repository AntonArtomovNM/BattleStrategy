using System;
using System.Collections.Generic;
using System.Text;

namespace BattleStrategy.Interfaces
{
    public interface IVisualizer
    {
        /// <summary>
        /// Displays a message of any type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message">Message to be displayed</param>
        public void Show<T>(T message);
    }
}
