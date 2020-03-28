using System;
using System.Collections.Generic;
using System.Text;
using StrategyGame.Warriors.Abstractions;
using StrategyGame.Base.Interfaces;

namespace StrategyGame.Warriors.Models
{
    class Knight : CombatUnit
    {
        protected CombatUnit(int hp, int strength, CombatUnitType unitType)
        {
            Health = hp;
            Strength = strength;
            UnitType = unitType;
        }
        public void MeleeAttack(IUnit unit)
        {

        }
    }
}
