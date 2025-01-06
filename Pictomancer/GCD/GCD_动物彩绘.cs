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

public class GCD_动物彩绘 : ISlotResolver
{
    public int Check()
    {
        if (!Helper.可以读条bool()) return -1;
        if (Core.Resolve<JobApi_Pictomancer>().生物画)
        {
            return -2;
        }
        if (PCTData.SkillId.动物彩绘.GetChangeSpell().Id == PCTData.SkillId.动物彩绘)
        {
            return -3;
        }
        if(!QT.QTGET("画动物"))
        {
            return -10;
        }
        //目标是小怪，差30秒溢出时画锤子
        if (!TargetHelper.IsBoss(Core.Me.GetCurrTarget()) && PCTData.SkillId.动物构想.GetChangeSpell().MaxCharges - PCTData.SkillId.动物构想.GetSpell().Charges < 1)
        {
            return 1;
        }
        //目标是boss，有半个动物充能就画
        if (TargetHelper.IsBoss(Core.Me.GetCurrTarget())  && PCTData.SkillId.动物构想.GetChangeSpell().Charges > 0.5 )
        {
            return 2;
        }
        
        if(!QT.QTGET("画动物"))
        {
            return -10;
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
        return PCTData.SkillId.动物彩绘.GetChangeSpell();
    }
}