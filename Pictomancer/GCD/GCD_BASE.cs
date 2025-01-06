using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using Pictomancer.Data;
using test.依赖.Helper;

namespace Pictomancer.Pictomancer.GCD;

public class GCD_BASE : ISlotResolver
{
    //正在动并且没有即刻buff
    public int Check()
    {
        return Helper.可以读条();
    }
    
    public void Build(Slot slot)
    {
        var spell = GetSpell();
        slot.Add(spell);
    }
    private Spell GetSpell()
    {
        //单体
        if (Core.Me.HasAura(PCTData.Buffs.长Buff))
        {
            if (Core.Me.HasAura(PCTData.Buffs.连击3buff)) return PCTData.SkillId.长3.GetSpell();
            if (Core.Me.HasAura(PCTData.Buffs.连击2buff)) return PCTData.SkillId.长2.GetSpell();
            return PCTData.SkillId.长1.GetSpell();
        }
        
        if (Core.Me.HasAura(PCTData.Buffs.连击3buff)) return PCTData.SkillId.短3.GetSpell();
        if (Core.Me.HasAura(PCTData.Buffs.连击2buff)) return PCTData.SkillId.短2.GetSpell();
        return PCTData.SkillId.短1.GetSpell();
        
    }
}