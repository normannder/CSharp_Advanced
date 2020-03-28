using System;
using System.Collections.Generic;
using System.Text;
using StrategyGame.Warriors.Models;
using StrategyGame.Warriors.Interfaces;
using StrategyGame.Warriors.Abstractions;
using static ITEA_Collections.Common.Extensions;

namespace StrategyGame.Actions
{
    class CavalryAttack<T> : Battle<Knight, T> where T:  CombatUnit, IRangeUnit, new()
    {
        protected override int CountPoints(IEnumerable<CombatUnit> army)
        {
            int total = 0;
            int count = 0;
            foreach (var item in army)
            {
                count++;
                total += item.Health + (int)(item.Strength * (item.UnitType == CombatUnitType.Melee ? 2 : 1));
            }
            ToConsole($"Total army count: {count}", ConsoleColor.DarkYellow);
            ToConsole($"Total army strength: {total}", ConsoleColor.DarkYellow);
            return total;
        }
    }
}
