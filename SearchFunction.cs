using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Impressions_Ratings
{
    class SearchFunction
    {
        public SearchFunction() { }

        public List_Item SearchFor(List<List_Item> GameList, string input)
        {
            int counter = 1;
            int dex = -1;
            int game_choice = -1;

            string game_selection;

            // Gets a list with all the titles containing the input string.
            List<List_Item> SearchList = pSearch(GameList, input);

            if (SearchList.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("==============================");
                Console.WriteLine(" Search returned 0 results.");
                Console.WriteLine(" Press Enter to Continue . . .");
                Console.WriteLine("==============================");

                return null;
            }

            if (SearchList.Count > 20)
            {
                Console.WriteLine("====================================");
                Console.WriteLine(" List returned too large to display.");
                Console.WriteLine(" Please try a more specific search.");
                Console.WriteLine(" Press Enter to Continue . . .");
                Console.WriteLine("====================================");

                return null;
            }

            while (game_choice == -1)
            {
                game_choice = -1;
                counter = 1;

                // Now we need to display all the games returned by the search with numbers
                Console.Clear();
                Console.WriteLine("\tList of Games");
                Console.WriteLine("==================================");

                foreach (List_Item item in SearchList)
                {
                    Console.WriteLine(" {0}: {1}", counter++, item.name);
                }

                Console.WriteLine("\n\n Search returned these games. Which would you like?");
                game_selection = Console.ReadLine();

                game_choice = InputParser(game_selection);
                game_choice--;

                if (game_choice < 0 || game_choice >= counter)
                    game_choice = -1;
            }

            dex = SearchList[game_choice].index;

            return GameList[dex];
        }

        private int InputParser(string input)
        {
            int result = -1;

            try
            {
                result = Convert.ToInt32(input);
            }
            catch (Exception)
            {
                result = -1;
            }

            return result;
        }

        private List<List_Item> pSearch(List<List_Item> GameList, string input)
        {
            List<List_Item> SearchList = new List<List_Item>();

            foreach (List_Item item in GameList)
                if (item.name.ToLower().Contains(input.ToLower()))
                    SearchList.Add(item);

            return SearchList;
        }
    }
}
