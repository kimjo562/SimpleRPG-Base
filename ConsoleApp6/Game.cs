using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Game                                                          // Out of the Scope
    {
        string playerName = "";
        int playerHealth = 100;

        public void Start()                                                                        // In the Scope
        {
            Welcome();                                                                             // Declaring the Function into use.

            bool alive = true;

            alive = Encounter(160);
            if(alive)
            {
             Console.WriteLine("Second Fight!\n");
             alive = Encounter(20);
            }

            Console.ReadKey();                                                                      // system("pause") + cin
        }

             void Welcome()                                                                         // <---- These are Functions
             {
                    // Player Section
                    Console.WriteLine("What is your name? ");
                    playerName = Console.ReadLine();                                                // Similar to cin
                    Console.WriteLine("Welcome " + playerName + "!\n");

             }

             bool Encounter(int monsterDamage)                                                      // <---- These are Functions
             {
                        // Monster Section
                    int monsterHealth = 100;

                    Console.WriteLine("A Monster has appeared!");
                    string action = "";
                    Console.WriteLine("What will you do?");
                    Console.WriteLine("Use numbers to declare action or words.");
                    Console.WriteLine("1.) Fight      2.) Flee\n");
                    action = Console.ReadLine();

                   if (action == "1" || action == "Fight" || action == "fight")                     // || = or
                   {
                        // Monster Attack
                        Console.WriteLine("The Monster attacks! " + playerName + " takes " + monsterDamage + " damage!");
                        playerHealth -= monsterDamage;
                        Console.WriteLine(playerName + " has " + playerHealth + " remaining.");
                        if(playerHealth <= 0)
                        {
                         Console.WriteLine(playerName + " was defeated.");
                         return false;
                         
                        }

                        // Player Attack
                        Console.WriteLine("You defeated the monster.\n");
                   }

                   else if (action == "2" || action == "Flee" || action == "flee")
                   {
                      // Escape!
                        Console.WriteLine("You sucessfully escaped.\n");

                   }
                   return true;
             }
             

    }
}
