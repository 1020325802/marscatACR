using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.JobApi;
using BLM.依赖;
using Pictomancer.Data;
using test.依赖.Helper;

namespace marscat.BLM.Skill.Combo;


public class 双星灵骗悖论 : ISlotSequence
{
    public Action CompeltedAction { get; set; }

    public int StartCheck()
    {
        if (Core.Me.Level <90)
            return -1;
        if (QT.QTGET("双星灵") == false)
            return -2;
        
        if (BLMBuff.冰火时间 > 4 && BLMSkill.魔泉.IsReady() && BLMBuff.MP == 0)
            return 1;
        return -99;
    }

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