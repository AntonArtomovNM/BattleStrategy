using System;
using System.Collections.Generic;
using System.Text;
using BattleStrategy.Interfaces;

namespace BattleStrategy.Warriors
{
    public abstract class ArmyUnitBuilder : IBuilder<Warrior>
    {
        protected Warrior result;

        public void Reset()
        {
            result = new Warrior();
        }

        internal abstract void SetType();
        internal abstract void SetMaxHP();
        internal abstract void SetDamage();

        internal virtual void SetAttackRange()
        {
            result.AttackRange = 1;
        }

        internal virtual void SetDefence()
        {
            result.Defence = 0;
        }

        internal virtual void SetVampirism()
        {
            result.Vampirism = 0;
        }

        internal virtual void SetHealingPower()
        {
            result.HealingPower = 0;
        }

        internal Warrior GetResult()
        {
            return result;
        }

        void IBuilder<Warrior>.Reset()
        {
            Reset();
        }

        Warrior IBuilder<Warrior>.GetResult()
        {
            return GetResult();
        }
    }
}
