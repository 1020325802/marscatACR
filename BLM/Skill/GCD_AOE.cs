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

public class GCD_AOE : ISlotResolver
{
    public int Check()
    {
        // 获取最佳目标
        var AOE目标 = TargetHelper.GetMostCanTargetObjects(PCTData.SkillId.AOE短1, 3);
        if (QT.QTGET("日随模式") && AOE目标!= null)
        {
            return 1;
        }
        uint 即刻 = 7561;
        uint 三连 = 7421;
        uint 魔泉 = 158;
        var spell1 = 不动();
        var 天语状态 = Core.Resolve<JobApi_BlackMage>().IsEnochianActive;
        return -1;
    }

    public void Build(Slot slot)
    {
        var 通晓层数 = Core.Resolve<JobApi_BlackMage>().PolyglotStacks;
        var 天语时间 = Core.Resolve<JobApi_BlackMage>().EnochianTimer;
        var spell1 = 不动();
        if (spell1 != null)
        {
            slot.Add(spell1);
        }

    }

    private Spell 不动()
    {
        var AOE目标 = TargetHelper.GetMostCanTargetObjects(PCTData.SkillId.AOE短1, 3);
        var lv = Core.Me.Level;
        var 通晓层数 = BLMBuff.通晓层数;
        var 冰火时间 = BLMBuff.冰火时间;
        var 冰针数 = BLMBuff.冰针数;
        var 天语时间 = BLMBuff.天语时间;
        var 悖论激活 = BLMBuff.悖论激活;
        var 冰状态 = BLMBuff.冰状态;
        var 火状态 = BLMBuff.火状态;
        var 天语状态 = BLMBuff.天语状态;
        var MP = BLMBuff.MP;
        var 火苗 = BLMBuff.火苗状态;
        var 通晓溢出 = BLMBuff.通晓溢出();
        var 详述可用 = BLMBuff.详述可用();

        uint 火3 = 152;
        uint 火4 = 3577;
        uint 冰3 = 154;
        uint 冰4 = 3576;
        uint 雷1 = 144;
        uint 星灵移位 = 149;
        uint 异言 = 16507;
        uint 绝望 = 16505;
        uint 悖论 = 25797;
        uint 耀星 = 36989;
        uint 即刻 = 7561;
        uint 三连 = 7421;
        uint 魔泉 = 158;
        uint 核爆 = 162;
        uint 高烈炎AOE = 25794;
        uint 雷2AOE = 7447;
        uint 火2AOE = 147;
        uint 冰2AOE = 142;
        uint 玄冰 = 159;
        if (AOE目标 != null)
        {
            if (!Core.Me.IsMoving())
            {
                if (火状态)
                {
                    if (冰火时间 > 7000 && 雷2AOE.GetChangeSpell().Id.IsReady() &&
                        TTKHelper.IsTargetTTK(Core.Me.GetCurrTarget(), 15, true))
                    {
                        return 雷2AOE.getAoeSpell();
                    }
                    if (耀星.CanSpell())
                    {
                        return 耀星.getAoeSpell();
                    }

                    if (核爆.CanSpell())
                    {
                        return 核爆.getAoeSpell();
                    }

                    if (火2AOE.CanSpell())
                    {
                        return 火2AOE.getAoeSpell();
                    }

                    if (冰2AOE.CanSpell())
                    {
                        return 冰2AOE.getAoeSpell();
                    }
                }

                if (冰状态)
                {
                    
                }
            }
            
        }

        

        return null;
    }
}