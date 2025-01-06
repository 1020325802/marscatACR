using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using Pictomancer.Data;
using test.JOB.依赖;
using test.依赖.Helper;

namespace Pictomancer.Pictomancer.GCD;

public class PCT_GCD_锤3连 : ISlotResolver
{
    public int Check()
    {
        if (!Core.Me.HasAura(PCTData.Buffs.锤子预备))
        {
            return -1;
        }
        if(!QT.QTGET("锤子"))
        {
            return -2;
        }

        if (Core.Me.IsMoving())
        {
            return 1;
        }

        if (Core.Me.HasMyAuraWithTimeleft(PCTData.Buffs.锤子预备, 10))
        {
            return 0;
        }

        return -1;
    }

    private Spell GetSpell()
    {
        return Helper.getAoeSpell(PCTData.SkillId.重锤敲章);
    }

public void Build(Slot slot)
    {
        var spell = GetSpell();
        slot.Add(spell);
    }
    
}