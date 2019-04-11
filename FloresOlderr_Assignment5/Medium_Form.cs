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
        MediumData MD2;
        MediumData MD3;

        private Pen medium_White_Pen;

        System.Windows.Forms.Timer medium_Timer = null;
        System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

        SolidBrush medium_Default_White_Brush = new SolidBrush(Color.White);
        SolidBrush medium_Correct_Green_Brush = new SolidBrush(Color.Green);
        SolidBrush medium_Incorrect_Red_Brush = new SolidBrush(Color.Red);
        SolidBrush medium_Input_Blue_Brush = new SolidBrush(Color.Blue);
        SolidBrush medium_Black_Brush = new SolidBrush(Color.Black);
        SolidBrush medium_Cyan_Brush = new SolidBrush(Color.Cyan);

        Font draw_Font_14_Bold = new Font("Arial", 14, FontStyle.Bold);
        Font input_Font_14 = new Font("Arial", 14);

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
            this.MD2 = MD2;
            this.MD3 = MD3;

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

            #region MouseLocator
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
            #endregion

            if (MediumTextBox.Text != "" && Regex.IsMatch(MediumTextBox.Text, @"^\d+$") && MediumTextBox.Text != "0" )
            {
                string[] numbers_array = new string[100]; 
               
                int number = Convert.ToInt32(MediumTextBox.Text);
                if (!initially_displayed[X, Y])
                {
                    should_display_number[X, Y] = true;
                    if (number >= 1 && number < 100)
                    {
                        // Loop necessary for deletion of every number, in case user changes his mind
                        for (int i = 0; i < 100; i++)
                        {
                            numbers_array[i] = i.ToString();
                            // Required for erasing                          
                            g.DrawString(numbers_array[i], draw_Font_14_Bold, medium_Black_Brush, (X * (width / 6)) + 12, (Y * (height / 6)) + 12);     
                            g.DrawString(numbers_array[i], input_Font_14, medium_Black_Brush, (X * (width / 6)) + 12, (Y * (height / 6)) + 12);
                        }
                        //g.DrawString(number.ToString(), input_Font_14, medium_Input_Blue_Brush, (X * (width / 6)) + 12, (Y * (height / 6)) + 12);

                        Console.WriteLine("Custom in DRAW: " + custom_summation_matrix[X, Y]);
                        Console.WriteLine("REG in DRAW: " + summation_matrix[X, Y]);
                        if (X <= 4 && Y <= 4)
                        {
                            custom_summation_matrix[Y, X] = number;
                            if (summation_matrix[Y, X] == number)
                            {
                                g.DrawString(number.ToString(), input_Font_14, medium_Correct_Green_Brush, (X * (width / 6)) + 12, (Y * (height / 6)) + 12);
                                MessageBox.Show("Getting Close!", "HOT", MessageBoxButtons.OK);
                                
                                if (custom_summation_matrix.OfType<int>().SequenceEqual(summation_matrix.OfType<int>()))
                                {
                                    //medium_Timer.Stop(); 
                                    //stopWatch.Stop();

                                    MessageBox.Show("You Won the Game! " +
                                        "/n Completion time: "  
                                        , "SUCCESS", MessageBoxButtons.OK);

                                }
                            }
                            else
                            {
                                g.DrawString(number.ToString(), input_Font_14, medium_Incorrect_Red_Brush, (X * (width / 6)) + 12, (Y * (height / 6)) + 12);
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
                MessageBox.Show("Please make sure to enter integers only.", "ERROR", MessageBoxButtons.OK);
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

        void Initialize_Edge(int u, int v)
        {
            //int u, v;
            for (u = 0; u < 5; u++)
            {
                int row_sum = 0;
                for (v = 0; v < 5; v++)
                {
                    row_sum += summation_matrix[v, u];
                    //Console.WriteLine("row_sum so far is " + row_sum);
                }
                right_edge[u] = row_sum;
            }

            for (v = 0; v < 5; v++)
            {
                int col_sum = 0;
                for (u = 0; u < 5; u++)
                {
                    col_sum += summation_matrix[v, u];
                }
                bottom_edge[v] = col_sum;
            }
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
                    if (custom_summation_matrix[y, x] > 0)
                    {                
                        g.DrawString(custom_summation_matrix[y, x] + "", input_Font_14, medium_Default_White_Brush, screen_X + 12, screen_Y + 12);
                        Initialize_Edge(y, x);
                        Console.WriteLine("custom_summation_matrix: " + custom_summation_matrix[y, x]);
                    }
                }
            }

            screen_X = (Medium_Playing_Field.Width * 5) / 6;

            for (int y = 0; y < 5; y++)
            {
                screen_Y = y * (Medium_Playing_Field.Height / 6);
                //should_show_number = random.Next(2);
                if (custom_right_edge[y] > 0)
                {
                    g.DrawString(custom_right_edge[y] + "", draw_Font_14_Bold, medium_Default_White_Brush, screen_X, screen_Y);
                }
            }

            screen_Y = (Medium_Playing_Field.Height * 5) / 6;
            for (int x = 0; x < 5; x++)
            {
                screen_X = x * (Medium_Playing_Field.Width / 6);
                //should_show_number = random.Next(2);
                if (custom_bottom_edge[x] > 0)
                {
                    g.DrawString(custom_bottom_edge[x] + "", draw_Font_14_Bold, medium_Default_White_Brush, screen_X, screen_Y);
                }
            }

            //screen_X = (Medium_Playing_Field.Width * 5) / 6;

            //for (int y = 0; y < 5; y++)
            //{
            //    screen_Y = y * (Medium_Playing_Field.Height / 6);
            //    //should_show_number = random.Next(2);
            //    if (right_edge[y] > 0)
            //    {
            //        g.DrawString(right_edge[y] + "", draw_Font_14_Bold, medium_Default_White_Brush, screen_X, screen_Y);
            //        Console.WriteLine("Right Edge(" + y + "): " + right_edge[y]);
            //    }
            //}

            //screen_Y = (Medium_Playing_Field.Height * 5) / 6;
            //for (int x = 0; x < 5; x++)
            //{
            //    screen_X = x * (Medium_Playing_Field.Width / 6);
            //    //should_show_number = random.Next(2);
            //    if (bottom_edge[x] > 0)
            //    {
            //        g.DrawString("4" + "", draw_Font_14_Bold, medium_Default_White_Brush, screen_X, screen_Y);
            //        Console.WriteLine("Bottom Edge(" + x + "): " + bottom_edge[x]);
            //    }
        //}

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

            //medium_Timer.Stop();
            //stopWatch.Stop();
            Medium_Form medium_Form = new Medium_Form(MD);
            form1.Show();
            this.Hide();
            medium_Form.Close();
        }

        //private void MediumTimerTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    MediumTimerTextBox.Text = StartTimer();
        //}
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

        private void Reset_Button_Click(object sender, EventArgs e)
        {
            int[,] original_custom_summation_matrix = new int[6, 6];
            Graphics g = Medium_Playing_Field.CreateGraphics();
            SolidBrush paintItBlack = new SolidBrush(Color.Black);

            g.FillRectangle(paintItBlack, 0, 0, Medium_Playing_Field.Width, Medium_Playing_Field.Height);

            int screen_X; int screen_Y;

            for (int x = 0; x < 5; x++)
            {
                screen_X = x * (Medium_Playing_Field.Width / 6);
                for (int y = 0; y < 5; y++)
                {
                    screen_Y = y * (Medium_Playing_Field.Height / 6);

                    if (custom_summation_matrix[y, x] != summation_matrix[y,x])
                    {
                        
                    }
                    else
                    {
                        g.DrawString(custom_summation_matrix[y, x] + "", input_Font_14, medium_Default_White_Brush, screen_X + 12, screen_Y + 12);
                    }
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

        private void ProgressButton_Click(object sender, EventArgs e)
        {
            int width = Medium_Playing_Field.Width;
            int height = Medium_Playing_Field.Height;
            Graphics g = Medium_Playing_Field.CreateGraphics();
            string[] numbers_array = new string[100];
            
            //g.DrawString(number.ToString(), input_Font_14, medium_Input_Blue_Brush, (X * (width / 6)) + 12, (Y * (height / 6)) + 12);
            for (int x = 0; x < 5; x++)
            {
                for (int y  = 0; y < 5; y++)
                {
                    if (custom_summation_matrix[y, x] == summation_matrix[y, x])
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            numbers_array[i] = i.ToString();
                            // Required for erasing                          
                            g.DrawString(numbers_array[i], draw_Font_14_Bold, medium_Black_Brush, (x * (width / 6)) + 12, (y * (height / 6)) + 12);
                            g.DrawString(numbers_array[i], input_Font_14, medium_Black_Brush, (x * (width / 6)) + 12, (y * (height / 6)) + 12);
                        }
                        g.DrawString(custom_summation_matrix[y, x] + "", input_Font_14, medium_Cyan_Brush, (x * (width / 6)) + 12, (y * (height / 6)) + 12);

                    }
                }
            }
        }
    }
}
