using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using Pictomancer.Pictomancer;


namespace test.JOB
{
    public class JOBRotationEventHandler : IRotationEventHandler
    {




        public void OnResetBattle()//重置战斗
        {
            JOBBattleData.Instance = new JOBBattleData();
            JOBBattleData.Instance.Reset();
        }

        public async Task OnNoTarget()//进战且无目标时
        {

            await Task.CompletedTask;
        }

        public void OnSpellCastSuccess(Slot slot, Spell spell)//施法成功判定可以滑步时
        {
        
        }

        public async Task OnPreCombat()//脱战时
        {
            
            await Task.CompletedTask;
        }
        
    

        public void AfterSpell(Slot slot, Spell spell)
        //某个技能使用之后的处理,比如诗人在刷Dot之后记录这次是否是强化buff的Dot 如果是读条技能，则是服务器判定它释放成功的时间点，比上面的要慢一点
        {

             

        }

        public void OnBattleUpdate(int currTime)//战斗中逐帧检测
        {
      
        }

        public void OnEnterRotation()//切换到当前ACR
        {
        
        }

        public void OnExitRotation()//退出ACR
        {
      
        }

        public void OnTerritoryChanged()
        {
        
        }
        

    }
}