namespace CAB201_Advance;

public class Square
{
    public IPiece? ThisPiece { get; set; }
    public char Symbol { get; set; }
    public int[] Position { get; set; }
    public Square(char _symbol, int[] _position)
    {
        Symbol = _symbol;
        Position = _position;
        ThisPiece = _symbol is '.' or '#' ? null : PieceFactory();
    }

    private IPiece PieceFactory()
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
                return new Builder(side);
            case 'j' or 'J':
                return new Jester(side);
            case 'm' or 'M':
                return new Miner(side);
            case 's' or 'S':
                return new Sentinel(side);
            case 'c' or 'C':
                return new Catapult(side);
            case 'd' or 'D':
                return new Dragon(side);
            case 'g' or 'G':
                return new General(side);
            default:
                throw new ApplicationException(
                    $"Error 7: Encountered invalid symbol {Symbol} when creating a new piece on " +
                    $"line 33 of Square.cs. Please summon all your strength and make the trek to the immortal" +
                    $"peak of Mt Killdeath and meditate for 10,000 years to gain the wisdom to fix this error.");
        }
    }
}