using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.JobApi;
using AEAssist.MemoryApi;
using Pictomancer.Data;
using Pictomancer.Pictomancer.Ability;
using test.JOB.依赖;
using test.依赖.Helper;

namespace Pictomancer.Pictomancer.GCD;

public class GCD_武器彩绘 : ISlotResolver
{
    public int Check()
    {
        if (!Helper.可以读条bool()) return -1;
        
        if (Core.Resolve<JobApi_Pictomancer>().武器画)
        {
            return -2;
        }
        if (PCTData.SkillId.武器彩绘.GetChangeSpell().Id == PCTData.SkillId.武器彩绘)
        {
            return -3;
        }
        if (Core.Me.HasAura(PCTData.Buffs.锤子预备))
        {
            return -4;
        }
        if(!QT.QTGET("画武器"))
        {
            return -10;
        }
        
        //目标是小怪，差30秒溢出时画锤子
        if (!TargetHelper.IsBoss(Core.Me.GetCurrTarget()) && PCTData.SkillId.武器构想.GetChangeSpell().MaxCharges - PCTData.SkillId.武器构想.GetSpell().Charges < 0.5)
        {
            return 1;
        }
        
        //目标是boss，有半个锤子冲能就画
        if (TargetHelper.IsBoss(Core.Me.GetCurrTarget()) && PCTData.SkillId.武器构想.GetSpell().Charges > 0.5)
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
        return PCTData.SkillId.武器彩绘.GetChangeSpell();
    }
}