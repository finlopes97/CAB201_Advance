namespace CAB201_Advance;
public class Zombie : IPiece
{
    private string Side { get; }
    private int Direction { get; set; }
    public int ScoreValue { get; }
    private int[,] MoveRange { get; }
    private int[,] AbilityRange { get; }
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
    
    public void IsMoveValid(Square destination, int x, int y)
    {
        int[] pos = new int[] { x, y }; 
        throw new System.NotImplementedException();
    }

    public int[,] GetMoves()
    {
        List<int[]> moveList = new List<int[]>();
        for (int i = 0; i < MoveRange.GetLength(0); i++)
        {
            moveList.Add( new int[] { MoveRange[i, 0], MoveRange[i, 1] } );
        }
        for (int i = 0; i < AbilityRange.GetLength(0); i++)
        {
            moveList.Add( new int[] { AbilityRange[i, 0], AbilityRange[i, 1] } );
        }

        int[,] moves = new int[moveList.Count, 2];
        for (int i = 0; i < moveList.Count; i++)
        {
            moves[i, 0] = moveList[i][0];
            moves[i, 1] = moveList[i][1];
        }

        return moves;
    }
    public string GetSide()
    {
        return Side;
    }
}