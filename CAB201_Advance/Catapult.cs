namespace CAB201_Advance;

public class Catapult : IPiece
{
    private string Side { get; set; }
    private int Direction { get; set; }
    public int ScoreValue { get; set; }
    public int[,] MoveRange { get; set; }
    public int[,] AbilityRange { get; set; }

    public Catapult(string side)
    {
        Side = side;
        Direction = side == "black" ? 1 : -1;
        ScoreValue = 1;
        MoveRange = new int[,]
        {
        };
        AbilityRange = new int[,]
        {
        };
    }
    public void Move()
    {
        
    }
    public void Capture()
    {
        
    }
    public bool IsMoveLegal()
    {
        return true;
    }
    public int[,] GetMoves()
    {
        return MoveRange;
    }

    public string GetSide()
    {
        return Side;
    }
}