using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.JobApi;
using Pictomancer.Data;
using test.JOB.依赖;
using test.依赖.Helper;

namespace Pictomancer.Pictomancer.GCD;

public class PCT_GCD_白豆 : ISlotResolver
{
    public int Check()
    {
        if (Core.Resolve<JobApi_Pictomancer>().豆子==0)
        {
            return -1;
        }
        if(!QT.QTGET("白豆"))
        {
            return -10;
        }

        if (!Core.Me.IsMoving())
        {
            return -2;
        }
        

        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(Helper.getAoeSpell(PCTData.SkillId.白豆));
    }
    
}