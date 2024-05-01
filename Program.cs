namespace lesson_5;

internal class Program
{
    private static void Main()
    {
        var calc = new Calc();
        var opMatrix =  "+-*/u" ;
        Console.Write($"Текущий результат {calc.Result}\n");
        calc.MyEventHandler += Calc_MyEventHandler;
        while (true)
        {
            var s = Console.ReadLine();
            if (s.Length == 0) break;
            if (s.Substring(0, 1).ToLower() == "u") calc.CancelLast();
            if (!opMatrix.Contains(s[0]) || s.Length < 2 || !int.TryParse(s.Substring(1), out var i)) continue;
            var op = s.Substring(0,1);
            var intNum = i;
            switch (op)
                {
                    case "*":
                        calc.Multy(intNum);
                        break;
                    case "+":
                        calc.Sum(intNum);
                        break;
                    case "-":
                        calc.Sub(intNum);
                        break;
                    case "/":
                        calc.Divide(intNum);
                        break;
                }
        }
    }

    private static void Calc_MyEventHandler(object? sender, EventArgs e)
    {

        if (sender is Calc)
        {
            Console.Write("Текущий результат ");
            Console.WriteLine(((Calc)sender).Result);
            
        }
    }
}