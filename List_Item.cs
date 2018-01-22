using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Impressions_Ratings
{
    class List_Item
    {
        public string name;
        public int gameplay;
        public int controls;
        public int story;
        public int graphics;
        public int music;
        public int fun;

        public int index;
        public double average;

        public List_Item()
        {
            name = "Default";
            gameplay = -1;
            controls = -1;
            story = -1;
            graphics = -1;
            music = -1;
            fun = -1;
            average = -1;
        }
        public List_Item(string n)
        {
            name = n;
            gameplay = -1;
            controls = -1;
            story = -1;
            graphics = -1;
            music = -1;
            fun = -1;
            average = -1;
        }
        public List_Item(string n, int ga, int c, int s, int gr, int m, int f)
        {
            name = n;
            gameplay = ga;
            controls = c;
            story = s;
            graphics = gr;
            music = m;
            fun = f;
            average = ((double)(ga + c + s + gr + m + f)) / 6;
        }

        public void RateGame()
        {
            gameplay = InputChecker("Gameplay");
            controls = InputChecker("Controls");
            story = InputChecker("Story");
            graphics = InputChecker("Graphics");
            music = InputChecker("Music");
            fun = InputChecker("Fun");

            average = ((double)(gameplay + controls + story + graphics + music + fun)) / 6;
        }
        private int InputChecker(string attribute)
        {
            int rating = -1;
            string input;

            while (rating == -1)
            {
                Console.Clear();
                Console.WriteLine(" Give your rating (1-10) for:\n\n {0}", attribute);
                input = Console.ReadLine();

                try
                {
                    rating = Convert.ToInt32(input);
                    if (rating < 1 || rating > 10)
                        rating = -1;
                }
                catch (Exception)
                {
                    rating = -1;
                }
            }

            return rating;
        }

        public void PrintCard()
        {
            string input;

            Console.Clear();
            Console.WriteLine("==========================================================");
            Console.WriteLine("\t\t{0}", name);
            Console.WriteLine("==========================================================");
            Console.WriteLine();
            Console.WriteLine("\tGameplay: {0}/10\t\tControls: {1}/10", gameplay, controls);
            Console.WriteLine();
            Console.WriteLine("\tStory: {0}/10\t\tGraphics: {1}/10", story, graphics);
            Console.WriteLine();
            Console.WriteLine("\tMusic: {0}/10\t\tFun: {1}/10", music, fun);
            Console.WriteLine();
            Console.WriteLine("==========================================================");
            Console.WriteLine();
            Console.WriteLine("\t\tAverage: {0:N2}/10", average);
            Console.WriteLine();
            Console.WriteLine("==========================================================");
            Console.WriteLine();

            if (average == -1)
            {
                Console.WriteLine(" Would you like to rate this game (y/n)?");
                input = Console.ReadLine();

                if (input.ToLower() == "y")
                    RateGame();
            }
            else
            {
                Console.WriteLine(" Press Enter to Continue . . .");
                Console.ReadLine();
            }
        }
    }
}
