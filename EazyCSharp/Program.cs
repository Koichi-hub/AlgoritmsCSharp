using System.Text;

var sb = new StringBuilder();

var a = new int[] { 1, 2, 3, 4, 5, 6, 7 };

var n = a.Length;
var k = 3;

var indexes = Enumerable.Range(0, k).ToArray();

var exit = false;
var iterationCount = 0;
while (!exit)
{
    iterationCount++;
    PrintCombination();

    var nextIndex = indexes[indexes.Length - 1] + 1;

    if (nextIndex == n)
    {
        var cursor = indexes.Length - 2;
        var count = indexes.Length - cursor - 1;
        while (indexes[cursor] + 1 + count >= n)
        {
            cursor--;
            count++;

            if (cursor < 0)
            {
                exit = true;
                break;
            }
        }

        if (!exit)
        {
            indexes[cursor]++;
            cursor++;
            while (cursor < indexes.Length)
            {
                indexes[cursor] = indexes[cursor - 1] + 1;
                cursor++;
            }
        }
    } 
    else
    {
        indexes[indexes.Length - 1] = nextIndex;
    }
}
Console.WriteLine($"Кол-во итераций: {iterationCount}");

void PrintCombination()
{
    sb.Clear();
    for (var i = 0; i < k; i++)
    {
        if (i < k - 1)
            sb.Append($"{a[indexes[i]]}, ");
        else
            sb.Append($"{a[indexes[i]]}");
    }
    Console.WriteLine(sb.ToString());
}
