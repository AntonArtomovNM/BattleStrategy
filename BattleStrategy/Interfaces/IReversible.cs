using System;
using System.Collections.Generic;
using System.Text;

namespace BattleStrategy.Interfaces
{
    interface IReversible
    {
        /// <summary>
        /// Returns a string which represents reversed ToString() of this object
        /// </summary>
        /// <returns>Reversed ToString()</returns>
        public string ToReversedString();
    }
}
