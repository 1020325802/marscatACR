using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using Pictomancer.Data;
using test.依赖.Helper;

namespace Pictomancer.BLM.Skill;

public class 魔泉相关 : ISlotResolver
{
    public int Check()
    {
        if (BLMSkill.魔泉.IsReady() && BLMBuff.MP == 0)
        {
            return 1;
        }

        return -1;
    }

    public void Build(Slot slot)
    {
        if (Core.Me.HasAura(BLMBuff.火苗))
        {
            slot.Add(BLMSkill.火3.GetChangeSpell());
            slot.Add(BLMSkill.魔泉.GetChangeSpell());
        }

        if (!Core.Me.HasAura(BLMBuff.火苗))
        {
            //有能力技窗口
            if (GCDHelper.GetGCDCooldown() > 600)
            {
                slot.Add(BLMSkill.魔泉.GetChangeSpell());
            }
            else if (BLMSkill.异言.IsReady())
            {
                slot.Add(BLMSkill.异言.GetChangeSpell());
                slot.Add(BLMSkill.魔泉.GetChangeSpell());
            }
        }
        
        if (BLMSkill.三连咏唱.充能层数() > 1)
        {
            slot.Add(BLMSkill.三连咏唱.GetChangeSpell());
        }
        else if (BLMSkill.即刻.IsReady())
        {
            slot.Add(BLMSkill.即刻.GetChangeSpell());
        }
    }
}