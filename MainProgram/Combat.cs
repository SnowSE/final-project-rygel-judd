using static Mechanics.Utilities;

namespace Combat
{
    public class Utilities
    {


        public static void MainCombat(string userName, int roomNumber, string userWeaponType, string userWeaponRarity, int userWeaponLevel)
        {
            Console.Clear();
            int playerHealth = 20 + (roomNumber * 10);
            int monsterHealth = 15 + (roomNumber * 15);

            while (true)
            {
                do //Main combat begins here
                {
                    int playerAttackDamage;
                    bool defending;
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine($"ENEMY HEALTH: {monsterHealth}\n{userName}'S HEALTH: {playerHealth}\nCURRENT WEAPON: LVL {userWeaponLevel} {userWeaponRarity} {userWeaponType}");
                        Console.WriteLine("----------------------------------------------");
                        Console.Write("A) ONE-HANDED ATTACK\nB) TWO-HANDED ATTACK");
                        Console.WriteLine("\n----------------------------------------------");
                        Console.Write("Press the corresponding key to perform the move.");
                        (playerAttackDamage, defending) = AttackOption(userWeaponType, userWeaponRarity, userWeaponLevel);
                        break;
                    }

                    monsterHealth -= playerAttackDamage;
                    if (monsterHealth <= 0)
                    {
                        Console.WriteLine("As you're bracing the monster's next attack, it falls dead before it can do any damage.");
                        Console.WriteLine("It looks like the monster dropped something, so you take a closer look.");
                        Console.ReadKey();
                        Console.Clear();
                        return;
                    }

                    int enemyDamage = EnemyAttack(roomNumber, defending);
                    playerHealth -= enemyDamage;
                    if (playerHealth <= 0) throw new Exception("GAME OVER");

                } while (playerHealth > 0 && monsterHealth > 0);
            }
        }


        public static (int, bool) AttackOption(string userWeaponType, string userWeaponRarity, int userWeaponLevel)
        {
            int playerAttackDamage;
            while (true)
            {
                var attackInput = Console.ReadKey();
                switch (attackInput.Key)
                {
                    case ConsoleKey.A:
                        playerAttackDamage = DamageDealt(userWeaponType, userWeaponRarity, userWeaponLevel);
                        Console.Clear();
                        Console.WriteLine($"Your one-handed attack dealt {playerAttackDamage} damage!\nPress any key to bolster your defenses with your shield...");
                        Console.ReadKey();
                        Console.Clear();
                        return (playerAttackDamage, true);

                    case ConsoleKey.B:
                        playerAttackDamage = DamageDealt(userWeaponType, userWeaponRarity, userWeaponLevel) * 2; //make monster do extra damage
                        Console.Clear();
                        Console.WriteLine($"Your two-handed attack dealt {playerAttackDamage} damage!\nPress any key to get ready for an undefended attack...");
                        Console.ReadKey();
                        Console.Clear();
                        return (playerAttackDamage, false);
                }
            }
        }


        public static int EnemyAttack(int roomNumber, bool defended)
        {
            bool enemyLandsAttack;
            double enemyDamageDouble;
            int enemyDamage;
            Random random = new Random();
            int monsterAttackRoll = random.Next(8);

            switch (monsterAttackRoll) //Monster has a 12.5% chance of missing its attack
            {
                case 1:
                    enemyLandsAttack = false;
                    break;

                default:
                    enemyLandsAttack = true;
                    break;
            }

            int monsterVaryingDamage = random.Next(5);
            if (enemyLandsAttack == true)
            {
                enemyDamageDouble = (roomNumber * 2.5) + monsterVaryingDamage;
                if (defended == false) enemyDamageDouble *= 2;
                enemyDamage = (int)enemyDamageDouble;
                Console.WriteLine($"The monster swings at you, dealing {enemyDamage} damage!\nPress any key to start the next round...");
                Console.ReadKey();
                return enemyDamage;
            }

            else
            {
                Console.WriteLine("You managed to dodge the monster's attack!\nPress any key to start the next round...");
                Console.ReadKey();
                return 0;
            }
        }


    }
}