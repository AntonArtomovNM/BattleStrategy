using System;
using System.Collections.Generic;
using System.Text;
using BattleStrategy.Visualizers;
using BattleStrategy.Interfaces;

namespace BattleStrategy.Warriors
{
    public class Warrior : IAttacker<Warrior>
    {
        internal static float rangedAttackModifier = 0.5f;

        private int maxHP;
        private int hp;
        private int damage;
        private int attackRange;
        private int defence;
        private int vampirism;
        private int healingPower;

        /// <summary>
        /// Shows the max amount of hp this unit can have (including weapon bonus)
        /// </summary>
        public int MaxHP
        {
            get => maxHP;
            internal set
            {
                maxHP = Math.Clamp(value, 0, int.MaxValue);
                hp = maxHP;
            }
        }
        /// <summary>
        /// Shows the damage of this unit (including weapon bonus)
        /// </summary>
        public int Damage 
        {
            get => damage;
            internal set => damage = Math.Clamp(value, 0, int.MaxValue);
        }
        /// <summary>
        /// Shows the attack range of this unit (including weapon bonus)
        /// </summary>
        public int AttackRange
        {
            get => attackRange;
            internal set => attackRange = Math.Clamp(value, 1, int.MaxValue);
        }
        /// <summary>
        /// Shows the defence of this unit (including weapon bonus)
        /// </summary>
        public int Defence
        {
            get => defence;
            internal set => defence = Math.Clamp(value, 0, int.MaxValue);
        }
        /// <summary>
        /// Shows the vampirism power of this unit in percentage (including weapon bonus).
        /// Vampirism heals the warrior when they attack, as a percentage of the damage dealt
        /// </summary>
        public int Vampirism
        {
            get => vampirism;
            internal set => vampirism = Math.Clamp(value, 0, 100);
        }
        /// <summary>
        /// Shows the healing power of this unit (including weapon bonus).
        /// Healing power lets the warrior heal one unit right in front of them when that unit deals damage
        /// </summary>
        public int HealingPower
        {
            get => healingPower;
            internal set => healingPower = Math.Clamp(value, 0, int.MaxValue);
        }
        /// <summary>
        /// Shows if warrior's HP is greater than 0
        /// </summary>
        public bool IsAlive => hp > 0;
        /// <summary>
        /// Shows warrior's type
        /// </summary>
        public WarriorType Type { get; internal set; }

        /// <summary>
        /// Heals this warrior by some amount. Cannot heal over max HP
        /// </summary>
        /// <param name="amount">Amount of healing</param>
        public void Heal(int amount)
        {
            if (amount > 0)
            {
                hp = Math.Clamp(hp + amount, 1, MaxHP);
            }
        }

        /// <summary>
        /// Attacks selected warrior using stats of this warrior multiplied by damage modifier
        /// </summary>
        /// <param name="target">Targeted warrior</param>
        /// <param name="damageModifier">Multiplier for attacker's damage</param>
        /// <exception cref="ArgumentNullException"> Thrown if parameter was null</exception>
        public void Attack(Warrior target, float damageModifier)
        {
            if (target == null)
                throw new ArgumentNullException();

            if (IsAlive && target.IsAlive)
            {
                DealDamage(target, damageModifier, out int damageDone);

                if (Vampirism > 0)
                {
                    VampiricHeal(damageDone);
                }
            }
        }

        /// <summary>
        /// Attacks selected warrior using stats of this warrior
        /// </summary>
        /// <param name="target">Targeted warrior</param>
        /// <exception cref="ArgumentNullException"> Thrown if parameter was null</exception>
        public void Attack(Warrior target)
        {
            if (target == null)
                throw new ArgumentNullException();

            Attack(target, 1);
        }

        private void DealDamage(Warrior target, float damageModifier, out int damageDone)
        {
            damageDone = (int)(CalculateDamageToTarget(target) * damageModifier);
            target.hp -= damageDone;
        }

        private int CalculateDamageToTarget(Warrior target)
        {
            if (target == null)
                throw new ArgumentNullException();

            int result = Math.Clamp(Damage - target.Defence, 0, Damage);
            return result;
        }

        private void VampiricHeal(int damageDone)
        {
            Heal(damageDone * Vampirism / 100);
        }

        /// <summary>
        /// Displays stats of warrior via visualizer
        /// </summary>
        /// <param name="visualizer">Determines the way of displaying stats</param>
        public void ShowInfo(IVisualizer visualizer)
        {
            if (visualizer == null)
                throw new ArgumentNullException();

            visualizer.Show($"\t\t\t{Type}\nHP = {hp,-8} | Attack = {Damage,-9} | Vampirism = {Vampirism}%" +
                $"\nDefence = {Defence,-3} | Attack range = {AttackRange,-3} | Healing power = {HealingPower}\n");
        }

        public override string ToString()
        {
            if (this == null)
                return string.Empty;

            string result = Type.ToString();
            return result[0].ToString();
        }
    }
}
