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
    public partial class algorithms3 : Form
    {
        public algorithms3()
        {
            InitializeComponent();
        }
        public algorithms3(string value)
        {
            InitializeComponent();
            this.Value = value;
        }

        public string Value { get; set; }
        private void knapsack_click(object sender, EventArgs e)
        {
            string[] a;
            string[] b;
            int weight,n;
            int[] arr1 = new int[100];
            int[] arr2 = new int[100];
            string[] lines = System.IO.File.ReadAllLines(Globals.path + Value);
            a = lines[0].Split(','); //converts to integer
            b = lines[1].Split(',');
            weight = int.Parse(lines[2]);
            n = a.Length;
            for (int i = 0; i < n; i++)
            {
                arr1[i] = int.Parse(a[i]);
                arr2[i] = int.Parse(b[i]);
            }

            MessageBox.Show(knapsack(weight, arr1,arr2,n).ToString(), "maximum profit is");
        }
        static int max(int a, int b)
        {
            return (a > b) ? a : b;
        }

      
        static int knapsack(int Weight, int[] wt, int[] val, int n)
        {
            int i, w;
            int[,] K = new int[n + 1, Weight + 1];
            for (i = 0; i <= n; i++)
            {
                for (w = 0; w <= Weight; w++)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;

                    else if (wt[i - 1] <= w)
                        K[i, w] = Math.Max(
                            val[i - 1]
                            + K[i - 1, w - wt[i - 1]],
                            K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            return K[n, Weight];
        }
        private void rodcutting_click(object sender, EventArgs e)
        {
            string[] a;
            string[] b;
            int weight, n;
            int[] arr1 = new int[100];
            int[] arr2 = new int[100];
            string[] lines = System.IO.File.ReadAllLines(Globals.path + Value);
            a = lines[0].Split(','); //converts to integer
            b = lines[1].Split(',');
            weight = int.Parse(lines[2]);
            n = a.Length;
            for (int i = 0; i < n; i++)
            {
                arr1[i] = int.Parse(a[i]);
                arr2[i] = int.Parse(b[i]);
            }

          MessageBox.Show(RodCutting(weight, n, arr1, arr2).ToString(), "value is");
        }
        private static int RodCutting(int Weight, int n, int[] val, int[] wt)
        {
            int[] a = new int[Weight + 1];
   
            for (int i = 0; i <= Weight; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (wt[j] <= i)
                    {
                        a[i] = Math.Max(a[i], a[i - wt[j]] + val[j]);
                    }
                }
            }
            return a[Weight];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
