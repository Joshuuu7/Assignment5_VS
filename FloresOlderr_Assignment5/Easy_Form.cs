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
    public partial class Easy_Form : Form
    {
        private static Pen easy_White_Pen;

        public Easy_Form()
        {
            easy_White_Pen = new Pen(Color.White);
            InitializeComponent();
        }

        private void Easy_Playing_Field_Draw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawLine(easy_White_Pen, (Easy_Playing_Field.Width / 3), 0,
                                   (Easy_Playing_Field.Width / 3), Easy_Playing_Field.Height);
            g.DrawLine(easy_White_Pen, (Easy_Playing_Field.Width * 2 / 3), 0,
                                   (Easy_Playing_Field.Width * 2 / 3), Easy_Playing_Field.Height);

            g.DrawLine(easy_White_Pen, 0, (Easy_Playing_Field.Height / 3),
                                   Easy_Playing_Field.Width, (Easy_Playing_Field.Height / 3));
            g.DrawLine(easy_White_Pen, 0, (Easy_Playing_Field.Height * 2 / 3),
                                   Easy_Playing_Field.Width, (Easy_Playing_Field.Height * 2 / 3));
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            Easy_Form easy_Form = new Easy_Form();
            form1.Show();
            this.Hide();
            easy_Form.Close();
        }
    }
}
