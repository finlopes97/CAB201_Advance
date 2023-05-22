namespace CAB201_Advance;

public interface Piece
{
    protected void Move() { } 
    protected void Capture() { }
    protected bool IsMoveLegal() { return true; }
}