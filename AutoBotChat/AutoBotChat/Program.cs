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

namespace AutoBotChat
{
    public static class Program
    {
        public static string Author = "devAkumetsu";
        public static string AddonName = "AutoBotChat";

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {

            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            string scriptVersion = v.Major + "." + v.MajorRevision + "." + v.Minor + "." + v.MinorRevision;

            Chat.Print(AddonName + " made by " + Author + " loaded!");  // set version          
            Chat.Print("Version Loaded" + scriptVersion); // set version

            // start menu
            MenuManager.Init(args);
        }
    }
}
