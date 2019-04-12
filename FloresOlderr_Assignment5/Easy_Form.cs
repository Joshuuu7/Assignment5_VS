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
        private static Pen easy_White_Pen;

        EasyData ED;
        EasyData ED2;
        EasyData ED3;

        SolidBrush easy_Default_White_Brush = new SolidBrush(Color.White);
        SolidBrush easy_Correct_Green_Brush = new SolidBrush(Color.Green);
        SolidBrush easy_Incorrect_Red_Brush = new SolidBrush(Color.Red);
        SolidBrush easy_Input_Blue_Brush = new SolidBrush(Color.Blue);
        SolidBrush easy_Black_Brush = new SolidBrush(Color.Black);
        SolidBrush easy_Cyan_Brush = new SolidBrush(Color.Cyan);

        Font draw_Font_14_Bold = new Font("Arial", 2, FontStyle.Bold);
        Font input_Font_14 = new Font("Arial", 26);

        Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 5);

        Random random = new Random();

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

        //public Easy_Form()
        //{
        //    easy_White_Pen = new Pen(Color.White);
        //    InitializeComponent();
        //}


        public Easy_Form(EasyData ED)
        {
            this.ED = ED;
            //this.MD2 = MD2;
            //this.MD3 = MD3;

            //StartTimer();

            summation_matrix = ED.easy_summation_matrix;
            should_display_number = ED.should_display_number;
            initially_displayed = ED.initially_displayed;

            right_edge = ED.easy_right_edge;
            bottom_edge = ED.easy_bottom_edge;

            custom_summation_matrix = ED.easy_custom_summation_matrix;
            original_summation_matrix = ED.easy_original_summation_matrix;

            custom_bottom_edge = ED.easy_custom_bottom_edge;
            custom_right_edge = ED.easy_custom_right_edge;

            easy_White_Pen = new Pen(Color.White);

            InitializeComponent();
        }
        private void Easy_Playing_Field_Draw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int screen_X; int screen_Y;

            //Random random = new Random();
            //int should_show_number = random.Next(2);

            for (int x = 0; x < 3; x++)
            {
                screen_X = x * (Easy_Playing_Field.Width / 4);
                for (int y = 0; y < 3; y++)
                {
                    screen_Y = y * (Easy_Playing_Field.Height / 4);
                    //summation_matrix[x, y] = random.Next(3, 100);
                    //should_show_number = random.Next(2);
                    if (custom_summation_matrix[y, x] > 0)
                    {
                        g.DrawString(custom_summation_matrix[y, x] + "", input_Font_14, easy_Default_White_Brush, screen_X + 45, screen_Y + 35);                       
                    }
                }
            }

            screen_X = (Easy_Playing_Field.Width * 3) / 4;

            for (int y = 0; y < 3; y++)
            {
                screen_Y = y * (Easy_Playing_Field.Height / 4);
                //should_show_number = random.Next(2);
                if (custom_right_edge[y] > 0)
                {
                    g.DrawString(custom_right_edge[y] + "", draw_Font_14_Bold, easy_Default_White_Brush, screen_X, screen_Y);
                }
            }

            screen_Y = (Easy_Playing_Field.Height * 3) / 4;
            for (int x = 0; x < 3; x++)
            {
                screen_X = x * (Easy_Playing_Field.Width / 4);
                //should_show_number = random.Next(2);
                if (custom_bottom_edge[x] > 0)
                {
                    g.DrawString(custom_bottom_edge[x] + "", draw_Font_14_Bold, easy_Default_White_Brush, screen_X, screen_Y);
                }
            }

            g.DrawLine(easy_White_Pen, (Easy_Playing_Field.Width / 3), 0,
                                   (Easy_Playing_Field.Width / 3), Easy_Playing_Field.Height);
            g.DrawLine(easy_White_Pen, (Easy_Playing_Field.Width * 2 / 3), 0,
                                   (Easy_Playing_Field.Width * 2 / 3), Easy_Playing_Field.Height);

            g.DrawLine(easy_White_Pen, 0, (Easy_Playing_Field.Height / 3),
                                   Easy_Playing_Field.Width, (Easy_Playing_Field.Height / 3));
            g.DrawLine(easy_White_Pen, 0, (Easy_Playing_Field.Height * 2 / 3),
                                   Easy_Playing_Field.Width, (Easy_Playing_Field.Height * 2 / 3));
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
                g.DrawString(numbers_array[i].ToString(), draw_Font_14_Bold, easy_Black_Brush, (X * (width / 4)) + 12, (Y * (height / 4)) + 12);
                g.DrawString(numbers_array[i].ToString(), input_Font_14, easy_Black_Brush, (X * (width / 4)) + 12, (Y * (height / 4)) + 12);
            }
        }

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
                        g.DrawString(custom_summation_matrix[y, x] + "", input_Font_14, easy_Default_White_Brush, screen_X + 45, screen_Y + 35);
                    }
                    //g.DrawString(custom_summation_matrix[y, x] + "", input_Font_14, easy_Default_White_Brush, screen_X + 45, screen_Y + 35);

                }
            }

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
            Easy_Form easy_Form = new Easy_Form(ED);
            form1.Show();
            this.Hide();
            easy_Form.Close();
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

            // EASY
            string easy_digits = "0123454789";

            StringBuilder easy_file_data_builder = new StringBuilder();
            StringBuilder easy_solution = new StringBuilder();

            using (StreamReader easy_inFile = new StreamReader(easy_file))
            {
                while (!easy_inFile.EndOfStream)
                {
                    char ch = (char)easy_inFile.Read();
                    //Console.WriteLine("ch = " + ch);
                    if (easy_digits.IndexOf(ch) == -1)
                    {
                        easy_file_data_builder.Append('$');
                        Console.WriteLine(easy_file_data_builder);
                        if (easy_file_data_builder.Equals("$$"))
                        {

                        }
                    }
                    else
                    {
                        easy_file_data_builder.Append(ch);
                        //Console.WriteLine(file_data_builder);
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

                    ED.easy_original_summation_matrix[easy_r / 3, easy_r % 3] = easy_file_chars[easy_r] - 48;
                }
                else
                {
                    int easy_t = easy_r - (easy_len / 2);
                    ED.easy_summation_matrix[easy_t / 3, easy_t % 3] = easy_file_chars[easy_r] - 48;
                    //Console.WriteLine("Normal (In ELSE): " + mediumData.medium_summation_matrix[t / 5, t % 5]);
                }
                easy_r++;
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
                            g.DrawString(numbers_array[i], draw_Font_14_Bold, easy_Black_Brush, (x * (width / 4)) + 45, (y * (height /4)) + 35);
                            g.DrawString(numbers_array[i], input_Font_14, easy_Black_Brush, (x * (width / 4)) + 45, (y * (height / 4)) + 35);
                        }
                        //ClearCell(y, x);

                        g.DrawString(custom_summation_matrix[y, x] + "", input_Font_14, easy_Default_White_Brush, (x * (width / 4)) + 45, (y * (height / 4)) + 35);
                    }
                }


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
                            g.DrawString(numbers_array[i], draw_Font_14_Bold, easy_Black_Brush, (X * (width / 4)) + 45, (Y * (height / 4)) + 35);
                            g.DrawString(numbers_array[i], input_Font_14, easy_Black_Brush, (X * (width / 4)) + 45, (Y * (height / 4)) + 35);
                        }
                        //g.DrawString(number.ToString(), input_Font_14, easy_Input_Blue_Brush, (X * (width / 4)) + 35, (Y * (height / 4)) + 35);

                        if (X <= 4 && Y <= 4)
                        {
                            custom_summation_matrix[Y, X] = number;
                            if (summation_matrix[Y, X] == number)
                            {
                                g.DrawString(number.ToString(), input_Font_14, easy_Correct_Green_Brush, (X * (width / 4)) + 45, (Y * (height / 4)) + 35);
                                MessageBox.Show("Getting Close!", "HOT", MessageBoxButtons.OK);

                                if (custom_summation_matrix.OfType<int>().SequenceEqual(summation_matrix.OfType<int>()))
                                {
                                    //medium_Timer.Stop(); 
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
                                g.DrawString(number.ToString(), input_Font_14, easy_Incorrect_Red_Brush, (X * (width / 4)) + 45, (Y * (height / 4)) + 35);
                            }
                            // LookAtSolution();
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
                        //DisplayAlert("You entered too high of a value!", "ERROR");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please make sure to enter integers only.", "ERROR", MessageBoxButtons.OK);
            }
        }
    }
}
