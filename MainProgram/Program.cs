using static Mechanics.Utilities;
using static Combat.Utilities;

namespace Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string? userName = Console.ReadLine().ToUpper();
            Console.WriteLine($"The brave adventurer {userName} enters the evil dungeon... Will they survive?");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine("----------------------------------------------");

            string? userWeaponRarity = "Beginner's";
            string? userWeaponType = "Dagger";
            int userWeaponLevel = 1;

            int roomNumber = 1;
            while (roomNumber <= 10)
            {
                string floorMonster;

                try
                {
                    floorMonster = RollEnemy();
                    Console.WriteLine($"You enter Room {roomNumber} and find a hostile {floorMonster}! Combat begins!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    MainCombat(userName, roomNumber, userWeaponType, userWeaponRarity, userWeaponLevel); //This MainCombat method is the main combat
                }

                catch //Catches the exception that's thrown when the player's health reaches 0 and ends the game
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("GAME OVER");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

                string? currentWeapon = $"LVL {userWeaponLevel} {userWeaponRarity} {userWeaponType}"; //Combined for easy script writing
                string? newWeaponRarity = ItemRarityRoll();
                string? newWeaponType = RollWeapon();
                int newWeaponLevel = roomNumber;
                string? newWeaponDrop = $"LVL {newWeaponLevel} {newWeaponRarity} {newWeaponType}"; //Combined for easy script writing

                bool weaponPickup = WeaponReplace(newWeaponDrop, currentWeapon);
                if (weaponPickup)
                {
                    userWeaponRarity = newWeaponRarity;
                    userWeaponType = newWeaponType;
                    userWeaponLevel = newWeaponLevel;
                }
                else
                {
                    userWeaponLevel += 1;
                }
                Console.WriteLine("You also gained a level and your maximum health has increased by 10 points!");
                Console.ReadKey();
                Console.Clear();
                currentWeapon = $"LVL {userWeaponLevel} {userWeaponRarity} {userWeaponType}"; //Reassigns currentWeapon for the forge

                if (roomNumber == 5) ForgeDecision(currentWeapon, ref userWeaponLevel, ref userWeaponRarity); //Player meets the blacksmith after the 5th round

                roomNumber++;
            }

            roomNumber += 10; //Increases the room level by a lot to make the final boss harder
            while (true)
            {
                try
                {
                    string bossMonster = RollEnemy();
                    Console.WriteLine($"You enter the final room and find an Elite {bossMonster}! Combat begins!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    MainCombat(userName, roomNumber, userWeaponType, userWeaponRarity, userWeaponLevel); //This MainCombat method is the main combat
                    Console.WriteLine("It appears to be a magic stone...\nYou pick it up and you teleport home safe and sound!\nCongrats on surviving the dungeon!");
                    break; //Breaks out of the loop, ending the program
                }

                catch //Catches the exception that's thrown when the player's health reaches 0 and ends the game
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("GAME OVER");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
            }


        }
    }
}
