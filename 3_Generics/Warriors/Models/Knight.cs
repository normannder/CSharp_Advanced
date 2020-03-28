using System;
using System.Collections.Generic;
using System.Text;
using StrategyGame.Base.Interfaces;
using StrategyGame.Warriors.Abstractions;
using StrategyGame.Warriors.Interfaces;

namespace StrategyGame.Warriors.Models
{
    public sealed class Knight : CombatUnit
    {
        public Knight() : base(20, 15, CombatUnitType.Melee)
        {
        }

        public override void MeleeAttack(IUnit enemy)
        {
            enemy.Health -= this.Strength;
        }


        public override string Unnamed() => "For the King!";

    }
}
