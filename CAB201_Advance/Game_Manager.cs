namespace CAB201_Advance;

public class Game_Manager
{
    protected string color;
    public string Color
    {
        get => color;
        set => color = value;
    }
    
    protected Square[,] Board = new Square[9, 9];

    public void initBoard()
    {
        foreach (Square square in Board)
        {
            
        }
    }
    
    public void updateBoard()
    {
        
    }
}