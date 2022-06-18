using System;

using NGL.LinkBot.Core;

namespace NGL.LinkBot.CLI
{
    internal class Program
    {
        private static void DisplayTitle(char identifier, string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write($" [{identifier}] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text);
        }

        static void Main(string[] args)
        {
            Console.Title = "NGL.Link Bot - Developed By: SaturnKai";

            DisplayTitle('-', "Enter in Username of Profile:\n\n > ", ConsoleColor.Cyan);
            string name = Console.ReadLine();

            Console.WriteLine("");
            DisplayTitle('*', "Loading Profile...\n\n", ConsoleColor.DarkCyan);
            if (!Bot.ProfileExists(name))
            {
                DisplayTitle('!', "Profile Does Not Exist!\n\n", ConsoleColor.Red);
                Console.ReadKey();
                Environment.Exit(0);
            }

            DisplayTitle('-', $"Successfully Loaded Profile: {name}! Enter in Message You Would Like to Spam:\n\n > ", ConsoleColor.Green);
            string message = Console.ReadLine();
            Console.WriteLine("");

            int sent = 0;
            while (true)
            {
                Console.Title = $"NGL.Link Bot - Developed By: SaturnKai | Sent: {sent}";
                if (Bot.SendMessage(name, message))
                {
                    DisplayTitle('-', $"Successfully Sent Message: {message}!\n", ConsoleColor.Green);
                    sent++;
                }
                else
                    DisplayTitle('!', $"Failed to Send Message: {message}!\n", ConsoleColor.Red);
            }
        }
    }
}