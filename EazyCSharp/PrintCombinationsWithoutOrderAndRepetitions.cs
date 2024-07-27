namespace EazyCSharp
{
    /// <summary>
    /// Решение задачи Binary Watch с LeetCode https://leetcode.com/problems/binary-watch/description/
    /// </summary>
    internal class PrintCombinationsWithoutOrderAndRepetitions
    {
        private readonly int[] indexes;
        private readonly int n;
        private readonly int turnedOn;
        private readonly Dictionary<int, int> indexToHoursMinutes;
        private readonly List<string> results;

        public PrintCombinationsWithoutOrderAndRepetitions()
        {
            indexToHoursMinutes = new Dictionary<int, int>()
            {
                { 0, 8 },
                { 1, 4 },
                { 2, 2 },
                { 3, 1 },
                { 4, 32 },
                { 5, 16 },
                { 6, 8 },
                { 7, 4 },
                { 8, 2 },
                { 9, 1 },
            };
            n = indexToHoursMinutes.Count;
            turnedOn = 5;
            indexes = Enumerable.Range(0, turnedOn).ToArray();

            results = new List<string>();
        }

        public void Start()
        {
            if (turnedOn == 0)
            {
                Console.WriteLine("turneOn должен быть больше 0");
                return;
            }

            var exit = false;
            var iterationCount = 0;
            while (!exit)
            {
                iterationCount++;
                AddResult();

                var nextIndex = indexes[indexes.Length - 1] + 1;

                if (nextIndex == n)
                {
                    var cursor = indexes.Length - 2;

                    if (cursor < 0)
                    {
                        break;
                    }

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

            foreach (var i in results)
            {
                Console.WriteLine(i);
            }
        }

        void AddResult()
        {
            var hours = 0;
            var minutes = 0;
            for (var i = 0; i < turnedOn; i++)
            {
                if (indexes[i] >= 0 && indexes[i] <= 3)
                {
                    hours += indexToHoursMinutes[indexes[i]];
                } 
                else
                {
                    minutes += indexToHoursMinutes[indexes[i]];
                }
            }

            if (hours > 11 || minutes > 59)
                return;

            results.Add($"{hours.ToString().PadLeft(2, '0')}:{minutes.ToString().PadLeft(2, '0')}");
        }
    }
}
