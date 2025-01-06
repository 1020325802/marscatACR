﻿using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.Helper;
using AEAssist.MemoryApi;


namespace Pictomancer.Data;

public class PCTData
{
    public static class Buffs
    {
        public const ushort
            长Buff = 3674,
            连击2buff = 3675,
            连击3buff = 3676,
            黑豆buff = 3691,
            锤子预备 = 3680,
            彩虹预备 = 3679,
            免费反转 = 3690,
            大招预备buff = 3681,
            加速 = 3688,
            团辅 = 3685;
    }

    public static class SkillId
    {
        public const uint
            //基础技能
            短1 = 34650,
            短2 = 34651,
            短3 = 34652,
            长1 = 34653,
            长2 = 34654,
            长3 = 34655,
            AOE短1 = 34656,
            AOE短2 = 34657,
            AOE短3 = 34658,
            AOE长1 = 34659,
            AOE长2 = 34660,
            AOE长3 = 34661,
            白豆 = 34662,
            黑豆 = 34663,
            减色混合 = 34683,
            
            //画画技能
            动物彩绘 = 34689,    绒球彩绘 = 34664,翅膀彩绘=34665,兽爪彩绘=34666,尖牙彩绘=34667,
            武器彩绘 = 34690,    重锤彩绘 = 34668,
            风景彩绘 = 34691,    星空彩绘 = 34669,
            
            //用画技能，有画之后，就变成后面的
            动物构想 = 35347,    绒球构想 = 34670,翅膀构想 = 34671,兽爪构想 = 34672,尖牙构想 = 34672,
            武器构想 = 35348,    重锤构想 = 34674,
            风景构想 = 35349,    星空构想 = 34675,
            
            //
            莫古力激流 = 34676,
            马蒂恩惩罚 = 34677,
            
            //三大锤
            重锤敲章 = 34678, 重锤掠刷 = 34679, 重锤抛光 = 34680,
            
            天星棱光 = 34681,
            彩虹 = 34688,
            画魔纹 = 34675;
            
            
    }
}