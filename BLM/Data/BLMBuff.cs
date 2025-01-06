using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.JobApi;

namespace Pictomancer.Data;

public class BLMBuff
{
    public const uint 火苗 = 165;
    public const uint 云砧 = 3870;

    //敌方buff
    public const uint 闪雷 = 161;
    public const uint 暴雷 = 163;
    public const uint 高闪雷 = 3871;
    public const uint 震雷 = 162;
    public const uint 霹雷 = 1210;
    public const uint 高震雷 = 3872;
    
    
    public static bool 即刻buff => Core.Me.HasAura(167);
    public static bool 三连buff => Core.Me.HasAura(1211);
    public static int 通晓层数 => Core.Resolve<JobApi_BlackMage>().PolyglotStacks;
    public static int 冰层数 => Core.Resolve<JobApi_BlackMage>().UmbralIceStacks;
    public static int 火层数 => Core.Resolve<JobApi_BlackMage>().AstralFireStacks;
    public static long 冰火时间 => Core.Resolve<JobApi_BlackMage>().ElementTimeRemaining;
    public static int 冰针数 => Core.Resolve<JobApi_BlackMage>().UmbralHearts;
    public static long 天语时间 => Core.Resolve<JobApi_BlackMage>().EnochianTimer;
    public static bool 悖论激活 => Core.Resolve<JobApi_BlackMage>().IsParadoxActive;
    public static bool 冰状态 => Core.Resolve<JobApi_BlackMage>().InUmbralIce;
    public static bool 火状态 => Core.Resolve<JobApi_BlackMage>().InAstralFire;
    public static bool 天语状态=> Core.Resolve<JobApi_BlackMage>().IsEnochianActive;
    public static int 火豆数量 => Core.Resolve<JobApi_BlackMage>().AstralSoulStacks;
    public static uint MP => Core.Me.CurrentMp;
    public static bool 火苗状态 => Core.Me.HasAura(火苗);
    public static bool 云砧状态 => Core.Me.HasAura(云砧);

    public static bool 通晓溢出()
    {
        var Level = Core.Me.Level;
        if (Level >= 98)
        {
            return 通晓层数 == 3 && 天语时间 < 8000;
        }

        if (Level < 98 && Level >= 80)
        {
            return 通晓层数 == 2 && 天语时间 < 8000;
        }
        
        if (Level < 80 && Level >= 70)
        {
            return 通晓层数 == 1;
        }

        return false;
    }
    public static bool 详述可用()
    {
        uint 详述 = 25796;
        var Level = Core.Me.Level;
        if (Level >= 98)
        {
            return 通晓层数 < 3 && 天语时间 > 8000 && 详述.IsReady();
        }

        if (Level < 98 && Level >= 86)
        {
            return 通晓层数 < 2 && 天语时间 > 8000 && 详述.IsReady();
        }
        return false;
    }

    public static int 通晓保留数量()
    {
        //TODO
        return 0;
    }
}