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
        string side = char.IsUpper(Symbol) ? side = "white" : side = "black";
        switch (Symbol)
        {
            case '.' or '#':
                // Implement new function to handle non-piece squares '.' and '#'.
                return null;
            case 'z' or 'Z':
                return new Zombie(side);
            case 'b' or 'B':
                return new Builder();
            case 'j' or 'J':
                return new Jester();
            case 'm' or 'M':
                return new Miner();
            case 's' or 'S':
                return new Sentinel();
            case 'c' or 'C':
                return new Catapult();
            case 'd' or 'D':
                return new Dragon();
            case 'g' or 'G':
                return new General();
            default:
                throw new ApplicationException(
                    $"Error 7: Encountered invalid symbol {Symbol} when creating a new piece on " +
                    $"line 33 of Square.cs. Please summon all your strength and make the trek to the immortal" +
                    $"peak of Mt Killdeath and meditate for 10,000 years to gain the wisdom to fix this error.");
        }
    }
}