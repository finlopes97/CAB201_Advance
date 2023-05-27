namespace CAB201_Advance;
public class Zombie : IPiece
{
    private string Side { get; }
    private int Direction { get; set; }
    public int ScoreValue { get; }
    public int[,] MoveRange { get; }
    public int[,] AbilityRange { get; }
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
    public int[,] GetMoveRange()
    {
        return MoveRange;
    }
    public int[,] GetAbilityRange()
    {
        return AbilityRange;
    }
    public string GetSide()
    {
        return Side;
    }
}