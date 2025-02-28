﻿using FS0924_S13_L4.Models;

bool loop = true;

while (loop)
{
    Console.Clear();
    Console.WriteLine("==========OPERAZIONI==========");
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1.: Login");
    Console.WriteLine("2.: Logout");
    Console.WriteLine("3.: Verify last login");
    Console.WriteLine("4.: Show all logins");
    Console.WriteLine("5.: Exit");

    string choice = Console.ReadLine();
    if (int.TryParse(choice, out int value))
    {
        switch (value)
        {
            case 1:
                if (!User.IsUserLogged())
                {
                    Console.Clear();
                    Console.Write("Username: ");
                    string username = Console.ReadLine();

                    Console.Write("Password: ");
                    string password = Console.ReadLine();
                    Console.Write("Repeat password: ");
                    string confirmPassword = Console.ReadLine();

                    if (password == confirmPassword)
                    {
                        if (User.GetUsername() == null)
                        {
                            User.SetUserInfo(username, password, DateTime.Now);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Welcome {User.GetUsername()}!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (User.GetUsername() == username)
                        {
                            if (User.Login(password, DateTime.Now))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(
                                    $"Welcome {User.GetUsername()}! Nice to met you again!"
                                );
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("ERROR! Check your password!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(
                            "ERROR! Passwords don't match! Press a key to continue.."
                        );
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Hi {User.GetUsername()}, you'r alredy logged!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.ReadKey();
                break;

            case 2:
                if (User.Logout())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Bye bye, see you soon!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You'r not logged!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.ReadKey();
                break;

            case 3:
                if (User.IsUserLogged())
                {
                    Console.WriteLine($"Your last log in was at: {User.GetLastAccess()}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You'r not logged!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.ReadKey();
                break;

            case 4:
                if (User.IsUserLogged())
                {
                    var allAccesses = User.GetAllAccesses();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    foreach (DateTime access in allAccesses)
                    {
                        Console.WriteLine($"{access}");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You'r not logged!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.ReadKey();
                break;

            case 5:

                loop = false;
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR! Invalid option! Press a key to continue..");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                break;
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("ERROR! Invalid option! Press a key to continue..");
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
    }
}
