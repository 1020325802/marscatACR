using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using BLM.依赖;
using Pictomancer.Data;
using test.依赖.Helper;

namespace Pictomancer.BLM.Skill;

public class 即刻耀星 : ISlotResolver
{
    public int Check()
    {
        uint 即刻 = 7561;
        uint 耀星 = 36989;
        if(!QT.QTGET("即刻耀星"))
        {
            return -10;
        }
        if (即刻.IsReady() && 耀星.CanSpell())
        {
            return 1;
        }
        return -1;
    }

    public void Build(Slot slot)
    {
        uint 即刻 = 7561;
        uint 耀星 = 36989;
        slot.Add(即刻.GetChangeSpell());
        slot.Add(耀星.GetChangeSpell());
    }
}