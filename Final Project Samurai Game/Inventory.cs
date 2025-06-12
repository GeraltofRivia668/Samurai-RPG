namespace Final_Project_Samurai_Game
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
    }
}



