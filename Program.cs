using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace First_Impressions_Ratings
{
    class Program
    {
        static string LIST_PATH = "Lists\\";

        static void Main(string[] args)
        {
            // Housekeeping, boredom lies ahead
            string path = LIST_PATH;

            // Create Lists Directory if one doesn't exist.
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            ExampleFile(path);

            // The Program begins
            MainMenu();
        }

        // Creates the example file
        public static void ExampleFile(string path)
        {
            path = path + "Example.txt";

            if (!File.Exists(path))
            {
                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    sw.WriteLine(FileHeader());
                    sw.WriteLine("Example Game 1");
                    sw.WriteLine("Example Game 2");
                    sw.WriteLine("Example Game 3");
                }
            }
        }

        // Returns the string for the list File Header.
        public static string FileHeader()
        {
            string fh = "# Format for List\n";
            fh += "# <Title>, <Gameplay>, <Controls>, <Story>, <Graphics>, <Music>, <Fun>\n";
            fh += "# For more information, view README.txt that is included with this app\n";

            return fh;
        }

        public static void MainMenu()
        {
            int menuChoice = -1;
            string input;

            while (menuChoice != 0)
            {
                Console.Clear();
                Console.WriteLine("=====================================");
                Console.WriteLine(" Main Menu");
                Console.WriteLine("=====================================");

                Console.WriteLine("\n 1. View Available Lists");
                Console.WriteLine();
                Console.WriteLine(" 0. Exit\n");

                Console.WriteLine("=====================================");

                Console.WriteLine("\n Enter your choice:");
                input = Console.ReadLine();

                try
                {
                    menuChoice = Convert.ToInt32(input);
                }
                catch (Exception e)
                {
                    menuChoice = -1;
                }

                switch (menuChoice)
                {
                    case 1:
                        OpenGameLists();
                        break;
                    default:
                        break;
                }
            }
        }

        public static void OpenGameLists()
        {
            string path = LIST_PATH;
            string filepath = "false";
            string input;
            int choice;
            int counter;

            string[] files = System.IO.Directory.GetFiles(path, "*.txt");

            for (int i = 0; i < files.Length; i++)
                files[i] = files[i].Substring(files[i].IndexOf('\\') + 1);

            while (filepath == "false")
            {
                Console.Clear();
                Console.WriteLine("=====================================");
                Console.WriteLine(" List Menu");
                Console.WriteLine("=====================================\n");

                counter = 0;
                foreach (string element in files)
                {
                    Console.WriteLine(" {0}: {1}", counter + 1, files[counter]);
                    counter++;
                }

                Console.WriteLine("\n 0: Exit to Main\n");

                Console.WriteLine("=====================================");

                Console.WriteLine(" Enter your choice:");
                input = Console.ReadLine();

                try
                {
                    choice = Convert.ToInt32(input);

                    if (choice == 0)
                        break;

                    choice--;
                    filepath = files[choice];
                }
                catch (Exception)
                {
                    filepath = "false";
                }

                ListMenu(filepath);
            }            
        }

        public static void ListMenu(string path)
        {            
            string filepath = LIST_PATH + path;
            string input;
            string s;
            string[] values;
            int choice = -1;
            int counter = 0;

            GameRandomizer gr = new GameRandomizer();
            SearchFunction sf = new SearchFunction();
            List_Item SearchResult = null;
            List<List_Item> GameList = new List<List_Item>();

            if (!File.Exists(filepath))
            {
                Console.Clear();
                Console.WriteLine(" Error: \"{0}\" does not exist. Exiting to Main Menu.", filepath);
                Console.WriteLine(" Press Enter to Continue . . .");
                Console.ReadLine();
                return;
            }

            using (StreamReader sr = File.OpenText(filepath))
            {
                s = "";

                while ((s = sr.ReadLine()) != null)
                {
                    if (s == "")
                        continue;
                    else if (s[0] == '#' || s == "\n")
                        continue;

                    values = s.Split(';');

                    if (values.Length == 1)
                        GameList.Add(new List_Item(values[0]));
                    else
                        GameList.Add(new List_Item(
                            values[0],
                            Convert.ToInt32(values[1]),
                            Convert.ToInt32(values[2]),
                            Convert.ToInt32(values[3]),
                            Convert.ToInt32(values[4]),
                            Convert.ToInt32(values[5]),
                            Convert.ToInt32(values[6])));
                } // End of File Read and List creation
            } // End of StreamReader

            GameList.Sort((x, y) => x.name.CompareTo(y.name));

            foreach (List_Item item in GameList)
            {
                item.index = counter++;
            }

            while (choice != 0)
            {
                Console.Clear();
                Console.WriteLine("=====================================");
                Console.WriteLine(" {0}", path);
                Console.WriteLine("=====================================\n");

                Console.WriteLine(" 1. Search for Title");
                Console.WriteLine(" 2. Random Game");
                Console.WriteLine(" 3. Generate Top 10 List (Nonfunctional)");

                Console.WriteLine(" 0. Exit to Main");
                Console.WriteLine("=====================================\n");

                Console.WriteLine(" Enter your choice:");
                input = Console.ReadLine();

                try
                {
                    choice = Convert.ToInt32(input);
                }
                catch (Exception)
                {
                    choice = -1;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n\n\n Enter part of the game name you would like to search for:");
                        input = Console.ReadLine();
                        SearchResult = sf.SearchFor(GameList, input);

                        if (SearchResult != null)
                            SearchResult.PrintCard();

                        break;
                    case 2:
                        gr.RandomGame(GameList);
                        break;
                    default:
                        break;
                }
            } // End While Loop

            // On exit, write the header info to the file and then write the list to the file
            // The old file is NOT retained
            using (StreamWriter sw = new StreamWriter(filepath, false))
            {
                sw.WriteLine(FileHeader());

                foreach (List_Item item in GameList)
                {
                    sw.Write("{0}; {1}; {2}; {3}; ", item.name, item.gameplay, item.controls, item.story);
                    sw.Write("{0}; {1}; {2}", item.graphics, item.music, item.fun);
                    sw.WriteLine();
                }
            }
        }
        // End of the program, stop putting stuff below here
    }
}
