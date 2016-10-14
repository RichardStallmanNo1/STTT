using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormPractice
{
	class Board
	{
		public int movesMade = 0;

		private Holder[,] holders = new Holder[3, 3];

		public const int X = 0;
		public const int O = 1;
		public const int B = 2;
		public const char l = ' ';
		public void initBoard()
		{
			for(int i = 0; i < 3; i++)
			{
				for(int x = 0; x < 3; x++)
				{
                    holders[i, x] = new Holder();
					holders[i, x].setValue(B);
					holders[i, x].setLocation(new Point(i, x));
				}
			}
		}

        public void detectClick(Point mouseLoc)
        {
            gameTurn(mouseLoc);
        }



        public void gameTurn(Point mouseLoc)
        {
            int x = 0;
            int y = 0;

            if (mouseLoc.Y <= 500)
            {
               
                    if (mouseLoc.X < 167) {
                        x = 0;
                    }
                    else if (mouseLoc.X < 334) {
                        x = 1;
                    }
                    else {
                        x = 2;
                    }
                    if (mouseLoc.Y < 167)  {
                        y = 0;
                    }
                    else if (mouseLoc.Y < 334)  {
                        y = 1;
                    }
                    else if (mouseLoc.Y < 503) {
                        y = 2;
                    }


                    if (detectWin() == 0)
                    {
                        if (holders[x, y].getLetter().Equals('X') || holders[x, y].getLetter().Equals('O'))
                        {
                        }
                        else
                        {
                            //Turn Logic:
                            if (movesMade % 2 == 0)
                            {
                                GFX.drawX(new Point(x, y));
                                holders[x, y].setValue(X);
                                holders[x, y].setLetter('X');
                                movesMade++;
                            }
                            else
                            {
                                GFX.drawO(new Point(x, y));
                                holders[x, y].setValue(O);
                                holders[x, y].setLetter('O');
                                movesMade++;
                            }

                            if (detectWin() == 1)
                            {
                                Console.WriteLine("Congratulations, player {0}, you Win!", holders[x, y].getLetter());

                            }
                        if (detectWin() == 2) {
                            Console.WriteLine("I tawt I taw a puddycat; CAT.");

                        }
                        }
                    
                }
            }
        }









        public int detectWin()
		{

            int boardFull = 0;

			int[,] win = new int[8, 3] {
				{ holders[0, 0].getValue(), holders[0, 1].getValue(), holders[0, 2].getValue() }, //Top Row
				{ holders[1, 0].getValue(), holders[1, 1].getValue(), holders[1, 2].getValue() }, //Middle Row
				{ holders[2, 0].getValue(), holders[2, 1].getValue(), holders[2, 2].getValue() }, //Bottom Row
				{ holders[0, 0].getValue(), holders[1, 0].getValue(), holders[2, 0].getValue() }, //Left Column
				{ holders[0, 1].getValue(), holders[1, 1].getValue(), holders[2, 1].getValue() }, //Middle Column
				{ holders[0, 2].getValue(), holders[1, 2].getValue(), holders[2, 2].getValue() }, //Right Column
				{ holders[0, 0].getValue(), holders[1, 1].getValue(), holders[2, 2].getValue() }, //Negative Slope
				{ holders[2, 0].getValue(), holders[1, 1].getValue(), holders[0, 2].getValue() }  //Positive Slope
				};

			for (int i = 0; i < 8; i++)
			{
				if (win[i, 0] == win[i, 1] && win[i, 1] == win[i, 2] && win[i, 0] != B && win[i, 1] != B && win[i, 2] != B)
				{
					return 1;
				}
			}

            for (int i = 0; i < 3; i++) {
                for (int k = 0; k < 3; k++) {
                    if (holders[i, k].getLetter().Equals('X') || holders[i, k].getLetter().Equals('O'))
                    {
                        boardFull++;
                    }
                }
            }
            if (boardFull == 9) {
                return 2;
            }

			return 0;







		}

	}

	class Holder
	{
		private Point location;
		private int value = Board.B;
		private char letter = Board.l;
		public void setLocation(Point p)
		{
			location = p;
		}
		public Point getLocation()
		{
			return location;
		}
		public void setValue(int i)
		{
			value = i;
		}
		public int getValue()
		{
			return value;
		}
		public void setLetter(char l)
		{
			letter = l;
		}
		public char getLetter()
		{
			return letter;
		}
	}

  



}
