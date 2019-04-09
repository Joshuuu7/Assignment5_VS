using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloresOlderr_Assignment5
{
    public partial class Hard_Form : Form
    {
        private Pen hard_White_Pen;
        SolidBrush hard_Brush = new SolidBrush(Color.Green);
        Font drawFont = new Font("Arial", 16);

        public Hard_Form()
        {
            hard_White_Pen = new Pen(Color.White);
            InitializeComponent();
        }

        private void Hard_Playing_Field_Draw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int screen_X; int screen_Y;

            Random random = new Random();
            int should_show_number = random.Next(2);

            //for (int x = 0; x < 5; x++)
            //{
            //    screen_X = x * (Hard_Playing_Field.Width / 6);
            //    for (int y = 0; y < 5; y++)
            //    {
            //        screen_Y = y * (Hard_Playing_Field.Height / 6);
            //        //summation_matrix[x, y] = random.Next(5, 100);
            //        //should_show_number = random.Next(2);
            //        if (should_display_number[x, y])
            //        {
            //            g.DrawString(summation_matrix[x, y] + "", drawFont, hard_Brush, screen_X, screen_Y);
            //        }
            //    }
            //}

            //screen_X = (Hard_Playing_Field.Width * 5) / 6;

            //for (int y = 0; y < 5; y++)
            //{
            //    screen_Y = y * (Hard_Playing_Field.Height / 6);
            //    should_show_number = random.Next(2);
            //    if (should_display_number[5, y])
            //    {
            //        g.DrawString(right_edge[y] + "", drawFont, hard_Brush, screen_X, screen_Y);
            //    }
            //}

            //screen_Y = (Hard_Playing_Field.Height * 5) / 6;
            //for (int x = 0; x < 5; x++)
            //{
            //    screen_X = x * (Hard_Playing_Field.Width / 6);
            //    should_show_number = random.Next(2);
            //    if (should_display_number[x, 5])
            //    {
            //        g.DrawString(bottom_edge[x] + "" + "", drawFont, hard_Brush, screen_X, screen_Y);
            //    }
            //}

            g.DrawLine(hard_White_Pen, (Hard_Playing_Field.Width * 1 / 10), 0,
                                   (Hard_Playing_Field.Width * 1 / 10), Hard_Playing_Field.Height);
            g.DrawLine(hard_White_Pen, (Hard_Playing_Field.Width * 2 / 10), 0,
                                   (Hard_Playing_Field.Width * 2 / 10), Hard_Playing_Field.Height);
            g.DrawLine(hard_White_Pen, (Hard_Playing_Field.Width * 3 / 10), 0,
                                   (Hard_Playing_Field.Width * 3 / 10), Hard_Playing_Field.Height);
            g.DrawLine(hard_White_Pen, (Hard_Playing_Field.Width * 4 / 10), 0,
                                   (Hard_Playing_Field.Width * 4 / 10), Hard_Playing_Field.Height);
            g.DrawLine(hard_White_Pen, (Hard_Playing_Field.Width * 5 / 10), 0,
                                   (Hard_Playing_Field.Width * 5 / 10), Hard_Playing_Field.Height);
            g.DrawLine(hard_White_Pen, (Hard_Playing_Field.Width * 6 / 10), 0,
                                  (Hard_Playing_Field.Width * 6 / 10), Hard_Playing_Field.Height);
            g.DrawLine(hard_White_Pen, (Hard_Playing_Field.Width * 7 / 10), 0,
                                  (Hard_Playing_Field.Width * 7 / 10), Hard_Playing_Field.Height);
            g.DrawLine(hard_White_Pen, (Hard_Playing_Field.Width * 8 / 10), 0,
                                  (Hard_Playing_Field.Width * 8 / 10), Hard_Playing_Field.Height);
            g.DrawLine(hard_White_Pen, (Hard_Playing_Field.Width * 9 / 10), 0,
                                  (Hard_Playing_Field.Width * 9 / 10), Hard_Playing_Field.Height);

            g.DrawLine(hard_White_Pen, 0, (Hard_Playing_Field.Height * 1 / 10),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 1 / 10));
            g.DrawLine(hard_White_Pen, 0, (Hard_Playing_Field.Height * 2 / 10),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 2 / 10));
            g.DrawLine(hard_White_Pen, 0, (Hard_Playing_Field.Height * 3 / 10),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 3 / 10));
            g.DrawLine(hard_White_Pen, 0, (Hard_Playing_Field.Height * 4 / 10),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 4 / 10));
            g.DrawLine(hard_White_Pen, 0, (Hard_Playing_Field.Height * 5 / 10),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 5 / 10));
            g.DrawLine(hard_White_Pen, 0, (Hard_Playing_Field.Height * 6 / 10),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 6 / 10));
            g.DrawLine(hard_White_Pen, 0, (Hard_Playing_Field.Height * 7 / 10),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 7 / 10));
            g.DrawLine(hard_White_Pen, 0, (Hard_Playing_Field.Height * 8 / 10),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 8 / 10));
            g.DrawLine(hard_White_Pen, 0, (Hard_Playing_Field.Height * 9 / 10),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 9 / 10));
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            Hard_Form hard_Form = new Hard_Form();
            form1.Show();
            this.Hide();
            hard_Form.Close();
        }
    }
}
