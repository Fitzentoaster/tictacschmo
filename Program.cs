//This is the first line

using System.Runtime.CompilerServices;

namespace TicTacSchmo
{
    class TTS
    {
        
        public const char secondPlayer = 'O';
        public const char firstPlayer = 'X';
        public const char emptySquare = 'N';
        public const string betweenLine = "-----";
        public const char delim = '|';

        private Dictionary<int, char> myBoard = new();

        private void InitBoard()
        {
            myBoard.Clear();
            for (int i = 0; i < 9; i++)
            {
                myBoard.Add(i, emptySquare);
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
                if (firstCell != emptySquare && firstCell == myBoard[combination[1]] && firstCell == myBoard[combination[2]])
                {
                    return firstCell;
                }
            }

            return emptySquare;
        }

        private bool CheckForCatsGameMeow()
        {
            if (myBoard.ContainsValue(emptySquare))
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
            if (myBoard[space] != emptySquare)
            {
                return false;
            }
            else if (space < 0 || space > 9)
            {
                return false;
            }
            else
            {
                myBoard[space] = firstPlayer;
                return true;
            }
        }

        private bool CPUMove()
        {
            Random rnd = new Random();
            int space = rnd.Next(0, 9);
            if (myBoard[space] != emptySquare)
            {
                return false;
            }
            else
            {
                myBoard[space] = secondPlayer;
                return true;
            }
        }

        private void ShowBoard()
        {
            Console.Clear();
            Console.WriteLine(myBoard[0].ToString() + delim + myBoard[1].ToString() + delim + myBoard[2].ToString());
            Console.WriteLine(betweenLine);
            Console.WriteLine(myBoard[3].ToString() + delim + myBoard[4].ToString() + delim + myBoard[5].ToString());
            Console.WriteLine(betweenLine);
            Console.WriteLine(myBoard[6].ToString() + delim + myBoard[7].ToString() + delim + myBoard[8].ToString());
        }

        static void Main(string[] args)
        {
            TTS myTTS = new TTS();
            myTTS.InitBoard();
            while (myTTS.CheckForWinner() == emptySquare && !myTTS.CheckForCatsGameMeow())
            {
                myTTS.ShowBoard();
                if (myTTS.CheckForWinner() == emptySquare)
                {
                    myTTS.GetPlayerMove();
                }
                if (myTTS.CheckForWinner() == emptySquare)
                {
                    while (!myTTS.CPUMove()) { }
                }
            }
            myTTS.ShowBoard();
            switch (myTTS.CheckForWinner())
            {
                case emptySquare:
                    Console.WriteLine("Cat's Game!");
                    break;
                case firstPlayer:
                    Console.WriteLine("You Win!");
                    break;
                case secondPlayer:
                    Console.WriteLine("The CPU Won!");
                    break;
            }
        }
    }
}
