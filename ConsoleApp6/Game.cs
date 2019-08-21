using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Game                                                                                                    // Out of the Scope
    {
        string playerName = "";
        int playerHealth = 200;
        int playerMaxHealth = 200;
        int playerDamage = 25;
        int playerHealing = 60;

        public void Start()                                                                                       // In the Scope
        {
            Welcome();                                                                                            // Declaring the Function into use.
            int monstersRemaining = 5;
            bool alive = true;

            // Fight until you lose.
            while (alive && monstersRemaining > 0)
            {
                Console.WriteLine("There are " + monstersRemaining + " monsters remaining.\n");
                alive = Encounter(20, 80);                                                                        // First Digit is Monster Damage, Second Digit is Monster Health
                monstersRemaining--;
            }

            Console.ReadKey();                                                                                    // system("pause") + cin
        }

        void Welcome()                                                                                            // <---- These are Functions
        { 
            // Player Section
            Console.WriteLine("What is your name? ");
            playerName = Console.ReadLine();                                                                      // Similar to cin
            Console.WriteLine("Welcome " + playerName + "!\n");

        }

        bool Encounter(int monsterDamage, int monsterHealth)                                                      // <---- These are Functions     Self Note: Order of variables does affect code)
        {
            // Monster Section
            Console.WriteLine("A Monster has appeared!");
            string action = "";
            bool survived = true;

            while (monsterHealth > 0 && playerHealth > 0)
            {
                Console.WriteLine("What will you do?");
                Console.WriteLine("Use numbers to declare action or words.");
                Console.WriteLine("1.) Fight      2.) Heal      3.) Flee\n");
                action = Console.ReadLine();

                if (action == "1" || action == "Fight" || action == "fight")
                {
                    // Attack
                    survived = Fight(ref monsterHealth, ref monsterDamage);
                    if (!survived)
                    {
                        return false;
                    }
                }

                else if (action == "2" || action == "Heal" || action == "heal")
                {
                    // Recovery
                    survived = Heal(ref monsterHealth,ref monsterDamage);
                    if (!survived)
                    {
                        return false;
                    }
                   
                }

                else if (action == "3" || action == "Flee" || action == "flee")
                {
                    // Escape!
                    Flee();
                    if (!survived)
                    {
                        return false;
                    }
                    return true;
                }

            }
            return survived;
        }
        bool Fight(ref int monsterHealth, ref int monsterDamage)
        {                                                                                                                                  // Beginning of bool Bracket
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
            Console.WriteLine("You attack!");
            Console.WriteLine("The monster takes " + playerDamage + " damage.");
            monsterHealth -= playerDamage;
            Console.WriteLine("The monster has " + monsterHealth + " health remaining.\n");
            if (monsterHealth <= 0)
            {
                //Monster Defeat
                Console.WriteLine("The monster was defeated.");
                return true;              
            }
            return true;
        }                                                                                                                                     // End of the bool Bracket

        bool Flee()
        {
           Console.WriteLine("You sucessfully escaped.\n");


            return true;
        }

        bool Heal(ref int monsterHealth,ref int monsterDamage)
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

            // Player Heals
            Console.WriteLine("You drink...a red empty bottle. (really -_-)");
            Console.WriteLine("You heal for " + playerHealing + " health points.\n");
            playerHealth += playerHealing;

            if (playerHealth > playerMaxHealth)
            {
                playerHealth = playerMaxHealth;
            }

            if (monsterHealth <= 0)
            {
                //Monster Defeat
                Console.WriteLine("The monster was defeated.");
                return true;

            }
            return true;
        }
    }
}
 