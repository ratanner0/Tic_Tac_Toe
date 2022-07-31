using System;

namespace tic_tac_toe
{
    internal class Program
    {
        //the playfield array
        static char[,] playfield =
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };

        

        static int turns = 0;

        static void Main(string[] args)
        {
            //Player 1 starts
            int player = 2;

            // sets the default value of the input to 0
            int input = 0;

            // sets the logic to determine if the input value is correct.
            bool inputCorrect = true;

            SetBoard();
            

            //run the code as long as the program is running
            do
            {
                               
                //set which players turn it is and which character is used
                if (player == 2)
                {
                    
                    EnterXorO(player, input);
                    player = 1;
                }
                else if (player == 1)
                {
                    
                    EnterXorO(player, input);
                    player = 2;
                }

                SetBoard();

                #region
                //check to see if the game has been won.
                char[] playerChars = { 'X', 'O' };

                foreach (char playerChar in playerChars)
                {
                    if (((playfield[0, 0] == playerChar) && (playfield[0, 1] == playerChar) && (playfield[0, 2] == playerChar))
                        || ((playfield[1, 0] == playerChar) && (playfield[1, 1] == playerChar) && (playfield[1, 2] == playerChar))
                        || ((playfield[2, 0] == playerChar) && (playfield[2, 1] == playerChar) && (playfield[2, 2] == playerChar))
                        || ((playfield[0, 0] == playerChar) && (playfield[1, 0] == playerChar) && (playfield[2, 0] == playerChar))
                        || ((playfield[0, 1] == playerChar) && (playfield[1, 1] == playerChar) && (playfield[2, 1] == playerChar))
                        || ((playfield[0, 2] == playerChar) && (playfield[1, 2] == playerChar) && (playfield[2, 2] == playerChar))
                        || ((playfield[0, 0] == playerChar) && (playfield[1, 1] == playerChar) && (playfield[2, 2] == playerChar))
                        || ((playfield[0, 2] == playerChar) && (playfield[1, 1] == playerChar) && (playfield[2, 0] == playerChar)))
                    {
                        if(playerChar == 'X')
                        {
                            Console.WriteLine("Winner is Player 1");
                        }
                        else
                        {
                            Console.WriteLine("Winner is Player 2");
                        }
                        Console.WriteLine("Would you like to play again? \nPress Y for Yes or N for No");
                        string playAgain = Console.ReadLine();

                        if (playAgain.ToUpper() == "Y")
                        {
                            ResetBoard();
                        }
                        else if (playAgain.ToUpper() == "N")
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("You have entered an invalid value!  Press Y or N");
                        }
                      
                        break;
                    }
                    else if (turns == 10)
                    {
                        Console.WriteLine("The Game is a TIE!");
                        Console.WriteLine("Would you like to play again? \nPress Y for Yes or N for No");
                        string playAgain = Console.ReadLine();

                        if (playAgain.ToUpper() == "Y")
                        {
                            ResetBoard();
                        }
                        else if (playAgain.ToUpper() == "N")
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("You have entered an invalid value!  Press Y or N");
                        }
                    }
                    
                }

                #endregion


                #region
                //Tests to see if the spot has already been played
                //Display for the user which continues to run until program closes
                do
                {
                    Console.Write("\nPlayer {0}: Choose where you would like to place your piece! ",player);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a number!");
                    }

                    if ((input == 1) && (playfield[0,0] == '1'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 2) && (playfield[0, 1] == '2'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 3) && (playfield[0, 2] == '3'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 4) && (playfield[1, 0] == '4'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 5) && (playfield[1, 1] == '5'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 6) && (playfield[1, 2] == '6'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 7) && (playfield[2, 0] == '7'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 8) && (playfield[2, 1] == '8'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 9) && (playfield[2, 2] == '9'))
                    {
                        inputCorrect = true;
                    }
                    else
                    {
                        Console.Write("\nThis location has already been used.  \nPlease select another spot!");
                        inputCorrect = false;
                    }

                } while (!inputCorrect);
                #endregion

            } while (true);
            
        }

        public static void ResetBoard()
        {
            char[,] playfieldStart =
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };
            playfield = playfieldStart;
            turns = 0;
            SetBoard();
            
        }

        public static void SetBoard()
        {
            //clear the board
            Console.Clear();
            //creates the basics of the board and reference locations
            Console.WriteLine("      |      |            Current number of moves: {0}",turns - 1);
            Console.WriteLine("  {0}   |  {1}   |  {2}", playfield[0, 0], playfield[0, 1], playfield[0, 2]);
            Console.WriteLine("______|______|______");
            Console.WriteLine("      |      |      ");
            Console.WriteLine("  {0}   |  {1}   |  {2}", playfield[1, 0], playfield[1, 1], playfield[1, 2]);
            Console.WriteLine("______|______|______");
            Console.WriteLine("      |      |      ");
            Console.WriteLine("  {0}   |  {1}   |  {2}", playfield[2, 0], playfield[2, 1], playfield[2, 2]);
            Console.WriteLine("      |      |      ");
            turns++;
        }

        public static void EnterXorO(int player, int input)
        {
            char playerSign = ' ';

            if (player == 1)
            {
                playerSign = 'X';
            }
            else if (player == 2)
            {
                playerSign = 'O';
            }
            switch (input)
            {
                //changes the field value from the number to the X for Player 1
                //or O for Player 2 based on location picked
                case 1:
                    playfield[0, 0] = playerSign;
                    break;
                case 2:
                    playfield[0, 1] = playerSign;
                    break;
                case 3:
                    playfield[0, 2] = playerSign;
                    break;
                case 4:
                    playfield[1, 0] = playerSign;
                    break;
                case 5:
                    playfield[1, 1] = playerSign;
                    break;
                case 6:
                    playfield[1, 2] = playerSign;
                    break;
                case 7:
                    playfield[2, 0] = playerSign;
                    break;
                case 8:
                    playfield[2, 1] = playerSign;
                    break;
                case 9:
                    playfield[2, 2] = playerSign;
                    break;

            }

        }
    }
}
