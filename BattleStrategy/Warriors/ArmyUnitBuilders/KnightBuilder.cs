using System;
using System.Collections.Generic;
using System.Text;

namespace BattleStrategy.Warriors
{
    public class KnightBuilder : ArmyUnitBuilder
    {
        internal override void SetType()
        {
            result.Type = WarriorType.Knight;
        }

        internal override void SetMaxHP()
        {
            result.MaxHP = 50;
        }

        internal override void SetDamage()
        {
            result.Damage = 7;
        }
    }
}
