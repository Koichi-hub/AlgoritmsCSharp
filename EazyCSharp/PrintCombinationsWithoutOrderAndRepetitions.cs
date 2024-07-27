using System.Text;

namespace EazyCSharp
{
    internal class PrintCombinationsWithoutOrderAndRepetitions
    {
        private readonly StringBuilder sb;
        private readonly int[] a;
        private readonly int[] indexes;
        private readonly int n;
        private readonly int k;

        public PrintCombinationsWithoutOrderAndRepetitions()
        {
            sb = new StringBuilder();
            a = new int[] { 8, 4, 2, 1 };
            n = a.Length;
            k = 3;
            indexes = Enumerable.Range(0, k).ToArray();
        }

        public void Start()
        {
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
        }

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
    }
}
