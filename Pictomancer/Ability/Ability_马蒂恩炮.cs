using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.JobApi;
using AEAssist.MemoryApi;
using Pictomancer.Data;
using test.JOB.依赖;
using test.依赖.Helper;

namespace Pictomancer.Pictomancer.Ability;

public class PCT_Ability_马丁炮: ISlotResolver
{
    public int Check()
    {
        if (!Core.Resolve<JobApi_Pictomancer>().蔬菜准备 )
        {
            return -1;
        }
        if (GCDHelper.GetGCDCooldown() < 600)
        {
            return -2;
        }
        if (!Core.Resolve<MemApiSpell>().CheckActionChange(PCTData.SkillId.莫古力激流).GetSpell().Id.IsReady())
        {
            return -3;
        }
        if (PCTData.SkillId.星空构想.GetChangeSpell().Cooldown.TotalSeconds < 50 && !Core.Me.HasAura(PCTData.Buffs.团辅))
        {
            return -2;
        }
        if(!QT.QTGET("马丁炮"))
        {
            return -10;
        }

        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(PCTData.SkillId.马蒂恩惩罚.GetSpell());
        
    }
}