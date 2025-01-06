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

namespace BLM.Skill;

public class 雷dot : ISlotResolver
{
    public int Check()
    {
     
        if (Helper.可以打雷())
        {
            return 1;
        }

        return -1;
    }

    public void Build(Slot slot)
    {
        uint 雷1 = 144;
        slot.Add(雷1.GetChangeSpell()) ;
    }
    
}