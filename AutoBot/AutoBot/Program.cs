using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Events;
using EloBuddy.Sandbox;
using Version = System.Version;
using System.Reflection;

namespace AutoBot
{
    class Program
    {
        public static string Author = "devAkumetsu";
        public static string AddonName = "AutoBot";
        public static Menu Config;
        public static Random Rnd = new Random(Environment.TickCount);

        static void Main(string[] args)
        {
            // load the addon
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            // version of addon
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            string scriptVersion = v.Major + "." + v.MajorRevision + "." + v.Minor + "." + v.MinorRevision;      
            Chat.Print(AddonName + " made by " + Author + " loaded!");            
            Chat.Print("Version Loaded" + scriptVersion); 

            // menu AutoBot
            Config = MainMenu.AddMenu("Auto Bot", "AutoBot");
            Config.Add("menu_active_autobot", new CheckBox("Active the AutoBot?"), true);
            Config.Add("menu_hacks_autobot", new CheckBox("Active Texture? (f5 to load)"), false);
            Config.Add("menu_chatting_autobot", new CheckBox("Active Chatting BOT?"), false);

            Game.OnUpdate += On_Update;

        }

        private static void On_Update(EventArgs args)
        {
            // check if we need to active the addon ifself
                if (!Config["menu_active_autobot"].Cast<CheckBox>().CurrentValue)
                    return;

            // Setup hacks texture for BOTTING
            if (!Config["menu_hacks_autobot"].Cast<CheckBox>().CurrentValue) { 
                   // Hacks.Init();
            }

            // Setup Chatting BOT
            if (!Config["menu_chatting_autobot"].Cast<CheckBox>().CurrentValue) { 
                  //  Chatting.Init();
            }
        }

    }
}
