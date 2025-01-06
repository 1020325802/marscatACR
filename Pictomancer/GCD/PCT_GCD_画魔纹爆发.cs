using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.JobApi;
using AEAssist.MemoryApi;
using Pictomancer.Data;
using test.JOB.依赖;
using test.依赖.Helper;

namespace Pictomancer.Pictomancer.GCD;

public class PCT_GCD_画魔纹爆发 : ISlotResolver
{
    //有没有画魔纹
    public int Check()
    {
        if ( Core.Me.HasAura(PCTData.Buffs.加速)) return 0;
        return -1;
    }
    
    public void Build(Slot slot)
    {
        var spell = GetSpell();
        slot.Add(spell);
    }
    private Spell GetSpell()
    {
        var 即刻buff = Core.Me.HasAura(AurasDefine.Swiftcast);
        //黑豆
        if (Core.Resolve<JobApi_Pictomancer>().豆子!=0 && Core.Me.HasAura(PCTData.Buffs.黑豆buff) && QT.QTGET("黑豆"))
        {
            return Helper.getAoeSpell(PCTData.SkillId.黑豆);
        }
        //天星快到时间
        if (Core.Me.HasMyAuraWithTimeleft(PCTData.Buffs.大招预备buff,10)&& QT.QTGET("天星") )
        {
            return Helper.getAoeSpell(PCTData.SkillId.天星棱光);
        }
        //123
        if (Core.Me.HasAura(PCTData.Buffs.长Buff) && Helper.可以读条bool() && Core.Me.GetAuraStack(PCTData.Buffs.加速) > 0)
        {
            var target = TargetHelper.GetMostCanTargetObjects(PCTData.SkillId.AOE短1,3);
            if (target != null)
            {
                if (Core.Me.HasAura(PCTData.Buffs.连击3buff)) return new Spell(PCTData.SkillId.AOE长3, target);
                if (Core.Me.HasAura(PCTData.Buffs.连击2buff)) return new Spell(PCTData.SkillId.AOE长2, target);
                return new Spell(PCTData.SkillId.AOE长1, target);
            }
            if (Core.Me.HasAura(PCTData.Buffs.连击3buff)) return PCTData.SkillId.长3.GetSpell();
            if (Core.Me.HasAura(PCTData.Buffs.连击2buff)) return PCTData.SkillId.长2.GetSpell();
            return PCTData.SkillId.长1.GetSpell();
        }
        //三锤
        if (Core.Me.HasAura(PCTData.Buffs.锤子预备) )
        {
            return Helper.getAoeSpell(PCTData.SkillId.重锤敲章);
        }
        //天星
        if (Core.Me.HasAura(PCTData.Buffs.大招预备buff)&& QT.QTGET("天星"))
        {
            return Helper.getAoeSpell(PCTData.SkillId.天星棱光);
        }
        //彩虹
        if (Core.Me.HasAura(PCTData.Buffs.彩虹预备)&& QT.QTGET("彩虹"))
        {
            return PCTData.SkillId.彩虹.GetSpell();
        }
        
        //没辙打白豆
        if (Core.Resolve<JobApi_Pictomancer>().豆子!=0 && QT.QTGET("白豆"))
        {
            return Helper.getAoeSpell(PCTData.SkillId.白豆);
        }
        if (Core.Me.HasAura(PCTData.Buffs.连击3buff)) return PCTData.SkillId.短3.GetSpell();
        if (Core.Me.HasAura(PCTData.Buffs.连击2buff)) return PCTData.SkillId.短2.GetSpell();
        return PCTData.SkillId.短1.GetSpell();
    }
}