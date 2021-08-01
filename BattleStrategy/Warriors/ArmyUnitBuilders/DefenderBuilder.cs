using System;
using System.Collections.Generic;
using System.Text;

namespace BattleStrategy.Warriors
{
    public class DefenderBuilder : ArmyUnitBuilder
    {
        internal override void SetType()
        {
            result.Type = WarriorType.Defender;
        }

        internal override void SetMaxHP()
        {
            result.MaxHP = 60;
        }

        internal override void SetDamage()
        {
            result.Damage = 3;
        }

        internal override void SetDefence()
        {
            result.Defence = 2;
        }
    }
}
