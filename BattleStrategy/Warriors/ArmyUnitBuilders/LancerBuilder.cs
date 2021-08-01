using System;
using System.Collections.Generic;
using System.Text;

namespace BattleStrategy.Warriors
{
    public class LancerBuilder : ArmyUnitBuilder
    {
        internal override void SetType()
        {
            result.Type = WarriorType.Lancer;
        }

        internal override void SetDamage()
        {
            result.Damage = 6;
        }

        internal override void SetMaxHP()
        {
            result.MaxHP = 50;
        }

        internal override void SetAttackRange()
        {
            result.AttackRange = 2;
        }
    }
}
