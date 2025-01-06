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

namespace marscat.BLM.Skill.Combo;


public class 获取火苗短循环 : ISlotSequence
{
    public Action CompeltedAction { get; set; }

    /*public int StartCheck()
        { var 雷buff剩余时间 = Core.Resolve<MemApiBuff>().GetAuraTimeleft(Core.Me.GetCurrTarget(), BLMBuff.暴雷, true);
        var 通晓层数 = BLMBuff.通晓层数;
        var 冰层数 = BLMBuff.冰层数;
        var 火层数 = BLMBuff.火层数;
        var 冰火时间 = BLMBuff.冰火时间;
        var 冰针数 = BLMBuff.冰针数;
        var 悖论激活 = BLMBuff.悖论激活;
        var 冰状态 = BLMBuff.冰状态;
        var 火状态 = BLMBuff.火状态;
        var 天语状态 = BLMBuff.天语状态;
        var MP = BLMBuff.MP;
        var 火苗 = BLMBuff.火苗状态;
        var 通晓溢出 = BLMBuff.通晓溢出();
        var 通晓保留数量 = BLMBuff.通晓保留数量();
        var 火豆数量 = BLMBuff.火豆数量;
        var 资源雷 = 雷buff剩余时间 < 8000 && BLMSkill.高闪雷.IsReady();
        var 资源数量 = 资源雷 ? 通晓层数 - 通晓保留数量 : 通晓层数 + 1;

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
        if (Core.Me.Level != 90)
            return -1;
        /*if (QT.QTGET("双星灵") == false)
            return -2;
            #1#
        //什么时候使用获取火苗短循环
        //1.三档火状态
        //2.蓝量为0
        //3.悖论不可用
        //4.有瞬发窗口
        //5.身上不带火苗
        //6.至少有一个可用资源
        //7.耀星不可用
        //达成以上条件,进入短循环判断逻辑
        if (火层数 == 3 && MP == 0 && !悖论激活 && )
            return 1;
        return -99;
    }*/

    public int StopCheck(int index)
    {
        return -1;
    }

    public List<Action<Slot>> Sequence { get; } = new()
    {
        Step0,
        Step1,
        Step2,
    };

    private static void Step0(Slot slot)
    {
        if(BLMBuff.火苗状态) slot.Add(BLMSkill.火3.GetChangeSpell());
        else if(Helper.可以打雷()) slot.Add(BLMSkill.雷1.GetChangeSpell());
        
    }

    private static void Step1(Slot slot)
    {
        if (Core.Me.GetCurrTarget().HasMyAuraWithTimeleft(AurasDefine.DeathsDesign, 40000) && Core.Me.HasAura(AurasDefine.Soulsow))
            slot.Add(new Spell(SpellsDefine.HarvestMoon, SpellTargetType.Target));
        else
            slot.Add(new Spell(SpellsDefine.ShadowOfDeath, SpellTargetType.Target));
        slot.Add(new SlotAction(SlotAction.WaitType.WaitForSndHalfWindow, 0, Spell.CreatePotion()));

    }
    private static void Step2(Slot slot)
    {
        slot.Add(new Spell(SpellsDefine.VoidReaping, SpellTargetType.Target));
        slot.Add(new Spell(SpellsDefine.ArcaneCircle, SpellTargetType.Self));
    }

}