using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Final_Project_Samurai_Game
{
    internal class Program
    {




        public class Inventory
        {
            public Dictionary<string, int> Items = new Dictionary<string, int>();

            public Inventory()
            {
                Items["Food"] = 0;
                Items["Medicine"] = 0;
                Items["Potions"] = 0;
            }
            public void AddItem(string item, int quantity = 1)
            {
                if (Items.ContainsKey(item))
                {
                    Items[item] += quantity;
                }
                else
                {
                    Console.WriteLine("Invalid item.");
                }
            }



            public bool UseItem(string item)
            {
                if (Item.ContainsKey(item))
                {
                    Item[item]--;
                    return true;
                }
                return false;
            }
            public class Hero
            {
                public string Name;
                public string ClassType;
                public int Health;
                public int Level;
                public int Experience;
                public int Attack;
                public int Defense;
                public Inventory Inventory;
                public int MaxHealth;

                public Hero(string name, string classType)
                {
                    Name = name;
                    ClassType = classType;
                    Health = 500;
                    Level = 1;
                    Experience = 0;
                    Inventory = new Inventory();
                    MaxHealth = 0;

                    if (classType == "Samurai")
                    {
                        Attack = 45;
                        Defense = 30;
                    }
                    else if (classType == "Archer")
                    {
                        Attack = 35;
                        Defense = 25;

                    }
                    else if (classType == "Assassin")
                    {
                        Attack = 40;
                        Defense = 28;
                    }
                }
                public void LevelUp()
                {
                    if (Experience >= 100 * Level)
                    {
                        Level++;
                        Experience = 0;
                        Attack += 50;
                        Defense += 15;
                        MaxHealth += 50;
                        Health = MaxHealth;
                        Console.WriteLine($"{Name} Leveled up to level {Level}!!");
                    }

                }
                public void TakeDamage(int damage)
                {
                    Health -= Math.Max(0, damage - Defense);
                    if (Health < 0)
                        Health = 0;
                    Console.WriteLine($"{Name} took {damage} damage. Health: {Health/MaxHealth}");
                }
                public void Heal(int amount)
                {
                    Health = Math.Min(MaxHealth, Health + amount);
                    Console.WriteLine($"{Name} healed {amount} health. Health: {Health / MaxHealth}");
                }

                public void AttackEnemy(Enemy enemy)
                {
                    Random random = new Random();
                    int damage = random.Next(Attack - 10, Attack + 10);
                    if (random.NextDouble() < 0.1)
                    {
                        damage *= 5;
                        Console.WriteLine("Critical Hit!!");
                    }
                    Console.WriteLine($"{Name} attacks {enemy.Name} for {damage} damage!!");
                    enemy.TakeDamage(damage);
                }
                public class Enemy
                {

                }



            }

        }
    }
}



