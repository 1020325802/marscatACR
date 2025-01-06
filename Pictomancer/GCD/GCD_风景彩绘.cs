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

public class GCD_风景彩绘 : ISlotResolver
{
    public int Check()
    {
        if (!Helper.可以读条bool()) return -1;
        
        if (Core.Resolve<JobApi_Pictomancer>().风景画)
        {
            return -2;
        }
        if (Core.Resolve<MemApiSpell>().CheckActionChange(PCTData.SkillId.风景彩绘) == PCTData.SkillId.风景彩绘)
        {
            return -3;
        }
        //非BOSS不画
        if (!TargetHelper.IsBoss(Core.Me.GetCurrTarget()))
        {
            return -4;
        }
        if (Core.Me.Level < 70)
        {
            return -5;
        }
        if(!QT.QTGET("画风景"))
        {
            return -10;
        }
        //是boss，差30秒转好，画
        if (TargetHelper.IsBoss(Core.Me.GetCurrTarget()) && PCTData.SkillId.风景构想.GetChangeSpell().Charges>0.7)
        {
            return 1;
        }
        
       
        return -1;
    }

    public void Build(Slot slot)
    {
        var spell = GetSpell();
        slot.Add(spell);
    }

    private Spell GetSpell()
    {
        return PCTData.SkillId.风景彩绘.GetChangeSpell();
    }
}