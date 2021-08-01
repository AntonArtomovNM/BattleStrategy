using System;
using System.Collections.Generic;
using System.Text;

namespace BattleStrategy.Warriors
{
    public class HealerBuilder : ArmyUnitBuilder
    {
        internal override void SetType()
        {
            result.Type = WarriorType.Healer;
        }

        internal override void SetDamage()
        {
            result.Damage = 0;
        }

        internal override void SetMaxHP()
        {
            result.MaxHP = 60;
        }

        internal override void SetHealingPower()
        {
            result.HealingPower = 2;
        }
    }
}
