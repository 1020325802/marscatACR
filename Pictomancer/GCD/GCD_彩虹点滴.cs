using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using Pictomancer.Data;
using test.JOB.依赖;
using test.依赖.Helper;

namespace Pictomancer.Pictomancer.GCD;

public class GCD_彩虹点滴 : ISlotResolver
{
    public int Check()
    {
        if (!Core.Me.HasAura(PCTData.Buffs.彩虹预备))
        {
            return -1;
        }
        if(!QT.QTGET("彩虹"))
        {
            return -10;
        }
        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(PCTData.SkillId.彩虹.GetChangeSpell());
    }
    
}