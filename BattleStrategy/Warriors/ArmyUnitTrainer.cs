using System;
using System.Collections.Generic;
using System.Text;
using BattleStrategy.Interfaces;

namespace BattleStrategy.Warriors
{
    public class ArmyUnitTrainer : ICreator<Warrior, ArmyUnitBuilder>
    {
        /// <summary>
        /// Trains a certain type of warrior, classified by builder
        /// </summary>
        /// <param name="builder">Concrete warrior builder</param>
        /// <returns>Warrior created with builder</returns>
        public Warrior Create(ArmyUnitBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException();

            builder.Reset();
            builder.SetType();
            builder.SetMaxHP();
            builder.SetDamage();
            builder.SetAttackRange();
            builder.SetDefence();
            builder.SetVampirism();
            builder.SetHealingPower();

            return builder.GetResult();
        }
    }
}
