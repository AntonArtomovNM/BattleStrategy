using System;
using System.Collections.Generic;
using System.Text;
using BattleStrategy.Warriors;
using BattleStrategy.Interfaces;

namespace BattleStrategy.Battles
{
    public class Battle
    {
        /// <summary>
        /// Performs a set of attacks from the first warrior to the second warrior and vice versa until one of them dies
        /// </summary>
        /// <param name="warrior1">First warrior</param>
        /// <param name="warrior2">Second warrior</param>
        /// <param name="visualizer">Visuaizer which will display the process of the fight</param>
        /// <returns>True if the first warrior survives the fight, false if the second warrior survives</returns>
        /// <exception cref="ArgumentNullException">Thrown if parameter was null</exception>
        public bool Fight(Warrior warrior1, Warrior warrior2, IBattleVisualizer visualizer)
        {
            if (warrior1 == null || warrior2 == null)
                throw new ArgumentNullException();

            visualizer?.ShowBattle(warrior1, warrior2);
            while (warrior1.IsAlive && warrior2.IsAlive)
            {
                warrior1.Attack(warrior2);
                warrior2.Attack(warrior1);
                visualizer?.ShowBattle(warrior1, warrior2);
            }
            return warrior1.IsAlive;
        }

        /// <summary>
        /// Performs a set of attacks from the first rank to the second rank and vice versa until one of them dies
        /// </summary>
        /// <param name="rank1">First rank</param>
        /// <param name="rank2">Second rank</param>
        /// <param name="visualizer">Visuaizer which will display the process of the fight</param>
        /// <returns>True if the first rank survives the fight, false if the second rank survives</returns>
        /// <exception cref="ArgumentNullException">Thrown if parameter was null</exception>
        public bool Fight(Rank rank1, Rank rank2, IBattleVisualizer visualizer)
        {
            if (rank1 == null || rank2 == null)
                throw new ArgumentNullException();

            visualizer?.ShowBattle(rank1, rank2);
            while (rank1.IsAlive && rank2.IsAlive)
            {
                rank1.Attack(rank2);
                rank2.Attack(rank1);

                bool haveChanged = false;
                haveChanged |= rank1.RemoveDead();
                haveChanged |= rank2.RemoveDead();

                if (haveChanged)
                {
                    visualizer?.ShowBattle(rank1, rank2);
                }
            }
            return rank1.IsAlive;
        }

        /// <summary>
        /// Performs a set of attacks from the first army to the second army and vice versa until one of them dies
        /// </summary>
        /// <param name="army1">First army</param>
        /// <param name="army2">Second army</param>
        /// <param name="visualizer">Visuaizer which will display the process of the fight</param>
        /// <returns>True if the first army survives the fight, false if the second army survives</returns>
        /// <exception cref="ArgumentNullException">Thrown if parameter was null</exception>
        public bool Fight(Army army1, Army army2, IBattleVisualizer visualizer)
        {
            if (army1 == null || army2 == null)
                throw new ArgumentNullException();

            visualizer?.ShowBattle(army1, army2);
            while (army1.IsAlive && army2.IsAlive)
            {
                army1.Attack(army2);
                army2.Attack(army1);

                bool haveChanged = false;
                haveChanged |= army1.RemoveDead();
                haveChanged |= army2.RemoveDead();

                if (haveChanged)
                {
                    visualizer?.ShowBattle(army1, army2);
                }
            }
            return army1.IsAlive;
        }

        /// <summary>
        /// Performs a set of attacks from the first warrior to the second warrior and vice versa until one of them dies
        /// </summary>
        /// <param name="warrior1">First warrior</param>
        /// <param name="warrior2">Second warrior</param>
        /// <returns>True if the first warrior survives the fight, false if the second warrior survives</returns>
        /// <exception cref="ArgumentNullException">Thrown if parameter was null</exception>
        public bool Fight(Warrior warrior1, Warrior warrior2)
        {
            return Fight(warrior1, warrior2, null);
        }

        /// <summary>
        /// Performs a set of attacks from the first rank to the second rank and vice versa until one of them dies
        /// </summary>
        /// <param name="rank1">First rank</param>
        /// <param name="rank2">Second rank</param>
        /// <returns>True if the first rank survives the fight, false if the second rank survives</returns>
        /// <exception cref="ArgumentNullException">Thrown if parameter was null</exception>
        public bool Fight(Rank rank1, Rank rank2)
        {
            return Fight(rank1, rank2, null);
        }

        /// <summary>
        /// Performs a set of attacks from the first army to the second army and vice versa until one of them dies
        /// </summary>
        /// <param name="army1">First army</param>
        /// <param name="army2">Second army</param>
        /// <returns>True if the first army survives the fight, false if the second army survives</returns>
        /// <exception cref="ArgumentNullException">Thrown if parameter was null</exception>
        public bool Fight(Army army1, Army army2)
        {
            return Fight(army1, army2, null);
        }
    }
}
