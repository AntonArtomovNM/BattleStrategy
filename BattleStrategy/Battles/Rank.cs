using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using BattleStrategy.Warriors;
using BattleStrategy.Interfaces;

namespace BattleStrategy.Battles
{
    public class Rank :IBattleStructure<Warrior, Rank>, IReversible
    {
        readonly List<Warrior> warriors;

        /// <summary>
        /// Gets the first unit of the rank
        /// </summary>
        public Warrior FirstUnit => warriors.Count > 0 ? warriors[0] : null;
        public string Name { get; }
        public int Count => warriors.Count;
        public bool IsAlive => warriors.Exists(w => w.IsAlive);

        public Warrior this[int index]
        {
            get
            {
                if (index >= warriors.Count || index < 0)
                    throw new ArgumentOutOfRangeException();

                return warriors[index];
            }
        }

        /// <summary>
        /// Creates a rank object
        /// </summary>
        public Rank(string name = "Rank")
        {
            warriors = new List<Warrior>();
            Name = name;
        }

        /// <summary>
        /// Creates a rank object with units in it
        /// </summary>
        /// <param name="units">Units to be added</param>
        /// <exception cref="ArgumentNullException">Thrown if parameter was null</exception>
        public Rank(IEnumerable<Warrior> units, string name = "Rank") : this(name)
        {
            if (units == null)
                throw new ArgumentNullException();

            AddUnit(units);
        }

        /// <summary>
        /// Adds one unit to te rank
        /// </summary>
        /// <param name="unit">Unit to be added</param>
        /// <exception cref="ArgumentNullException">Thrown if parameter was null</exception>
        public void AddUnit(Warrior unit)
        {
            if (unit == null)
                throw new ArgumentNullException();

            warriors.Add(unit);
        }

        /// <summary>
        /// Adds collection of units to the rank
        /// Ignores null units
        /// </summary>
        /// <param name="units">Units to be added</param>
        /// <exception cref="ArgumentNullException">Thrown if parameter was null</exception>
        public void AddUnit(IEnumerable<Warrior> units)
        {
            if (units == null)
                throw new ArgumentNullException();

            foreach (var unit in units)
            {
                if (unit != null)
                    AddUnit(unit);
            }
        }

        /// <summary>
        /// Attacks first warrior of selected rank using stats of first warrior of this rank
        /// </summary>
        /// <param name="target">Targeted rank</param>
        /// <exception cref="ArgumentNullException"> Thrown if parameter was null</exception>
        public void Attack(Rank target)
        {
            if (target == null)
                throw new ArgumentNullException();

            if (IsAlive && FirstUnit.IsAlive && target.IsAlive)
            {
                FirstUnit.Attack(target.FirstUnit);
                if (FirstUnit.AttackRange > 1)
                {
                    for (int i = 1; i <= FirstUnit.AttackRange && i < target.Count; i++)
                    {
                        FirstUnit.Attack(target[i], Warrior.rangedAttackModifier);
                    }
                }

                if (IsAlive && warriors.Count > 1)
                {
                    FirstUnit.Heal(warriors[1].HealingPower);
                }
            }
        }

        public bool RemoveDead()
        {
            return warriors.RemoveAll(w => !w.IsAlive) > 0;
        }

        public override string ToString()
        {
            if (warriors == null)
                return string.Empty;

            StringBuilder builder = new StringBuilder();
            foreach (var warrior in warriors)
            {
                builder.Append(warrior.ToString());
                builder.Append(" ");
            }

            if (builder.Length > 0)
            {
                builder.Remove(builder.Length - 1, 1);
            }

            return builder.ToString();
        }

        public string ToReversedString()
        {
            if (warriors == null)
                return string.Empty;

            StringBuilder builder = new StringBuilder();
            for(int i = warriors.Count - 1; i >= 0; i--)
            {
                builder.Append(warriors[i].ToString());
                builder.Append(" ");
            }

            if (builder.Length > 0)
            {
                builder.Remove(builder.Length - 1, 1);
            }

            return builder.ToString();
        }

        public IEnumerator<Warrior> GetEnumerator()
        {
            return warriors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
