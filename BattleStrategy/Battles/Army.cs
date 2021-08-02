using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BattleStrategy.Warriors;
using BattleStrategy.Interfaces;

namespace BattleStrategy.Battles
{
    public class Army : IBattleStructure<Rank, Army>, IReversible
    {
        readonly List<Rank> ranks;
        private string name;

        public int Count => ranks.Count;
        public bool IsAlive => ranks.Exists(r => r.IsAlive);
        public string Name
        {
            get
            {
                if (name == null || name == string.Empty)
                    return GetType().Name;
                return name;
            }
            set
            {
                name = value;
            }
        }

        public Rank this[int index]
        {
            get
            {
                if (index >= ranks.Count || index < 0)
                    throw new ArgumentOutOfRangeException();

                return ranks[index];
            }
        }

        /// <summary>
        /// Creates an army object
        /// </summary>
        public Army()
        {
            ranks = new List<Rank>();
            Name = name; 
        }

        /// <summary>
        /// Creates an army object with ranks in it
        /// </summary>
        /// <param name="ranks">Ranks to be added</param>
        /// <exception cref="ArgumentNullException">Thrown if parameter was null</exception>
        public Army (IEnumerable<Rank> ranks) : this()
        {
            if (ranks == null)
                throw new ArgumentNullException();

            AddRank(ranks);
        }


        /// <summary>
        /// Adds rank to the army
        /// </summary>
        /// <param name="rank">Rank to be added</param>
        /// <exception cref="ArgumentNullException">Thrown if parameter was null</exception>
        public void AddRank(Rank rank)
        {
            if (rank == null)
                throw new ArgumentNullException();

            ranks.Add(rank);
        }

        /// <summary>
        /// Adds collection of warriors to the army in form of new rank
        /// </summary>
        /// <param name="rank">Rank to be added</param>
        /// <exception cref="ArgumentNullException">Thrown if parameter was null</exception>
        public void AddRank(IEnumerable<Warrior> rank)
        {
            if (rank == null)
                throw new ArgumentNullException();

            AddRank(new Rank(rank));
        }

        /// <summary>
        /// Adds coolection of ranks to the army
        /// </summary>
        /// <param name="ranks">Ranks to be added</param>
        /// <exception cref="ArgumentNullException">Thrown if parameter was null</exception>
        public void AddRank(IEnumerable<Rank> ranks)
        {
            if (ranks == null)
                throw new ArgumentNullException();

            foreach (var rank in ranks)
            {
                if (rank != null) 
                {
                    AddRank(rank);
                }
            }
        }

        /// <summary>
        /// Adds unit to specific rank
        /// </summary>
        /// <param name="unit">Unit to be added</param>
        /// <param name="rankIndex">Index of the rank where unit will be added</param>
        /// <exception cref="ArgumentNullException">Thrown if parameter was null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if index was out of army boundaries</exception>
        public void AddToRank(Warrior unit, int rankIndex)
        {
            if (unit == null)
                throw new ArgumentNullException();

            if (rankIndex >= ranks.Count || rankIndex < 0)
                throw new ArgumentOutOfRangeException();

            ranks[rankIndex].AddUnit(unit);
        }

        /// <summary>
        /// Adds a collection of units to specific rank
        /// </summary>
        /// <param name="units">Units to be added</param>
        /// <param name="rankIndex">Index of the rank where units will be added</param>
        /// /// <exception cref="ArgumentNullException">Thrown if parameter was null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if index was out of army boundaries</exception>
        public void AddToRank(IEnumerable<Warrior> units, int rankIndex)
        {
            if (units == null)
                throw new ArgumentNullException();

            if (rankIndex >= ranks.Count || rankIndex < 0)
                throw new ArgumentOutOfRangeException();

            ranks[rankIndex].AddUnit(units);
        }

        /// <summary>
        /// Attacks first warrior of selected rank using stats of first warrior of this rank
        /// </summary>
        /// <param name="target">Targeted rank</param>
        /// <exception cref="ArgumentNullException"> Thrown if parameter was null</exception>
        public void Attack(Army target)
        {
            if (target == null)
                throw new ArgumentNullException();

            if (IsAlive && target.IsAlive)
            {
                Parallel.For(0, Math.Min(Count, target.Count), i => ranks[i].Attack(target[i]));     
            }
        }

        public bool RemoveDead()
        {
            bool wasRemoved = false;
            Parallel.For(0, ranks.Count, i => wasRemoved |= ranks[i].RemoveDead());
            return wasRemoved |= ranks.RemoveAll(r => !r.IsAlive) > 0;
        }

        public override string ToString()
        {
            if (ranks == null)
                return string.Empty;

            StringBuilder builder = new StringBuilder();
            foreach (var rank in ranks)
            {
                builder.AppendLine(rank.ToString());
            }
            return builder.ToString();
        }

        public string ToReversedString()
        {
            if (ranks == null)
                return string.Empty;

            StringBuilder builder = new StringBuilder();
            for (int i = ranks.Count - 1; i >= 0; i--)
            {
                builder.AppendLine(ranks[i].ToString());
            }
            return builder.ToString();
        }

        public IEnumerator<Rank> GetEnumerator()
        {
            return ranks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
