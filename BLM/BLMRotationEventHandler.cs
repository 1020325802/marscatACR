using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.Module.AILoop;
using test.JOB.依赖;


namespace BLM;

/// <summary>
/// 事件回调处理类 参考接口里的方法注释
/// </summary>
public class BLMRotationEventHandler : IRotationEventHandler
{
    private long randomSongTime;
    public async Task OnPreCombat()
    {
        if (!QT.QTGET("自动灵极魂") && Core.Me.Level >= 35)
        {
            var slot = new Slot();
            自动灵极魂(slot);
            await slot.Run(AI.Instance.BattleData, false);
        }
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
    private void 自动灵极魂 (Slot slot)
    {
        
        
    }
    
}