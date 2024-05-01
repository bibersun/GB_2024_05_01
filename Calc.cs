namespace lesson_5;

public class Calc : ICalc
{
    private Stack<double> LastRes { get; } = new();
    public double Result { get; set; }

    public void Sum(int x)
    {
        LastRes.Push(Result);
        Result += x;
        PrintRes();
    }

    public void Sub(int x)
    {
        LastRes.Push(Result);
        Result -= x;
        PrintRes();
    }

    public void Multy(int x)
    {
        LastRes.Push(Result);
        Result *= x;
        PrintRes();
    }

    public void Divide(int x)
    {
        if (x != 0)
        {
            LastRes.Push(Result);
            Result /= x;
            PrintRes();
        }
        else
        {
            Console.WriteLine("На ноль делить нельзя");
            PrintRes();
        }
    }

    public void CancelLast()
    {
        if (LastRes.TryPop(out var res))
        {
            Console.WriteLine("Последнее действие отменено");
            Result = res;
            PrintRes();
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Не можем отменять последнее действие");
        }
    }

    public event EventHandler<EventArgs>? MyEventHandler;

    private void PrintRes()
    {
        MyEventHandler?.Invoke(this, EventArgs.Empty);
    }
}