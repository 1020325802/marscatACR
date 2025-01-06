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

public class PCT_GCD_黑豆 : ISlotResolver
{
    public int Check()
    {
        if (!Core.Me.HasAura(PCTData.Buffs.黑豆buff))
        {
            return -2;
        }
        if (Core.Resolve<JobApi_Pictomancer>().豆子==0)
        {
            return -3;
        }
        if(!QT.QTGET("黑豆"))
        {
            return -4;
        }
        if (Core.Me.IsMoving())
        {
            return 0;
        }
        if (Core.Resolve<JobApi_Pictomancer>().能量>49)
        {
            return 1;
        }
        
        return -1;
    }
    
    private Spell GetSpell()
    {
        return Helper.getAoeSpell(PCTData.SkillId.黑豆);
    }

    public void Build(Slot slot)
    {
        var spell = GetSpell();
        slot.Add(spell);
    }
    
}