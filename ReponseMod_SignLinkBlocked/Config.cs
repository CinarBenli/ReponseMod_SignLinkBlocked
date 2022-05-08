using Rocket.API;
using System.Collections.Generic;

namespace ReponseMod_SignLinkBlocked
{
    public class Config : IRocketPluginConfiguration
    {
        public string WarningMessage;
        public string ServerLogo;
        public string DiscordWebhook;
        public List<string> BlockedList = new List<string>();
        public void LoadDefaults()
        {
            WarningMessage = "<color=red>Warning</color> Advertising Was Detected On The <color=orange>Sign</color>. If You Continue to Advertise, You will be <color=yellow>Banned</color>!";
            ServerLogo = "https://media.discordapp.net/attachments/959142220366237796/962008357990977626/122.png";
            DiscordWebhook = "https://discord.com/api/webhooks/967861057894879282/SCzX9wjfhwGee75qidIsPG8690W4jKXk1CGIvXtjSOy2iOapp0KkSokPWHMjoJDW9gto";
            BlockedList = new List<string> { "discord.gg", "discord.", "dc", "sunucumuza", "gelin", "d i s c o r d", "di", "sc", "d i s c o r d", "gg", "//", "g g ", "gg/", "g9", "./,", "./", "//", "gg", ":/", "rd", "rd", ".gg", ". g g", "rd", "or", "co", "ord", "sc", "scord", "iscord", " /", " sunucumuza", "sunucumuza", "gelmeyi", "unutmayın", "sunucumuz", "sunucu", "d i sc o r d. G9", "G9", "gg", " o r d ", "reklam", "türkiyenn en iyisi", "en iyisi", "dc", "dcord", "en iyi", "server", " s e r v e r ", "se", "ser" };

        }
    }
}