using EazyCSharp;

while (true)
{
    Console.Clear();
    Console.Write("Номер модуля: ");

    var input = Console.ReadLine();

    if (input == "exit")
    {
        break;
    }

    if (int.TryParse(input, out var moduleNumber))
    {
        switch (moduleNumber)
        {
            case 1:
                new DynamicProgrammingExampleProblem().Run();
                break;
            case 2:
                new PrintCombinationsWithoutOrderAndRepetitions().Start();
                break;
            case 3:
                new UidAsType().Start();
                break;
            default:
                break;
        }
    }
    else
    {
        Console.WriteLine("Некорректный ввод");
    }

    Console.Write("Нажмите любую клавишу чтобы продолжить...");
    Console.ReadKey();
}

