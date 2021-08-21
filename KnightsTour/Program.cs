using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace KnightsTour
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int count = 1;
            int[] horizontal = { 2, 1, -1, -2, -2, -1, 1, 2 };
            int[] vertical = { -1, -2, -2, -1, 1, 2, 2, 1 };
            int row = 0, column = 0, newRow = 0, newCol = 0; /*to initialize the starting position of 
            the knight*/
            Boolean end = false, range = true, possibility = false;
            //setting up 8 x 8 arrays
            int[,] board = new int[8,8];
            int[,] possibleMoves = new int[8,8];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i,j] = 0;
                }
            }
            //first move
            WriteLine("Enter the row of where to start the knight:");
            row = Convert.ToInt32(ReadLine()) - 1;
            WriteLine("Enter the column of where to start the knight:");
            column = Convert.ToInt32(ReadLine()) - 1;
            //check that inputs are in the appropriate range
            if ((row < 0) || (row > 7) || (column < 0) || (column > 7)) range = false;
            while (range == false)
            {
                WriteLine("Enter an integer between 1 & 8 for the row:");
                row = Convert.ToInt32(ReadLine()) - 1;
                WriteLine("Enter an integer between 1 & 8 for the column:");
                column = Convert.ToInt32(ReadLine()) - 1;
                if ((row < 0) || (row > 7) || (column < 0) || (column > 7)) range = false;
                else range = true;
            }
            board[row,column] = count;
            WriteLine("board[row,column] = {0}", board[row,column]);
            //print current version of board
            for (int row5 = 0; row5 < board.GetLength(0); row5++)
            {
                WriteLine("");
                for (int col5 = 0; col5 < board.GetLength(1); col5++)
                {
                    Write("{0} ", board[row5,col5]);
                }
            }
            WriteLine("");
            //print board w/possible moves
            //i) create a separate cleared board to show possible moves
            for (int row2 = 0; row2 < possibleMoves.GetLength(0); row2++)
            {
                for (int col = 0; col < possibleMoves.GetLength(1); col++)
                {
                    possibleMoves[row2,col] = 0;
                }
            }
            //ii) print a board with the current position of the knight and the possible moves
            WriteLine("Here is the board and list of possible moves.");
            int pRow = 0, pColumn = 0;
            for (int pMove = 0; pMove < 8; pMove++)
            {
                pRow = row + horizontal[pMove];
                pColumn = column + vertical[pMove];
                if ((pRow >= 0) && (pRow < 8) && (pColumn >= 0) && (pColumn < 8))
                {
                    possibleMoves[pRow,pColumn] = pMove + 1;
                }

            }
            possibleMoves[row,column] = count;
            //print possible moves array
            for (int row4 = 0; row4 < possibleMoves.GetLength(0); row4++)
            {
                WriteLine("");
                for (int col4 = 0; col4 < possibleMoves.GetLength(1); col4++)
                {
                    Write("{0} ", possibleMoves[row4,col4]);
                }
            }
            WriteLine(""); WriteLine("");

            //second move and beyond
            while ((count != 64) && (end == false))
            {
                WriteLine("Enter how many spaces to the left (e.g., -1 or -2) or the right (e.g., 1 or 2): ");
                newCol = Convert.ToInt32(ReadLine());
                while ((newCol != -2) && (newCol != -1) && (newCol != 1) && (newCol != 2)) //make sure the appropriate number of moves is made
                {
                    WriteLine("Enter either a -2, -1, 1, or 2: ");
                    newCol = Convert.ToInt32(ReadLine());
                }
                //determine if input is a possible move, otherwise repeat possibility board and command
                WriteLine("Enter how many spaces up or down (remember, if you entered a \"2\", then you can only enter "
                        + "a \"1\" and vice versa: ");
                newRow = Convert.ToInt32(ReadLine());
                while ((newRow != -1) && (newRow != -2) && (newRow != 2) && (newRow != 1)) //check to determine that appropriate value is entered.
                {
                    WriteLine("Enter how many spaces up or down (remember, if you entered a \"2\", then you can only enter" + "a \"1\" and vice versa: *");
                    newRow = Convert.ToInt32(ReadLine());
                }
                if ((newCol == -1) || (newCol == 1))
                {
                    while ((newRow != -2) && (newRow != 2))
                    {
                        WriteLine("Enter how many spaces up or down (remember, if you entered a \"2\", then you can only enter"
                                + "a \"1\" and vice versa: ");
                        newRow = Convert.ToInt32(ReadLine());
                    }
                }
                if ((newCol == -2) || (newCol == 2))
                {
                    while ((newRow != -1) && (newRow != 1))
                    {
                        WriteLine("Enter how many spaces up or down (remember, if you entered a \"2\", then you can only enter"
                                + "a \"1\" and vice versa: ");
                        newRow = Convert.ToInt32(ReadLine());
                    }
                }
                //check to make sure that the move is possible & the space is empty
                while (possibility == false)
                {
                    WriteLine("You have entered the possibility check.");
                    if ((row + newRow >= 0) && (row + newRow < 8) && (column + newCol >= 0) && (column + newCol < 8)
                            && (board[row + newRow,column + newCol] == 0))
                    {
                        possibility = true;
                        WriteLine("This is a possible move.");
                    }
                    else
                    {
                        WriteLine("This move is not possible. Please find a new space and enter the moves to navigate to it.");
                        WriteLine("Enter how many spaces to the left (e.g., -1 or -2) or the right (e.g., 1 or 2): ");
                        newCol = Convert.ToInt32(ReadLine());
                        while ((newCol != -2) && (newCol != -1) && (newCol != 1) && (newCol != 2))
                        // make sure the appropriate number of moves is made
                        {
                            WriteLine("Enter either a -2, -1, 1, or 2: ");
                            newCol = Convert.ToInt32(ReadLine());
                        }
                        //determine if input is a possible move, otherwise repeat possibility board and command
                        WriteLine("Enter how many spaces up or down (remember, if you entered a \"2\", then you can only enter "
                                + "a \"1\" and vice versa: ");
                        newRow = Convert.ToInt32(ReadLine());
                        while ((newRow != -1) && (newRow != -2) && (newRow != 2) && (newRow != 1)) /*check to determine that appropriate value
						is entered.*/
                        {
                            WriteLine("Enter how many spaces up or down (remember, if you entered a \"2\", then you can only"
                                    + " enter" + "a \"1\" and vice versa: ");
                            newRow = Convert.ToInt32(ReadLine());
                        }
                        if ((newCol == -1) || (newCol == 1))
                        {
                            while ((newRow != -2) && (newRow != 2))
                            {
                                WriteLine("%n%s%n", "Enter how many spaces up or down (remember, if you entered a \"2\", then you can only"
                                        + " enter" + "a \"1\" and vice versa: ");
                                newRow = Convert.ToInt32(ReadLine());
                            }
                        }
                        if ((newCol == -2) || (newCol == 2))
                        {
                            while ((newRow != -1) && (newRow != 1))
                            {
                                WriteLine("%n%s%n", "Enter how many spaces up or down (remember, if you entered a \"2\", then you can only"
                                        + " enter" + "a \"1\" and vice versa: ");
                                newRow = Convert.ToInt32(ReadLine());
                            }
                        }
                    }
                }
                possibility = false;
                //output result
                count++;
                row += newRow;
                column += newCol;
                board[row,column] = count;
                //prints out current board
                for (int row2 = 0; row2 < board.GetLength(0); row2++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        WriteLine($"[{board[row2,col]}]");
                    }
                    WriteLine("");
                }
                //loop to determine if there are any more possible moves
                Boolean endThisLoop = false;
                while (endThisLoop == false)
                {
                    endThisLoop = true;
                    int possibleRow = 0, possibleCol = 0, endCount = 0;
                    for (int pMove = 0; pMove < 8; pMove++)
                    {
                        possibleRow = row + horizontal[pMove];
                        possibleCol = column + vertical[pMove];
                        //this needs the ability to discern whether a move is possible or not
                        if ((possibleRow > 0) && (possibleRow < 8) && (possibleCol > 0) && (possibleCol < 8))
                        {
                            if (board[possibleRow,possibleCol] == 0)
                            {
                                endCount += 1;
                            }
                        }
                    }
                    if (endCount > 0)
                    {
                        end = false;
                        WriteLine("%s%d%n", "Number of possible moves: ", endCount);
                        WriteLine("%s%d%n", "Count: ", count);
                    }
                    else
                    {
                        end = true;
                        WriteLine("%s%d%n", "There are no more possible moves. The count = ", count);
                    }
                }
            }
        }
    }
}
