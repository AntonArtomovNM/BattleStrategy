using System;
using System.Collections.Generic;
using System.Text;

namespace BattleStrategy.Warriors
{
    public class VampireBuilder : ArmyUnitBuilder
    {
        internal override void SetType()
        {
            result.Type = WarriorType.Vampire;
        }

        internal override void SetMaxHP()
        {
            result.MaxHP = 40;
        }

        internal override void SetDamage()
        {
            result.Damage = 4;
        }

        internal override void SetVampirism()
        {
            result.Vampirism = 50;
        }
    }
}
