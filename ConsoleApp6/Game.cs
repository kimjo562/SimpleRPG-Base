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
        int monsterHealth = 20;
        int playerDamage = 10;

        public void Start()                                                                        // In the Scope
        {
            Welcome();                                                                             // Declaring the Function into use.
            int monstersRemaining = 5;
            bool alive = true;

            // Fight until you lose.
            while (alive && monstersRemaining > 0)
            {
                Console.WriteLine("There are " + monstersRemaining + " monsters remaining.");

                alive = Encounter(20, 15);

                monstersRemaining--;

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

             bool Encounter(int monsterDamage, int monsterHealth)                                                      // <---- These are Functions
             {
                        // Monster Section
                    Console.WriteLine("A Monster has appeared!");
                    string action = "";
                 while (monsterHealth > 0 || playerHealth > 0)
                 { 
                    Console.WriteLine("What will you do?");
                    Console.WriteLine("Use numbers to declare action or words.");
                    Console.WriteLine("1.) Fight      2.) Flee\n");
                    action = Console.ReadLine();
              
                if (action == "1" || action == "Fight" || action == "fight")                     // || = or
                {
                   
                        // Monster Attack
                        Console.WriteLine("The Monster attacks! " + playerName + " takes " + monsterDamage + " damage!");
                        playerHealth -= monsterDamage;
                        Console.WriteLine(playerName + " has " + playerHealth + " health remaining.");
                        if (playerHealth <= 0)
                        {
                            Console.WriteLine(playerName + " was defeated.");
                            return false;

                        }

                        // Player Attack
                        Console.WriteLine("The monster takes " + playerDamage + " damage.");
                        monsterHealth -= playerDamage;
                        Console.WriteLine("The monster has " + monsterHealth + " health remaining.\n");
                        if (monsterHealth < 0)
                        {
                            //Monster Defeat
                            Console.WriteLine("The monster was defeated.");
                            Console.WriteLine("Another monster has appeared!\n");




                        }
                    
                }

                else if (action == "2" || action == "Flee" || action == "flee")
                {
                    // Escape!
                    Console.WriteLine("You sucessfully escaped.\n");
                    return true;
                }



                 }
                return true;
             }
             

    }
}
