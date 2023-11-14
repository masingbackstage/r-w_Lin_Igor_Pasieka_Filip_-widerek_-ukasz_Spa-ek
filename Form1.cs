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

        int size = 1 ,x;
        public Complex suma;
        private void button1_Click(object sender, EventArgs e)
        {
            Complex[,] Wektor = new Complex[size, size];
            for (int k = 0; k < size; k++)
            {
                for (int w = 0; w < size; w++)
                {
                   Wektor[w, k] = new Complex(w + 1, k + 1);
                }
            }

            Complex[] wynik = new Complex[size];
            for (int k = 0; k < size; k++)
            {
                x++;
                for (int w = 0; w < size; w++)
                {
                    wynik[k] += Wektor[k,w] * x;
                }
            }
            x = 0;

            Complex[,] Hilbert = new Complex[size, size];
            for(int k = 0; k < size; k++)
            {
                for(int w = 0; w < size; w++)
                {
                    Hilbert[k, w] = 1 / (k + w - 1);
                }
            }
            //dGV1 print
            dGV1.RowCount = size;
            dGV1.ColumnCount = size;
            dGV1.RowHeadersWidth = 80;
            for (int k = 0; k < size; k++)
            {
                dGV1.Columns[k].HeaderCell.Value = " k = " + k.ToString();
                for (int w = 0; w < size; w++)
                {
                    dGV1.Rows[w].HeaderCell.Value = " w = " + w.ToString();
                    dGV1.Rows[w].Cells[k].Value = Wektor[w, k].ToString();
                }
            }

            //dGV2 print
            dGV2.RowCount = 1;
            dGV2.ColumnCount = size;
            dGV2.RowHeadersWidth = 80;
            for (int k = 0; k < size; k++)
            {
                dGV2.Rows[0].HeaderCell.Value = " w = 0";
                dGV2.Columns[k].HeaderCell.Value = " x = " + (k+1).ToString();
                dGV2.Rows[0].Cells[k].Value = wynik[k].ToString();
            }
            
            //dGV3 print
            dGV3.RowCount = 1;
            dGV3.ColumnCount = size;
            dGV3.RowHeadersWidth = 80;
            for (int k = 0; k < size; k++)
            {
                dGV3.Rows[0].HeaderCell.Value = " w = 0";
                dGV3.Columns[k].HeaderCell.Value = " x = " + (k + 1).ToString();
                dGV3.Rows[0].Cells[k].Value = (k + 1).ToString();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            size = (int)numericUpDown1.Value;
        }
    }
}
