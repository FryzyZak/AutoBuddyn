using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version = System.Version;

namespace AutoCloseApp
{

    class Program
    {
        public static Obj_HQ AllyNexus;
        public static Obj_HQ EnemyNexus;

        static void Main(string[] args)
        {          
            Loading.OnLoadingComplete += delegate
            {
                AllyNexus = ObjectManager.Get<Obj_HQ>().First(n => n.IsAlly);
                EnemyNexus = ObjectManager.Get<Obj_HQ>().First(n => n.IsEnemy);
                Core.DelayAction(OnEndGame, 20000);
                Chat.Print("AutoCloseApp: By DevAkumetsu");
            };   
        }
         
        
        public static void OnEndGame() {

            if (AllyNexus != null && EnemyNexus != null && (AllyNexus.Health > 1) && (EnemyNexus.Health > 1))
            {
                Core.DelayAction(OnEndGame, 5000);
                return;
            }

            Core.DelayAction(() =>
            {        
                Game.QuitGame(); // new close game from API 6.5
            }, 14000);
        }
    }
}
