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
    public partial class Form1 : Form
    {
        private static Pen myWhitePen;

        public static MediumData mediumData;

        public Form1()
        {           
            myWhitePen = new Pen(Color.White);
            InitializeComponent();           
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
                //Console.WriteLine("Here is the Form1.mediumData.medium_summation_matrix[i, j]: ");
                //for (int i = 0; i < 5; i++)
                //{
                //    for(int j = 0; j < 0; j++)
                //    {
                //        Console.WriteLine(Form1.mediumData.medium_summation_matrix[i, j] + " ");
                //        Console.WriteLine(Form1.mediumData.medium_custom_summation_matrix[i, j] + " ");
                //    }
                //}                

                //if (Form1.mediumData.medium_Form == null)
                //{
                //    //Console.WriteLine("Here is the uninitiazed Form1.mediumData.medium_summation_matrix[i, j]: ");
                //    //for (int i = 0; i < 5; i++)
                //    //{
                //    //    for (int j = 0; j < 0; j++)
                //    //    {
                //    //        Console.WriteLine(Form1.mediumData.medium_summation_matrix[i, j] + " ");
                //    //        Console.WriteLine(Form1.mediumData.medium_custom_summation_matrix[i, j] + " ");
                //    //    }
                //    //}
                //    Medium_Form medium_Form = new Medium_Form();
                //    medium_Form.Show();
                //    this.Hide();
                //    form1.Close();
                //}
                //else
                //{
                //    //Console.WriteLine("Here is the initalized Form1.mediumData.medium_summation_matrix[i, j]: ");
                //    //for (int i = 0; i < 5; i++)
                //    //{
                //    //    for (int j = 0; j < 0; j++)
                //    //    {
                //    //        Console.WriteLine(Form1.mediumData.medium_summation_matrix[i, j] + " ");
                //    //        Console.WriteLine(Form1.mediumData.medium_custom_summation_matrix[i, j] + " ");
                //    //    }
                //    //}
                //    Medium_Form medium_Form = Form1.mediumData.medium_Form;
                //    medium_Form.Show();
                //    this.Hide();
                //    form1.Close();
                //} 

                if(mediumData == null)
                {
                    Medium_Form medium_Form = new Medium_Form();
                    medium_Form.Show();
                    this.Hide();
                    form1.Close();
                }
                else
                {
                    Medium_Form medium_Form = new Medium_Form(mediumData);
                    medium_Form.Show();
                    this.Hide();
                    form1.Close();
                }
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

        public MediumData( )
        {

        }
    }
}