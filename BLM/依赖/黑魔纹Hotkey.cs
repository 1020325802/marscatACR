using System.Numerics;
using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.View.JobView;
using AEAssist.Helper;
using Pictomancer.Data;


public class 黑魔纹Hotkey : IHotkeyResolver
{
    private const uint SpellId = BLMSkill.黑魔纹;

    public void Draw(Vector2 size)
    {
        HotkeyHelper.DrawSpellImage(size, SpellId);
    }

    public void DrawExternal(Vector2 size, bool isActive)
    {
        if (isActive)
        {
            HotkeyHelper.DrawActiveState(size);
        }
        else
        {
            HotkeyHelper.DrawGeneralState(size);
        }

        HotkeyHelper.DrawCooldownText(SpellId.GetSpell(), size);
    }

    public int Check()
    {
        if (SpellId.IsReady())
        {
            return 0;
        }

        return -1;
    }

    public void Run()
    {
        var slot = new Slot();
        slot.Add(new Spell(SpellId,Core.Me.Position));
        AI.Instance.BattleData.NextSlot = slot;
    }
}