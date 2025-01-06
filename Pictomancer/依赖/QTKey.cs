using Pictomancer.Pictomancer;

namespace test.JOB.依赖
{
    // 直接定义好 方便编码
    public static class QTKey
    {
        public const string 空闲画画 = "空闲画画";
        public const string 锤子 = "锤子";
        public const string 黑豆 = "黑豆";
        public const string 白豆 = "白豆";
        public const string 天星 = "天星";
        public const string 彩虹 = "彩虹";
        public const string 反转 = "反转";
        public const string 莫古炮 = "莫古炮";
        public const string 马丁炮 = "马丁炮";
        public const string 画动物 = "画动物";
        public const string 画武器 = "画武器";
        public const string 画风景 = "画风景";
        public const string 画魔纹 = "画魔纹";
        public const string 动物构想 = "动物构想";
        public const string 小怪给爆发 = "小怪给爆发";
        public const string 满级起手 = "满级起手";

    }
    public static class QT
    {
        public static bool QTGET(string qtName) => PictomancerRotationEntry.QT.GetQt(qtName);
        public static bool QTSET(string qtName, bool qtValue) => PictomancerRotationEntry.QT.SetQt(qtName, qtValue);
    }
}