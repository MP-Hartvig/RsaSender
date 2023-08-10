using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;

namespace RsaSender
{
    internal class Gui
    {
        EncryptionService es = new();
        string navigationMessage = "press enter twice to go to next step ";
        string goBackMessage = "or escape to go back to start";

        /// <summary>
        /// The graphical user interface start menu
        /// </summary>
        public void StartMenu()
        {
            MenuHeader("Encryption with public key");
            bool menuBool = true;
            Console.WriteLine("Press escape to exit the application \n\n" + "Write a text to encrypt, " + navigationMessage + "\n");

            while (menuBool)
            {
                string input = Console.ReadLine()!;

                if (input != string.Empty)
                {
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        InsertPathToKeyMenu(input);
                    }
                }

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    ExitApplication();
                }
            }
        }

        /// <summary>
        /// Menu for giving path to key input
        /// </summary>
        /// <param name="input">User input to be encrypted</param>
        private void InsertPathToKeyMenu(string input)
        {
            bool insertKeyMenu = true;

            Console.WriteLine("\nInsert the path to the public key xml file, " + navigationMessage + goBackMessage);

            while (insertKeyMenu)
            {
                string pathToKey = Console.ReadLine()!;

                if (input != string.Empty)
                {
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        ShowEncryptionResult(input, pathToKey, es.StartEncryptionProcess(input, pathToKey));
                    }
                }

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    StartMenu();
                }
            }
        }

        /// <summary>
        /// Creates a menu to show the result of the encryption process
        /// </summary>
        /// <param name="input">User input to be decrypted</param>
        /// <param name="pathToKey">Path to the xml file containing the public key</param>
        /// <param name="cipherInfo">The encrypted message and time spent on the operation</param>
        private void ShowEncryptionResult(string input, string pathToKey, string[] cipherInfo)
        {
            MenuHeader("Result of the encryption process");
            Console.WriteLine("Input: " + input + "\n");
            Console.WriteLine("Path to key: " + pathToKey + "\n");
            Console.WriteLine("Cipher text in base64: " + cipherInfo[0] + "\n");
            Console.WriteLine("Time spent on operation: " + cipherInfo[1]);

            Console.WriteLine("Press escape to go back to the start menu");

            bool resultMenu = true;

            while (resultMenu)
            {
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    StartMenu();
                }
            }
        }

        /// <summary>
        /// Creates a menuheader for the current menu
        /// </summary>
        /// <param name="title">Title to display in the menu header</param>
        private void MenuHeader(string title)
        {
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("           " + title);
            Console.WriteLine("================================================== \n\n");
        }

        /// <summary>
        /// Closes the application
        /// </summary>
        private void ExitApplication()
        {
            Environment.Exit(0);
        }
    }
}
