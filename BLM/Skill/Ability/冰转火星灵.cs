using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.JobApi;
using Pictomancer.Data;
using test.依赖.Helper;

namespace Pictomancer.BLM.Skill;

public class 冰转火星灵 : ISlotResolver
{
    public int Check()
    {
        var 冰针数 = BLMBuff.冰针数;
        var 悖论激活 = Core.Resolve<JobApi_BlackMage>().IsParadoxActive;
        var 火苗 = Core.Me.HasAura(BLMBuff.火苗);
        if (BLMBuff.冰状态 && 火苗 && 冰针数== 3 && !悖论激活 )
        {
            return 1;
        }

        return -1;
    }
    private Spell GetSpell()
    {
        uint 星灵移位 = 149;
        return 星灵移位.GetChangeSpell();
    }

    public void Build(Slot slot)
    {
        var spell = GetSpell();
        slot.Add(spell);
    }
}