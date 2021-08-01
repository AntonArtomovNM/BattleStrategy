using System;
using System.Collections.Generic;
using System.Text;

namespace BattleStrategy.Warriors
{
    public class WarriorBuilder : ArmyUnitBuilder
    {
        internal override void SetType()
        {
            result.Type = WarriorType.Warrior;
        }

        internal override void SetMaxHP()
        {
            result.MaxHP = 50;
        }

        internal override void SetDamage()
        {
            result.Damage = 5;
        }
    }
}
