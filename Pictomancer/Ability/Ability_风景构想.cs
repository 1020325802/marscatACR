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

public class Ability_风景构想: ISlotResolver
{
    public int Check()
    {
        if (!Core.Resolve<JobApi_Pictomancer>().风景画)
        {
            return -1;
        }

        if (!Core.Me.InCombat())
        {
            return -2;
        }
        if (Core.Me.IsMoving()) return -3;

        if (PCTData.SkillId.风景构想.GetChangeSpell().Charges<1)
        {
            return -4;
        }
        //不是boss，15秒内打死，周围没有其他敌人，就不开画魔纹
        if(!TargetHelper.IsBoss(Core.Me.GetCurrTarget()) && TTKHelper.IsTargetTTK(Core.Me.GetCurrTarget(),15,true))
        {
            return -5;
        }
        if(!QT.QTGET("画魔纹"))
        {
            return -10;
        }

        return 0;
    }
    private Spell GetSpell()
    {
        var spell = new Spell(PCTData.SkillId.风景构想,SpellTargetType.Self);
        return spell;
    }

    public void Build(Slot slot)
    {
        var spell = GetSpell();
        slot.Add(spell);
    }
}