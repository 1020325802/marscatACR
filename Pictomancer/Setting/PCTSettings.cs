﻿using AEAssist.CombatRoutine.View.JobView;
using AEAssist.Helper;
using AEAssist.IO;

namespace demo1.Pictomancer.Setting;

/// <summary>
/// 配置文件适合放一些一般不会在战斗中随时调整的开关数据
/// 如果一些开关需要在战斗中调整 或者提供给时间轴操作 那就用QT
/// 非开关类型的配置都放配置里 比如诗人绝峰能量配置
/// </summary>
public class PCTSettings
{
    public static PCTSettings Instance;

    #region 标准模板代码 可以直接复制后改掉类名即可
    private static string path;
    public static void Build(string settingPath)
    {
        path = Path.Combine(settingPath,nameof(PCTSettings)+ ".json");
        if (!File.Exists(path))
        {
            Instance = new PCTSettings();
            Instance.Save();
            return;
        }
        try
        {
            Instance = JsonHelper.FromJson<PCTSettings>(File.ReadAllText(path));
        }
        catch (Exception e)
        {
            Instance = new();
            LogHelper.Error(e.ToString());
        }
    }

    public void Save()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path));
        File.WriteAllText(path, JsonHelper.ToJson(this));
    }
    #endregion
    
    public JobViewSave JobViewSave = new(); // QT设置存档
    
}