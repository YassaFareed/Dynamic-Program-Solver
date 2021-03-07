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
    public partial class algorithms1 : Form
    {
        public algorithms1()
        {
            InitializeComponent();
        }
        public algorithms1(string value)
        {
            InitializeComponent();
            this.Value2 = value;
        }

        public string Value2 {get;set;}
        private void editdistance_click(object sender, EventArgs e)
        {
            int c, d;
           string[] lines = System.IO.File.ReadAllLines(Globals.path+Value2);
            c = lines[0].Length;
            d = lines[1].Length;
            MessageBox.Show(editDistDP(lines[0], lines[1], c, d).ToString(),"minimum distance is");

        }


        static int min(int x, int y, int z)
        {
            if (x <= y && x <= z)
                return x;
            if (y <= x && y <= z)
                return y;
            else
                return z;
        }

        static int editDistDP(String str1, String str2, int m,
                              int n)
        {
          
            int[,] dp = new int[m + 1, n + 1];

            
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    
                    if (i == 0)

                        
                        dp[i, j] = j;

                  
                    else if (j == 0)

                        // Min. operations = i
                        dp[i, j] = i;

                 
                    else if (str1[i - 1] == str2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];

                 
                    else
                        dp[i, j] = 1
                                   + min(dp[i, j - 1], 
                                         dp[i - 1, j], 
                                         dp[i - 1,
                                            j - 1]);
                }
            }

            return dp[m, n];
        }
        private void scs_click(object sender, EventArgs e)
        {
            int c, d;
           string[] lines = System.IO.File.ReadAllLines(Globals.path + Value2);
            c = lines[0].Length;
            d = lines[1].Length;
            MessageBox.Show(shortestSuperSequence(lines[0].ToCharArray(), lines[1].ToCharArray(), c, d).ToString(),"Length of SCS is");

        }


        private void lcs_click(object sender, EventArgs e)
        {
            int a, b;
            string[] lines = System.IO.File.ReadAllLines(Globals.path+ Value2);
            a = lines[0].Length;
            b = lines[1].Length;
            MessageBox.Show(lcs(lines[0].ToCharArray(), lines[1].ToCharArray(), a, b).ToString(), "Length of LCS is");
         
        }
        static int max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        static int lcs(char[] X, char[] Y, int m, int n)
        {

            int[,] L = new int[m + 1, n + 1];

         
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        L[i, j] = 0;
                    else if (X[i - 1] == Y[j - 1])
                        L[i, j] = L[i - 1, j - 1] + 1;
                    else
                        L[i, j] = max(L[i - 1, j], L[i, j - 1]);
                }
            }
            return L[m, n];
        }

        static int shortestSuperSequence(char[] X, char[] Y, int m, int n)
        {


            // find lcs
            int l = lcs(X, Y, m, n);

            // Result is sum of input string
            // lengths - length of lcs
            return (m + n - l);
        }

        private void algorithms1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
