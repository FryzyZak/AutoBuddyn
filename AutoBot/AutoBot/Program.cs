using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Events;
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

            Hacks.DisableTextures = true;
            Hacks.AntiAFK = true;
            Hacks.RenderWatermark = false;

            ManagedTexture.OnLoad += ManagedTexture_OnLoad;
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {

            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            string scriptVersion = v.Major + "." + v.MajorRevision + "." + v.Minor + "." + v.MinorRevision;
            // version of addon
            Chat.Print(AddonName + " made by " + Author + " loaded!");            
            Chat.Print("Version Loaded" + scriptVersion); 

            // menu AutoBot
            Config = MainMenu.AddMenu("Auto Bot", "AutoBot");
            Config.Add("activeab", new CheckBox("Active the AutoBot?"));
            Config.Add("textureab", new CheckBox("Show Texture? (f5 to load)"), false);

            Game.OnUpdate += On_Update;

        }

        private static void On_Update(EventArgs args)
        {
            if (!Config["activeab"].Cast<CheckBox>().CurrentValue)
                return;
                      
            // Chat config
            if (Player.Instance.IsDead)
            {               
                return;
            }
        }
        

        private static void ManagedTexture_OnLoad(OnLoadTextureEventArgs args)
        {
            if (!Config["textureab"].Cast<CheckBox>().CurrentValue)
                return;

            args.Process = false;
        }
    }
}
