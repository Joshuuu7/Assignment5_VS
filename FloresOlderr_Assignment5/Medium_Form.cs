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

        System.Windows.Forms.Timer medium_Timer = null;
        System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

        SolidBrush medium_Default_White_Brush = new SolidBrush(Color.White);
        SolidBrush medium_Input_Blue_Brush = new SolidBrush(Color.Blue);
        SolidBrush medium_Black_Brush = new SolidBrush(Color.Black);

        Font draw_Font_12_Bold = new Font("Arial", 12, FontStyle.Bold);
        Font draw_Font_13_Bold = new Font("Arial", 13, FontStyle.Bold);
        Font draw_Font_14_Bold = new Font("Arial", 14, FontStyle.Bold);
        Font draw_Font_15_Bold = new Font("Arial", 15, FontStyle.Bold);
        Font draw_Font_16_Bold = new Font("Arial", 16, FontStyle.Bold);
        Font draw_Font_17_Bold = new Font("Arial", 17, FontStyle.Bold);
        Font draw_Font_18_Bold = new Font("Arial", 18, FontStyle.Bold);
        Font draw_Font_19_Bold = new Font("Arial", 19, FontStyle.Bold);

        Font input_Font_12 = new Font("Arial", 12);
        Font input_Font_13 = new Font("Arial", 13);
        Font input_Font_14 = new Font("Arial", 14);
        Font input_Font_15 = new Font("Arial", 15);
        Font input_Font_16 = new Font("Arial", 16);
        Font input_Font_17 = new Font("Arial", 17);
        Font input_Font_18 = new Font("Arial", 18);
        Font input_Font_19 = new Font("Arial", 19);

        Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 5);

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

        //public Medium_Form(MediumData MD)
        //{
        //    this.MD = MD;
        //    Console.WriteLine("Successfully transferred the saved data");

        //    summation_matrix = MD.medium_summation_matrix;
        //    should_display_number = MD.should_display_number;
        //    initially_displayed = MD.initially_displayed;

        //    right_edge = MD.medium_right_edge;
        //    bottom_edge = MD.medium_bottom_edge;

        //    custom_summation_matrix = MD.medium_custom_summation_matrix;

        //    custom_right_edge = MD.medium_custom_right_edge;

        //    for (int x = 0; x < 5; x++)
        //    {
        //        Console.WriteLine("Custom Right Edge: " + custom_bottom_edge[x]);
        //    }

        //    custom_bottom_edge = MD.medium_custom_bottom_edge;

        //    medium_White_Pen = new Pen(Color.White);
        //    InitializeComponent();
        //}

        public Medium_Form(MediumData MD)
        {
            this.MD = MD;

            //StartTimer();

            summation_matrix = MD.medium_summation_matrix;
            should_display_number = MD.should_display_number;
            initially_displayed = MD.initially_displayed;

            right_edge = MD.medium_right_edge;
            bottom_edge = MD.medium_bottom_edge;

            custom_summation_matrix = MD.medium_custom_summation_matrix;

            custom_bottom_edge = MD.medium_custom_bottom_edge;
            custom_right_edge = MD.medium_custom_right_edge;

            medium_White_Pen = new Pen(Color.White);

            InitializeComponent();


        }

        //public Medium_Form()
        //{
        //    for (int x = 0; x < 5; x++)
        //    {
        //        for (int y = 0; y < 5; y++)
        //        {
        //            summation_matrix[x, y] = random.Next(5, 100);                   
        //        }
        //    }

        //    medium_White_Pen = new Pen(Color.White);
        //    InitializeComponent();
      
        //    // Right Edge
        //    for (uint y = 0; y < 5; y++)
        //    {
        //        int row_sum = 0;
        //        for (uint x = 0; x < 5; x++)
        //        {
        //            row_sum += summation_matrix[x, y];
        //        }
        //        right_edge[y] = row_sum;
        //    }

        //    // Bottom Edge
        //    for (int x = 0; x < 5; x++)
        //    {
        //        int col_sum = 0;
        //        for (int y = 0; y < 5; y++)
        //        {
        //            col_sum += summation_matrix[x, y];
        //        }
        //        bottom_edge[x] = col_sum;
        //    }

        //    for (int u = 0; u < 5; u++)
        //    {

        //        for (int v = 0; v < 5; v++)
        //        {
        //            rand = random.Next(2);
        //            if (rand == 1)
        //            {
        //                should_display_number[u, v] = true;
        //                initially_displayed[u, v] = true;
        //                custom_summation_matrix[u, v] = summation_matrix[u, v];
        //            }
        //            else
        //            {
        //                should_display_number[u, v] = false;
        //                initially_displayed[u, v] = false;
        //            }
        //        }
        //    }

        //    for (int u = 0; u < 5; u++)
        //    {
        //        rand = random.Next(2);
        //        if (rand == 1)
        //        {
        //            should_display_number[5, u] = true;
        //        }
        //        else
        //        {
        //            should_display_number[5, u] = false;
        //        }
        //    }

        //    for (int v = 0; v < 5; v++)
        //    {
        //        rand = random.Next(2);
        //        if (rand == 1)
        //        {
        //            should_display_number[v, 5] = true;
        //        }
        //        else
        //        {
        //            should_display_number[v, 5] = false;
        //        }
        //    }
        //    for (int u = 0; u < 5; u++)
        //    {
        //        if (should_display_number[u, 5])
        //        {                  
        //            custom_right_edge[u] = right_edge[u];
        //        }
        //    }

        //    for (int v = 0; v < 5; v++)
        //    {
        //        if (should_display_number[5, v])
        //        {
        //            custom_bottom_edge[v] = bottom_edge[v];
        //        }
        //    }
        //}         

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
            
            if (MediumTextBox.Text != "" && Regex.IsMatch(MediumTextBox.Text, @"^\d+$") && MediumTextBox.Text != "0" )
            {
                int number = Convert.ToInt32(MediumTextBox.Text);
                if (!initially_displayed[X, Y])
                {
                    should_display_number[X, Y] = true;
                    if (number >= 1 && number < 100)
                    {

                        // Required for erasing
                        g.DrawString(number.ToString(), draw_Font_12_Bold, medium_Black_Brush, (X * (width / 6)) + 12, (Y * (height / 6)) + 12);
                        g.DrawString(number.ToString(), draw_Font_13_Bold, medium_Black_Brush, (X * (width / 6)) + 12, (Y * (height / 6)) + 12);
                        g.DrawString(number.ToString(), draw_Font_14_Bold, medium_Black_Brush, (X * (width / 6)) + 12, (Y * (height / 6)) + 12);
                        g.DrawString(number.ToString(), draw_Font_15_Bold, medium_Black_Brush, (X * (width / 6)) + 12, (Y * (height / 6)) + 12);
                        g.DrawString(number.ToString(), draw_Font_16_Bold, medium_Black_Brush, (X * (width / 6)) + 12, (Y * (height / 6)) + 12);
                        g.DrawString(number.ToString(), draw_Font_17_Bold, medium_Black_Brush, (X * (width / 6)) + 12, (Y * (height / 6)) + 12);
                        g.DrawString(number.ToString(), draw_Font_18_Bold, medium_Black_Brush, (X * (width / 6)) + 12, (Y * (height / 6)) + 12);
                        //g.DrawString(number.ToString(), draw_Font_19_Bold, medium_Black_Brush, X * (width / 6), Y * (height / 6));
                        g.DrawString(number.ToString(), input_Font_12, medium_Black_Brush, (X * (width / 6)) + 12, (Y * (height / 6)) + 12);
                        g.DrawString(number.ToString(), input_Font_13, medium_Black_Brush, (X * (width / 6)) + 12, (Y * (height / 6)) + 12);
                        g.DrawString(number.ToString(), input_Font_14, medium_Black_Brush, (X * (width / 6)) + 12, (Y * (height / 6)) + 12);
                        g.DrawString(number.ToString(), input_Font_15, medium_Black_Brush, (X * (width / 6)) + 12, (Y * (height / 6)) + 12);
                        g.DrawString(number.ToString(), input_Font_16, medium_Black_Brush, (X * (width / 6)) + 12, (Y * (height / 6)) + 12);
                        g.DrawString(number.ToString(), input_Font_17, medium_Black_Brush, (X * (width / 6)) + 12, (Y * (height / 6)) + 12);
                        g.DrawString(number.ToString(), input_Font_18, medium_Black_Brush, (X * (width / 6)) + 12, (Y * (height / 6)) + 12);
                        //g.DrawString(number.ToString(), input_Font_19, medium_Black_Brush, X * (width / 6), Y * (height / 6));

                        g.DrawString(number.ToString(), input_Font_14, medium_Input_Blue_Brush, (X * (width / 6)) + 12, (Y * (height / 6)) + 12);

                        Console.WriteLine("Custom in DRAW: " + custom_summation_matrix[X, Y]);
                        Console.WriteLine("REG in DRAW: " + summation_matrix[X, Y]);
                        if (X <= 4 && Y <= 4)
                        {
                            custom_summation_matrix[X, Y] = number;
                            if (summation_matrix[X, Y] == number)
                            {

                                MessageBox.Show("GETTING CLOSE!", "HOT", MessageBoxButtons.OK);
                                
                                if (custom_summation_matrix.OfType<int>().SequenceEqual(summation_matrix.OfType<int>()))
                                {
                                    MessageBox.Show("You Won the Game!", "Success", MessageBoxButtons.OK);
                                }
                            }
                            LookAtSolution();
                            //CheckSolution();
                            //if (!CheckSolution())
                            //{
                            //    custom_summation_matrix[X, Y] = 0;
                            //    ClearCell(X, Y);                                
                            //}
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

        public void LookAtSolution()
        {
            
            //int row_sum = 0;
            for (int x = 0; x < 5; x++)
            {
                int row_sum = 0;
                bool all_filled = true;
                int desired_row_sum = right_edge[x];
                for (int y = 0; y < 5; y++)
                {
                    row_sum += custom_summation_matrix[x, y];
                    if (custom_summation_matrix[x, y] == 0)
                    {
                        all_filled = false;
                    }
                }
                Console.WriteLine("row_sum(" + x +  "): " + row_sum);
                Console.WriteLine("desired_row_cum(" + x + "): " + desired_row_sum);
                if (row_sum > desired_row_sum)
                {
                    DisplayAlert("You entered values too high. Please lower your choices.", "ERROR");
                }
                else if (all_filled && row_sum < desired_row_sum)
                {
                    DisplayAlert("You didn't enter values high enough. Please raise your choices.", "ERROR");
                }
                else if (all_filled && row_sum == desired_row_sum)
                {
                    DisplayAlert("You just solved a row! Congratulations.", "SUCCESS");
                    Console.WriteLine("You just solved a row! Congratulations.");
                }
            }

            for (int y = 0; y < 5; y++)
            {
                int col_sum = 0;
                bool all_filled = true;
                int desired_col_sum = bottom_edge[y];
                for (int x = 0; x < 5; x++)
                {
                    col_sum += custom_summation_matrix[x, y];
                    if (custom_summation_matrix[x, y] == 0)
                    {
                        all_filled = false;
                        
                    }
                }
                if (col_sum > desired_col_sum)
                {
                    DisplayAlert("You entered values too high. Please lower your choices.", "ERROR");
                }
                else if (all_filled && col_sum < desired_col_sum)
                {
                    DisplayAlert("You didn't enter values high enough. Please raise your choices.", "ERROR");
                }
                else if (all_filled && col_sum == desired_col_sum)
                {
                    DisplayAlert("You just solved a column! Congratulations.", "SUCCESS");
                    Console.WriteLine("You solved a column!");
                }
                Console.WriteLine("col_cum(" + y + "): " + col_sum);
                Console.WriteLine("desired_col_cum(" + y + "): "+ desired_col_sum);
            }
            //if (  custom_summation_matrix == summation_matrix )
            //{
            //    MessageBox.Show("You won the game!", "SUCCESS", MessageBoxButtons.OK);
            //    Console.WriteLine("You won the game!");
            //}            
        }

        //bool CheckSolution()
        //{
        //    int u, v;
        //    for (u = 0; u < 5; u++)
        //    {
        //        int desired_row_sum = bottom_edge[u];
        //        if (desired_row_sum == 0)
        //        {
        //            continue;
        //        }
        //        int row_sum = 0;
        //        for (v = 0; v < 5; v++)
        //        {
        //            row_sum += custom_summation_matrix[u, v];
        //        }
        //        if (row_sum > desired_row_sum)
        //        {
        //            DisplayAlert("You entered too high of a value!", "Error");
        //            return false;
        //        }
        //        else if (row_sum == desired_row_sum)
        //        {
        //            DisplayAlert("Good!", "Success");
        //        }
        //    }
        //    return true;
        //}

        void ClearCell(int x, int y)
        {
            Graphics g = Medium_Playing_Field.CreateGraphics();

            SolidBrush paintItBlack = new SolidBrush(Color.Black);
            g.FillRectangle(paintItBlack, x / Medium_Playing_Field.Width, y / Medium_Playing_Field.Height, (x + 1) / (Medium_Playing_Field.Width), (y + 1) / (Medium_Playing_Field.Height));
        }

        void DisplayAlert(string message, string type)
        {
            //MessageBox.Show(string.Format(message), type, MessageBoxButtons.OK);
        }

        private void Medium_Playing_Field_Draw(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            int screen_X; int screen_Y;

            //Random random = new Random();
            //int should_show_number = random.Next(2);

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
                        g.DrawString(custom_summation_matrix[x, y] + "", input_Font_14, medium_Default_White_Brush, screen_X + 12, screen_Y + 12);
                        Console.WriteLine("custom_summation_matrix: " + custom_summation_matrix[x, y]);
                    }
                }
            }

            //screen_X = (Medium_Playing_Field.Width * 5) / 6;

            //for (int y = 0; y < 5; y++)
            //{
            //    screen_Y = y * (Medium_Playing_Field.Height / 6);
            //    should_show_number = random.Next(2);
            //    if (custom_right_edge[y] > 0)
            //    {
            //        g.DrawString(custom_right_edge[y] + "", input_Font_14, medium_Default_White_Brush, screen_X, screen_Y);
            //    }
            //}

            //screen_Y = (Medium_Playing_Field.Height * 5) / 6;
            //for (int x = 0; x < 5; x++)
            //{
            //    screen_X = x * (Medium_Playing_Field.Width / 6);
            //    should_show_number = random.Next(2);
            //    if (custom_bottom_edge[x] > 0)
            //    {
            //        g.DrawString(custom_bottom_edge[x] + "", draw_Font_16_Bold, medium_Default_White_Brush, screen_X, screen_Y);
            //    }
            //}

            screen_X = (Medium_Playing_Field.Width * 5) / 6;

            for (int y = 0; y < 5; y++)
            {
                screen_Y = y * (Medium_Playing_Field.Height / 6);
                //should_show_number = random.Next(2);
                if (right_edge[y] > 0)
                {
                    g.DrawString(right_edge[y] + "", draw_Font_14_Bold, medium_Default_White_Brush, screen_X, screen_Y);
                    Console.WriteLine("Right Edge(" + y + "): " + right_edge[y]);
                }
            }

            screen_Y = (Medium_Playing_Field.Height * 5) / 6;
            for (int x = 0; x < 5; x++)
            {
                screen_X = x * (Medium_Playing_Field.Width / 6);
                //should_show_number = random.Next(2);
                if (bottom_edge[x] > 0)
                {
                    g.DrawString("4" + "", draw_Font_14_Bold, medium_Default_White_Brush, screen_X, screen_Y);
                    Console.WriteLine("Bottom Edge(" + x + "): " + bottom_edge[x]);
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

            medium_Timer.Stop();
            Medium_Form medium_Form = new Medium_Form(MD);
            form1.Show();
            this.Hide();
            medium_Form.Close();
        }

        private void MediumTimerTextBox_TextChanged(object sender, EventArgs e)
        {

            MediumTimerTextBox.Text = "Timer";
                //StartTimer();
        }

        //string StartTimer()
        //{
        //    medium_Timer = new System.Windows.Forms.Timer();
        //    medium_Timer.Interval = 1000;
        //    medium_Timer.Tick += new EventHandler(MediumTimerTextBox_TextChanged);
        //    medium_Timer.Enabled = true;
        //    medium_Timer.Start();

        //    stopWatch.Start();
        //    TimeSpan ts = stopWatch.Elapsed;

        //    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
        //    ts.Hours, ts.Minutes, ts.Seconds);

        //    return elapsedTime;

        //}
    }
}
