using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.JobApi;
using Pictomancer.Data;
using test.JOB.依赖;

namespace Pictomancer.Pictomancer.Ability;

public class Ability_减色混合: ISlotResolver
{
    public int Check()
    {
        if (Core.Resolve<JobApi_Pictomancer>().能量<50 && !Core.Me.HasAura(PCTData.Buffs.免费反转)  )
        {
            return -1;
        }

        if (Core.Me.HasAura(PCTData.Buffs.长Buff))
        {
            return -2;
        }

        if (Core.Me.HasAura(PCTData.Buffs.黑豆buff))
        {
            return -3;
        }
        
        if (GCDHelper.GetGCDCooldown() < 600)
        {
            return -4;
        }

        if (Core.Me.Level < 60)
        {
            return -5;
        }
        if(!QT.QTGET("反转"))
        {
            return -10;
        }

        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(PCTData.SkillId.减色混合.GetSpell());
    }
}