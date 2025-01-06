using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.JobApi;
using AEAssist.MemoryApi;
using Pictomancer.Data;
using test.JOB.依赖;
using Pictomancer.Data;
using test.依赖.Helper;

namespace Pictomancer.Pictomancer.Ability;

public class Ability_武器构想: ISlotResolver
{
    public int Check()
    {
        var 风景构想冷却时间 = PCTData.SkillId.风景构想.GetChangeSpell().Cooldown.TotalSeconds;
        if (!Core.Resolve<JobApi_Pictomancer>().武器画)
        {
            return -2;
        }

        if (PCTData.SkillId.武器构想.GetChangeSpell().Charges<1)
        {
            return -4;
        }
        /*//用一次锤之后赶不上爆发
        if (PCTData.SkillId.风景构想.GetChangeSpell().Cooldown.TotalSeconds !=0 &&  !Core.Me.HasAura(PCTData.Buffs.加速) && PCTData.SkillId.风景构想.GetChangeSpell().Cooldown.TotalSeconds < 60 && PCTData.SkillId.风景构想.GetChangeSpell().Cooldown.TotalSeconds > (锤预备Spell.Charges-1) * 60 )
        {
            return -5;
        }*/
        //不是boss，15秒内打死，不锤
        if(!TargetHelper.IsBoss(Core.Me.GetCurrTarget()) && TTKHelper.IsTargetTTK(Core.Me.GetCurrTarget(),15,true))
        {
            return -6;
        }
        if(!QT.QTGET("锤子"))
        {
            return -10;
        }
        //如果扣掉一个动物，在下个动物转好时画魔纹还能有15秒冷却，就打出去,如果画魔纹太近，留出再打一个画的时间
        if ((PCTData.SkillId.武器构想.GetChangeSpell().Charges - 1) * 60 > 风景构想冷却时间 +15  || 风景构想冷却时间 > 60  )
        {
            return 1;
        }
        //86以下，好了就用
        if (PCTData.SkillId.武器构想.GetChangeSpell().MaxCharges == 1)
        {
            return 2;
        }
        return -99;
    }

    public void Build(Slot slot)
    {
        slot.Add(PCTData.SkillId.武器构想.GetChangeSpell());
    }
}