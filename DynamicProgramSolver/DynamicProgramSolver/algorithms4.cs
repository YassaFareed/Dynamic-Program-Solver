using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicProgramSolver
{
    public partial class algorithms4 : Form
    {
        public algorithms4()
        {
            InitializeComponent();
        }

        public algorithms4(string value)
        {
            InitializeComponent();
            this.Value = value;
        }

        public string Value { get; set; }
        private void wordbreak_click(object sender, EventArgs e)
        {
         
            string[] lines = System.IO.File.ReadAllLines(Globals.path + Value);
            List<string> l = new List<string>(); 
            l.Add(lines[1]);
            MessageBox.Show(WordBreak(lines[0],l) ? "It is possible" : "It is not possible","Output");

        }
        public bool WordBreak(string s, IList<string> wordDict)
        {

            bool[] dp = new bool[s.Length + 1];
            dp[0] = true;
            HashSet<string> set = new HashSet<string>(wordDict);

        
            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (dp[j] && set.Contains(s.Substring(j, i - j)))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }

            return dp[s.Length];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
