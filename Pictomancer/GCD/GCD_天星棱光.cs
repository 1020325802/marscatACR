using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using Pictomancer.Data;
using test.JOB.依赖;
using test.依赖.Helper;

namespace Pictomancer.Pictomancer.GCD;

public class GCD_天星棱光 : ISlotResolver
{
    public int Check()
    {
        if (!Core.Me.HasAura(PCTData.Buffs.大招预备buff))
        {
            return -1;
        }
        if(!QT.QTGET("天星"))
        {
            return -10;
        }

        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(Helper.getAoeSpell(PCTData.SkillId.天星棱光));
    }
    
}