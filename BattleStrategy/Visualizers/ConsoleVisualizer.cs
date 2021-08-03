using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BattleStrategy.Warriors;
using BattleStrategy.Battles;
using BattleStrategy.Interfaces;

namespace BattleStrategy.Visualizers
{
    public class ConsoleVisualizer : IBattleVisualizer
    {
        readonly StringBuilder builder = new StringBuilder();

        public void Show<T>(T message)
        {
            Console.WriteLine(message.ToString());
        }

        public void ShowBattle(Warrior warrior1, Warrior warrior2)
        {
            if (warrior1 == null || warrior2 == null)
                throw new ArgumentNullException();

            warrior1.ShowInfo(this);
            warrior2.ShowInfo(this);
        }

        public void ShowBattle(Rank rank1, Rank rank2)
        {
            if (rank1 == null || rank2 == null)
                throw new ArgumentNullException();

            int maxStringLength = Math.Max(rank1.Count * 2, rank2.Count * 2);
            ShowHeader(rank1, rank2, ref maxStringLength);
            AddBattleLine(rank1.ToReversedString(), rank2.ToString(), maxStringLength);
            Console.WriteLine();
        }

        public void ShowBattle(Army army1, Army army2)
        {
            if (army1 == null || army2 == null)
                throw new ArgumentNullException();

            int maxStringLength = Math.Max(army1.Count > 0 ? army1.Max(r => r.Count * 2) : 0, army2.Count > 0 ? army2.Max(r => r.Count * 2) : 0);
            ShowHeader(army1, army2, ref maxStringLength);
            for (int i = 0; i < Math.Max(army1.Count, army2.Count); i++)
            {
                AddBattleLine(i >= army1.Count? string.Empty : army1[i].ToReversedString(), i >= army2.Count ? string.Empty : army2[i].ToString(), maxStringLength);
            }
            Console.WriteLine();
        }

        public void ShowBattleResult<T>(IAttacker<T> winner) where T : class
        {
            builder.Clear();
            builder.Append('▬', 26 + winner.Name.Length);
            builder.Append("\n\t");
            builder.Append(winner.Name);
            builder.AppendLine(" have won!");
            builder.Append('▬', 26 + winner.Name.Length);
            builder.AppendLine();
            Console.WriteLine(builder.ToString());
        }

        private void ShowHeader<T, U>(IBattleStructure<T, U> structure1, IBattleStructure<T, U> structure2, ref int maxStringLength) where U : class
        {
            string name1 = $"{structure1.Name} " + structure1.GetType().Name;
            string name2 = $"{structure2.Name} " + structure2.GetType().Name;

            maxStringLength = Math.Max(maxStringLength, Math.Max(name1.Length, name2.Length));

            builder.Clear();
            builder.Append(' ', maxStringLength - name1.Length);
            builder.Append(name1);
            builder.Append(" | ");
            builder.AppendLine(name2);
            builder.Append('▬', maxStringLength);
            builder.Append(" | ");
            builder.Append('▬', maxStringLength);
            Console.WriteLine(builder.ToString());
        }

        private void AddBattleLine(string rank1, string rank2, int maxStringLength)
        {
            builder.Clear();
            builder.Append(' ', maxStringLength - rank1.Length);
            builder.Append(rank1);
            builder.Append(" | ");
            builder.Append(rank2);
            Console.WriteLine(builder.ToString());
        }
    }
}
