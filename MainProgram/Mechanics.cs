namespace Mechanics
{
    public class Utilities
    {


        public static string RollEnemy()
        {
            string[] monsters = { "Skeleton", "Zombie", "Giant Spider", "Ghoul", "Goblin", "Troll", "Slime", "Giant Rat" };
            Random random = new Random();
            int monsterRoll = random.Next(8);
            return monsters[monsterRoll];
        }


        public static string RollWeapon()
        {
            string[] weapons = { "Dagger", "Sword", "Mace", "Club", "Axe", "Spear" };
            Random random = new Random();
            int weaponRoll = random.Next(6);
            return weapons[weaponRoll];
        }


        public static string ItemRarityRoll(int chancePercentage = 100)
        {
            Random random = new Random();
            int rollNumber = random.Next(chancePercentage);

            //Common 1-45 for 45%, starts at 1 since random doesn't include 0 in its roll
            if (rollNumber <= 45 && rollNumber >= 1)
            {
                return "Common";
            }

            //Uncommon 46-75 for 30%
            else if (rollNumber >= 46 && rollNumber <= 75)
            {
                return "Uncommon";
            }

            //Epic 76-95 for 20%
            else if (rollNumber >= 76 && rollNumber <= 95)
            {
                return "Epic";
            }

            //Legendary 96-100 for 5%
            else if (rollNumber >= 96 && rollNumber <= 100)
            {
                return "Legendary";
            }

            else return "Common"; //The Beginner's Dagger's rarity counts as common
        }


        public static int DamageDealt(string weaponType, string weaponRarity, int weaponLevel)
        {
            double weaponDamage;
            {
                if (weaponType == "Sword" || weaponType == "Dagger") weaponDamage = 4;
                else if (weaponType == "Mace" || weaponType == "Club") weaponDamage = 5;
                else if (weaponType == "Axe" || weaponType == "Spear") weaponDamage = 6;
                else weaponDamage = 1;
            }

            {
                if (weaponRarity == "Common") weaponDamage *= 1;
                else if (weaponRarity == "Uncommon") weaponDamage *= 1.5;
                else if (weaponRarity == "Epic") weaponDamage *= 1.75;
                else if (weaponRarity == "Legendary") weaponDamage *= 2;
                else weaponDamage *= 1;
            }

            weaponDamage *= (1 + (weaponLevel - 1));
            int weaponDamageInt = (int)weaponDamage;
            return weaponDamageInt;
        }


        public static bool WeaponReplace(string droppedWeapon, string equippedWeapon)
        {
            Console.WriteLine($"You take a closer look, and the dropped item seems to be a {droppedWeapon}");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"A) Replace your {equippedWeapon} with the {droppedWeapon}\nB) Increase the level of your {equippedWeapon} by 1");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Press the key that corresponds with your decision.");

            while (true)
            {
                var decisionInput = Console.ReadKey();
                switch (decisionInput.Key)
                {
                    case ConsoleKey.A:
                        Console.Clear();
                        Console.WriteLine($"You drop your {equippedWeapon} and pick up the {droppedWeapon}.");
                        return true;

                    case ConsoleKey.B:
                        Console.Clear();
                        Console.WriteLine("Your current weapon has now gained a level.");
                        return false;
                }
            }
        }


        public static void ForgeDecision(string currentWeapon, ref int weaponLevel, ref string weaponRarity)
        {
            Console.WriteLine("Before entering the next room, you find a lone blacksmith. He offers to upgrade your current weapon's rarity by one rank, or to increase its level by 2.");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"A) Increase your {currentWeapon}'s rarity by one rank\nB) Increase your {currentWeapon}'s level by 2");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Press the key that corresponds with your decision.");

            while (true)
            {
                var decisionInput = Console.ReadKey();
                switch (decisionInput.Key)
                {
                    case ConsoleKey.A:
                        Console.Clear();
                        Console.WriteLine($"The blacksmith takes your weapon and refines it, increasing its rarity.");
                        if (weaponRarity == "Common") weaponRarity = "Uncommon";
                        else if (weaponRarity == "Uncommon") weaponRarity = "Epic";
                        else if (weaponRarity == "Epic") weaponRarity = "Legendary";
                        else //If the weapon's rarity is already Legendary then the blacksmith will just increase its level by 2
                        {
                            Console.WriteLine("The blacksmith informs you that your weapon cannot be refined any further.");
                            Console.WriteLine("The blacksmith takes your weapon and reinforces it, increasing its level by 2.");
                            weaponLevel += 2;
                        }
                        break;

                    case ConsoleKey.B:
                        Console.Clear();
                        Console.WriteLine("The blacksmith takes your weapon and reinforces it, increasing its level by 2.");
                        weaponLevel += 2;
                        break;
                }
                break;
            }
        }


    }
}