namespace Final_Project_Samurai_Game
{
    public class NPC
    {
        public string Name;
        public string Dialogue;

        public NPC(string name, string dialogue)
        {
            Name = name;
            Dialogue = dialogue;
        }
        public void Talk()
        {
            Console.WriteLine($"{Name}: {Dialogue}");
        }
    }
}



