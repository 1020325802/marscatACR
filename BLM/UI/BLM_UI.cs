using AEAssist;
using AEAssist.CombatRoutine.View.JobView;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.JobApi;
using AEAssist.MemoryApi;
using Pictomancer.Data;
using ImGuiNET;
using test.依赖.Helper;

namespace BLM.Ui;

public static class BLM_UI
{
    public static void DrawQtDev(JobViewWindow jobViewWindow)
    {
        ImGui.TextUnformatted($"上一个技能id: {Core.Resolve<MemApiSpell>().GetLastComboSpellId()}");
        ImGui.TextUnformatted($"火4是否可用: {BLMSkill.火4.IsReady()}");
        ImGui.TextUnformatted($"通晓层数: {Core.Resolve<JobApi_BlackMage>().PolyglotStacks}");
        ImGui.TextUnformatted($"冰层数: {Core.Resolve<JobApi_BlackMage>().UmbralIceStacks}");
        ImGui.TextUnformatted($"火层数: {Core.Resolve<JobApi_BlackMage>().AstralFireStacks}");
        ImGui.TextUnformatted($"冰火时间: {BLMBuff.冰火时间}");
        ImGui.TextUnformatted($"冰针数: {Core.Resolve<JobApi_BlackMage>().UmbralHearts}");
        ImGui.TextUnformatted($"天语时间: {Core.Resolve<JobApi_BlackMage>().EnochianTimer}");
        ImGui.TextUnformatted($"悖论激活: {Core.Resolve<JobApi_BlackMage>().IsParadoxActive}");
        ImGui.TextUnformatted($"冰状态: {Core.Resolve<JobApi_BlackMage>().InUmbralIce}");
        ImGui.TextUnformatted($"火状态: {Core.Resolve<JobApi_BlackMage>().InAstralFire}");
        ImGui.TextUnformatted($"天语状态: {Core.Resolve<JobApi_BlackMage>().IsEnochianActive}");
        ImGui.TextUnformatted($"火豆数量: {Core.Resolve<JobApi_BlackMage>().AstralSoulStacks}");
        ImGui.TextUnformatted($"有火苗: {Core.Me.HasAura(BLMBuff.火苗)}");
        ImGui.TextUnformatted($"火4咏唱时间: {BLMSkill.火4.GetChangeSpell().CastTime.TotalMilliseconds}");
        ImGui.TextUnformatted($"火4复唱时间: {BLMSkill.火4.GetChangeSpell().RecastTime.TotalMilliseconds}");
        ImGui.TextUnformatted($"可以打雷: {Helper.可以打雷()}");

    }
    public static void DrawQtGeneral(JobViewWindow jobViewWindow)
    {
        ImGui.Text("当前版本v1.1.2");
        ImGui.Text("2024-10-16:修复卡GCD释放能力技问题");
        ImGui.Text("2024-10-16:开放90级支持");
        ImGui.Text("2024-10-19:修复倒数开场打两个冰3的问题，添加黑魔纹转好提醒");
    }
}