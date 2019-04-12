using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloresOlderr_Assignment5
{
    public partial class Hard_Form : Form
    {
        HardData HD;
        HardData HD2;
        HardData HD3;

        private Pen Hard_White_Pen;

        SolidBrush Hard_Default_White_Brush = new SolidBrush(Color.White);
        SolidBrush Hard_Correct_Green_Brush = new SolidBrush(Color.Green);
        SolidBrush Hard_Incorrect_Red_Brush = new SolidBrush(Color.Red);
        SolidBrush Hard_Input_Blue_Brush = new SolidBrush(Color.Blue);
        SolidBrush Hard_Black_Brush = new SolidBrush(Color.Black);
        SolidBrush Hard_Cyan_Brush = new SolidBrush(Color.Cyan);

        Font draw_Font_14_Bold = new Font("Arial", 9, FontStyle.Bold);
        Font input_Font_14 = new Font("Arial", 9);

        Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 5);

        Random random = new Random();
        int rand;

        bool[,] should_display_number = new bool[8, 8];
        bool[,] initially_displayed = new bool[8, 8];

        // Summation Matrix
        int[,] summation_matrix = new int[7, 7];

        // Right Edge, Bottom Edge
        int[] right_edge = new int[7];
        int[] bottom_edge = new int[7];

        // Custom Summation Matrix
        int[,] custom_summation_matrix = new int[7, 7];
        int[,] original_summation_matrix = new int[7, 7];

        // Custom Right Edge, Custom Bottom Edge
        int[] custom_right_edge = new int[7];
        int[] custom_bottom_edge = new int[7];

        public Hard_Form(HardData HD)
        {
            this.HD = HD;
            summation_matrix = HD.hard_summation_matrix;
            should_display_number = HD.should_display_number;
            initially_displayed = HD.initially_displayed;

            right_edge = HD.hard_right_edge;
            bottom_edge = HD.hard_bottom_edge;

            custom_summation_matrix = HD.hard_custom_summation_matrix;
            original_summation_matrix = HD.hard_original_summation_matrix;

            custom_bottom_edge = HD.hard_custom_bottom_edge;
            custom_right_edge = HD.hard_custom_right_edge;

            Hard_White_Pen = new Pen(Color.White);

            InitializeComponent();
        }

        private void UpdateVisibleGrid(int x, int y, int number)
        {
            Graphics g = Hard_Playing_Field.CreateGraphics();

            if (x == 7)
            {
                right_edge[y] = number;
            }
            else if (y == 7)
            {
                bottom_edge[x] = number;
            }
            else
            {
                summation_matrix[x, y] = number;
            }

            int screen_X = (x * Hard_Playing_Field.Width) / 8;
            int screen_Y = (y * Hard_Playing_Field.Height) / 8;
        }


        void PullUpNewPuzzle()
        {
            string hard_file = "";
            Random random = new Random();
            int hard_rand = random.Next(3);
            switch (hard_rand)
            {
                case 0:
                    hard_file = "hard/h1.txt";
                    break;
                case 1:
                    hard_file = "hard/h2.txt";
                    break;
                case 2:
                    hard_file = "hard/h3.txt";
                    break;
            }

            string hard_digits = "0123458789";

            StringBuilder hard_file_data_builder = new StringBuilder();
            StringBuilder hard_solution = new StringBuilder();

            using (StreamReader hard_inFile = new StreamReader(hard_file))
            {
                while (!hard_inFile.EndOfStream)
                {
                    char ch = (char)hard_inFile.Read();
                    if (hard_digits.IndexOf(ch) == -1)
                    {
                        hard_file_data_builder.Append('$');
                        if (hard_file_data_builder.Equals("$$"))
                        {

                        }
                    }
                    else
                    {
                        hard_file_data_builder.Append(ch);
                    }
                }
            }

            StringBuilder hard_digitsOnly = new StringBuilder();

            foreach (char cha in hard_file_data_builder.ToString().ToCharArray())
            {
                if (hard_digits.IndexOf(cha) >= 0)
                {
                    hard_digitsOnly.Append(cha);
                }
            }

            char[] hard_file_chars = hard_digitsOnly.ToString().ToCharArray();

            int hard_len = hard_file_chars.Length;

            int hard_r = 0;

            while (hard_r < hard_len)
            {
                if (hard_r < hard_len / 2)
                {
                    if (hard_file_chars[hard_r] > 48)
                    {
                        HD.initially_displayed[hard_r / 7, hard_r % 7] = true;
                    }
                    HD.hard_custom_summation_matrix[hard_r / 7, hard_r % 7] = hard_file_chars[hard_r] - 48;
                }
                else
                {
                    int hard_t = hard_r - (hard_len / 2);
                    HD.hard_summation_matrix[hard_t / 7, hard_t % 7] = hard_file_chars[hard_r] - 48;
                }
                hard_r++;
            }
        }

        private void Update_Hard_Form_Click(object sender, MouseEventArgs e)
        {
            Graphics g = Hard_Playing_Field.CreateGraphics();

            int X = 0;
            int Y = 0;
            int width = Hard_Playing_Field.Width;
            int height = Hard_Playing_Field.Height;

            #region MouseLocator
            if (e.X < width / 8)
                X = 0;
            else if (e.X < ((2 * width) / 8))
                X = 1;
            else if (e.X < ((3 * width) / 8))
                X = 2;
            else if (e.X < ((4 * width) / 8))
                X = 3;
            else if (e.X < ((5 * width) / 8))
                X = 4;
            else if (e.X < ((6 * width) / 8))
                X = 5;
            else if (e.X < ((7 * width) / 8))
                X = 6;
            else
                X = 7;

            if (e.Y < height / 8)
                Y = 0;
            else if (e.Y < ((2 * height) / 8))
                Y = 1;
            else if (e.Y < ((3 * height) / 8))
                Y = 2;
            else if (e.Y < ((4 * height) / 8))
                Y = 3;
            else if (e.Y < ((5 * height) / 8))
                Y = 4;
            else if (e.Y < ((6 * height) / 8))
                Y = 5;
            else if (e.Y < ((7 * height) / 8))
                Y = 6;
            else
                Y = 7;
            #endregion

            if (HardTextBox.Text != "" && Regex.IsMatch(HardTextBox.Text, @"^\d+$") && HardTextBox.Text != "0")
            {
                string[] numbers_array = new string[100];

                int number = Convert.ToInt32(HardTextBox.Text);
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
                            g.DrawString(numbers_array[i], draw_Font_14_Bold, Hard_Black_Brush, (X * (width / 8)) + 3, (Y * (height / 8)) + 3);
                            g.DrawString(numbers_array[i], input_Font_14, Hard_Black_Brush, (X * (width / 8)) + 3, (Y * (height / 8)) + 3);
                        }
                        Console.WriteLine("Clicked (X , Y):  " + X + ", " +  Y);
                        if (X <= 6 && Y <= 6)
                        {
                            custom_summation_matrix[Y, X] = number;
                            if (summation_matrix[Y, X] == number)
                            {
                                g.DrawString(number.ToString(), input_Font_14, Hard_Correct_Green_Brush, (X * (width / 8)) + 3, (Y * (height / 8)) + 3);
                                MessageBox.Show("Getting Close!", "HOT", MessageBoxButtons.OK);

                                if (custom_summation_matrix.OfType<int>().SequenceEqual(summation_matrix.OfType<int>()))
                                {
                                    //Hard_Timer.Stop(); 
                                    //stopWatch.Stop();

                                    MessageBox.Show("You Won the Game! " +
                                        "/n Completion time: "
                                        , "SUCCESS", MessageBoxButtons.OK);

                                    HD.solved = true;
                                    ClearCustomMatrix();
                                    PullUpNewPuzzle();
                                    HD = new HardData();
                                }
                            }
                            else
                            {
                                g.DrawString(number.ToString(), input_Font_14, Hard_Incorrect_Red_Brush, (X * (width / 8)) + 3, (Y * (height / 8)) + 3);
                            }
                            LookAtSolution();
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

        void EraseNumbers(int X, int Y)
        {
            Graphics g = Hard_Playing_Field.CreateGraphics();
            int width = Hard_Playing_Field.Width;
            int height = Hard_Playing_Field.Height;
            int[] numbers_array = new int[100];
            for (int i = 0; i < 100; i++)
            {
                numbers_array[i] = i;
                // Required for erasing                          
                g.DrawString(numbers_array[i].ToString(), draw_Font_14_Bold, Hard_Black_Brush, (X * (width / 8)) + 3, (Y * (height / 8)) + 3);
                g.DrawString(numbers_array[i].ToString(), input_Font_14, Hard_Black_Brush, (X * (width / 8)) + 3, (Y * (height / 8)) + 3);
            }
        }

        public void LookAtSolution()
        {
            int screen_X; int screen_Y;

            Graphics g = Hard_Playing_Field.CreateGraphics();
            for (int y = 0; y < 7; y++)
            {
                EraseNumbers(7, y);
            }
            for (int x = 0; x < 7; x++)
            {
                EraseNumbers(x, 7);
            }

            for (int x = 0; x < 7; x++)
            {
                screen_X = 7 * (Hard_Playing_Field.Width / 8);
                int row_sum = 0;
                bool all_filled = true;
                int desired_row_sum = right_edge[x];
                for (int y = 0; y < 7; y++)
                {
                    row_sum += custom_summation_matrix[x, y];
                    if (custom_summation_matrix[x, y] == 0)
                    {
                        all_filled = false;
                    }
                }
                screen_Y = x * (Hard_Playing_Field.Height / 8);
                g.DrawString(row_sum.ToString(), draw_Font_14_Bold, Hard_Correct_Green_Brush, screen_X + 3, screen_Y + 3);
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
                }
            }
            for (int y = 0; y < 7; y++)
            {
                screen_X = (y * (Hard_Playing_Field.Width / 8) + 3);
                screen_Y = (7 * (Hard_Playing_Field.Height / 8) + 3);
                int col_sum = 0;
                bool all_filled = true;
                int desired_col_sum = bottom_edge[y];
                for (int x = 0; x < 7; x++)
                {
                    col_sum += custom_summation_matrix[x, y];
                    if (custom_summation_matrix[x, y] == 0)
                    {
                        all_filled = false;
                    }
                }
                g.DrawString(col_sum.ToString(), draw_Font_14_Bold, Hard_Correct_Green_Brush, screen_X, screen_Y);
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
                }
            }
        }

        void DisplayAlert(string message, string type)
        {
            //MessageBox.Show(string.Format(message), type, MessageBoxButtons.OK);
        }

        void Initialize_Edge(int u, int v)
        {
            //int u, v;
            for (u = 0; u < 7; u++)
            {
                int row_sum = 0;
                for (v = 0; v < 7; v++)
                {
                    row_sum += summation_matrix[v, u];
                }
                right_edge[u] = row_sum;
            }

            for (v = 0; v < 7; v++)
            {
                int col_sum = 0;
                for (u = 0; u < 7; u++)
                {
                    col_sum += summation_matrix[v, u];
                }
                bottom_edge[v] = col_sum;
            }
        }

        private void Hard_Playing_Field_Draw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int screen_X; int screen_Y;

            for (int x = 0; x < 7; x++)
            {
                screen_X = x * (Hard_Playing_Field.Width / 8);
                for (int y = 0; y < 7; y++)
                {
                    screen_Y = y * (Hard_Playing_Field.Height / 8);
                    if (custom_summation_matrix[y, x] > 0)
                    {
                        g.DrawString(custom_summation_matrix[y, x] + "", input_Font_14, Hard_Default_White_Brush, screen_X + 3, screen_Y + 3);
                        Initialize_Edge(y, x);
                    }
                }
            }

            screen_X = (Hard_Playing_Field.Width * 7) / 8;

            for (int y = 0; y < 7; y++)
            {
                screen_Y = y * (Hard_Playing_Field.Height / 8);
                if (custom_right_edge[y] > 0)
                {
                    g.DrawString(custom_right_edge[y] + "", draw_Font_14_Bold, Hard_Default_White_Brush, screen_X, screen_Y);
                }
            }

            screen_Y = (Hard_Playing_Field.Height * 7) / 8;
            for (int x = 0; x < 7; x++)
            {
                screen_X = x * (Hard_Playing_Field.Width / 8);
                if (custom_bottom_edge[x] > 0)
                {
                    g.DrawString(custom_bottom_edge[x] + "", draw_Font_14_Bold, Hard_Default_White_Brush, screen_X, screen_Y);
                }
            }

            g.DrawLine(Hard_White_Pen, (Hard_Playing_Field.Width * 1 / 8), 0,
                                   (Hard_Playing_Field.Width * 1 / 8), Hard_Playing_Field.Height);
            g.DrawLine(Hard_White_Pen, (Hard_Playing_Field.Width * 2 / 8), 0,
                                   (Hard_Playing_Field.Width * 2 / 8), Hard_Playing_Field.Height);
            g.DrawLine(Hard_White_Pen, (Hard_Playing_Field.Width * 3 / 8), 0,
                                   (Hard_Playing_Field.Width * 3 / 8), Hard_Playing_Field.Height);
            g.DrawLine(Hard_White_Pen, (Hard_Playing_Field.Width * 4 / 8), 0,
                                   (Hard_Playing_Field.Width * 4 / 8), Hard_Playing_Field.Height);
            g.DrawLine(Hard_White_Pen, (Hard_Playing_Field.Width * 5 / 8), 0,
                                   (Hard_Playing_Field.Width * 5 / 8), Hard_Playing_Field.Height);
            g.DrawLine(Hard_White_Pen, (Hard_Playing_Field.Width * 6 / 8), 0,
                                  (Hard_Playing_Field.Width * 6 / 8), Hard_Playing_Field.Height);
            g.DrawLine(Hard_White_Pen, (Hard_Playing_Field.Width * 7 / 8), 0,
                                  (Hard_Playing_Field.Width * 7 / 8), Hard_Playing_Field.Height);

            g.DrawLine(Hard_White_Pen, 0, (Hard_Playing_Field.Height * 1 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 1 / 8));
            g.DrawLine(Hard_White_Pen, 0, (Hard_Playing_Field.Height * 2 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 2 / 8));
            g.DrawLine(Hard_White_Pen, 0, (Hard_Playing_Field.Height * 3 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 3 / 8));
            g.DrawLine(Hard_White_Pen, 0, (Hard_Playing_Field.Height * 4 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 4 / 8));
            g.DrawLine(Hard_White_Pen, 0, (Hard_Playing_Field.Height * 5 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 5 / 8));
            g.DrawLine(Hard_White_Pen, 0, (Hard_Playing_Field.Height * 6 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 6 / 8));
            g.DrawLine(Hard_White_Pen, 0, (Hard_Playing_Field.Height * 7 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 7 / 8));

        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            HD = new HardData();

            HD.hard_summation_matrix = summation_matrix;
            HD.should_display_number = should_display_number;
            HD.initially_displayed = initially_displayed;

            HD.hard_right_edge = right_edge;
            HD.hard_bottom_edge = bottom_edge;

            HD.hard_custom_summation_matrix = custom_summation_matrix;

            HD.hard_custom_right_edge = custom_right_edge;
            HD.hard_custom_bottom_edge = custom_bottom_edge;

            Form1 form1 = new Form1(HD);

            Hard_Form Hard_Form = new Hard_Form(HD);
            form1.Show();
            this.Hide();
            Hard_Form.Close();
        }

        //private void HardTimerTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    HardTimerTextBox.Text = StartTimer();
        //}
        //string StartTimer()
        //{
        //    Hard_Timer = new System.Windows.Forms.Timer();
        //    Hard_Timer.Interval = 1000;
        //    Hard_Timer.Tick += new EventHandler(HardTimerTextBox_TextChanged);
        //    Hard_Timer.Enabled = true;
        //    Hard_Timer.Start();

        //    stopWatch.Start();
        //    TimeSpan ts = stopWatch.Elapsed;

        //    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
        //    ts.Hours, ts.Minutes, ts.Seconds);

        //    return elapsedTime;
        //}

        private void Reset_Button_Click(object sender, EventArgs e)
        {
            int[,] original_custom_summation_matrix = new int[8, 8];
            Graphics g = Hard_Playing_Field.CreateGraphics();
            SolidBrush paintItBlack = new SolidBrush(Color.Black);

            g.FillRectangle(paintItBlack, 0, 0, Hard_Playing_Field.Width, Hard_Playing_Field.Height);

            int screen_X; int screen_Y;

            for (int x = 0; x < 7; x++)
            {
                screen_X = x * (Hard_Playing_Field.Width / 8);
                for (int y = 0; y < 7; y++)
                {
                    screen_Y = y * (Hard_Playing_Field.Height / 8);

                    if (custom_summation_matrix[y, x] != summation_matrix[y, x])
                    {

                    }
                    else
                    {
                        g.DrawString(custom_summation_matrix[y, x] + "", input_Font_14, Hard_Default_White_Brush, screen_X + 3, screen_Y + 3);
                    }
                }
            }

            g.DrawLine(Hard_White_Pen, (Hard_Playing_Field.Width * 1 / 8), 0,
                                   (Hard_Playing_Field.Width * 1 / 8), Hard_Playing_Field.Height);
            g.DrawLine(Hard_White_Pen, (Hard_Playing_Field.Width * 2 / 8), 0,
                                   (Hard_Playing_Field.Width * 2 / 8), Hard_Playing_Field.Height);
            g.DrawLine(Hard_White_Pen, (Hard_Playing_Field.Width * 3 / 8), 0,
                                   (Hard_Playing_Field.Width * 3 / 8), Hard_Playing_Field.Height);
            g.DrawLine(Hard_White_Pen, (Hard_Playing_Field.Width * 4 / 8), 0,
                                   (Hard_Playing_Field.Width * 4 / 8), Hard_Playing_Field.Height);
            g.DrawLine(Hard_White_Pen, (Hard_Playing_Field.Width * 5 / 8), 0,
                                   (Hard_Playing_Field.Width * 5 / 8), Hard_Playing_Field.Height);
            g.DrawLine(Hard_White_Pen, (Hard_Playing_Field.Width * 6 / 8), 0,
                                 (Hard_Playing_Field.Width * 6 / 8), Hard_Playing_Field.Height);
            g.DrawLine(Hard_White_Pen, (Hard_Playing_Field.Width * 7 / 8), 0,
                                  (Hard_Playing_Field.Width * 7 / 8), Hard_Playing_Field.Height);

            g.DrawLine(Hard_White_Pen, 0, (Hard_Playing_Field.Height * 1 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 1 / 8));
            g.DrawLine(Hard_White_Pen, 0, (Hard_Playing_Field.Height * 2 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 2 / 8));
            g.DrawLine(Hard_White_Pen, 0, (Hard_Playing_Field.Height * 3 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 3 / 8));
            g.DrawLine(Hard_White_Pen, 0, (Hard_Playing_Field.Height * 4 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 4 / 8));
            g.DrawLine(Hard_White_Pen, 0, (Hard_Playing_Field.Height * 5 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 5 / 8));
            g.DrawLine(Hard_White_Pen, 0, (Hard_Playing_Field.Height * 6 / 8),
                                  Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 6 / 8));
            g.DrawLine(Hard_White_Pen, 0, (Hard_Playing_Field.Height * 7 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 7 / 8));
        }

        private void ProgressButton_Click(object sender, EventArgs e)
        {
            int width = Hard_Playing_Field.Width;
            int height = Hard_Playing_Field.Height;
            Graphics g = Hard_Playing_Field.CreateGraphics();
            string[] numbers_array = new string[100];

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    if (custom_summation_matrix[y, x] > 0 && custom_summation_matrix[y, x] != summation_matrix[y, x])
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            numbers_array[i] = i.ToString();
                            // Required for erasing                          
                            g.DrawString(numbers_array[i], draw_Font_14_Bold, Hard_Black_Brush, (x * (width / 8)) + 3, (y * (height / 8)) + 3);
                            g.DrawString(numbers_array[i], input_Font_14, Hard_Black_Brush, (x * (width / 8)) + 3, (y * (height / 8)) + 3);
                        }
                        g.DrawString(custom_summation_matrix[y, x] + "", input_Font_14, Hard_Default_White_Brush, (x * (width / 8)) + 3, (y * (height / 8)) + 3);
                    }
                }
            }
        }

        void ClearCustomMatrix()
        {
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    if (!initially_displayed[y, x])
                        custom_summation_matrix[y, x] = 0;
                }
            }
        }
    }
}
