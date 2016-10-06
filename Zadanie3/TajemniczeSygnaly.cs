using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightBulbs
{
    public class TajemniczeSygnaly : ILightBulbs
    {
        public new static ILightBulbs GetInstance()
        {
            lightBulbsInstance = new TajemniczeSygnaly();
            return lightBulbsInstance;
        }

        public override int CountLightsOn(bool[,] lightsBoard, int s)
        {
            var board = PrepareBoard(lightsBoard);
            for (int i = 0; i < s; i++) ChangeBoard(board);
            return CountBoard(board);
        }

        int CountBoard(bool[,] board)
        {
            int n = board.GetLength(0) - 2; //72
            int m = board.GetLength(1) - 2; //72
            var count = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (board[i, j]) count++;
                }
            }
            return count;
        }

        bool[,] PrepareBoard(bool[,] board)
        {
            int n = board.GetLength(0); //72
            int m = board.GetLength(1); //72
            var b = new bool[n + 2, m + 2]; //add borders
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    b[i + 1, j + 1] = board[i, j];
                }
            }
            return b;
        }

        void ChangeBoard(bool[,] board)
        {
            int n = board.GetLength(0) - 2; //72
            int m = board.GetLength(1) - 2; //72
            var countBoard = new int[n + 2, m + 2];
            //build count board
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    var state = board[i, j];
                    var count = CountOn(board, i, j);
                    countBoard[i, j] = count;
                }
            }
            //change board lights
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (i == 1 && j == 1) continue;
                    if (i == 1 && j == n) continue;
                    if (i == m && j == 1) continue;
                    if (i == n && j == m) continue;
                    var lighOn = board[i, j];
                    var countOn = countBoard[i, j];
                    if (lighOn) board[i, j] = countOn > 1 && countOn < 4;
                    else board[i, j] = countOn == 3;
                }
            }
        }

        int CountOn(bool[,] board, int iStart, int jStart)
        {
            var count = 0;
            for (int i = iStart - 1; i <= iStart + 1; i++)
            {
                for (int j = jStart - 1; j <= jStart + 1; j++)
                {
                    if (i == iStart && j == jStart) continue; //nie licz siebie
                    if (board[i, j]) count++;
                }
            }
            return count;
        }
    }
}
