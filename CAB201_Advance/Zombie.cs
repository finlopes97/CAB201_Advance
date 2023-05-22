namespace CAB201_Advance;
public class Zombie : Piece
{
    private string Side { get; set; }
    private int Direction { get; set; }
    public int ScoreValue { get; set; }
    public int[,] MoveRange { get; set; }
    public int[,] AbilityRange { get; set; }
    public Zombie(string side)
    {
        Side = side;
        Direction = side == "black" ? 1 : -1;
        ScoreValue = 1;
        MoveRange = new int[,]
        {
            { 1 * Direction, 0 }, // Forward 1 square
            { 1 * Direction, 1 }, // Forward 1 square, right 1 square
            { 1 * Direction, -1 } // Forward 1 square, left 1 square
        };
        AbilityRange = new int[,]
        {
            { 2 * Direction, 0 }, // Forward 2 squares
            { 2 * Direction, 2 }, // Forward 2 squares, right 2 square
            { 2 * Direction, -2 } // Forward 2 squares, left 2 square
        };
    }

    public void Move()
    {
        
    }

    public void Capture()
    {
        
    }

    public void Leap()
    {
        
    }

    public bool IsMoveLegal()
    {
        return true;
    }
}