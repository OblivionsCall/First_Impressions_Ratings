using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Impressions_Ratings
{
    class GameRandomizer
    {        
        public GameRandomizer()
        {

        }

        public void RandomGame(List<List_Item> GameList)
        {
            bool game_found = false;
            bool list_done = true;
            Random rnd = new Random();
            int index = 0;
            string input = "";

            foreach (List_Item item in GameList)
            {
                if (item.average == -1)
                {
                    list_done = false;
                    break;
                }
            }

            if (!list_done)
            {
                while (game_found == false)
                {
                    index = rnd.Next(0, GameList.Count);

                    if (GameList[index].average == -1)
                        game_found = true;
                }

                while (input != "done")
                {
                    Console.Clear();
                    Console.WriteLine("==========================================================");
                    Console.WriteLine("Your game is: {0}", GameList[index].name);
                    Console.WriteLine("==========================================================");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(" Go Play that for at least an hour and type 'done' when finished!");
                    input = Console.ReadLine();
                }

                GameList[index].RateGame();
                GameList[index].PrintCard();
            } // endif !list_done

            else
            {
                Console.Clear();
                Console.WriteLine(" You've rated every game on this list! Congratulations!");
                Console.WriteLine(" Press Enter to Continue . . .");
                Console.ReadLine();
            }
        }

    }
}
