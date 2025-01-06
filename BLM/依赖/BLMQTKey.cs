using Pictomancer.Pictomancer;

namespace BLM.依赖
{
    // 直接定义好 方便编码
    public static class BLMQTKey
    {
        public const string 火起手 = "火起手";
        public const string AOE = "AOE";
        public const string 即刻耀星 = "即刻耀星";
        public const string 起手1 = "起手1";
    }
    public static class QT
    {
        public static bool QTGET(string qtName) => BLMRotationEntry.QT.GetQt(qtName);
        public static bool QTSET(string qtName, bool qtValue) => BLMRotationEntry.QT.SetQt(qtName, qtValue);
    }
}