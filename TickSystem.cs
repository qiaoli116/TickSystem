namespace Qiaoli116;
public class TickSystem<T>
{
    public List<Digit<T>> Digits { get; set; } = new List<Digit<T>>();
    public void AddDigit(int max, T data)
    {
        var digit = new Digit<T>() {
            Max = max,
            Data = data
        };
        Digits.Add(digit);
        var count = Digits.Count;
        if (count > 1)
        {
            // link the last two digits
            Digits[count - 2].Next = Digits[count - 1];
        }
    }

    public bool Tick()
    {
        return Digits[0].Tick();
    }

    public void Reset()
    {
        foreach(var digit in Digits)
        {
            digit.Value = 0;
        }
    }
    public void Print()
    {
        foreach(var digit in Digits)
        {
            Console.Write($"{digit.Value}\t");
        }
        Console.Write("\n");
    }

}

public class Digit<T>
{
    // Value will be in range of [0, Max]
    public int Value { get; set; } = 0;
    public int Max { get; set; }
    public Digit<T>? Next { get; set; }

    public T? Data { get; set; }

    public bool Tick()
    {
        bool flag = false;

        if(Value == Max)
        {
            Value = 0;
            if(Next != null)
            {
                flag = Next.Tick();
            }
            else
            {
                flag = true;
            }

        } else
        {
            Value++;
        }

        return flag;
    }
}
