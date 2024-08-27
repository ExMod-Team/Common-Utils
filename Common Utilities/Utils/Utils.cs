namespace Common_Utilities.Utils;

using System.Linq;
using ConfigObjects;
using System.Collections.Generic;

public static class Utils
{
    public static double RollChance(IEnumerable<IChanceObject> scp914EffectChances)
    {
        double rolledChance;
        
        if (Plugin.Instance.Config.AdditiveProbabilities)
            rolledChance = Plugin.Random.NextDouble() * scp914EffectChances.Sum(x => x.Chance);
        else
            rolledChance = Plugin.Random.NextDouble() * 100;
        
        return rolledChance;
    }
}