using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.JobApi;
using AEAssist.MemoryApi;
using BLM.依赖;
using Pictomancer.Data;
using test.依赖.Helper;

namespace Pictomancer.BLM.Skill;

public class Ability : ISlotResolver
{
    public int Check()
    {
        uint 魔泉 = 158;
        uint 详述 = 25796;
        uint 即刻 = 7561;
        uint 三连 = 7421;
        uint 耀星 = 36989;
        var 天语状态 = Core.Resolve<JobApi_BlackMage>().IsEnochianActive;
        var 火状态 = Core.Resolve<JobApi_BlackMage>().InAstralFire;
        var MP = Core.Me.CurrentMp;
        var 通晓层数 = Core.Resolve<JobApi_BlackMage>().PolyglotStacks;
        var 详述可用 = BLMBuff.详述可用();
        var 悖论激活 = Core.Resolve<JobApi_BlackMage>().IsParadoxActive;
        var 火苗 = Core.Me.HasAura(BLMBuff.火苗);
        if ( 天语状态 && !Helper.有三连即刻buff() && !火苗 && !悖论激活 && 通晓层数 < 1 && Core.Me.IsMoving() && (即刻.IsReady() || 三连.IsReady() || 火状态)
            || 火状态 && MP <= 1200 && !Helper.有三连即刻buff() && 魔泉.IsReady() && ((!耀星.IsReady() && 即刻.IsReady()) || 三连.GetSpell().Charges >= 1)
            || 火状态 && MP == 0 && !火苗 && 魔泉.IsReady()
            || 详述可用 
            || BLMBuff.冰层数 == 2 && MP <800)
        {
            return 1;
        }

        return -1;
    }
    private Spell GetSpell()
    {
        var 通晓层数 = BLMBuff.通晓层数;
        var 悖论激活 = BLMBuff.悖论激活;
        var 火状态 = BLMBuff.火状态;
        var 天语状态 = BLMBuff.天语状态;
        var MP = BLMBuff.MP;
        var 火苗 = BLMBuff.火苗状态;
        var 详述可用 = BLMBuff.详述可用();
        
        uint 详述 = 25796;
        uint 星灵移位 = 149;
        uint 耀星 = 36989;
        uint 即刻 = 7561;
        uint 三连 = 7421;
        uint 魔泉 = 158;
        //当全部资源都打完，并且还在移动的时候，用三连或者即刻
        if (天语状态 && !Helper.有三连即刻buff() && !火苗 && !悖论激活 && 通晓层数 < 1 && Core.Me.IsMoving() && (即刻.IsReady() || 三连.IsReady() || 火状态))
        {
            if (即刻.IsReady())
            {
                return 即刻.GetChangeSpell();
            }

            if (!即刻.IsReady() && 三连.IsReady())
            {
                return 三连.GetChangeSpell();
            }

            if (火状态)
            {
                return 魔泉.GetChangeSpell();
            }
        }
        
        if (火状态 && MP <= 1200 && !Helper.有三连即刻buff() && 魔泉.IsReady())
        {
            if (!耀星.IsReady() && 即刻.IsReady())
            {
                return 即刻.GetChangeSpell();
            }
            
            if (三连.GetSpell().Charges >= 1)
            {
                return 三连.GetChangeSpell();
            }
        }
        if (火状态 && MP == 0 && !火苗)
        {
            if (魔泉.IsReady()) return 魔泉.GetChangeSpell();
        }

        if (详述可用)
        {
            if (详述.IsReady()) return 详述.GetChangeSpell();
        }

        return null;
    }

    public void Build(Slot slot)
    {
        var spell = GetSpell();
        slot.Add(spell);
    }
}