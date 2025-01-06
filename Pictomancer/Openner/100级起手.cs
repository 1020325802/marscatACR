using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.Module.Opener;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.JobApi;
using AEAssist.MemoryApi;
using Pictomancer.Data;
using test.JOB.依赖;
using test.依赖.Helper;

namespace Pictomancer.Pictomancer.GCD;

public class 满级起手 : IOpener
{
    public int StartCheck()
    {
        /*if (!QT.QTGET(QTKey.满级起手))  return -100;*/
        if (AI.Instance.BattleData.CurrBattleTimeInMs > 2000) return -99;
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
        Step2,
        Step3,
        Step4,
        Step5,
        Step6,
        Step7,
    };
    
    
    private static void Step0(Slot slot)
    {
        if (QT.QTGET("爆发药"))
        {
            slot.Add(Spell.CreatePotion());
        }
    }
    private static void Step1(Slot slot)
    {
        slot.Add(PCTData.SkillId.白豆.GetChangeSpell());
    }

    private static void Step2(Slot slot)
    {
        slot.Add(PCTData.SkillId.动物构想.GetChangeSpell());
    }
    private static void Step3(Slot slot)
    {
        slot.Add(PCTData.SkillId.武器构想.GetChangeSpell());
    }
    private static void Step4(Slot slot)
    {
        slot.Add(PCTData.SkillId.动物彩绘.GetChangeSpell());
    }
    private static void Step5 (Slot slot)
    {
        slot.Add(new Spell(PCTData.SkillId.风景构想,SpellTargetType.Target));
    }
    private static void Step6(Slot slot)
    {
        slot.Add(PCTData.SkillId.重锤敲章.GetChangeSpell());
    }
    private static void Step7(Slot slot)
    {
        slot.Add(PCTData.SkillId.减色混合.GetChangeSpell());
    }
    
    
    public Action CompeltedAction { get; set; }
    public void InitCountDown(CountDownHandler countDownHandler)
    {
        //倒数五秒彩虹
        countDownHandler.AddAction(5000, PCTData.SkillId.彩虹,SpellTargetType.Target);
    }
    
}