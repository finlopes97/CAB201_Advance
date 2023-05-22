using System.Security.Cryptography.X509Certificates;

namespace CAB201_Advance;

public class Square
{
    public Piece ThisPiece { get; set; }

    public char Symbol { get; set; }

    public int X { get; set; }

    public int Y { get; set; }

    public Square()
    {
        ThisPiece = null;
        Symbol = '.';
        X = 0;
        Y = 0;
    }

    public void UpdateSquareInfo(char _symbol, int _x, int _y)
    {
        Symbol = _symbol;
        X = _x;
        Y = _y;
        ThisPiece = PieceFactory();
    }

    private Piece PieceFactory()
    {
        switch (Symbol)
        {
            case 'z' or 'Z':
                return new Zombie(X, Y, Symbol);
        }
    }
}