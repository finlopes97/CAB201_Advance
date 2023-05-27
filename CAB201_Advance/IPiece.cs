namespace CAB201_Advance;

public interface IPiece
{
    public void Move();
    public void Capture();
    public bool IsMoveLegal();
    public int[,] GetMoveRange();
    public int[,] GetAbilityRange();
    public string GetSide();
}