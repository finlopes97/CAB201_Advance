namespace CAB201_Advance;

public class Square
{
    protected int[] currentPosition;

    public char OccupadoPor { get; set; }

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