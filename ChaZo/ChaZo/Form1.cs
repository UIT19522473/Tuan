using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChaZo
{
    public partial class Form1 : Form
    {
        private List<List<Button>> matrix;

        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("them Hinh");
        }

        private void txtUserName_Click(object sender, EventArgs e)
        {

        }

        void LoadMatrix()
        {
            Matrix = new List<List<Button>>();
            Button oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.Margin, 0) };
            for (int i = 0; i < Cons.DayOffColumn; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < Cons.DayOfweek; j++)
                {
                    Button a = new Button() { Height = Cons.Height, Width = Cons.Width };

                    //a.Image = Image.FromFile(@"C:\Users\tuank\Desktop\up.png");
                    //a.ImageAlign = ContentAlignment.MiddleRight;
                    //a.TextAlign = ContentAlignment.MiddleLeft;
                    //// Give the button a flat appearance.
                    //a.FlatStyle = FlatStyle.Flat;

                    a.Location = new Point(oldBtn.Location.X + oldBtn.Width + Cons.Margin, oldBtn.Location.Y);

                    a.Click += A_Click; ;

                    pnShow.Controls.Add(a);
                    Matrix[i].Add(a);
                    oldBtn = a;
                }
                oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.Margin, oldBtn.Location.Y + Cons.Height) };
            }

            //SetDefaultDate();
        }

        private void A_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void test()
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadMatrix();
        }
    }
}
