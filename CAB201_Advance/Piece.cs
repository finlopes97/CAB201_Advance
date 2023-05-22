namespace CAB201_Advance;

public abstract class Piece
{
    private int x, y;
    private char symbol;

    public Piece(int _x, int _y, char _symbol)
    {
        x = _x;
        y = _y;
        symbol = _symbol;
    }
}