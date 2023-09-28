//This is the first line

namespace TicTacSchmo
{
    class TTS
    {
        private Dictionary<int, char> myBoard = new();

        private void InitBoard()
        {
            myBoard.Clear();
            for (int i = 0; i < 9; i++)
            {
                myBoard.Add(i, 'N');
            }
        }

        private char CheckForWinner()
        {
            // Define winning combinations
            int[][] winningCombinations = new int[][]
            {
                new int[] {0, 1, 2},
                new int[] {3, 4, 5},
                new int[] {6, 7, 8},
                new int[] {0, 3, 6},
                new int[] {1, 4, 7},
                new int[] {2, 5, 8},
                new int[] {0, 4, 8},
                new int[] {2, 4, 6}
            };

            foreach (int[] combination in winningCombinations)
            {
                char firstCell = myBoard[combination[0]];
                if (firstCell != 'N' && firstCell == myBoard[combination[1]] && firstCell == myBoard[combination[2]])
                {
                    return firstCell;
                }
            }

            return 'N';
        }

        private bool CheckForCatsGameMeow()
        {
            if (myBoard.ContainsValue('N'))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void GetPlayerMove()
        {
            int newSpace = 10;
            while (newSpace < 0 || newSpace > 9 || !SetPlayerMove(newSpace))
            {
                newSpace = int.Parse(Console.ReadLine());
            }
        }

        private bool SetPlayerMove(int space)
        {
            if (myBoard[space] == 'X' || myBoard[space] == 'O')
            {
                return false;
            }
            else if (space < 0 || space > 9)
            {
                return false;
            }
            else
            {
                myBoard[space] = 'X';
                return true;
            }
        }

        private bool CPUMove()
        {
            Random rnd = new Random();
            int space = rnd.Next(0, 9);
            if (myBoard[space] == 'X' || myBoard[space] == 'O')
            {
                return false;
            }
            else
            {
                myBoard[space] = 'O';
                return true;
            }
        }

        private void ShowBoard()
        {
            Console.Clear();
            Console.WriteLine(myBoard[0].ToString() + "|" + myBoard[1].ToString() + "|" + myBoard[2].ToString());
            Console.WriteLine("-----");
            Console.WriteLine(myBoard[3].ToString() + "|" + myBoard[4].ToString() + "|" + myBoard[5].ToString());
            Console.WriteLine("-----");
            Console.WriteLine(myBoard[6].ToString() + "|" + myBoard[7].ToString() + "|" + myBoard[8].ToString());
        }

        static void Main(string[] args)
        {
            TTS myTTS = new TTS();
            myTTS.InitBoard();
            while (myTTS.CheckForWinner() == 'N' && !myTTS.CheckForCatsGameMeow())
            {
                myTTS.ShowBoard();
                if (myTTS.CheckForWinner() == 'N')
                {
                    myTTS.GetPlayerMove();
                }
                if (myTTS.CheckForWinner() == 'N')
                {
                    while (!myTTS.CPUMove()) { }
                }
            }
            myTTS.ShowBoard();
            switch (myTTS.CheckForWinner())
            {
                case 'N':
                    Console.WriteLine("Cat's Game!");
                    break;
                case 'X':
                    Console.WriteLine("You Win!");
                    break;
                case 'O':
                    Console.WriteLine("The CPU Won!");
                    break;
            }
        }
    }
}