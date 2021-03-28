using BepInEx;
using RoR2;

namespace BetterAnnouncing
{
    [BepInPlugin("com.avarianknight.BetterAnnouncing", "BetterAnnouncing", "1.0.0")]
    public class BetterAnnouncing : BaseUnityPlugin
    {
        public void Awake()
        {
            AddHooks();
        }

        private void AddHooks()
        {
            On.RoR2.TeleporterInteraction.ChargedState.OnInteractionBegin += onChargedPortalInteractionBegin;
        }

        private void onChargedPortalInteractionBegin(On.RoR2.TeleporterInteraction.ChargedState.orig_OnInteractionBegin orig, EntityStates.BaseState self, RoR2.Interactor activator)
        {
            orig(self, activator);
            var user = activator.GetComponent<CharacterBody>();
            Logger.LogWarning($"<color=red>{user.GetUserName()}</color> has activated the teleporter.");
            Chat.SendBroadcastChat(new Chat.SimpleChatMessage
            {
                baseToken = $"<color=red>{user.GetUserName()}</color> has activated the teleporter."
            });
        }
    }
}