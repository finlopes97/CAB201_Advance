namespace CAB201_Advance;

public interface Piece
{
    protected virtual void Move() { } 
    protected virtual void Capture() { }
    protected virtual bool IsLegalMove() { return true; }
}