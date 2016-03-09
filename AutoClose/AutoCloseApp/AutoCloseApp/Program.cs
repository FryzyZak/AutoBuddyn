using EloBuddy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCloseAddon
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.OnUpdate += OnGameUpdate;
        }

        public static void OnGameUpdate(EventArgs args)
        {
            // new close game from API 6.5;
            Game.QuitGame(); 
        }       
    }
}
