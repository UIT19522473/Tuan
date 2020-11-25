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
    public partial class Calendar : Form
    {
        private List<List<Button>> matrix;

        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }

        private List<string> dateOfWeek = new List<string>() { "Monday"
        ,"Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday"};

        string InUser = "";

        public Calendar()
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

        //ham lay thu tu ngay trong nam
        int DayofMonth(DateTime date)
        {
            switch (date.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    if ((date.Year % 4 == 0 && date.Year % 100 != 0) || date.Year % 400 == 0)
                        return 29;
                    else return 28;
                default:
                    return 30;
            }
        }

        //tao ma tran button
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

                    
                    a.FlatAppearance.BorderSize = 1;
                    a.FlatAppearance.BorderColor = Color.LightSkyBlue;
                    a.TextAlign = ContentAlignment.TopLeft;
                    a.FlatStyle = FlatStyle.Flat;


                    a.Location = new Point(oldBtn.Location.X + oldBtn.Width + Cons.Margin, oldBtn.Location.Y);

                    a.Click += A_Click; ;

                    pnShow.Controls.Add(a);
                    Matrix[i].Add(a);
                    oldBtn = a;
                }
                oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.Margin, oldBtn.Location.Y + Cons.Height) };
            }

            SetDefaultDate();
        }
        //ham them gia tri ngay vao matrix
        void AddNumberIntoMatrixByDate(DateTime date)
        {
            Clear();
            DateTime useDate = new DateTime(date.Year, date.Month, 1);

            int line = 0;
            for (int i = 1; i <= DayofMonth(date); i++)
            {
                int column = dateOfWeek.IndexOf(useDate.DayOfWeek.ToString());
                Button btn = Matrix[line][column];
                btn.Text = i.ToString();

                if (column >= 6)
                    line++;
                if (checkEvent(useDate, InUser))
                {
                    btn.BackColor = Color.Red;
                }
                else if (isEqualDate(useDate, date))
                {
                    btn.BackColor = Color.Blue;
                }

                else if (isEqualDate(useDate, DateTime.Now))
                {
                    btn.BackColor = Color.Yellow;
                }

                useDate = useDate.AddDays(1);

            }

        }

        //kiem tra ngay duoc chon
        bool isEqualDate(DateTime a, DateTime b)
        {
            return a.Year == b.Year && a.Month == b.Month && a.Day == b.Day;
        }


        //kiem tra ngay do co envent hay ko
        bool checkEvent(DateTime useDate, string InUser)
        {
            //string s = "";
            //s = s + useDate.Month.ToString() + "/" + useDate.Day.ToString() + "/" + useDate.Year.ToString();
            ////if (curAcc.JobList.Exists(x => x.DTPK == s))
            ////    return true;
            ////return false;
            //DataTable tb = new DataTable();
            //SqlConnection sql = new SqlConnection(curAcc.query);
            //sql.Open();
            //// MessageBox.Show("select *from DailyEvent where InDTPK = '" + s + "' and InUser = '" + InUser + "'");
            //SqlDataAdapter read = new SqlDataAdapter("select *from DailyEvent where InDTPK = '" + s + "' and InUser = '" + InUser + "'", sql);
            //read.Fill(tb);
            //for (int j = 0; j < tb.Rows.Count; j++)
            //{
            //    if (tb.Rows[0][j].ToString() == s)
            //    {
            //        sql.Close();

            //        return true;
            //    }

            //}

            //sql.Close();

            return false;
        }

        //set thoi gian ve mac dinh
        void SetDefaultDate()
        {
            dtpkDate.Value = DateTime.Now;
        }

        // clear panel co lich hien tai
        void Clear()
        {
            for (int i = 0; i < Matrix.Count; i++)
            {
                for (int j = 0; j < Matrix[i].Count; j++)
                {
                    Button x = Matrix[i][j];
                    x.Text = "";
                    x.BackColor = Color.WhiteSmoke;
                }
            }
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

        //print ra ma tran moi khi datimepicker thay doi
        private void dtpkDate_ValueChanged(object sender, EventArgs e)
        {
            AddNumberIntoMatrixByDate((sender as DateTimePicker).Value);
        }

        private void btnMDown_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddMonths(-1);
        }

        private void btnMUp_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddMonths(1);
        }

        private void btnToDay_Click(object sender, EventArgs e)
        {
            SetDefaultDate();
        }
    }
}
