using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using Pictomancer.Data;
using test.依赖.Helper;

namespace Pictomancer.BLM.Skill;

public class 详述 : ISlotResolver
{
    public int Check()
    {
        var 详述可用 = BLMBuff.详述可用();
        if (详述可用)
        {
            return 1;
        }
        return -1;
    }

    private Spell GetSpell()
    {
        uint 详述 = 25796;
        if (详述.IsReady()) return 详述.GetChangeSpell();
        return null;
    }

    public void Build(Slot slot)
    {
        var spell = GetSpell();
        slot.Add(spell);
    }
}