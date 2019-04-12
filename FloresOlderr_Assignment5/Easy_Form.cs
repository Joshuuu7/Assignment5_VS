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
    public partial class Easy_Form : Form
    {
        EasyData ED;
        EasyData ED2;
        EasyData ED3;

        private Pen Easy_White_Pen;

        SolidBrush Easy_Default_White_Brush = new SolidBrush(Color.White);
        SolidBrush Easy_Correct_Green_Brush = new SolidBrush(Color.Green);
        SolidBrush Easy_Incorrect_Red_Brush = new SolidBrush(Color.Red);
        SolidBrush Easy_Input_Blue_Brush = new SolidBrush(Color.Blue);
        SolidBrush Easy_Black_Brush = new SolidBrush(Color.Black);
        SolidBrush Easy_Cyan_Brush = new SolidBrush(Color.Cyan);

        Font draw_Font_14_Bold = new Font("Arial", 14, FontStyle.Bold);
        Font input_Font_14 = new Font("Arial", 14);

        Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 5);

        Random random = new Random();
        int rand;

        bool[,] should_display_number = new bool[4, 4];
        bool[,] initially_displayed = new bool[4, 4];

        // Summation Matrix
        int[,] summation_matrix = new int[3, 3];

        // Right Edge, Bottom Edge
        int[] right_edge = new int[3];
        int[] bottom_edge = new int[3];

        // Custom Summation Matrix
        int[,] custom_summation_matrix = new int[3, 3];
        int[,] original_summation_matrix = new int[3, 3];

        // Custom Right Edge, Custom Bottom Edge
        int[] custom_right_edge = new int[3];
        int[] custom_bottom_edge = new int[3];

        public Easy_Form(EasyData ED)
        {
            this.ED = ED;
            summation_matrix = ED.easy_summation_matrix;
            should_display_number = ED.should_display_number;
            initially_displayed = ED.initially_displayed;

            right_edge = ED.easy_right_edge;
            bottom_edge = ED.easy_bottom_edge;

            custom_summation_matrix = ED.easy_custom_summation_matrix;
            original_summation_matrix = ED.easy_original_summation_matrix;

            custom_bottom_edge = ED.easy_custom_bottom_edge;
            custom_right_edge = ED.easy_custom_right_edge;

            Easy_White_Pen = new Pen(Color.White);

            InitializeComponent();
        }

        private void UpdateVisibleGrid(int x, int y, int number)
        {
            Graphics g = Easy_Playing_Field.CreateGraphics();

            if (x == 3)
            {
                right_edge[y] = number;
            }
            else if (y == 3)
            {
                bottom_edge[x] = number;
            }
            else
            {
                summation_matrix[x, y] = number;
            }

            int screen_X = (x * Easy_Playing_Field.Width) / 4;
            int screen_Y = (y * Easy_Playing_Field.Height) / 4;
        }


        void PullUpNewPuzzle()
        {
            string easy_file = "";
            Random random = new Random();
            int easy_rand = random.Next(3);
            switch (easy_rand)
            {
                case 0:
                    easy_file = "easy/e1.txt";
                    break;
                case 1:
                    easy_file = "easy/e2.txt";
                    break;
                case 2:
                    easy_file = "easy/e3.txt";
                    break;
            }

            string easy_digits = "0123456789";

            StringBuilder easy_file_data_builder = new StringBuilder();
            StringBuilder easy_solution = new StringBuilder();

            using (StreamReader easy_inFile = new StreamReader(easy_file))
            {
                while (!easy_inFile.EndOfStream)
                {
                    char ch = (char)easy_inFile.Read();
                    if (easy_digits.IndexOf(ch) == -1)
                    {
                        easy_file_data_builder.Append('$');
                        if (easy_file_data_builder.Equals("$$"))
                        {

                        }
                    }
                    else
                    {
                        easy_file_data_builder.Append(ch);
                    }
                }
            }

            StringBuilder easy_digitsOnly = new StringBuilder();

            foreach (char cha in easy_file_data_builder.ToString().ToCharArray())
            {
                if (easy_digits.IndexOf(cha) >= 0)
                {
                    easy_digitsOnly.Append(cha);
                }
            }

            char[] easy_file_chars = easy_digitsOnly.ToString().ToCharArray();

            int easy_len = easy_file_chars.Length;

            int easy_r = 0;

            while (easy_r < easy_len)
            {
                if (easy_r < easy_len / 2)
                {
                    if (easy_file_chars[easy_r] > 48)
                    {
                        ED.initially_displayed[easy_r / 3, easy_r % 3] = true;
                    }
                    ED.easy_custom_summation_matrix[easy_r / 3, easy_r % 3] = easy_file_chars[easy_r] - 48;
                }
                else
                {
                    int easy_t = easy_r - (easy_len / 2);
                    ED.easy_summation_matrix[easy_t / 3, easy_t % 3] = easy_file_chars[easy_r] - 48;
                }
                easy_r++;
            }
        }

        private void Update_Easy_Form_Click(object sender, MouseEventArgs e)
        {
            Graphics g = Easy_Playing_Field.CreateGraphics();

            int X = 0;
            int Y = 0;
            int width = Easy_Playing_Field.Width;
            int height = Easy_Playing_Field.Height;

            #region MouseLocator
            if (e.X < width / 4)
                X = 0;
            else if (e.X < ((2 * width) / 4))
                X = 1;
            else if (e.X < ((3 * width) / 4))
                X = 2;
            else
                X = 3;

            if (e.Y < height / 4)
                Y = 0;
            else if (e.Y < ((2 * height) / 4))
                Y = 1;
            else if (e.Y < ((3 * height) / 4))
                Y = 2;
            else
                Y = 3;
            #endregion

            if (EasyTextBox.Text != "" && Regex.IsMatch(EasyTextBox.Text, @"^\d+$") && EasyTextBox.Text != "0")
            {
                string[] numbers_array = new string[100];

                int number = Convert.ToInt32(EasyTextBox.Text);
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
                            g.DrawString(numbers_array[i], draw_Font_14_Bold, Easy_Black_Brush, (X * (width / 4)) + 12, (Y * (height / 4)) + 12);
                            g.DrawString(numbers_array[i], input_Font_14, Easy_Black_Brush, (X * (width / 4)) + 12, (Y * (height / 4)) + 12);
                        }
                        if (X <= 2 && Y <= 2)
                        {
                            custom_summation_matrix[Y, X] = number;
                            if (summation_matrix[Y, X] == number)
                            {
                                g.DrawString(number.ToString(), input_Font_14, Easy_Correct_Green_Brush, (X * (width / 4)) + 12, (Y * (height / 4)) + 12);
                                MessageBox.Show("Getting Close!", "HOT", MessageBoxButtons.OK);

                                if (custom_summation_matrix.OfType<int>().SequenceEqual(summation_matrix.OfType<int>()))
                                {
                                    //Easy_Timer.Stop(); 
                                    //stopWatch.Stop();

                                    MessageBox.Show("You Won the Game! " +
                                        "/n Completion time: "
                                        , "SUCCESS", MessageBoxButtons.OK);

                                    ED.solved = true;
                                    ClearCustomMatrix();
                                    PullUpNewPuzzle();
                                    ED = new EasyData();
                                }
                            }
                            else
                            {
                                g.DrawString(number.ToString(), input_Font_14, Easy_Incorrect_Red_Brush, (X * (width / 4)) + 12, (Y * (height / 4)) + 12);
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
            Graphics g = Easy_Playing_Field.CreateGraphics();
            int width = Easy_Playing_Field.Width;
            int height = Easy_Playing_Field.Height;
            int[] numbers_array = new int[100];
            for (int i = 0; i < 100; i++)
            {
                numbers_array[i] = i;
                // Required for erasing                          
                g.DrawString(numbers_array[i].ToString(), draw_Font_14_Bold, Easy_Black_Brush, (X * (width / 4)) + 12, (Y * (height / 4)) + 12);
                g.DrawString(numbers_array[i].ToString(), input_Font_14, Easy_Black_Brush, (X * (width / 4)) + 12, (Y * (height / 4)) + 12);
            }
        }

        public void LookAtSolution()
        {
            int screen_X; int screen_Y;

            Graphics g = Easy_Playing_Field.CreateGraphics();
            for (int y = 0; y < 3; y++)
            {
                EraseNumbers(3, y);
            }
            for (int x = 0; x < 3; x++)
            {
                EraseNumbers(x, 3);
            }

            for (int x = 0; x < 3; x++)
            {
                screen_X = 3 * (Easy_Playing_Field.Width / 4);
                int row_sum = 0;
                bool all_filled = true;
                int desired_row_sum = right_edge[x];
                for (int y = 0; y < 3; y++)
                {
                    row_sum += custom_summation_matrix[x, y];
                    if (custom_summation_matrix[x, y] == 0)
                    {
                        all_filled = false;
                    }
                }
                screen_Y = x * (Easy_Playing_Field.Height / 4);
                g.DrawString(row_sum.ToString(), draw_Font_14_Bold, Easy_Correct_Green_Brush, screen_X + 12, screen_Y + 12);
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
            for (int y = 0; y < 3; y++)
            {
                screen_X = (y * (Easy_Playing_Field.Width / 4) + 12);
                screen_Y = (3 * (Easy_Playing_Field.Height / 4) + 12);
                int col_sum = 0;
                bool all_filled = true;
                int desired_col_sum = bottom_edge[y];
                for (int x = 0; x < 3; x++)
                {
                    col_sum += custom_summation_matrix[x, y];
                    if (custom_summation_matrix[x, y] == 0)
                    {
                        all_filled = false;
                    }
                }
                g.DrawString(col_sum.ToString(), draw_Font_14_Bold, Easy_Correct_Green_Brush, screen_X, screen_Y);
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
            for (u = 0; u < 3; u++)
            {
                int row_sum = 0;
                for (v = 0; v < 3; v++)
                {
                    row_sum += summation_matrix[v, u];
                }
                right_edge[u] = row_sum;
            }

            for (v = 0; v < 3; v++)
            {
                int col_sum = 0;
                for (u = 0; u < 3; u++)
                {
                    col_sum += summation_matrix[v, u];
                }
                bottom_edge[v] = col_sum;
            }
        }

        private void Easy_Playing_Field_Draw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int screen_X; int screen_Y;

            for (int x = 0; x < 3; x++)
            {
                screen_X = x * (Easy_Playing_Field.Width / 4);
                for (int y = 0; y < 3; y++)
                {
                    screen_Y = y * (Easy_Playing_Field.Height / 4);
                    if (custom_summation_matrix[y, x] > 0)
                    {
                        g.DrawString(custom_summation_matrix[y, x] + "", input_Font_14, Easy_Default_White_Brush, screen_X + 12, screen_Y + 12);
                        Initialize_Edge(y, x);
                    }
                }
            }

            screen_X = (Easy_Playing_Field.Width * 3) / 4;

            for (int y = 0; y < 3; y++)
            {
                screen_Y = y * (Easy_Playing_Field.Height / 4);
                if (custom_right_edge[y] > 0)
                {
                    g.DrawString(custom_right_edge[y] + "", draw_Font_14_Bold, Easy_Default_White_Brush, screen_X, screen_Y);
                }
            }

            screen_Y = (Easy_Playing_Field.Height * 3) / 4;
            for (int x = 0; x < 3; x++)
            {
                screen_X = x * (Easy_Playing_Field.Width / 4);
                if (custom_bottom_edge[x] > 0)
                {
                    g.DrawString(custom_bottom_edge[x] + "", draw_Font_14_Bold, Easy_Default_White_Brush, screen_X, screen_Y);
                }
            }

            g.DrawLine(Easy_White_Pen, (Easy_Playing_Field.Width * 1 / 4), 0,
                                   (Easy_Playing_Field.Width * 1 / 4), Easy_Playing_Field.Height);
            g.DrawLine(Easy_White_Pen, (Easy_Playing_Field.Width * 2 / 4), 0,
                                   (Easy_Playing_Field.Width * 2 / 4), Easy_Playing_Field.Height);
            g.DrawLine(Easy_White_Pen, (Easy_Playing_Field.Width * 3 / 4), 0,
                                    (Easy_Playing_Field.Width * 3 / 4), Easy_Playing_Field.Height);


            g.DrawLine(Easy_White_Pen, 0, (Easy_Playing_Field.Height * 1 / 4),
                                   Easy_Playing_Field.Width, (Easy_Playing_Field.Height * 1 / 4));
            g.DrawLine(Easy_White_Pen, 0, (Easy_Playing_Field.Height * 2 / 4),
                                   Easy_Playing_Field.Width, (Easy_Playing_Field.Height * 2 / 4));
            g.DrawLine(Easy_White_Pen, 0, (Easy_Playing_Field.Height * 3 / 4),
                                   Easy_Playing_Field.Width, (Easy_Playing_Field.Height * 3 / 4));

        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            ED = new EasyData();

            ED.easy_summation_matrix = summation_matrix;
            ED.should_display_number = should_display_number;
            ED.initially_displayed = initially_displayed;

            ED.easy_right_edge = right_edge;
            ED.easy_bottom_edge = bottom_edge;

            ED.easy_custom_summation_matrix = custom_summation_matrix;

            ED.easy_custom_right_edge = custom_right_edge;
            ED.easy_custom_bottom_edge = custom_bottom_edge;

            Form1 form1 = new Form1(ED);

            Easy_Form Easy_Form = new Easy_Form(ED);
            form1.Show();
            this.Hide();
            Easy_Form.Close();
        }

        //private void EasyTimerTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    EasyTimerTextBox.Text = StartTimer();
        //}
        //string StartTimer()
        //{
        //    Easy_Timer = new System.Windows.Forms.Timer();
        //    Easy_Timer.Interval = 1000;
        //    Easy_Timer.Tick += new EventHandler(EasyTimerTextBox_TextChanged);
        //    Easy_Timer.Enabled = true;
        //    Easy_Timer.Start();

        //    stopWatch.Start();
        //    TimeSpan ts = stopWatch.Elapsed;

        //    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
        //    ts.Hours, ts.Minutes, ts.Seconds);

        //    return elapsedTime;
        //}

        private void Reset_Button_Click(object sender, EventArgs e)
        {
            int[,] original_custom_summation_matrix = new int[4, 4];
            Graphics g = Easy_Playing_Field.CreateGraphics();
            SolidBrush paintItBlack = new SolidBrush(Color.Black);

            g.FillRectangle(paintItBlack, 0, 0, Easy_Playing_Field.Width, Easy_Playing_Field.Height);

            int screen_X; int screen_Y;

            for (int x = 0; x < 3; x++)
            {
                screen_X = x * (Easy_Playing_Field.Width / 4);
                for (int y = 0; y < 3; y++)
                {
                    screen_Y = y * (Easy_Playing_Field.Height / 4);

                    if (custom_summation_matrix[y, x] != summation_matrix[y, x])
                    {

                    }
                    else
                    {
                        g.DrawString(custom_summation_matrix[y, x] + "", input_Font_14, Easy_Default_White_Brush, screen_X + 12, screen_Y + 12);
                    }
                }
            }

            g.DrawLine(Easy_White_Pen, (Easy_Playing_Field.Width * 1 / 4), 0,
                                   (Easy_Playing_Field.Width * 1 / 4), Easy_Playing_Field.Height);
            g.DrawLine(Easy_White_Pen, (Easy_Playing_Field.Width * 2 / 4), 0,
                                   (Easy_Playing_Field.Width * 2 / 4), Easy_Playing_Field.Height);
            g.DrawLine(Easy_White_Pen, (Easy_Playing_Field.Width * 3 / 4), 0,
                                   (Easy_Playing_Field.Width * 3 / 4), Easy_Playing_Field.Height);        

            g.DrawLine(Easy_White_Pen, 0, (Easy_Playing_Field.Height * 1 / 4),
                                   Easy_Playing_Field.Width, (Easy_Playing_Field.Height * 1 / 4));
            g.DrawLine(Easy_White_Pen, 0, (Easy_Playing_Field.Height * 2 / 4),
                                   Easy_Playing_Field.Width, (Easy_Playing_Field.Height * 2 / 4));
            g.DrawLine(Easy_White_Pen, 0, (Easy_Playing_Field.Height * 3 / 4),
                                   Easy_Playing_Field.Width, (Easy_Playing_Field.Height * 3 / 4));          
        }

        private void ProgressButton_Click(object sender, EventArgs e)
        {
            int width = Easy_Playing_Field.Width;
            int height = Easy_Playing_Field.Height;
            Graphics g = Easy_Playing_Field.CreateGraphics();
            string[] numbers_array = new string[100];

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (custom_summation_matrix[y, x] > 0 && custom_summation_matrix[y, x] != summation_matrix[y, x])
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            numbers_array[i] = i.ToString();
                            // Required for erasing                          
                            g.DrawString(numbers_array[i], draw_Font_14_Bold, Easy_Black_Brush, (x * (width / 4)) + 12, (y * (height / 4)) + 12);
                            g.DrawString(numbers_array[i], input_Font_14, Easy_Black_Brush, (x * (width / 4)) + 12, (y * (height / 4)) + 12);
                        }
                        g.DrawString(custom_summation_matrix[y, x] + "", input_Font_14, Easy_Default_White_Brush, (x * (width / 4)) + 12, (y * (height / 4)) + 12);
                    }
                }
            }
        }

        void ClearCustomMatrix()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (!initially_displayed[y, x])
                        custom_summation_matrix[y, x] = 0;
                }
            }
        }
    }
}
