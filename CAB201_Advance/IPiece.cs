namespace CAB201_Advance;

public interface IPiece
{
    public void IsMoveValid(Square destination, int x, int y);
    public int[,] GetMoves();
    public string GetSide();
}