namespace CAB201_Advance;

class Program
{
    public static void Main(string[] args)
    {
        Game_Manager manager = new Game_Manager(args[0], args[1], args[2]);
        manager.SetupBoard();
        manager.DebugBoard();
        manager.Play();
    }
}

