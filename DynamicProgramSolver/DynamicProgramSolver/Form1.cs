using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//change the global path to set your directory absolute path in Globals.cs 

namespace DynamicProgramSolver
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        public string Value { get; set; }
        private void showcontent1_Click(object sender, EventArgs e)
        {
            try
            {

                using (StreamReader sr = new StreamReader(Globals.path + Value))
                {

                    ShowRichMessageBox("File content", sr.ReadToEnd());
                }
            }
            catch (Exception err)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                MessageBox.Show("Please press select file button first");
            }
        }
        private void ShowRichMessageBox(string title, string message)
        {
            RichTextBox rtbMessage = new RichTextBox();
            rtbMessage.Text = message;
            rtbMessage.Dock = DockStyle.Fill;
            rtbMessage.ReadOnly = true;
            rtbMessage.BorderStyle = BorderStyle.None;

            Form RichMessageBox = new Form();
            RichMessageBox.Text = title;
            RichMessageBox.StartPosition = FormStartPosition.CenterScreen;
            RichMessageBox.Size = new Size(776, 495);
         
            RichMessageBox.Controls.Add(rtbMessage);
            RichMessageBox.ShowDialog();


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if(!Directory.Exists(Globals.path))
            {
                Directory.CreateDirectory(Globals.path);
            }
            

            comboBox1.Items.AddRange(Directory.GetFiles(Globals.path));
        }



        private void selectfile_button(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0 || comboBox1.SelectedIndex == 0)
            {
                string gettext = comboBox1.SelectedItem.ToString();

                var fileName = System.IO.Path.GetFileName(gettext);
                Value = fileName;
                MessageBox.Show("Selected Successfully");
            }
            else
            {
                MessageBox.Show("Please select an option");
            }
        }

        private void possiblealgos_click(object sender, EventArgs e)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(Globals.path + Value);
               
                if (Regex.IsMatch(lines[0], @"^[a-z]+$"))
                {
                    //MessageBox.Show(lines[0][0].ToString()); //word break
                    algorithms4 A4 = new algorithms4(Value);
                    this.Hide();
                    A4.ShowDialog();
                    this.Show();
                }
                else if (Regex.IsMatch(lines[0], @"^[A-Z]+$"))
                {
                    // MessageBox.Show(lines[0][0].ToString()); //a,b,c
                    algorithms1 A1 = new algorithms1(Value);
                    this.Hide();
                    A1.ShowDialog();
                    this.Show();

                }
                else if (lines[0].Contains(','))
                {

                    //MessageBox.Show(lines[0]);
                    algorithms3 A3 = new algorithms3(Value);
                    this.Hide();
                    A3.ShowDialog();
                    this.Show();
                }
                else
                {
                    //  MessageBox.Show(lines[0]);
                    algorithms2 A2 = new algorithms2(Value);
                    this.Hide();
                    A2.ShowDialog();
                    this.Show();
                }
            }
            catch (Exception err)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                MessageBox.Show("Please select the file first");
            }
        }

        private void generate_click(object sender, EventArgs e)
        {
            
            Random random = new Random();
            for (var c = 1; c <= 10; c++)
            {
                //for a part
                var chars = "YASSA";
                var numbers = "FAREED";
                var rand = new Random();
                int numbr = random.Next(30, 100);

                var firstsequenceResult = new string(Enumerable.Repeat(chars,numbr ).Select(s => s[rand.Next(s.Length)]).ToArray());
                var secondsequenceResult = new string(Enumerable.Repeat(numbers,numbr ).Select(s => s[rand.Next(s.Length)]).ToArray());

                string a = firstsequenceResult  + "\n" + secondsequenceResult ;
                System.IO.File.WriteAllText(Globals.path +"filea" + c.ToString() + ".txt", a);

                //for b part
                chars = "HARIS";
                numbers = "KHAN";
               
                 var firstsequence2Result = new string(Enumerable.Repeat(chars, numbr).Select(s => s[rand.Next(s.Length)]).ToArray());
                 var secondsequence2Result = new string(Enumerable.Repeat(numbers, numbr).Select(s => s[rand.Next(s.Length)]).ToArray());

                string b = firstsequence2Result + "\n" + secondsequence2Result;
                System.IO.File.WriteAllText(Globals.path + "fileb" + c.ToString() + ".txt", b);

                //for c part
                chars = "HARIS";
                numbers = "YASSA";

                var firstsequence3Result = new string(Enumerable.Repeat(chars, numbr).Select(s => s[rand.Next(s.Length)]).ToArray());
                var secondsequence3Result = new string(Enumerable.Repeat(numbers, numbr).Select(s => s[rand.Next(s.Length)]).ToArray());

                string cc = firstsequence3Result + "\n" + secondsequence3Result;
                System.IO.File.WriteAllText(Globals.path + "filec" + c.ToString() + ".txt", cc);

                //for d 
               // Random random = new Random();
                var le = random.Next(30, 100);
                Console.WriteLine("\n Length = " + le);
                List<int> list = new List<int>();
                for (var i = 0; i < le; i++)
                {
                    list.Add(random.Next(0, 100));
                    Console.WriteLine(list[i]);

                }

                var combined = le + "\n" + string.Join(",", list);
                System.IO.File.WriteAllText(Globals.path + "filed" + c.ToString() + ".txt", combined);
                //Console.WriteLine(combined);

                //e
                list.Clear();
                le = random.Next(30, 100);
                Console.WriteLine("\n Length = " + le);
                //List<int> list2 = new List<int>();
                for (var i = 0; i < le; i++)
                {
                    list.Add(random.Next(0, 100));
                    Console.WriteLine(list[i]);

                }

                var combined2 = le + "\n" + string.Join(",", list);
                System.IO.File.WriteAllText(Globals.path + "filee" + c.ToString() + ".txt", combined2);
                //Console.WriteLine(combined);

                //g
                list.Clear();
                le = random.Next(30, 100);
                Console.WriteLine("\n Length = " + le);
                //List<int> list2 = new List<int>();
                for (var i = 0; i < le; i++)
                {
                    list.Add(random.Next(0, 100));
                    Console.WriteLine(list[i]);

                }

                var combined3 = le + "\n" + string.Join(",", list);
                System.IO.File.WriteAllText(Globals.path + "fileg" + c.ToString() + ".txt", combined3);
                //Console.WriteLine(combined);

                //i
                list.Clear();
                le = random.Next(30, 100);
                Console.WriteLine("\n Length = " + le);
                //List<int> list2 = new List<int>();
                for (var i = 0; i < le; i++)
                {
                    list.Add(random.Next(0, 100));
                    Console.WriteLine(list[i]);

                }

                var combined4 = le + "\n" + string.Join(",", list);
                System.IO.File.WriteAllText(Globals.path + "filei" + c.ToString() + ".txt", combined4);


                //f
              
                var len = random.Next(10, 100);
               // Console.WriteLine("\n Length = " + len);
                List<int> list1 = new List<int>();
                List<int> list2 = new List<int>();
                for (var i = 0; i < len; i++)
                {
                    list1.Add(random.Next(1, 100));
                    list2.Add(random.Next(1, 100));
                    //Console.WriteLine(list[i]);  

                }

                var partial = string.Join(",", list1) + "\n" + string.Join(",", list2);
                var list3 = new List<string> { "211", "190" };
                int index = random.Next(list3.Count);
                var total = partial + "\n" + list3[index].ToString();
                System.IO.File.WriteAllText(Globals.path + "filef" + c.ToString() + ".txt", total);


                list1.Clear();
                list2.Clear();
                list3.Clear();
                len = random.Next(10, 100);
               
                for (var i = 0; i < len; i++)
                {
                    list1.Add(random.Next(1, 100));
                    list2.Add(random.Next(1, 100));
                    //Console.WriteLine(list[i]);  

                }

                var partial2 = string.Join(",", list1) + "\n" + string.Join(",", list2);
                list3 = new List<string> { "211", "190" };
                index = random.Next(list3.Count);
                var total2 = partial + "\n" + list3[index].ToString();
                System.IO.File.WriteAllText(Globals.path + "fileh" + c.ToString() + ".txt", total2);

                // j part
                //for a part
                chars = "abcdefghijklmnopqrstuvwxyz";
                var namee = "yassafareed";
                numbr = random.Next(30, 100);

                var Result = new string(Enumerable.Repeat(chars, numbr).Select(s => s[rand.Next(s.Length)]).ToArray());
               
                string res = Result + "\n" + namee;
                System.IO.File.WriteAllText(Globals.path + "filej" + c.ToString() + ".txt", res);

            }
            Form1_Load(this, null);

            //    generateInputButton.Enabled = false;

        }
    }
}
