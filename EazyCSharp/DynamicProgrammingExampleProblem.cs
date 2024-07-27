namespace EazyCSharp
{
    internal class DynamicProgrammingExampleProblem
    {
        private readonly int[,] a;
        private readonly int[,] b;
        private readonly int[,,] paths;
        private readonly int[,] aHighlight;
        private readonly int rows;
        private readonly int columns;

        public DynamicProgrammingExampleProblem()
        {
            a = new int[,] {
                { 9, 8, 6, 2 },
                { 10, 111, 12, 11 },
                { 3, 7, 12, 8 },
                { 5, 9, 12, 90 }
            };
            aHighlight = new int[4, 4];
            b = new int[4, 4];
            paths = new int[4, 4, 2];

            rows = a.GetUpperBound(0) + 1;
            columns = a.Length / rows;
        }

        public void Run()
        {
            Recursive(rows - 1, 0, rows - 1, 0);

            PrintMatrix(a);
            PrintMatrix(b);

            CalcPath();

            PrintMatrix(a, true);
        }

        void Recursive(int i, int j, int fromI, int fromJ)
        {
            if (i < 0 || j == columns)
                return;

            var newValue = a[i, j] + b[fromI, fromJ];
            if (newValue > b[i, j])
            {
                b[i, j] = newValue;
                paths[i, j, 0] = fromI;
                paths[i, j, 1] = fromJ;
            }

            Recursive(i - 1, j, i, j);
            Recursive(i, j + 1, i, j);
        }

        void CalcPath()
        {
            var i = 0;
            var j = columns - 1;
            var tmpI = i;
            var tmpJ = j;
            do
            {
                aHighlight[i, j] = 1;
                tmpI = paths[i, j, 0];
                tmpJ = paths[i, j, 1];
                i = tmpI;
                j = tmpJ;
            }
            while (!(i == 3 && j == 0));
            aHighlight[3, 0] = 1;
        }

        void PrintMatrix(int[,] matrix, bool isHighlight = false)
        {
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    if (isHighlight && aHighlight[i, j] == 1)
                        Console.Write($"*{matrix[i, j]}*\t");
                    else
                        Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        void PrintPaths()
        {
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    Console.Write($"({paths[i, j, 0]}, {paths[i, j, 1]})\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
