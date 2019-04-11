using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloresOlderr_Assignment5
{
    public partial class Form1 : Form
    {
        private static Pen myWhitePen;

        MediumData mediumData;

        public Form1()
        {

            mediumData = new MediumData();
            myWhitePen = new Pen(Color.White);

            string digits = "0123456789";

            StringBuilder file_data_builder = new StringBuilder();
            StringBuilder solution = new StringBuilder();

            using (StreamReader inFile = new StreamReader("medium/m1.txt"))
            {
                while (!inFile.EndOfStream)
                {
                    char ch = (char)inFile.Read();
                    //Console.WriteLine("ch = " + ch);
                    if (digits.IndexOf(ch) == -1)
                    {
                        file_data_builder.Append('$');
                        Console.WriteLine(file_data_builder);
                        if(file_data_builder.Equals("$$"))
                        {

                        }
                    }
                    else
                    {
                        file_data_builder.Append(ch);
                        //Console.WriteLine(file_data_builder);
                    }
                }
            }

            StringBuilder digitsOnly = new StringBuilder();

            foreach (char cha in file_data_builder.ToString().ToCharArray())
            {
                if (digits.IndexOf(cha) >= 0)
                {
                    digitsOnly.Append(cha);
                }
            }

            //Console.WriteLine("digitsOnly " + digitsOnly.ToString());

            char[] file_chars = digitsOnly.ToString().ToCharArray();

            int len = file_chars.Length;

            int r = 0;

            while (r < len)
            {
                if (r < len / 2)
                {
                    if (file_chars[r] > 48)
                    {
                        mediumData.initially_displayed[r / 5, r % 5] = true;
                        //Console.WriteLine("Custom (In IF IF): " + mediumData.initially_displayed[r / 5, r % 5]);
                    }

                    mediumData.medium_custom_summation_matrix[r / 5, r % 5] = file_chars[r] - 48;
                    //Console.WriteLine("Custom (In IF): " + mediumData.medium_custom_summation_matrix[r / 5, r % 5]);
                }
                else
                {
                    int t = r - (len / 2);
                    mediumData.medium_summation_matrix[t / 5, t % 5] = file_chars[r] - 48;
                    //Console.WriteLine("Normal (In ELSE): " + mediumData.medium_summation_matrix[t / 5, t % 5]);
                }
                r++;
            }

            InitializeComponent();

            for (int u = 0; u < 5; u++)
            {
                for (int v = 0; v < 5; v++)
                {
                    Console.WriteLine("medium_custom_summation_matrix : " + mediumData.medium_custom_summation_matrix[u, v]);
                    Console.WriteLine("medium_summation_matrix: " + mediumData.medium_summation_matrix[u, v]);
                }
            }
        }

        public Form1(MediumData MD)
        {
            mediumData = MD;         
            myWhitePen = new Pen(Color.White);
            InitializeComponent();
        }

        private void Choose_Difficulty_Playing_Field(object sender, MouseEventArgs e)
        {
            Form1 form1 = new Form1();
            RadioButton EasyRB = EasyRadioButton;
            RadioButton MediumRB = MediumRadioButton;
            RadioButton HardRB = HardRadioButton;

            if (EasyRB.Checked)
            {
                Easy_Form easy_Form = new Easy_Form();
                easy_Form.Show();
                this.Hide();
                form1.Close();
            }
            else if (MediumRB.Checked)
            {
                Medium_Form medium_Form = new Medium_Form(mediumData);
                medium_Form.Show();
                this.Hide();
                form1.Close();

            }
            else if (HardRB.Checked)
            {
                Hard_Form hard_Form = new Hard_Form();
                hard_Form.Show();
                this.Hide();
                form1.Close();
            }
        }
        
    }

    public class MediumData
    {
        public Medium_Form medium_Form;
        public bool created;

        public int[,] medium_summation_matrix;
        public int[,] medium_custom_summation_matrix;
        public int[] medium_right_edge;
        public int[] medium_custom_right_edge;
        public int[] medium_bottom_edge;
        public int[] medium_custom_bottom_edge;

        public bool [,] should_display_number;
        public bool [,] initially_displayed;

        string medium_stop_watch;

        public MediumData( )
        {
            medium_summation_matrix = new int[6, 6];
            medium_custom_summation_matrix = new int[6, 6]; 
            medium_right_edge = new int[5];

            medium_bottom_edge = new int[5];


            should_display_number = new bool[6, 6];
            initially_displayed = new bool[6, 6];

            medium_custom_right_edge = new int[5];
            medium_custom_bottom_edge = new int[5];

            //medium_stop_watch = Medium_Stop_Watch;
        }
    }
}