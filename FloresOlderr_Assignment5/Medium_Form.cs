using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;

namespace FloresOlderr_Assignment5
{
    public partial class Medium_Form : Form
    {
        MediumData MD;

        private Pen medium_White_Pen;
        SolidBrush medium_Brush = new SolidBrush(Color.Blue);
        Font drawFont = new Font("Arial", 16);

        Random random = new Random();
        int rand;

        bool[,] should_display_number = new bool[6, 6];
        bool[,] initially_displayed = new bool[6, 6];

        // Summation Matrix
        int[,] summation_matrix = new int[5, 5];
        
        // Right Edge, Bottom Edge
        int[] right_edge = new int[5];
        int[] bottom_edge = new int[5];

        // Custom Summation Matrix
        int[,] custom_summation_matrix = new int[5, 5];

        // Custom Right Edge, Custom Bottom Edge
        int[] custom_right_edge = new int[5];
        int[] custom_bottom_edge = new int[5];

        public Medium_Form(MediumData MD)
        {
            this.MD = MD;
            Console.WriteLine("Successfully transferred the saved data");

            summation_matrix = MD.medium_summation_matrix;
            should_display_number = MD.should_display_number;
            initially_displayed = MD.initially_displayed;

            right_edge = MD.medium_right_edge;
            bottom_edge = MD.medium_bottom_edge;

            custom_summation_matrix = MD.medium_custom_summation_matrix;

            custom_right_edge = MD.medium_custom_right_edge;

            for (int x = 0; x < 5; x++)
            {
                Console.WriteLine("Custom Right Edge: " + custom_bottom_edge[x]);
            }

            custom_bottom_edge = MD.medium_custom_bottom_edge;

            medium_White_Pen = new Pen(Color.White);
            InitializeComponent();
        }

        public Medium_Form()
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    summation_matrix[x, y] = random.Next(5, 100);                   
                }
            }

            medium_White_Pen = new Pen(Color.White);
            InitializeComponent();
      
            // Right Edge
            for (uint y = 0; y < 5; y++)
            {
                int row_sum = 0;
                for (uint x = 0; x < 5; x++)
                {
                    row_sum += summation_matrix[x, y];
                }
                right_edge[y] = row_sum;
            }

            // Bottom Edge
            for (int x = 0; x < 5; x++)
            {
                int col_sum = 0;
                for (int y = 0; y < 5; y++)
                {
                    col_sum += summation_matrix[x, y];
                }
                bottom_edge[x] = col_sum;
            }

            for (int u = 0; u < 5; u++)
            {

                for (int v = 0; v < 5; v++)
                {
                    rand = random.Next(2);
                    if (rand == 1)
                    {
                        should_display_number[u, v] = true;
                        initially_displayed[u, v] = true;
                        custom_summation_matrix[u, v] = summation_matrix[u, v];
                    }
                    else
                    {
                        should_display_number[u, v] = false;
                        initially_displayed[u, v] = false;
                    }
                }
            }

            for (int u = 0; u < 5; u++)
            {
                rand = random.Next(2);
                if (rand == 1)
                {
                    should_display_number[5, u] = true;
                }
                else
                {
                    should_display_number[5, u] = false;
                }
            }

            for (int v = 0; v < 5; v++)
            {
                rand = random.Next(2);
                if (rand == 1)
                {
                    should_display_number[v, 5] = true;
                }
                else
                {
                    should_display_number[v, 5] = false;
                }
            }
            for (int u = 0; u < 5; u++)
            {
                if (should_display_number[u, 5])
                {                  
                    custom_right_edge[u] = right_edge[u];
                }
            }

            for (int v = 0; v < 5; v++)
            {
                if (should_display_number[5, v])
                {
                    custom_bottom_edge[v] = bottom_edge[v];
                }
            }
        }

        private void UpdateVisibleGrid(int x, int y, int number)
        {
            Graphics g = Medium_Playing_Field.CreateGraphics();

            if (x == 5)
            {
                right_edge[y] = number;
            } else if (y == 5)
            {
                bottom_edge[x] = number;
            } else
            {
                summation_matrix[x, y] = number;
            }

            int screen_X = (x * Medium_Playing_Field.Width) / 6;
            int screen_Y = (y * Medium_Playing_Field.Height) / 6;
        }

        private void Update_Medium_Form_Click(object sender, MouseEventArgs e)
        {
            Graphics g = Medium_Playing_Field.CreateGraphics();

            int X = 0;
            int Y = 0;
            int width = Medium_Playing_Field.Width;
            int height = Medium_Playing_Field.Height;

            if (e.X < width / 6)
                X = 0;
            else if (e.X < ((2 * width) / 6))
                X = 1;
            else if (e.X < ((3 * width) / 6))
                X = 2;
            else if (e.X < ((4 * width) / 6))
                X = 3;
            else if (e.X < ((5 * width) / 6))
                X = 4;
            else
                X = 5;

            if (e.Y < height / 6)
                Y = 0;
            else if (e.Y < ((2 * height) / 6))
                Y = 1;
            else if (e.Y < ((3 * height) / 6))
                Y = 2;
            else if (e.Y < ((4 * height) / 6))
                Y = 3;
            else if (e.Y < ((5 * height) / 6))
                Y = 4;
            else
                Y = 5;
            
            if (MediumTextBox.Text != "" && Regex.IsMatch(MediumTextBox.Text, @"^\d+$"))
            {
                int number = Convert.ToInt32(MediumTextBox.Text);
                if (!initially_displayed[X, Y])
                {
                    should_display_number[X, Y] = true;
                    if (number >= 1 && number < 1000)
                    {
                        g.DrawString(number.ToString(), drawFont, medium_Brush, X * (width / 6), Y * (height / 6));
                        if (X <= 4 && Y <= 4)
                        {
                            custom_summation_matrix[X, Y] = number;
                            CheckSolution();
                            if (!CheckSolution())
                            {
                                custom_summation_matrix[X, Y] = 0;
                                ClearCell(X, Y);
                            }
                        }
                    }
                    else
                    {
                        DisplayAlert("You entered too high of a value!", "ERROR");
                    }
                }
            }
            else
            {
                DisplayAlert("Please make sure to enter integers only.", "ERROR");
            }
        }

        bool CheckSolution()
        {
            int u, v;
            for (u = 0; u < 5; u ++)
            {                        
                int desired_row_sum = bottom_edge[u];
                if (desired_row_sum == 0)
                {
                    continue;
                }
                int row_sum = 0;
                for (v = 0; v < 5; v++)
                {
                    row_sum += custom_summation_matrix[u, v];
                }
                if (row_sum  > desired_row_sum)
                {
                    DisplayAlert("You entered too high of a value!", "Error");
                    return false;
                } else if (row_sum == desired_row_sum)
                {
                    DisplayAlert("Good!", "Success");
                }                
            }
            return true;
        }

        void ClearCell(int x, int y)
        {
            Graphics g = Medium_Playing_Field.CreateGraphics();

            SolidBrush paintItBlack = new SolidBrush(Color.Black);
            g.FillRectangle(paintItBlack, x / Medium_Playing_Field.Width, y / Medium_Playing_Field.Height, (x + 1) / (Medium_Playing_Field.Width), (y + 1) / (Medium_Playing_Field.Height));
        }

        void DisplayAlert(string message, string type)
        {
            MessageBox.Show(string.Format(message), type, MessageBoxButtons.OK);
        }

        private void Medium_Playing_Field_Draw(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            int screen_X; int screen_Y;

            Random random = new Random();
            int should_show_number = random.Next(2);

            for (int x = 0; x < 5; x++)
            {
                screen_X = x * (Medium_Playing_Field.Width / 6);
                for (int y = 0; y < 5; y++)
                {
                    screen_Y = y * (Medium_Playing_Field.Height / 6);
                    //summation_matrix[x, y] = random.Next(5, 100);
                    //should_show_number = random.Next(2);
                    if (custom_summation_matrix[x, y] > 0)
                    {
                        g.DrawString(custom_summation_matrix[x, y] + "", drawFont, medium_Brush, screen_X, screen_Y);
                    }
                }
            }

            screen_X = (Medium_Playing_Field.Width * 5) / 6;

            for (int y = 0; y < 5; y++)
            {
                screen_Y = y * (Medium_Playing_Field.Height / 6);
                should_show_number = random.Next(2);
                if (custom_right_edge[y] > 0)
                {
                    g.DrawString(custom_right_edge[y] + "", drawFont, medium_Brush, screen_X, screen_Y);
                }
            }

            screen_Y = (Medium_Playing_Field.Height * 5) / 6;
            for (int x = 0; x < 5; x++)
            {
                screen_X = x * (Medium_Playing_Field.Width / 6);
                should_show_number = random.Next(2);
                if (custom_bottom_edge[x] > 0)
                {
                    g.DrawString(custom_bottom_edge[x] + "", drawFont, medium_Brush, screen_X, screen_Y);
                }
            }

            g.DrawLine(medium_White_Pen, (Medium_Playing_Field.Width * 1 / 6), 0,
                                   (Medium_Playing_Field.Width * 1 / 6), Medium_Playing_Field.Height);
            g.DrawLine(medium_White_Pen, (Medium_Playing_Field.Width * 2 / 6), 0,
                                   (Medium_Playing_Field.Width * 2 / 6), Medium_Playing_Field.Height);
            g.DrawLine(medium_White_Pen, (Medium_Playing_Field.Width * 3 / 6), 0,
                                   (Medium_Playing_Field.Width * 3 / 6), Medium_Playing_Field.Height);
            g.DrawLine(medium_White_Pen, (Medium_Playing_Field.Width * 4 / 6), 0,
                                   (Medium_Playing_Field.Width * 4 / 6), Medium_Playing_Field.Height);
            g.DrawLine(medium_White_Pen, (Medium_Playing_Field.Width * 5 / 6), 0,
                                   (Medium_Playing_Field.Width * 5 / 6), Medium_Playing_Field.Height);

            g.DrawLine(medium_White_Pen, 0, (Medium_Playing_Field.Height * 1 / 6),
                                   Medium_Playing_Field.Width, (Medium_Playing_Field.Height * 1 / 6));
            g.DrawLine(medium_White_Pen, 0, (Medium_Playing_Field.Height * 2 / 6),
                                   Medium_Playing_Field.Width, (Medium_Playing_Field.Height * 2 / 6));
            g.DrawLine(medium_White_Pen, 0, (Medium_Playing_Field.Height * 3 / 6),
                                   Medium_Playing_Field.Width, (Medium_Playing_Field.Height * 3 / 6));
            g.DrawLine(medium_White_Pen, 0, (Medium_Playing_Field.Height * 4 / 6),
                                   Medium_Playing_Field.Width, (Medium_Playing_Field.Height * 4 / 6));
            g.DrawLine(medium_White_Pen, 0, (Medium_Playing_Field.Height * 5 / 6),
                                   Medium_Playing_Field.Width, (Medium_Playing_Field.Height * 5 / 6));

        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            MD = new MediumData();

            MD.medium_summation_matrix = summation_matrix;
            MD.should_display_number = should_display_number;
            MD.initially_displayed = initially_displayed;

            MD.medium_right_edge = right_edge;
            MD.medium_bottom_edge = bottom_edge;

            MD.medium_custom_summation_matrix = custom_summation_matrix;

            MD.medium_custom_right_edge = custom_right_edge;
            MD.medium_custom_bottom_edge = custom_bottom_edge;

            Form1 form1 = new Form1(MD);


            Medium_Form medium_Form = new Medium_Form();
            form1.Show();
            this.Hide();
            medium_Form.Close();
        }
    }
}
