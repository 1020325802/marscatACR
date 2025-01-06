using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using Pictomancer.Data;
using test.依赖.Helper;

namespace Pictomancer.Pictomancer.GCD;

public class GCD_BASEAOE : ISlotResolver
{
    //正在动并且没有即刻buff
    public int Check()
    {
        if (!Helper.可以读条bool())
        {
            return -1;
        }
        var target = TargetHelper.GetMostCanTargetObjects(PCTData.SkillId.AOE短1);
        var aoeCount = TargetHelper.GetNearbyEnemyCount(target, 25, 5);
        if (aoeCount < 3)
        {
            return -2;
        }

        if (Core.Me.Level < 25)
        {
            return -3;
        }
        return 0;
    }
    
    public void Build(Slot slot)
    {
        var spell = GetSpell();
        slot.Add(spell);
    }
    private Spell GetSpell()
    {
        // 获取最佳目标
        var target = TargetHelper.GetMostCanTargetObjects(PCTData.SkillId.AOE短1);
        if (target != null && target.IsValid())
        {
            // 检查目标周围敌人的数量
            var aoeCount = TargetHelper.GetNearbyEnemyCount(target, 25, 5);
            if (aoeCount >= 3)
            {
                if (Core.Me.HasAura(PCTData.Buffs.长Buff)) {
                    if (Core.Me.HasAura(PCTData.Buffs.连击3buff)) return new Spell(PCTData.SkillId.AOE长3, target);
                    if (Core.Me.HasAura(PCTData.Buffs.连击2buff)) return new Spell(PCTData.SkillId.AOE长2, target);
                    return new Spell(PCTData.SkillId.AOE长1, target);
                }
                if (Core.Me.HasAura(PCTData.Buffs.连击3buff) && Core.Me.Level > 44) return new Spell(PCTData.SkillId.AOE短3, target);
                if (Core.Me.HasAura(PCTData.Buffs.连击2buff) && Core.Me.Level > 34) return new Spell(PCTData.SkillId.AOE短2, target);
            }
        }

        // 默认返回短 AoE 技能
        return new Spell(PCTData.SkillId.AOE短1, target);

    }
    
}