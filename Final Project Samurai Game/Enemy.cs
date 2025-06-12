using static Final_Project_Samurai_Game.Program.Inventory;

public class Enemy
    {
        public string Name;
        public int Health;
        public int Attack;
        public int Defense;

        public Enemy(string name, int health, int attack, int defense)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Defense = defense;
        }

        public void TakeDamage(int damage)
        {
            Health -= Math.Max(0, damage - Defense);
            Console.WriteLine($"{Name} took {damage} damage. Health:{Health}");
        }
        public void AttackHero(Hero hero)
        {
            Random random = new Random();
            int damage = random.Next(Attack - 15, Attack + 15);
            hero.TakeDamage(damage);
        }
    }
}



