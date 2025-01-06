using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.Module.Opener;
using AEAssist.Extension;
using AEAssist.Helper;
using BLM.依赖;
using Pictomancer.Data;
using test.JOB.依赖;
using test.依赖.Helper;
using QT = test.JOB.依赖.QT;

namespace marscat.BLM.Skill.Combo;

public class 木桩特化起手1 : IOpener
{
    public int StartCheck()
    {
        if (!QT.QTGET("起手1"))
            return -100;
        if (!TargetHelper.IsBoss(Core.Me.GetCurrTarget()))
            return -1;
        if (AI.Instance.BattleData.CurrBattleTimeInMs > 2000)
        {
            return -5;
        }
        return -1;
    }
    
    public int StopCheck(int index)
    {
        return -1;
    }

    public List<Action<Slot>> Sequence { get; } = new()
    {
        Step0,
        Step1,
        Step2

    };
    
    private static void Step0(Slot slot)
    {
        slot.Add(BLMSkill.雷1.GetChangeSpell());
    }
    private static void Step1(Slot slot)
    {
        slot.Add(BLMSkill.三连咏唱.GetSpell(SpellTargetType.Self));
        slot.Add(new Spell(BLMSkill.黑魔纹,Core.Me.Position));
        slot.Add(BLMSkill.火4.GetChangeSpell());
        slot.Add(BLMSkill.即刻.GetSpell(SpellTargetType.Self));
        slot.Add(BLMSkill.火4.GetChangeSpell());
        slot.Add(BLMSkill.详述.GetSpell(SpellTargetType.Self));
        if (QT.QTGET("爆发药"))
        {
            slot.Add(Spell.CreatePotion());
        }
        slot.Add(BLMSkill.火4.GetChangeSpell());
        slot.Add(BLMSkill.绝望.GetChangeSpell());
        slot.Add(BLMSkill.魔泉.GetSpell(SpellTargetType.Self));
        slot.Add(BLMSkill.三连咏唱.GetSpell(SpellTargetType.Self));
        slot.Add(BLMSkill.火4.GetChangeSpell());
        slot.Add(BLMSkill.火4.GetChangeSpell());
        slot.Add(BLMSkill.耀星.GetChangeSpell());
    }

    private static void Step2(Slot slot)
    {
        slot.Add(BLMSkill.火4.GetChangeSpell());
        slot.Add(BLMSkill.火4.GetChangeSpell());
        slot.Add(BLMSkill.悖论.GetChangeSpell());
        slot.Add(BLMSkill.火4.GetChangeSpell());
        slot.Add(BLMSkill.雷1.GetChangeSpell());
        slot.Add(BLMSkill.火4.GetChangeSpell());
        slot.Add(BLMSkill.绝望.GetChangeSpell());
        slot.Add(BLMSkill.星灵移位.GetSpell(SpellTargetType.Self));
        slot.Add(BLMSkill.悖论.GetChangeSpell());
        slot.Add(BLMSkill.异言.GetChangeSpell());
        slot.Add(BLMSkill.星灵移位.GetSpell(SpellTargetType.Self));
        slot.Add(BLMSkill.绝望.GetChangeSpell());
        slot.Add(BLMSkill.冰3.GetChangeSpell());
        slot.Add(BLMSkill.冰4.GetChangeSpell());
    }


    public Action CompeltedAction { get; set; }
    public void InitCountDown(CountDownHandler countDownHandler)
    {
        LogHelper.Print("进入起手序列");
        countDownHandler.AddAction(4000, BLMSkill.火3);//倒数4秒火3
    }
}