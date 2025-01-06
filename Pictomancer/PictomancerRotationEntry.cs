using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.Module.Opener;
using AEAssist.CombatRoutine.View.JobView;
using demo1.Pictomancer.Setting;
using Fra.PCT.Ui;
using Pictomancer.Pictomancer.Ability;
using Pictomancer.Pictomancer.GCD;
using test.JOB.依赖;

namespace Pictomancer.Pictomancer;

// 重要 类一定要Public声明才会被查找到
public class PictomancerRotationEntry : IRotationEntry
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
        
        
        /*new SlotResolverData(new PCT_GCD_空暇自动画画(),SlotMode.Gcd),*/
        new SlotResolverData(new PCT_GCD_画魔纹爆发(),SlotMode.Gcd),
        new SlotResolverData(new GCD_彩虹点滴(),SlotMode.Gcd),
        new SlotResolverData(new GCD_天星棱光(),SlotMode.Gcd),
        new SlotResolverData(new PCT_GCD_黑豆(),SlotMode.Gcd),
        new SlotResolverData(new PCT_GCD_锤3连(),SlotMode.Gcd),
        new SlotResolverData(new GCD_风景彩绘(),SlotMode.Gcd),
        new SlotResolverData(new GCD_动物彩绘(),SlotMode.Gcd),
        new SlotResolverData(new GCD_武器彩绘(),SlotMode.Gcd),
        new SlotResolverData(new GCD_BASEAOE(),SlotMode.Gcd),
        new SlotResolverData(new GCD_BASE(),SlotMode.Gcd),
        new SlotResolverData(new PCT_GCD_白豆(),SlotMode.Gcd),
        new SlotResolverData(new Ability_风景构想(),SlotMode.OffGcd),
        new SlotResolverData(new Ability_武器构想(),SlotMode.OffGcd),
        new SlotResolverData(new Ability_莫古力激流(),SlotMode.OffGcd),
        new SlotResolverData(new PCT_Ability_马丁炮(),SlotMode.OffGcd),
        new SlotResolverData(new Ability_动物构想(),SlotMode.OffGcd),
        new SlotResolverData(new Ability_减色混合(),SlotMode.OffGcd),
       
    };
    
    public Rotation Build(string settingFolder)
    {
        PCTSettings.Build(settingFolder);
        BuildQT();
        var rot = new Rotation(SlotResolvers)
        {
            TargetJob = Jobs.Pictomancer,
            AcrType = AcrType.Normal,
            MinLevel = 0,
            MaxLevel = 100,
            Description = "画家测试",
        }; 
        rot.AddOpener(GetOpener);
        // 添加各种事件回调
        rot.SetRotationEventHandler(new PictomancerRotationEventHandler());
        return rot;
    }
    
    IOpener? GetOpener(uint level)
    {
        /*if (level == 100)
        {
            return new 满级起手();
        }*/
        

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
        QT = new JobViewWindow(PCTSettings.Instance.JobViewSave, PCTSettings.Instance.Save, "marscatPCT");
        QT.AddTab("DEV",PCT_UI.DrawQtGeneral);
        QT.AddQt(QTKey.空闲画画, true, "空闲画画");
        QT.AddQt(QTKey.锤子, true, "锤子");
        QT.AddQt(QTKey.黑豆, true, "黑豆");
        QT.AddQt(QTKey.白豆, true, "白豆");
        QT.AddQt(QTKey.天星, true, "天星");
        QT.AddQt(QTKey.彩虹, true, "彩虹");
        QT.AddQt(QTKey.反转, true, "反转");
        QT.AddQt(QTKey.莫古炮, true, "莫古炮");
        QT.AddQt(QTKey.马丁炮, true, "马丁炮");
        QT.AddQt(QTKey.画动物, true, "画动物");
        QT.AddQt(QTKey.画武器, true, "画武器");
        QT.AddQt(QTKey.画风景, true, "画风景");
        QT.AddQt(QTKey.画魔纹, true, "画魔纹");
        QT.AddQt(QTKey.动物构想, true, "动物构想");
        /*QT.AddQt(QTKey.小怪给爆发, true, "小怪给爆发");*/
    }
    // 构造函数里初始化QT

    public void OnDrawSetting()
    {
        
    }
}