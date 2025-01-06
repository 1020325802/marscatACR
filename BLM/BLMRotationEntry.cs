using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.Module.Opener;
using AEAssist.CombatRoutine.View.JobView;
using AEAssist.CombatRoutine.View.JobView.HotkeyResolver;
using AEAssist.Helper;
using BLM.Setting;
using BLM.Skill;
using BLM.Ui;
using BLM.依赖;
using marscat.BLM.Skill.Combo;
using Pictomancer.BLM.Skill;
using test.JOB.依赖;

namespace BLM;

// 重要 类一定要Public声明才会被查找到
public class BLMRotationEntry : IRotationEntry
{
    
    public string AuthorName { get; set; } = "marscat";

    public void Dispose()
    {
        // TODO release managed resources here
    }

    // 逻辑从上到下判断，通用队列是无论如何都会判断的 
    // gcd则在可以使用gcd时判断
    // offGcd则在不可以使用gcd 且没达到gcd内插入能力技上限时判断
    // pvp环境下 全都强制认为是通用队列
    private List<SlotResolverData> SlotResolvers = new()
    {
        new SlotResolverData(new 雷dot(),SlotMode.Gcd),
        new SlotResolverData(new GCD(),SlotMode.Gcd),
        new SlotResolverData(new 魔泉相关(),SlotMode.Always),
        new SlotResolverData(new 即刻耀星(),SlotMode.OffGcd),
        new SlotResolverData(new 详述(),SlotMode.OffGcd),
        new SlotResolverData(new 冰转火星灵(),SlotMode.OffGcd),
        new SlotResolverData(new Ability(),SlotMode.OffGcd),
    };
    
    public Rotation Build(string settingFolder)
    {
        BLMSettings.Build(settingFolder);
        BuildQT();
        var rot = new Rotation(SlotResolvers)
        {
            TargetJob = Jobs.BlackMage,
            AcrType = AcrType.HighEnd,
            MinLevel = 90,
            MaxLevel = 100,
            Description = "黑魔ACR，目前支持90-100级",
        }; 
        rot.AddOpener(GetOpener);
        // 添加各种事件回调
        return rot;
    }
    
    IOpener? GetOpener(uint level)
    {
        if (level == 100 && QT.GetQt("起手1"))
            return new 木桩特化起手1();
        return null;
    }

    // 声明当前要使用的UI的实例 示例里使用QT
    public static JobViewWindow QT { get; private set; }
    
    // 如果你不想用QT 可以自行创建一个实现IRotationUI接口的类
    public IRotationUI GetRotationUI()
    {
        return QT;
    }
    public void BuildQT()
    {
        // JobViewSave是AE底层提供的QT设置存档类 在你自己的设置里定义即可
        // 第二个参数是你设置文件的Save类 第三个参数是QT窗口标题
        QT = new JobViewWindow(BLMSettings.Instance.JobViewSave, BLMSettings.Instance.Save, "marscatBLM");
        QT.AddTab("通用", BLM_UI.DrawQtGeneral);
        QT.AddTab("DEV",BLM_UI.DrawQtDev);
        uint 黑魔纹 = 3573;
        uint 异言 = 16507;
        uint 魔泉 = 158;
        uint 详述 = 25796;
        uint 即刻 = 7561;
        uint 三连 = 7421;
        uint 魔纹步 = 7419;
        uint 魔罩 = 157;
        uint 沉稳咏唱 = 7559;
        uint 灵极魂 = 16506;
        uint 昏乱 = 7560;
        QT.AddHotkey("昏乱",new HotKeyResolver_NormalSpell(昏乱,SpellTargetType.Target,false));
        QT.AddHotkey("灵极魂",new HotKeyResolver_NormalSpell(灵极魂,SpellTargetType.Target,false));
        QT.AddHotkey("沉稳咏唱",new HotKeyResolver_NormalSpell(沉稳咏唱,SpellTargetType.Target,true));
        QT.AddHotkey("魔罩",new HotKeyResolver_NormalSpell(魔罩,SpellTargetType.Target,false));
        QT.AddHotkey("详述",new HotKeyResolver_NormalSpell(详述,SpellTargetType.Target,false));
        QT.AddHotkey("即刻",new HotKeyResolver_NormalSpell(即刻,SpellTargetType.Target,false));
        QT.AddHotkey("三连",new HotKeyResolver_NormalSpell(三连,SpellTargetType.Target,false));
        QT.AddHotkey("异言",new HotKeyResolver_NormalSpell(异言,SpellTargetType.Target,false));
        QT.AddHotkey("魔泉",new HotKeyResolver_NormalSpell(魔泉,SpellTargetType.Self,true));
        QT.AddHotkey("爆发药", new HotKeyResolver_Potion());
        QT.AddHotkey("极限技", new HotKeyResolver_LB());
        QT.AddHotkey("黑魔纹", new 黑魔纹Hotkey());
        QT.AddQt(BLMQTKey.起手1, false, "7.1木桩起手");
        QT.AddQt(BLMQTKey.即刻耀星, true, "即刻耀星");
        QT.AddQt(BLMQTKey.AOE, false, "打AOE");

    }
    // 构造函数里初始化QT

    
    
    public void OnDrawSetting()
    {
        
    }
}