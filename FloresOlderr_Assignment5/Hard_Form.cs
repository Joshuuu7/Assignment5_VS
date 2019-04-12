using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private Pen hard_White_Pen;

        SolidBrush hard_Default_White_Brush = new SolidBrush(Color.White);
        SolidBrush hard_Correct_Green_Brush = new SolidBrush(Color.Green);
        SolidBrush hard_Incorrect_Red_Brush = new SolidBrush(Color.Red);
        SolidBrush hard_Input_Blue_Brush = new SolidBrush(Color.Blue);
        SolidBrush hard_Black_Brush = new SolidBrush(Color.Black);
        SolidBrush hard_Cyan_Brush = new SolidBrush(Color.Cyan);

        Font draw_Font_9_Bold = new Font("Arial", 9, FontStyle.Bold);
        Font input_Font_9 = new Font("Arial", 9);

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
        int[,] custom_summation_matrix = new int[8, 8];
        int[,] original_summation_matrix = new int[8, 8];

        // Custom Right Edge, Custom Bottom Edge
        int[] custom_right_edge = new int[7];
        int[] custom_bottom_edge = new int[7];

        public Hard_Form(HardData HD)
        {
            this.HD = HD;
            //this.MD2 = MD2;
            //this.MD3 = MD3;

            summation_matrix = HD.hard_summation_matrix;
            should_display_number = HD.should_display_number;
            initially_displayed = HD.initially_displayed;

            right_edge = HD.hard_right_edge;
            bottom_edge = HD.hard_bottom_edge;

            custom_summation_matrix = HD.hard_custom_summation_matrix;
            original_summation_matrix = HD.hard_original_summation_matrix;

            custom_bottom_edge = HD.hard_custom_bottom_edge;
            custom_right_edge = HD.hard_custom_right_edge;

            hard_White_Pen = new Pen(Color.White);

            InitializeComponent();
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
                            g.DrawString(numbers_array[i], draw_Font_9_Bold, hard_Black_Brush, (X * (width / 8)) + 12, (Y * (height / 8)) + 12);
                            g.DrawString(numbers_array[i], input_Font_9, hard_Black_Brush, (X * (width / 8)) + 12, (Y * (height / 8)) + 12);
                        }
                        //g.DrawString(number.ToString(), input_Font_9, hard_Input_Blue_Brush, (X * (width / 6)) + 12, (Y * (height / 6)) + 12);

                        Console.WriteLine("Custom in DRAW: " + custom_summation_matrix[X, Y]);
                        Console.WriteLine("REG in DRAW: " + summation_matrix[X, Y]);
                        if (X <= 7 && Y <= 7)
                        {
                            custom_summation_matrix[Y, X] = number;
                            if (summation_matrix[Y, X] == number)
                            {
                                g.DrawString(number.ToString(), input_Font_9, hard_Correct_Green_Brush, (X * (width / 8)) + 12, (Y * (height / 8)) + 12);
                                MessageBox.Show("Getting Close!", "HOT", MessageBoxButtons.OK);

                                if (custom_summation_matrix.OfType<int>().SequenceEqual(summation_matrix.OfType<int>()))
                                {
                                    MessageBox.Show("You Won the Game! " +
                                        "/n Completion time: "
                                        , "SUCCESS", MessageBoxButtons.OK);

                                }
                            }
                            else
                            {
                                g.DrawString(number.ToString(), input_Font_9, hard_Incorrect_Red_Brush, (X * (width / 8)) + 12, (Y * (height / 8)) + 12);
                            }
                            //LookAtSolution();
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
            Hard_Form hard_Form = new Hard_Form(HD);
            form1.Show();
            this.Hide();
            hard_Form.Close();
        }

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
                        g.DrawString(custom_summation_matrix[y, x] + "", input_Font_9, hard_Default_White_Brush, screen_X + 12, screen_Y + 12);
                    }
                    //g.DrawString(custom_summation_matrix[y, x] + "", input_Font_9, hard_Default_White_Brush, screen_X + 12, screen_Y + 12);

                }
            }

            g.DrawLine(hard_White_Pen, (Hard_Playing_Field.Width * 1 / 8), 0,
                                   (Hard_Playing_Field.Width * 1 / 8), Hard_Playing_Field.Height);
            g.DrawLine(hard_White_Pen, (Hard_Playing_Field.Width * 2 / 8), 0,
                                   (Hard_Playing_Field.Width * 2 / 8), Hard_Playing_Field.Height);
            g.DrawLine(hard_White_Pen, (Hard_Playing_Field.Width * 3 / 8), 0,
                                   (Hard_Playing_Field.Width * 3 / 8), Hard_Playing_Field.Height);
            g.DrawLine(hard_White_Pen, (Hard_Playing_Field.Width * 4 / 8), 0,
                                   (Hard_Playing_Field.Width * 4 / 8), Hard_Playing_Field.Height);
            g.DrawLine(hard_White_Pen, (Hard_Playing_Field.Width * 5 / 8), 0,
                                   (Hard_Playing_Field.Width * 5 / 8), Hard_Playing_Field.Height);
            g.DrawLine(hard_White_Pen, (Hard_Playing_Field.Width * 6 / 8), 0,
                                   (Hard_Playing_Field.Width * 6/ 8), Hard_Playing_Field.Height);
            g.DrawLine(hard_White_Pen, (Hard_Playing_Field.Width * 7 / 8), 0,
                                   (Hard_Playing_Field.Width * 7 / 8), Hard_Playing_Field.Height);

            g.DrawLine(hard_White_Pen, 0, (Hard_Playing_Field.Height * 1 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 1 / 8));
            g.DrawLine(hard_White_Pen, 0, (Hard_Playing_Field.Height * 2 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 2 / 8));
            g.DrawLine(hard_White_Pen, 0, (Hard_Playing_Field.Height * 3 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 3 / 8));
            g.DrawLine(hard_White_Pen, 0, (Hard_Playing_Field.Height * 4 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 4 / 8));
            g.DrawLine(hard_White_Pen, 0, (Hard_Playing_Field.Height * 5 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 5 / 8));
            g.DrawLine(hard_White_Pen, 0, (Hard_Playing_Field.Height * 6 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 6 / 8));
            g.DrawLine(hard_White_Pen, 0, (Hard_Playing_Field.Height * 7 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 7 / 8));
        }

        void DisplayAlert(string message, string type)
        {
            //MessageBox.Show(string.Format(message), type, MessageBoxButtons.OK);
        }

        private void Hard_Playing_Field_Draw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int screen_X; int screen_Y;

            //Random random = new Random();
            //int should_show_number = random.Next(2);

            for (int x = 0; x < 7; x++)
            {
                screen_X = x * (Hard_Playing_Field.Width / 8);
                for (int y = 0; y < 7; y++)
                {
                    screen_Y = y * (Hard_Playing_Field.Height / 8);
                    //summation_matrix[x, y] = random.Next(5, 100);
                    //should_show_number = random.Next(2);
                    if (custom_summation_matrix[y, x] > 0)
                    {
                        g.DrawString(custom_summation_matrix[y, x] + "", input_Font_9, hard_Default_White_Brush, screen_X + 12, screen_Y + 12);
                        //Initialize_Edge(y, x);
                        Console.WriteLine("custom_summation_matrix: " + custom_summation_matrix[y, x]);
                    }
                }
            }

            screen_X = (Hard_Playing_Field.Width * 7) / 8;

            for (int y = 0; y < 7; y++)
            {
                screen_Y = y * (Hard_Playing_Field.Height / 8);
                //should_show_number = random.Next(2);
                if (custom_right_edge[y] > 0)
                {
                    g.DrawString(custom_right_edge[y] + "", draw_Font_9_Bold, hard_Default_White_Brush, screen_X, screen_Y);
                }
            }

            screen_Y = (Hard_Playing_Field.Height * 7) / 8;
            for (int x = 0; x < 7; x++)
            {
                screen_X = x * (Hard_Playing_Field.Width / 8);
                //should_show_number = random.Next(2);
                if (custom_bottom_edge[x] > 0)
                {
                    g.DrawString(custom_bottom_edge[x] + "", draw_Font_9_Bold, hard_Default_White_Brush, screen_X, screen_Y);
                }
            }

            g.DrawLine(hard_White_Pen, (Hard_Playing_Field.Width * 1 / 8), 0,
                                   (Hard_Playing_Field.Width * 1 / 8), Hard_Playing_Field.Height);
            g.DrawLine(hard_White_Pen, (Hard_Playing_Field.Width * 2 / 8), 0,
                                   (Hard_Playing_Field.Width * 2 / 8), Hard_Playing_Field.Height);
            g.DrawLine(hard_White_Pen, (Hard_Playing_Field.Width * 3 / 8), 0,
                                   (Hard_Playing_Field.Width * 3 / 8), Hard_Playing_Field.Height);
            g.DrawLine(hard_White_Pen, (Hard_Playing_Field.Width * 4 / 8), 0,
                                   (Hard_Playing_Field.Width * 4 / 8), Hard_Playing_Field.Height);
            g.DrawLine(hard_White_Pen, (Hard_Playing_Field.Width * 5 / 8), 0,
                                   (Hard_Playing_Field.Width * 5 / 8), Hard_Playing_Field.Height);
            g.DrawLine(hard_White_Pen, (Hard_Playing_Field.Width * 6 / 8), 0,
                                   (Hard_Playing_Field.Width * 6 / 8), Hard_Playing_Field.Height);
            g.DrawLine(hard_White_Pen, (Hard_Playing_Field.Width * 7 / 8), 0,
                                   (Hard_Playing_Field.Width * 7 / 8), Hard_Playing_Field.Height);

            g.DrawLine(hard_White_Pen, 0, (Hard_Playing_Field.Height * 1 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 1 / 8));
            g.DrawLine(hard_White_Pen, 0, (Hard_Playing_Field.Height * 2 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 2 / 8));
            g.DrawLine(hard_White_Pen, 0, (Hard_Playing_Field.Height * 3 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 3 / 8));
            g.DrawLine(hard_White_Pen, 0, (Hard_Playing_Field.Height * 4 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 4 / 8));
            g.DrawLine(hard_White_Pen, 0, (Hard_Playing_Field.Height * 5 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 5 / 8));
            g.DrawLine(hard_White_Pen, 0, (Hard_Playing_Field.Height * 6 / 8),
                                   Hard_Playing_Field.Width, (Hard_Playing_Field.Height * 6 / 8));
            g.DrawLine(hard_White_Pen, 0, (Hard_Playing_Field.Height * 7 / 8),
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
                            g.DrawString(numbers_array[i], draw_Font_9_Bold, hard_Black_Brush, (x * (width / 8)) + 12, (y * (height / 8)) + 12);
                            g.DrawString(numbers_array[i], input_Font_9, hard_Black_Brush, (x * (width / 8)) + 12, (y * (height / 8)) + 12);
                        }
                        //ClearCell(y, x);

                        g.DrawString(custom_summation_matrix[y, x] + "", input_Font_9, hard_Default_White_Brush, (x * (width / 8)) + 12, (y * (height / 8)) + 12);
                    }
                }


            }
        }

    }
}
