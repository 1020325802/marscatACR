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

public class GCD : ISlotResolver
{
    public int Check()
    {
        uint 即刻 = 7561;
        uint 三连 = 7421;
        uint 魔泉 = 158;
        var spell1 = 不动();
        var spell2 = 动();
        var 天语状态 = Core.Resolve<JobApi_BlackMage>().IsEnochianActive;
        var 战斗时间 = AI.Instance.BattleData.CurrBattleTimeInMs;
        if (spell1 == null && spell2 == null && 天语状态 && !即刻.IsReady() && !魔泉.IsReady() && !三连.IsReady())
        {
            Core.Resolve<MemApiChatMessage>().Toast2("别跑了没瞬发了", 1, 500);
            return -1;
        }

        if (BLMSkill.黑魔纹.GetChangeSpell().Cooldown.TotalSeconds < 5 &&
            BLMSkill.黑魔纹.GetChangeSpell().Cooldown.TotalSeconds != 0 && 战斗时间 > 30000)
        {
            Core.Resolve<MemApiChatMessage>().Toast2("黑魔纹马上转好", 1, 500);
        }

        return 1;
    }

    public void Build(Slot slot)
    {
        var 天语状态 = Core.Resolve<JobApi_BlackMage>().IsEnochianActive;
        uint 崩溃 = 156;
        var spell1 = 不动();
        var spell2 = 动();
        if (spell1 != null)
        {
            slot.Add(new Spell(spell1.Id, Core.Me.GetCurrTarget) { WaitServerAcq = false });
        }
        if (spell2 != null)
        {
            slot.Add(new Spell(spell2.Id, Core.Me.GetCurrTarget) { WaitServerAcq = false });
        }
        
        if (spell1 == null && spell2 == null)
        {
            if (!Core.Me.IsMoving())
            {
                slot.Add(BLMSkill.冰3.GetChangeSpell()) ;
            }

            if (Core.Me.IsMoving())
            {
                slot.Add(崩溃.GetChangeSpell());
            }
        }
        
    }

    private Spell 不动()
    {
        var 通晓层数 = BLMBuff.通晓层数;
        var 冰火时间 = BLMBuff.冰火时间;
        var 冰针数 = BLMBuff.冰针数;
        var 悖论激活 = BLMBuff.悖论激活;
        var 冰状态 = BLMBuff.冰状态;
        var 火状态 = BLMBuff.火状态;
        var 天语状态 = BLMBuff.天语状态;
        var MP = BLMBuff.MP;
        var 火苗 = BLMBuff.火苗状态;
        var 通晓溢出 = BLMBuff.通晓溢出();

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

        if (!Core.Me.IsMoving())
        {
            if (火状态)
            {
                if (冰火时间 > 5000)
                {
                    if (通晓溢出) return 异言.GetChangeSpell();
                }

                if (Helper.可以打雷())
                {
                    return BLMSkill.雷1.GetChangeSpell();
                }

                if (QT.QTGET("骗悖论"))
                {
                    //骗悖论
                    if (MP == 1200 && 耀星.IsReady() && 火苗 && 魔泉.IsReady())
                    {
                        if (!Helper.有三连即刻buff() && 绝望.CanSpell())
                        {
                            return 绝望.GetChangeSpell();
                        }

                        if (Helper.有三连即刻buff())
                        {
                            return 绝望.GetChangeSpell();
                        }

                        if (!Helper.有三连即刻buff() && 三连.GetSpell().Charges == 2 && 通晓层数 >= 1)
                        {
                            return 异言.GetChangeSpell();
                        }
                    }
                }

                if (MP == 1200 && !耀星.IsReady() && !火苗 && 魔泉.IsReady())
                {
                    if (Helper.有三连即刻buff())
                    {
                        return 绝望.GetChangeSpell();
                    }

                    if (!Helper.有三连即刻buff() && 三连.GetSpell().Charges == 2 && 通晓层数 >= 1)
                    {
                        return 异言.GetChangeSpell();
                    }
                }

                if (!Helper.有三连即刻buff() && !火苗 && !悖论激活 && 绝望.IsReady() && 冰火时间 < 6000)
                {
                    if (绝望.CanSpell()) return 绝望.GetChangeSpell();
                }

                if (耀星.打了不断() && 耀星.IsReady()) return 耀星.GetChangeSpell();
                if (MP >= 2400 && 火4.CanSpell()) return 火4.GetChangeSpell();
                if (MP < 2400 && 绝望.CanSpell()) return 绝望.GetChangeSpell();
                if (火苗) return 火3.GetChangeSpell();
                if (悖论激活) return 悖论.GetChangeSpell();
                if (绝望.CanSpell()) return 绝望.GetChangeSpell();
                if (冰3.CanSpell()) return 冰3.GetChangeSpell();
            }

            if (冰状态)
            {
                if (Helper.可以打雷())
                {
                    return BLMSkill.雷1.GetChangeSpell();
                }

                if (QT.QTGET("骗悖论"))
                {
                    //骗悖论
                    if (BLMBuff.冰层数 < 3)
                    {
                        if (悖论激活) return 悖论.GetChangeSpell();
                        if (异言.IsReady()) return 异言.GetChangeSpell();
                    }
                }

                if (冰针数 < 3 || MP != 10000 && Core.Resolve<MemApiSpell>().GetLastComboSpellId() != 冰4)
                {
                    if (冰4.CanSpell()) return 冰4.GetChangeSpell();
                }

                if (通晓溢出) return 异言.GetChangeSpell();
                if (悖论激活) return 悖论.GetChangeSpell();
                if (火3.CanSpell()) return 火3.GetChangeSpell();
            }
            var 战斗时间 = AI.Instance.BattleData.CurrBattleTimeInMs;
            if ((!天语状态 && Core.Resolve<MemApiSpell>().GetLastComboSpellId() == null) || (!天语状态 && 战斗时间 > 15000))
            {
                return 冰3.GetChangeSpell();
            }
        }

        return null;
    }

    private Spell 动()
    {
        var 通晓层数 = BLMBuff.通晓层数;
        var 冰火时间 = BLMBuff.冰火时间;
        var 冰针数 = BLMBuff.冰针数;
        var 悖论激活 = BLMBuff.悖论激活;
        var 冰状态 = BLMBuff.冰状态;
        var 火状态 = BLMBuff.火状态;
        var 天语状态 = BLMBuff.天语状态;
        var MP = BLMBuff.MP;
        var 火苗 = BLMBuff.火苗状态;
        var 通晓溢出 = BLMBuff.通晓溢出();


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

        if (Core.Me.IsMoving())
        {
            if (火状态)
            {
                if (Helper.可以打雷())
                {
                    return BLMSkill.雷1.GetChangeSpell();
                }

                if (Helper.有三连即刻buff())
                {
                    if (冰火时间 > 6000 && 耀星.IsReady()) return 耀星.GetChangeSpell();
                    if (冰火时间 > 6000 && MP >= 2400) return 火4.GetChangeSpell();
                    if (悖论激活) return 悖论.GetChangeSpell();
                    if (火苗) return 火3.GetChangeSpell();
                    if (绝望.IsReady()) return 绝望.GetChangeSpell();
                    return 冰3.GetChangeSpell();
                }

                if (通晓层数 >= 1 && 异言.打了不断()) return 异言.GetChangeSpell();
                if (悖论激活) return 悖论.GetChangeSpell();
                if (火苗) return 火3.GetChangeSpell();
            }

            if (冰状态)
            {
                if (Helper.可以打雷())
                {
                    return BLMSkill.雷1.GetChangeSpell();
                }

                if (QT.QTGET("骗悖论"))
                {
                    //骗悖论
                    if (BLMSkill.魔泉.IsReady() && 冰针数 < 3)
                    {
                        if (悖论.IsReady()) return 悖论.GetChangeSpell();
                        if (!星灵移位.IsReady())
                        {
                            if (异言.IsReady()) return 异言.GetChangeSpell();
                            return 雷1.GetChangeSpell();
                        }
                    }
                }

                if (通晓溢出) return 异言.GetChangeSpell();
                if (悖论激活) return 悖论.GetChangeSpell();
                if (Helper.有三连即刻buff())
                {
                    if (冰针数 < 3 || MP != 10000 && Core.Resolve<MemApiSpell>().GetLastComboSpellId() != 冰4)
                    {
                        if (冰4.CanSpell()) return 冰4.GetChangeSpell();
                    }

                    return 火3.GetChangeSpell();
                }

                if (通晓层数 >= 1 && 异言.打了不断()) return 异言.GetChangeSpell();
                if (雷1.CanSpell()) return 雷1.GetChangeSpell();
            }

            if (!天语状态 && Core.Resolve<MemApiSpell>().GetLastComboSpellId() != 冰3)
            {
                return 冰3.GetChangeSpell();
            }
        }

        return null;
    }
}