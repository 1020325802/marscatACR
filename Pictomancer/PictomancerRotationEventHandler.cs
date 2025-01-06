using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.Module.AILoop;
using AEAssist.CombatRoutine.Module.Target;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.JobApi;
using AEAssist.MemoryApi;
using Pictomancer.Data;
using test.JOB.依赖;
using test.依赖.Helper;

namespace Pictomancer.Pictomancer;

/// <summary>
/// 事件回调处理类 参考接口里的方法注释
/// </summary>
public class PictomancerRotationEventHandler : IRotationEventHandler
{
    private long randomSongTime;
    public async Task OnPreCombat()
    {
        
        /*
        if (!RedMageSettings.Instance.UsePeloton)
        {
            return;
        }

        // 检测有没有速行buff或者最近是否使用 (后者是考虑到服务器延迟)
        if (Core.Me.HasAura(AurasDefine.Peloton) || SpellsDefine.Peloton.RecentlyUsed())
        {
            return;
        }

        if (randomSongTime != 0)
        {
            if (TimeHelper.Now() < randomSongTime)
                return;
        }

        // 使用Peloton
        await SpellsDefine.Peloton.GetSpell().Cast();
        */
        var slot = new Slot();
        空闲画画(slot);
        await slot.Run(AI.Instance.BattleData, false);
    }

    public void OnResetBattle()
    {
        // 重置战斗中缓存的数据
        /*RedMageBattleData.Instance = new();*/
        // 战斗结束随机 500~3000 ms后 再使用速行
        //randomSongTime = TimeHelper.Now() + RandomHelper.RandomInt(500, 3000);
    }

    public async Task OnNoTarget()
    {
        
    }

    public void OnSpellCastSuccess(Slot slot, Spell spell)
    {
       
    }

    public void AfterSpell(Slot slot, Spell spell)
    {
        
    }

    public void OnBattleUpdate(int currTimeInMs)
    {
        
    }

    public void OnEnterRotation()
    {
        
    }

    public void OnExitRotation()
    {
        
    }

    public void OnTerritoryChanged()
    {
        
    }
    
    private void 空闲画画 (Slot slot)
    {
        List<uint> area = new List<uint>
        {
            129,//海都1
            128,//海都2
            641,//白银乡房区
            132,//森都1
            133,//森都2
            130,//沙都1
            131,//沙都1
            340,//森都房区
            418,//伊修加德1
            419,//伊修加德2
            478,//田园郡
            635,//神拳痕
            628,//黄金港
            963,//拉扎罕
            819,//水晶都
            820,//游末邦
            156,//摩杜纳
            962,//旧萨雷安
        };

        ushort currTerrId = (ushort)Core.Resolve<MemApiMap>().GetCurrTerrId();

        var matchingAreas = area.Where(a => a == currTerrId);
        
        if (!QT.QTGET("空闲画画")) return;

        if(Core.Resolve<MemApiDuty>().IsOver) return;

        if (QT.QTGET("空闲画画") && !matchingAreas.Any()){
           
        if (!Core.Resolve<JobApi_Pictomancer>().生物画 && !(PCTData.SkillId.动物彩绘.GetChangeSpell().Id == PCTData.SkillId.动物彩绘))
        {
            slot.Add(PCTData.SkillId.动物彩绘.GetChangeSpell());
        }
        if (!Core.Resolve<JobApi_Pictomancer>().武器画  && !(PCTData.SkillId.武器彩绘.GetChangeSpell().Id == PCTData.SkillId.武器彩绘))
        {
            slot.Add(PCTData.SkillId.武器彩绘.GetChangeSpell());
        }
        if (!Core.Resolve<JobApi_Pictomancer>().风景画  && !(PCTData.SkillId.风景彩绘.GetChangeSpell().Id == PCTData.SkillId.风景彩绘))
        {
            slot.Add(PCTData.SkillId.风景彩绘.GetChangeSpell());
        }
        
        }
    }
}