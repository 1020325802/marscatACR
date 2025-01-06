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

namespace Pictomancer.Pictomancer.Ability;

public class Ability_动物构想: ISlotResolver
{
    public int Check()
    {
        var 风景构想冷却时间 = PCTData.SkillId.风景构想.GetChangeSpell().Cooldown.TotalSeconds;
        if (!Core.Resolve<JobApi_Pictomancer>().生物画)
        {
            return -1;
        }

        if (PCTData.SkillId.动物构想.GetChangeSpell().Charges<1)
        {
            return -2;
        }
        //目标是小怪，并且在移动中，而且没溢出
        if(!TargetHelper.IsBoss(Core.Me.GetCurrTarget()) && Core.Me.IsMoving() && PCTData.SkillId.动物构想.GetChangeSpell().Charges < PCTData.SkillId.动物构想.GetChangeSpell().MaxCharges)
        {
            return -4;
        }
        if(!QT.QTGET("动物构想"))
        {
            return -10;
        }
        //如果扣掉一个动物，在下个动物转好时画魔纹还能有30秒冷却，就打出去,如果画魔纹太近，留出再打一个画的时间
        if ((PCTData.SkillId.动物构想.GetChangeSpell().Charges - 1) * 40 > 风景构想冷却时间 +15 || 风景构想冷却时间 > 40)
        {
            return 1;
        }
        //等级太低随便打
        if (PCTData.SkillId.动物构想.GetChangeSpell().MaxCharges == 2)
        {
            return 2;
        }
   

        return -99;
    }
    
    private Spell GetSpell()
    {
        if (Helper.getAoeSpell(PCTData.SkillId.动物构想) != null)
        {
            return Helper.getAoeSpell(PCTData.SkillId.动物构想);
        }

        return PCTData.SkillId.动物构想.GetChangeSpell();
    }

    public void Build(Slot slot)
    {
        var spell = GetSpell();
        slot.Add(spell);
    }
}