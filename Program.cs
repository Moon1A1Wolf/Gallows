using Gallows;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gallows
{
    public class Picture
    {
        string gallows = @"
                                          _____________
                                           |  
                                           |  
                                           |  
                                           |                             
                                        ___|_____           
            ";
        string rope = @"
                                          _____________
                                           |         |
                                           |  
                                           |  
                                           |                             
                                        ___|_____          
            ";
        string stool = @"
                                          _____________
                                           |         |
                                           |  
                                           |  
                                           |         _                   
                                        ___|_____   |-|          
             ";
        string head = @"
                                          _____________
                                           |         |       
                                           |         O           
                                           |         
                                           |         _                   
                                        ___|_____   |-|            
            ";
        string body = @"
                                          _____________
                                           |         |       
                                           |         O           
                                           |         |      
                                           |         _                   
                                        ___|_____   |-| 
            ";
        string leftArm = @"
                                          _____________
                                           |         |       
                                           |         O           
                                           |        /|         
                                           |         _                   
                                        ___|_____   |-| 
            ";
        string rihtArm = @"
                                          _____________
                                           |         |       
                                           |         O           
                                           |        /|\          
                                           |         _                   
                                        ___|_____   |-| 
            ";
        string leftLeg = @"
                                          _____________
                                           |         |       
                                           |         O           
                                           |        /|\
                                           |        /_                   
                                        ___|_____   |-| 
            ";
        string rihtLeg = @"
                                          _____________
                                           |         |       
                                           |         O           
                                           |        /|\
                                           |        /_\                   
                                        ___|_____   |-| 
            ";
        string hangman = @"
    

                   ██╗  ██╗ █████╗ ███╗   ██╗ ██████╗ ███╗   ███╗ █████╗ ███╗   ██╗
                   ██║  ██║██╔══██╗████╗  ██║██╔════╝ ████╗ ████║██╔══██╗████╗  ██║
                   ███████║███████║██╔██╗ ██║██║  ███╗██╔████╔██║███████║██╔██╗ ██║
                   ██╔══██║██╔══██║██║╚██╗██║██║   ██║██║╚██╔╝██║██╔══██║██║╚██╗██║
                   ██║  ██║██║  ██║██║ ╚████║╚██████╔╝██║ ╚═╝ ██║██║  ██║██║ ╚████║
                   ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝
            ";
        string death = @"
                      ▓██   ██▓ ▒█████   █    ██    ▓█████▄  ██▓▓█████ ▓█████▄ 
                       ▒██  ██▒▒██▒  ██▒ ██  ▓██▒   ▒██▀ ██▌▓██▒▓█   ▀ ▒██▀ ██▌
                        ▒██ ██░▒██░  ██▒▓██  ▒██░   ░██   █▌▒██▒▒███   ░██   █▌
                        ░ ▐██▓░▒██   ██░▓▓█  ░██░   ░▓█▄   ▌░██░▒▓█  ▄ ░▓█▄   ▌
                        ░ ██▒▓░░ ████▓▒░▒▒█████▓    ░▒████▓ ░██░░▒████▒░▒████▓ 
                         ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒     ▒▒▓  ▒ ░▓  ░░ ▒░ ░ ▒▒▓  ▒ 
                       ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░     ░ ▒  ▒  ▒ ░ ░ ░  ░ ░ ▒  ▒ 
                       ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░     ░ ░  ░  ▒ ░   ░    ░ ░  ░ 
                       ░ ░         ░ ░     ░           ░     ░     ░  ░   ░    
                       ░ ░                           ░                  ░      
            ";
        string rules = @"
  _____________________________________________________________________________________________
 / \                            ___,   __   _, __    ____, ____                                \.
|   |                          (-|_)  (-|  |  (-|   (-|_, (-(__`                               |.
|   |                           _| \_,  |__|_, _|__, _|__, ____)                               |.
 \__|                          (              (     (     (                                    |.
    |                                                                                          |.
    |   Игра ""Виселица"" - это  игра на угадывание слова. Компьютер  выбирает  слово из заранее |.
    | заданного  списка  слов, а  игрок  должен  угадать  это  слово,  вводя буквы  по  одной. |.
    |                                                                                          |.
    | При  каждой  неудачной  попытке  игрока  отгадать  букву,  на  экране  появляется  новый |.
    | элемент  виселицы. Если  игрок не угадывает слово до того, как виселица будет  полностью |.
    | нарисована,  он  проигрывает.                                                            |.
    |                                                                                          |.
    | Игроку  дается  определенное количество попыток (обычно 6, но  по просьбе  преподавателя |.
    | стало 9) для угадывания слова. При каждой попытке игрок должен вводить только одну букву.|.
    | Если  игрок  вводит больше  одной буквы, программа  должна  выдать сообщение об ошибке и |.
    | запросить  ввод  буквы  еще  раз.                                                        |.
    |                                                                                          |.
    | Если  игрок  угадывает букву, программа  должна  отобразить эту  букву в соответствующей |.
    | позиции  слова. Если  игрок  угадывает все  буквы в слове до  того, как  виселица  будет |.
    | полностью  нарисована,  он  побеждает.                                                   |.
    |   _______________________________________________________________________________________|___
    |  /                                                                                          /.
    \_/__________________________________________________________________________________________/. ";

        public string Print(int item)
        {
            string[] pics = { gallows, rope, stool, head, body, leftArm, rihtArm, leftLeg, rihtLeg, hangman, death, rules };
            return pics[item];
        }

    }

    public class Menu2
    {
        Picture pic = new Picture();

        string[] menu = { "START  AGAIN", "    MENU    " };
        int index = 0;
        bool fl = true;

        public void Menu()
        {

            while (fl == true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine('\n' + pic.Print(10));
                Console.ResetColor();

                for (int i = 0; i < menu.Length; i++)
                {
                    if (i == index)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\t\t\t\t\t  | " + menu[i] + " |");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("\n\t\t\t\t\t    " + menu[i]);
                    }
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                Console.Clear();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        index--;
                        if (index < 0)
                        {
                            index = menu.Length - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        index++;
                        if (index >= menu.Length)
                        {
                            index = 0;
                        }
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (index)
                        {
                            case 0:
                                fl = false;

                                StateGame state = new StateGame();
                                state.Play(keyInfo);

                                break;
                            case 1:
                                fl = false;
                                Thread.Sleep(100);

                                Game start = new Game();
                                start.NewGame();

                                break;
                        }
                        break;

        }   }   }
    }

    public class StateGame
    {
        Menu2 menu2 = new Menu2();
        Picture pic = new Picture();
        bool fl = true;
        int num = 1;

        public void Play(ConsoleKeyInfo keyInfo)
        {
            while (fl == true && keyInfo.Key != ConsoleKey.Backspace)
            {
                string path = "words.txt";
                string[] allWords = File.ReadAllLines(path);

                string[] themesInFile = allWords.Select(w => w.Split(',')[1]).ToArray();

                Random random = new Random();
                string theme = themesInFile[random.Next(themesInFile.Length)];

                string[] wordsInTheme = allWords.Where(w => w.Split(',')[1].ToLower() == theme.ToLower()).Select(w => w.Split(',')[0]).ToArray();
                string word = wordsInTheme[random.Next(wordsInTheme.Length)];

                string hiddenWord = new string('_', word.Length);
                int attempts = 9;

                while (fl == true)
                {
                    Console.Clear();

                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t Backspace -> EXIT \n\n");
                    Console.WriteLine("\t\t\t\t\t    LEVEL " + num + '\n');

                    Console.Write("\t\t\t\t\tТЕМА: " + theme.ToUpper());
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(" (" + word + ')');
                    Console.ForegroundColor = ConsoleColor.White;

                    string print = string.Join(" ", hiddenWord.ToCharArray());
                    Console.WriteLine(pic.Print(9 - attempts) + '\n');
                    Console.WriteLine("\t\t\t\t    СЛОВО: " + print.ToUpper() + '\n');
                    Console.WriteLine("\t\t\t\t    ПОПЫТОК: " + attempts);
                    Console.Write("\t\t\t\t    БУКВА: ");

                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Backspace)
                        break;
                    else if (Char.IsLetter(keyInfo.KeyChar))
                    {
                        Console.WriteLine();
                        bool foundLetter = false;
                        for (int i = 0; i < word.Length; i++)
                        {
                            if (word[i] == keyInfo.KeyChar)// || word[i].ToString() == keyInfo.KeyChar.ToString().ToLower())
                            {
                                hiddenWord = hiddenWord.Remove(i, 1).Insert(i, keyInfo.KeyChar.ToString());
                                foundLetter = true;
                                Console.WriteLine();
                            }
                        }

                        if (foundLetter == false)
                        {
                            attempts--;
                            Console.WriteLine("\n\t\t\t\t\tТакой буквы нет в слове!\n");
                            Thread.Sleep(500);
                        }
                        if (hiddenWord == word)
                        {
                            Console.WriteLine("\n\t\t\t\tПоздравляем! Вы угадали слово: " + word + '\n');
                            num++;

                            Thread.Sleep(1500);
                            Console.Clear();
                            break;
                        }
                        else if (attempts == 0)
                        {
                            fl = false;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine('\n' + pic.Print(10));
                            Console.ResetColor();

                            Console.WriteLine("\t\t\t_____________");
                            Console.WriteLine("\t\t\t |         |");
                            Console.WriteLine("\t\t\t |         O\t\tК сожалению, вы не угадали слово:(");
                            Console.WriteLine("\t\t\t |        /|\\\t\tЗагаданное слово было: " + word);
                            Console.WriteLine("\t\t\t |        / \\");
                            Console.WriteLine("\t\t      ___|_____");

                            Thread.Sleep(2000);

                            menu2.Menu();
            }   }   }   }
        }

        public void Description()
        {
            Console.WriteLine(pic.Print(11));
            ConsoleKeyInfo keyInfo = Console.ReadKey();
        }

        public void Author()
        {
            System.Diagnostics.Process.Start("https://github.com/Moon1A1Wolf");
        }

    }

    public class Game
    {
        public void NewGame()
        {
            StateGame state = new StateGame();
            string[] menuItems = { "   PLAY    ", "DESCRIPTION", "  AUTHOR   " };
            int selectedIndex = 0;
            Picture pic = new Picture();

            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(pic.Print(9) + "\n");
                Console.ForegroundColor = ConsoleColor.White;

                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\t\t\t\t\t  | " + menuItems[i] + " |");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine("\n\t\t\t\t\t    " + menuItems[i]);
                    }
                }
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex--;

                        if (selectedIndex < 0)
                            selectedIndex = menuItems.Length - 1;

                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex++;

                        if (selectedIndex >= menuItems.Length)
                            selectedIndex = 0;

                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();

                        switch (selectedIndex)
                        {
                            case 0:
                                {
                                    state.Play(keyInfo);
                                    break;
                                }
                            case 1:
                                {
                                    state.Description();
                                    break;
                                }
                            case 2:
                                {
                                    state.Author();
                                    break;
                                }
                        }
                        break;
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 25);

            Game start = new Game();
            start.NewGame();
        }
    }
}
