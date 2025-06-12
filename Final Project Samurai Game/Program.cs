using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Final_Project_Samurai_Game
{
    internal class Program
    {
        public Hero PlayerHero;

        class Program
        {
            static void Main(string[] args)
            {
                Game game = new Game();
                game.Start();
            }


            public void Start()
            {
                Console.WriteLine("Enter your hero`s name:");
                string name = Console.ReadLine();
                Console.WriteLine("Choose your class (Samurai,Archer,Assassin):");
                string classChoice = Console.ReadLine().ToLower();

                PlayerHero = new Hero(name, classChoice);

                bool playing = true;
                while (playing)
                {

                    DisplayMenu();
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            FightEnemy();
                            break;
                        case "2":
                            UsePotion();
                            break;
                        case "3":
                            TalkToNPC();
                            break;
                        case "4":
                            SaveGame();
                            break;
                        case "5":
                            playing = false;
                            break;
                        default:
                            Console.WriteLine("Invalid Option.");
                            break;
                    }
                }
            }

            public void DisplayMenu()
            {
                Console.WriteLine($"Level: {PlayerHero.Level} | Health: {PlayerHero.Health} ");
                Console.WriteLine("1.Attack an Enemy");
                Console.WriteLine("2.Use Medicine");
                Console.WriteLine("3.Talk to NPC");
                Console.WriteLine("4.Save Game");
                Console.WriteLine("5.Exit");
                Console.Write("Choose an Action");

            }
            public void FightEnemy()
            {
                Enemy enemy = new Enemy("Ronin", 60, 15, 7);
                PlayerHero.AttackEnemy(enemy);
            }
            public void UseMedicine()
            {
                if (PlayerHero.Inventory.UseItem("Medicine"))
                {
                    PlayerHero.Heal(60);
                }
                else
                {
                    Console.WriteLine("You don`t have any Medicine.");
                }
            }
            public void TalkToNPC()
            {
                NPC npc = new NPC("Old Samurai", "Seek the katana of Raijin");
                npc.Talk();
            }
            public void SaveGame()
            {
                FileStream fs = new FileStream($"{PlayerHero.Name}_save.dat", FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, PlayerHero);
                fs.Close();

                Console.WriteLine(("Game Saved!");

            }
            public static Hero LoadGame(string fileName)
            {
                if (File.Exists(fileName))
                {
                    FileStream fs = new FileStream(fileName, FileMode.Open);
                    BinaryFormatter formatter = new BinaryFormatter();
                    Hero loadedHero = (Hero)formatter.Deserialize(fs);
                    fs.Close();
                    Console.WriteLine("Game loaded!");
                    return loadedHero


            }
                else
                {
                    Console.WriteLine("No Saved game found.");
                    return null;
                }
            }

        }
    }



