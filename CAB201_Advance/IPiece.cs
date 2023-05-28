namespace CAB201_Advance;

public interface IPiece
{
    public void Move();
    public void Capture();
    public bool IsMoveLegal();
    public int[,] GetMoves();
    public string GetSide();
}