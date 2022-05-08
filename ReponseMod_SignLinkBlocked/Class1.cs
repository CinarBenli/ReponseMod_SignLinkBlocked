using Newtonsoft.Json;
using Rocket.API;
using Rocket.Core.Commands;
using Rocket.Core.Plugins;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ReponseMod_SignLinkBlocked
{
    public class Class1 : RocketPlugin<Config>
    {
        protected override void Load()
        {
            base.Load();
            BarricadeManager.onModifySignRequested += Sign;
        }
        internal static void Send(string message, string webhook, string logo)
        {
            try
            {
                var wr = (HttpWebRequest)WebRequest.Create(webhook);
                wr.ContentType = "application/json";
                wr.Method = "POST";
                using (var sw = new StreamWriter(wr.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(new
                    {
                        username = "Reponse Mod - Sign Advertisement Blocked",
                        avatar_url = logo,
                        embeds = new[]
                        {
                            new
                            {
                                description = message,
                                title = "Reponse Mod - Sign Advertisement Blocked",
                                color = 15844367,
                            }
                        }
                    });
                    sw.Write(json);
                }
                var response = (HttpWebResponse)wr.GetResponse();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private void Sign(CSteamID instigator, InteractableSign sign, ref string text, ref bool shouldAllow)
        {
            UnturnedPlayer unturnedPlayer = UnturnedPlayer.FromCSteamID(instigator);
            if (unturnedPlayer.IsAdmin)
                return;
            foreach (string str in this.Configuration.Instance.BlockedList)
            {
                if (text.ToLower().Contains(str))
                {
                    shouldAllow = false;
                    ChatManager.serverSendMessage(Configuration.Instance.WarningMessage, Color.white, (SteamPlayer)null, unturnedPlayer.SteamPlayer(), (EChatMode)4, this.Configuration.Instance.ServerLogo, true);
                    Send($"{unturnedPlayer.CharacterName}, The Named User Tried to Advertise the Signage \n Information; \n Steam Id: {unturnedPlayer.CSteamID} \n\n\n **Text;** \n {text}", Configuration.Instance.DiscordWebhook, Configuration.Instance.ServerLogo);
                    break;
                }
            }
        }
        [RocketCommand("signblock", "You Add the Forbidden Word October The Sign.", "/signblock <text>", AllowedCaller.Both)]
        [RocketCommandPermission("reponse.blockadd")]
        public void sasa(IRocketPlayer caller, string[] args)
        {
            string değer = "";
            for (int i = 0; i < args.Length; i++)
            {
                değer = değer + " " + args[i];
            }
            this.Configuration.Instance.BlockedList.Add(değer);
            this.Configuration.Save();
        }
    }
}
