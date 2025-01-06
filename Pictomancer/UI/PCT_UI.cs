using AEAssist;
using AEAssist.CombatRoutine.View.JobView;
using AEAssist.Helper;
using AEAssist.JobApi;
using AEAssist.MemoryApi;
using Pictomancer.Data;
using ImGuiNET;
using test.依赖.Helper;

namespace Fra.PCT.Ui;

public static class PCT_UI
{
    public static void DrawQtGeneral(JobViewWindow jobViewWindow)
    {
        var dutySchedule = Core.Resolve<MemApiDuty>().GetSchedule();
        if (dutySchedule != null)
        {
            ImGui.TextUnformatted($"副本需要进度: {dutySchedule.CountPoint}");
            ImGui.TextUnformatted($"副本当前进度: {dutySchedule.NowPoint}");
            ImGui.TextUnformatted($"当前进度名称: {dutySchedule.NowPointName}");
        }
        var 打完动物充能 = (PCTData.SkillId.动物构想.GetChangeSpell().Charges - 1) * 40;
        var 打完锤子充能 = (PCTData.SkillId.武器构想.GetChangeSpell().Charges - 1) * 60;
        ImGui.TextUnformatted($"打完动物充能: {打完动物充能}");
        ImGui.TextUnformatted($"打完锤子充能: {打完锤子充能}");
        ImGui.TextUnformatted($"豆子: {Core.Resolve<JobApi_Pictomancer>().豆子}");
        ImGui.TextUnformatted($"风景构想CD: {PCTData.SkillId.风景构想.GetChangeSpell().Cooldown.TotalSeconds}");
        ImGui.TextUnformatted($"能量: {Core.Resolve<JobApi_Pictomancer>().能量}");
        ImGui.TextUnformatted($"生物画: {Core.Resolve<JobApi_Pictomancer>().生物画}");
        ImGui.TextUnformatted($"风景画: {Core.Resolve<JobApi_Pictomancer>().风景画}");
        ImGui.TextUnformatted($"武器画: {Core.Resolve<JobApi_Pictomancer>().武器画}");
        ImGui.TextUnformatted($"蔬菜准备: {Core.Resolve<JobApi_Pictomancer>().蔬菜准备}");
        ImGui.TextUnformatted($"莫古准备: {Core.Resolve<JobApi_Pictomancer>().莫古准备}");
        ImGui.TextUnformatted($"动物充能: {Core.Resolve<MemApiSpell>().CheckActionChange(PCTData.SkillId.动物构想).GetSpell().Charges}");
        //ImGui.TextUnformatted($"CanCast: {PctData.Spells.短1.GetSpell().CanCastEx()}");
        ImGui.TextUnformatted($"画魔纹充能: {PCTData.SkillId.风景构想.GetSpell().Charges}");
    }
}