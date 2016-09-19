using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Events;
using System.Reflection;

namespace AutoBot
{
    class Chatting
    {
      
        public static Random Rand = new Random(Environment.TickCount);


        public static void Init()
        {

            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            

        }       
    }
}
