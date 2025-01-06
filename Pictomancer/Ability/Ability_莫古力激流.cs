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

namespace Pictomancer.Pictomancer.Ability;

public class Ability_莫古力激流: ISlotResolver
{
    public int Check()
    {
        if (!Core.Resolve<JobApi_Pictomancer>().莫古准备)
        {
            return -1;
        }
        
        if(!QT.QTGET("莫古炮"))
        {
            return -10;
        }

        if (PCTData.SkillId.星空构想.GetChangeSpell().Cooldown.TotalSeconds < 50 && !Core.Me.HasAura(PCTData.Buffs.团辅))
        {
            return -2;
        }

        if (PCTData.SkillId.莫古力激流.IsReady())
        {
            return 0;
        }

        return -4;
    }
    private Spell GetSpell()
    {
        
        return PCTData.SkillId.莫古力激流.GetSpell();
    }

    public void Build(Slot slot)
    {
        var spell = GetSpell();
        slot.Add(spell);
        
    }
}