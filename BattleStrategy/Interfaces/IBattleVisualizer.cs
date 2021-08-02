using System;
using System.Collections.Generic;
using System.Text;
using BattleStrategy.Warriors;
using BattleStrategy.Battles;

namespace BattleStrategy.Interfaces
{
    public interface IBattleVisualizer : IVisualizer
    {
        /// <summary>
        /// Displays battle warrior VS warrior in its current stage
        /// </summary>
        /// <param name="warrior1">First warrior</param>
        /// <param name="warrior2">Second warrior</param>
        public void ShowBattle(Warrior warrior1, Warrior warrior2);
        /// <summary>
        /// Displays battle rank VS rank in its current stage
        /// </summary>
        /// <param name="rank1">First rank</param>
        /// <param name="rank2">Second rank</param>
        public void ShowBattle(Rank rank1, Rank rank2);
        /// <summary>
        /// Displays battle army VS army in its current stage
        /// </summary>
        /// <param name="army1">First army</param>
        /// <param name="army2">Second army</param>
        public void ShowBattle(Army army1, Army army2);
        /// <summary>
        /// Displayes battle result in attacker vs attacker fight
        /// </summary>
        /// <param name="winner">Winning attacker</param>
        public void ShowBattleResult<T>(IAttacker<T> winner) where T : class;
    }
}