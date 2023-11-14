using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace rów_Lin_Igor_Pasieka_Filip_Świderek_Łukasz_Spałek
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        int N = 1 ,x = 1;

        private void button1_Click(object sender, EventArgs e)
        {
            Complex[,] F1 = new Complex[N, N];
            for (int k = 0; k < N; k++)
            {
                for (int i = 0; i < N; i++)
                {
                    F1[i, k] = new Complex(i - 1, k + 1);
                }
            }

            Complex[,] W1;
            W1 = F1;

            dGV1.RowCount = N;
            dGV1.ColumnCount = N;
            dGV1.RowHeadersWidth = 80;
            for (int k = 0; k < N; k++)
            {
                dGV1.Columns[k].HeaderCell.Value = " k = " + k.ToString();
                for (int i = 0; i < N; i++)
                {
                    dGV1.Rows[i].HeaderCell.Value = " w = " + i.ToString();
                    dGV1.Rows[i].Cells[k].Value = W1[i, k].ToString();
                }

            }

            Complex[] F0 = new Complex[N];
            for (int k = 0; k < N; k++)
            {
                for (int i = 0; i < N; i++)
                {
                    F0[k] = F1[k,i]*x;
                }
                x++;
            }
            x = 0;
            Complex[] W2;
            W2 = F0;

            dGV2.RowCount = 1;
            dGV2.ColumnCount = N;
            dGV2.RowHeadersWidth = 80;
            for (int k = 0; k < N; k++)
            {
                dGV2.Rows[0].HeaderCell.Value = " w = 0";
                dGV2.Columns[k].HeaderCell.Value = " k = " + k.ToString();
                dGV2.Rows[0].Cells[k].Value = W2[k].ToString();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            N = (int)numericUpDown1.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*Complex[,] F1 = new Complex[N,N];
            for (int k = 0; k < N; k++)
            {
                for (int i = 0; i < N; i++)
                {
                    F1[i,k] = new Complex(i - 1, k + 1);
                }
            }
                
            Complex[,] F;
            F = F1;

            dGV1.RowCount = N;
            dGV1.ColumnCount = N;
            dGV1.RowHeadersWidth = 80;
            for (int k = 0; k < N; k++)
            {
                dGV1.Columns[k].HeaderCell.Value = " k = " + k.ToString();
                for (int i = 0; i < N; i++)
                {
                    dGV1.Rows[i].HeaderCell.Value = " w = " + i.ToString();
                    dGV1.Rows[i].Cells[k].Value = F[i,k].ToString();
                }
                
            }*/
        }

    }
}
