namespace DrangonsWay.Logic
{
    public class Game
    {
        private char[,] game;
        public bool Win;

        public Game(int n, string way)
        {
            N = n;
            Way = way;
            game = new char[n, n * 2];
            Fillcave();
            FillWay();
        }


        public int N { get; }
        public string Way { get; }


        public override string ToString()
        {
            var output = string.Empty;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N * 2; j++)
                {
                    output += $"{game[i, j]}";
                }
                output += "\n";
            }
            return output;
        }


        private void Fillcave()
        {
            for (int i = 0; i < N * 2; i++)
            {
                game[0, i] = '▄';
            }
            for (int i = 0; i < N * 2 - 1; i++)
            {
                game[1, i] = ' ';
            }
            game[1, N * 2 - 1] = '█';
            for (int i = 2; i < N - 2; i++)
            {
                game[i, 0] = '█';
                for (int j = 1; j < N * 2 - 1; j++)
                {
                    game[i, j] = ' ';
                }
                game[i, N * 2 - 1] = '█';
            }
            game[N - 2, 0] = '█';
            for (int i = 1; i < N * 2; i++)
            {
                game[N - 2, i] = ' ';
            }

            for (int i = 0; i < N * 2; i++)
            {
                game[N - 1, i] = '▄';
            }

        }

        private void FillWay()
        {
            int row = 1;
            int j = 0;
         
                for (int i = 0; i < Way.Length; i++)
                {
                if (j < N * 2)
                {
                    if (Way[i] == '→')
                    {
                        game[row, j] = '→';
                        j++;
                    }
                    if (Way[i] == '↓')
                    {
                        game[row, j] = '↓';
                        row++;
                    }
                }
                else
                {
                    if (!(row == 9))
                    {
                        Win = true;
                    }
                    else
                    {
                        Win = false;
                    }
                }
                    
                }

        }       

    }
}