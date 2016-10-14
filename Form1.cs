using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormPractice
{
	public partial class Form1 : Form
	{
		GFX engine;
		Board board;

		public Form1()
		{
			InitializeComponent();
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Graphics toPass = panel1.CreateGraphics();
			engine = new GFX(toPass);

			board = new Board();
			board.initBoard();
		}

		private void panel1_Click(object sender, EventArgs e)
		{
			Point mouse = Cursor.Position;
			mouse = panel1.PointToClient(mouse);
			board.detectClick(mouse);
		}
	}
}
