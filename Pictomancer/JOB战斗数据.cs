namespace test.JOB;

public class JOBBattleData
{
        private static readonly JOBBattleData BattleData = new();
        public static JOBBattleData Instance = BattleData;

        public void Reset()
        {
            Instance = new JOBBattleData();
        }
        
}