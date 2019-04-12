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

        EasyData easyData1;
        EasyData easyData2;
        EasyData easyData3;

        MediumData mediumData1;
        MediumData mediumData2;
        MediumData mediumData3;

        HardData hardData1;
        HardData hardData2;
        HardData hardData3;

        public Form1()
        {
            easyData1 = new EasyData();
            easyData2 = new EasyData();
            easyData3 = new EasyData();

            mediumData1 = new MediumData();
            mediumData2 = new MediumData();
            mediumData3 = new MediumData();

            hardData1 = new HardData();
            hardData2 = new HardData();
            hardData3 = new HardData();

            myWhitePen = new Pen(Color.White);

            string easy_file = "";
            string med_file = "";
            string hard_file = "";
           
            Random random = new Random();
            int easy_rand = random.Next(3);
            int med_rand = random.Next(3);
            int hard_rand = random.Next(3);

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
            switch (med_rand)
            {
                case 0:
                    med_file = "medium/m1.txt";
                    break;
                case 1:
                    med_file = "medium/m2.txt";
                    break;
                case 2:
                    med_file = "medium/m3.txt";
                    break;
            }
            switch(hard_rand)
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

            // EASY
            string easy_digits = "0123456789";

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
                        easyData1.initially_displayed[easy_r / 3, easy_r % 3] = true;
                        //Console.WriteLine("Custom (In IF IF): " + mediumData.initially_displayed[r / 5, r % 5]);
                    }

                    easyData1.easy_custom_summation_matrix[easy_r / 3, easy_r % 3] = easy_file_chars[easy_r] - 48;

                    easyData1.easy_original_summation_matrix[easy_r / 3, easy_r % 3] = easy_file_chars[easy_r] - 48;

                    //Console.WriteLine("Custom (In IF): " + mediumData.medium_custom_summation_matrix[r / 5, r % 5]);
                }
                else
                {
                    int easy_t = easy_r - (easy_len / 2);
                    easyData1.easy_summation_matrix[easy_t / 3, easy_t % 3] = easy_file_chars[easy_r] - 48;
                    //Console.WriteLine("Normal (In ELSE): " + mediumData.medium_summation_matrix[t / 5, t % 5]);
                }
                easy_r++;
            }

            // MEDIUM
            string med_digits = "0123456789";

            StringBuilder med_file_data_builder = new StringBuilder();
            StringBuilder med_solution = new StringBuilder();

            using (StreamReader med_inFile = new StreamReader(med_file))
            {
                while (!med_inFile.EndOfStream)
                {
                    char ch = (char)med_inFile.Read();
                    //Console.WriteLine("ch = " + ch);
                    if (med_digits.IndexOf(ch) == -1)
                    {
                        med_file_data_builder.Append('$');
                        Console.WriteLine(med_file_data_builder);
                        if (med_file_data_builder.Equals("$$"))
                        {

                        }
                    }
                    else
                    {
                        med_file_data_builder.Append(ch);
                        //Console.WriteLine(file_data_builder);
                    }
                }
            }

            StringBuilder med_digitsOnly = new StringBuilder();

            foreach (char cha in med_file_data_builder.ToString().ToCharArray())
            {
                if (med_digits.IndexOf(cha) >= 0)
                {
                    med_digitsOnly.Append(cha);
                }
            }

            char[] med_file_chars = med_digitsOnly.ToString().ToCharArray();

            int med_len = med_file_chars.Length;

            int med_r = 0;

            while (med_r < med_len)
            {
                if (med_r < med_len / 2)
                {
                    if (med_file_chars[med_r] > 48)
                    {
                        mediumData1.initially_displayed[med_r / 5, med_r % 5] = true;
                        //Console.WriteLine("Custom (In IF IF): " + mediumData.initially_displayed[r / 5, r % 5]);
                    }
                    
                    mediumData1.medium_custom_summation_matrix[med_r / 5, med_r % 5] = med_file_chars[med_r] - 48;

                    mediumData1.medium_original_summation_matrix[med_r / 5, med_r % 5] = med_file_chars[med_r] - 48;

                    //Console.WriteLine("Custom (In IF): " + mediumData.medium_custom_summation_matrix[r / 5, r % 5]);
                }
                else
                {
                    int med_t = med_r - (med_len / 2);
                    mediumData1.medium_summation_matrix[med_t / 5, med_t % 5] = med_file_chars[med_r] - 48;
                    //Console.WriteLine("Normal (In ELSE): " + mediumData.medium_summation_matrix[t / 5, t % 5]);
                }
                med_r++;
            }


            // HARD
            string hard_digits = "0123456789";

            StringBuilder hard_file_data_builder = new StringBuilder();
            StringBuilder hard_solution = new StringBuilder();


            using (StreamReader hard_inFile = new StreamReader(hard_file))
            {
                while (!hard_inFile.EndOfStream)
                {
                    char ch = (char)hard_inFile.Read();
                    //Console.WriteLine("ch = " + ch);
                    if (hard_digits.IndexOf(ch) == -1)
                    {
                        hard_file_data_builder.Append('$');
                        Console.WriteLine(hard_file_data_builder);
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
                        hardData1.initially_displayed[hard_r / 7, hard_r % 7] = true;
                    }

                    hardData1.hard_custom_summation_matrix[hard_r / 7, hard_r % 7] = hard_file_chars[hard_r] - 48;
                }
                else
                {
                    int hard_t = hard_r - (hard_len / 2);
                    hardData1.hard_summation_matrix[hard_t / 7, hard_t % 7] = hard_file_chars[hard_r] - 48;
                }
                hard_r++;
            }

            InitializeComponent();
        }

        public Form1(EasyData ED)
        {
            if(easyData1.solved == true)
                RemakePuzzle();
            easyData1 = ED;
            myWhitePen = new Pen(Color.White);
            InitializeComponent();
        }        
        public Form1(MediumData MD)
        {
            if (MD.solved == true)
                RemakePuzzle();
            mediumData1 = MD;
            myWhitePen = new Pen(Color.White);
            InitializeComponent();
        }
        public Form1(HardData HD)
        {
            if(hardData1.solved == true)
                RemakePuzzle();
            hardData1 = HD;
            myWhitePen = new Pen(Color.White);
            InitializeComponent();
        }

        void RemakePuzzle()
        {
            string file_easy = "";
            string file_medium = "";
            string file_hard = "";

            Random random = new Random();
            int rand = random.Next(3);

            switch(rand)
            {
                case 0:
                    file_easy = "easy/e1.txt";
                    file_medium = "medium/m1.txt";
                    file_hard = "hard/h1.txt";
                    break;
                case 1:
                    file_easy = "easy/e2.txt";
                    file_medium = "medium/m2.txt";
                    file_hard = "hard/h2.txt";
                    break;
                case 2:
                    file_easy = "easy/e3.txt";
                    file_medium = "medium/m3.txt";
                    file_hard = "hard/h3.txt";
                    break;
            }
        }


        private void Choose_Difficulty_Playing_Field(object sender, MouseEventArgs e)
        {
            Form1 form1 = new Form1();
            RadioButton EasyRB = EasyRadioButton;
            RadioButton MediumRB = MediumRadioButton;
            RadioButton HardRB = HardRadioButton;

            if (EasyRB.Checked)
            {
                Easy_Form easy_Form = new Easy_Form(easyData1);
                easy_Form.Show();
                this.Hide();
                form1.Close();
            }
            else if (MediumRB.Checked)
            {
                Medium_Form medium_Form1 = new Medium_Form(mediumData1);
                medium_Form1.Show();
                this.Hide();
                form1.Close();

            }
            else if (HardRB.Checked)
            {
                Hard_Form hard_Form = new Hard_Form(hardData1);
                hard_Form.Show();
                this.Hide();
                form1.Close();
            }
            else
            {
                MessageBox.Show("Select difficulty level.", "ERROR");
            }
        }

    }

    public class EasyData
    {
        public Easy_Form easy_Form;
        public bool created;
        public bool solved;
        public int[,] easy_summation_matrix;
        public int[,] easy_custom_summation_matrix;
        public int[,] easy_original_summation_matrix;
        public int[] easy_right_edge;
        public int[] easy_custom_right_edge;
        public int[] easy_bottom_edge;
        public int[] easy_custom_bottom_edge;
        public bool[,] should_display_number;
        public bool[,] initially_displayed;

        public EasyData()
        {
            easy_summation_matrix = new int[4, 4];
            easy_custom_summation_matrix = new int[4, 4];
            easy_original_summation_matrix = new int[4, 4];
            easy_right_edge = new int[3];
            easy_bottom_edge = new int[3];
            should_display_number = new bool[4, 4];
            initially_displayed = new bool[4, 4];
            easy_custom_right_edge = new int[3];
            easy_custom_bottom_edge = new int[3];
        }
    }
    public class MediumData
    {
        public Medium_Form medium_Form;
        public bool created;
        public bool solved;
        public int[,] medium_summation_matrix;
        public int[,] medium_custom_summation_matrix;
        public int[,] medium_original_summation_matrix;
        public int[] medium_right_edge;
        public int[] medium_custom_right_edge;
        public int[] medium_bottom_edge;
        public int[] medium_custom_bottom_edge;
        public bool[,] should_display_number;
        public bool[,] initially_displayed;

        public MediumData()
        {
            medium_summation_matrix = new int[6, 6];
            medium_custom_summation_matrix = new int[6, 6];
            medium_original_summation_matrix = new int[6, 6];
            medium_right_edge = new int[5];
            medium_bottom_edge = new int[5];
            should_display_number = new bool[6, 6];
            initially_displayed = new bool[6, 6];
            medium_custom_right_edge = new int[5];
            medium_custom_bottom_edge = new int[5];
        }
    }
    public class HardData
    {
        public Hard_Form hard_Form;
        public bool created;
        public bool solved;
        public int[,] hard_summation_matrix;
        public int[,] hard_custom_summation_matrix;
        public int[,] hard_original_summation_matrix;
        public int[] hard_right_edge;
        public int[] hard_custom_right_edge;
        public int[] hard_bottom_edge;
        public int[] hard_custom_bottom_edge;
        public bool[,] should_display_number;
        public bool[,] initially_displayed;

        public HardData()
        {
            hard_summation_matrix = new int[8, 8];
            hard_custom_summation_matrix = new int[8, 8];
            hard_original_summation_matrix = new int[8, 8];
            hard_right_edge = new int[7];
            hard_bottom_edge = new int[7];
            should_display_number = new bool[8, 8];
            initially_displayed = new bool[8, 8];
            hard_custom_right_edge = new int[7];
            hard_custom_bottom_edge = new int[7];
        }
    }
}