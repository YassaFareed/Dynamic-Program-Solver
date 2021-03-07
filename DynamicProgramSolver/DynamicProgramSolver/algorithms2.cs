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
    public partial class algorithms2 : Form
    {
        public algorithms2()
        {
            InitializeComponent();
        }
        public algorithms2(string value)
        {
            InitializeComponent();
            this.Value = value;
        }
        public string Value { set; get; }

        private void LincreasingS_click(object sender, EventArgs e)
        {
            int c;
            string[] d;
            int[] arr = new int[100];
           string[] lines = System.IO.File.ReadAllLines(Globals.path+ Value);
            c = int.Parse(lines[0]); //converts to integer
            d = lines[1].Split(',');
            for (int i = 0; i < c; i++)
            {
                arr[i] = int.Parse(d[i]);
            }

            MessageBox.Show(lis(arr, c).ToString(), "Length is");
        }
        static int lis(int[] arr, int n)
        {
            int[] lis = new int[n];
            int i, j, max = 0;
            List<int> p= new List<int>();
       
            for (i = 0; i < n; i++)
                lis[i] = 1;

            for (i = 1; i < n; i++)
                for (j = 0; j < i; j++)
                    if (arr[i] > arr[j] && lis[i] < lis[j] + 1)
                        lis[i] = lis[j] + 1;

         
            for (i = 0; i < n; i++)
                if (max < lis[i])
                    max = lis[i];
               
            return max;
        }

        private void mcm_click(object sender, EventArgs e)
        {
            int a;
            string[] b;
            int[] arr = new int[100];
            string[] lines = System.IO.File.ReadAllLines(Globals.path+Value);
            a = int.Parse(lines[0]); //converts to integer
            b = lines[1].Split(',');
            for (int i = 0; i < a; i++)
            {
                arr[i] = int.Parse(b[i]);
            }

            MessageBox.Show(matrixchain(arr, a).ToString(), "minimum number of multiplications");


        }

        static int matrixchain(int[] p, int n)
        {
            int[,] m = new int[n, n];

            int i, j, k, L, q;

           
            for (i = 1; i < n; i++)
                m[i, i] = 0;

            // L is chain length. 
            for (L = 2; L < n; L++)
            {
                for (i = 1; i < n - L + 1; i++)
                {
                    j = i + L - 1;
                    if (j == n)
                        continue;
                    m[i, j] = int.MaxValue;
                    for (k = i; k <= j - 1; k++)
                    {
                        // q = cost/scalar multiplications 
                        q = m[i, k] + m[k + 1, j]
                            + p[i - 1] * p[k] * p[j];
                        if (q < m[i, j])
                            m[i, j] = q;
                    }
                }
            }

            return m[1, n - 1];
        }

        private void pp_click(object sender, EventArgs e)
        {
            int c;
            string[] d;
            int[] arr = new int[100];
            string[] lines = System.IO.File.ReadAllLines(Globals.path + Value);
            c = int.Parse(lines[0]); //converts to integer
            d = lines[1].Split(',');
            for (int i = 0; i < c; i++)
            {
                arr[i] = int.Parse(d[i]);
            }

            MessageBox.Show(Partition(arr, c) ? "can be possibly divided into two subset of equal sum":"can not be divided into two subset of equal sum", "output");
        }

        static bool Partition(int[] arr, int n)
        {

            int sum = 0;
            int i, j;

            // Calculate sum of all elements
            for (i = 0; i < n; i++)
                sum += arr[i];

            if (sum % 2 != 0)
                return false;

            bool[,] part = new bool[sum / 2 + 1, n + 1];


            for (i = 0; i <= n; i++)
                part[0, i] = true;

            for (i = 1; i <= sum / 2; i++)
                part[i, 0] = false;

      
            for (i = 1; i <= sum / 2; i++)
            {
                for (j = 1; j <= n; j++)
                {
                    part[i, j] = part[i, j - 1];
                    if (i >= arr[j - 1])
                        part[i, j]
                            = part[i, j - 1]
                              || part[i - arr[j - 1], j - 1];
                }
            }
            return part[sum / 2, n];
        }

        private void coinchange_click(object sender, EventArgs e)
        {

            int c;
            string[] d;
            int[] arr = new int[100];
            string[] lines = System.IO.File.ReadAllLines(Globals.path + Value);
            c = int.Parse(lines[0]); //converts to integer
            d = lines[1].Split(',');
            for (int i = 0; i < c; i++)
            {
                arr[i] = int.Parse(d[i]);
            }

            MessageBox.Show(coinchange(arr, c, 211).ToString(), "number of ways it can be done is "); //taken change as roll number's last 3 numbers

        }
        static long coinchange(int[] S, int m, int n)
        {
           
            int[] table = new int[n + 1];

            // Initialize all table values as 0 
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = 0;
            }

            // Base case (If given value is 0) 
            table[0] = 1;

         
            for (int i = 0; i < m; i++)
                for (int j = S[i]; j <= n; j++)
                    table[j] += table[j - S[i]];

            return table[n];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
