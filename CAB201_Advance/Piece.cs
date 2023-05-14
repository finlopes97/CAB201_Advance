namespace CAB201_Advance;

public abstract class Piece
{
    protected int[] currentPosition;
    public int[] CurrentPosition
    {
        get => currentPosition;
        set
        {
            int x = value[0];
            int y = value[1];
            CurrentPosition[0] = x;
            CurrentPosition[1] = y;
        }
    }
}