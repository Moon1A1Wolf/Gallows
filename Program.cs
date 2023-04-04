using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gallows
{
    class HangmanGame
    {
         static void Main()
         {
            string path = "words.txt";
            string[] allWords = File.ReadAllLines(path);

            string[] themesInFile = allWords.Select(w => w.Split(',')[1]).ToArray();

            Random random = new Random();
            string theme = themesInFile[random.Next(themesInFile.Length)];

            string[] wordsInTheme = allWords.Where(w => w.Split(',')[1].ToLower() == theme.ToLower()).Select(w => w.Split(',')[0]).ToArray();
            string word = wordsInTheme[random.Next(wordsInTheme.Length)];
            
            
            Console.WriteLine("\t\tТЕМА: " + theme.ToUpper() + " - " + word);

            string hiddenWord = new string('_', word.Length);

            int attempts = 6;

            while (true)
            {
                string print = string.Join(" ", hiddenWord.ToCharArray());

                Console.WriteLine("СЛОВО: " + print.ToUpper() + '\n');
                Console.WriteLine("ПОПЫТОК: " + attempts);

                Console.Write("БУКВА: ");
                char letter = Console.ReadKey().KeyChar;
                Console.WriteLine();

                bool foundLetter = false;
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == letter)
                    {
                        hiddenWord = hiddenWord.Remove(i, 1).Insert(i, letter.ToString());
                        foundLetter = true;
                        Console.WriteLine();
                    }
                }

                if (!foundLetter)
                {
                    attempts--;
                    Console.WriteLine("Такой буквы нет в слове\n");
                }

                if (hiddenWord == word)
                {
                    Console.WriteLine("Поздравляем! Вы угадали слово: " + word + '\n');
                    break;
                }
                else if (attempts == 0)
                {
                    Console.WriteLine("К сожалению, вы не угадали слово:( \n\t\tЗагаданное слово было: " + word + '\n');
                    break;
                }
            }
        }
    }




    /*string gallows = @"
            ________                     __          __
           /  ______|       _____ _     |  |        |  |          ______    __            __   ______
          /  /             / ____| |    |  |        |  |         / ____ \   \ \    /\    / /  / _____|
         |  |     ___     / /    | |    |  |        |  |        / /    \ \   \ \  /  \  / /  |  |____
         |  |     \  \   / /     | |    |  |        |  |       | |      | |   \ \/ /\ \/ /    \____  \
          \  \____|  |   \ \____/| |    |  |____    |  |____    \ \____/ /     \  /  \  /     _____|  |
           \________/     \_____/|_|    |_______|   |_______|    \______/       \/    \/     |_______/ 

           

                        |   |    __            __              __    
                        |___|   /  \|  |\  |  /  \|  |\  /|   /  \|  |\  |  
                        |   |  |    |  | \ |  \__/|  | \/ |  |    |  | \ |
                        |   |   \__/|  |  \|  ___/   |    |   \__/|  |  \| 


    ___________________
    |                 |       ТЕМА: ЖИВОТНЫЕ 
    |                          
    |                          
    |                          
    |                          СЛОВО: _ _ _ _ _ _ 
    |                          ПОПЫТОК: 6
    |                          БУКВА:
    |                          
 ___|________                  
                                                          ---
                        А      Б      В      Г      Д    | Е |    Ж      З      И      К
                                                          ---

                        Л      Н      О      П      Р      С      Т      У      Ф      Х


                        Ц      Ч      Ш      Щ      Ъ      Ь      Ы      Э      Ю      Я


";*/
}
