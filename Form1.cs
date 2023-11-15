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

        //Rozmiar macierzy, wektora
        public int size = 1;

        //Zmienna ukryta
        public int x;

        //Wyświetlenie macierzy w tabeli
        void Print_dGV(Complex[,] A, Complex[] B)
        {
            //dGV1 wyswietlenie macierzy
            dGV1.RowCount = size;
            dGV1.ColumnCount = size;
            dGV1.RowHeadersWidth = 80;
            for (int k = 0; k < size; k++)
            {
                dGV1.Columns[k].HeaderCell.Value = " k = " + k.ToString();
                for (int w = 0; w < size; w++)
                {
                    dGV1.Rows[w].HeaderCell.Value = " w = " + w.ToString();
                    dGV1.Rows[w].Cells[k].Value = A[w, k].ToString();
                }
            }

            //dGV2 wyswietlenie wektora ukrytych 
            dGV2.RowCount = size;
            dGV2.ColumnCount = 1;
            dGV2.RowHeadersWidth = 80;
            for (int k = 0; k < size; k++)
            {
                dGV2.Rows[k].HeaderCell.Value = " x = " + (k + 1).ToString();
                dGV2.Rows[k].Cells[0].Value = (k + 1).ToString();
            }

            //dGV3 wyswietlenie wektora b
            dGV3.RowCount = size;
            dGV3.ColumnCount = 1;
            dGV3.RowHeadersWidth = 80;
            for (int k = 0; k < size; k++)
            {
                dGV3.Rows[k].HeaderCell.Value = " x = " + (k + 1).ToString();
                dGV3.Rows[k].Cells[0].Value = B[k].ToString();
            }
        }

        //Mnożenie macierzy z wektorem
        void AxB(Complex[,] A)
        {
            Complex[] wynik = new Complex[size];
            for (int k = 0; k < size; k++)
            {
                x++;
                for (int w = 0; w < size; w++)
                {
                    wynik[k] += A[k, w] * x;
                }
            }
            x = 0;
            Print_dGV(A, wynik);
        }

        //Zmiana rozmiaru macierzy
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            size = (int)numericUpDown1.Value;
        }
        
        //Macierz Gaussa
        private void Gauss(object sender, EventArgs e)
        {
            Complex[,] Gauss = new Complex[size, size];
            for (int k = 0; k < size; k++)
            {
                for (int w = 0; w < size; w++)
                {
                    Gauss[w, k] = new Complex(w + 1, k + 1);
                }
            }
            AxB(Gauss);
        }

        //Macierz Hilberta
        private void Hilbert(object sender, EventArgs e)
        {
            Complex[,] Hilbert = new Complex[size, size];
            for (int k = 0; k < size; k++)
            {
                for (int w = 0; w < size; w++)
                {
                    Hilbert[k, w] = Math.Round((double)1 / (k + w + 1), 5);
                }
            }
            AxB(Hilbert);
        }

        // Macierz cykliczna
        private void Cykliczna(object sender, EventArgs e)
        {
            //zmienna urojona do przesuwania liczb w macierzy
            Complex cykl;

            Complex[,] cykliczna = new Complex[size, size];
            for (int k = 0; k < size; k++)
            {
                for (int w = 0; w < size; w++)
                {
                    cykliczna[w, k] = new Complex(w + 1, k + 1);
                }
            }
            for (int i = size - 1; i >= 0; i--)
            {
                for (int k = size - 1; k >= size - i; k--)
                {
                    for (int w = size - 1; w >= 1; w--)
                    {
                        cykl = cykliczna[k, w];
                        cykliczna[k, w] = cykliczna[k, w - 1];
                        cykliczna[k, w - 1] = cykl;
                    }
                }
            }
            AxB(cykliczna);
        }

        //Macierz Vandermonda
        private void Vandermonde(object sender, EventArgs e)
        {
            Complex[,] Vandermonde = new Complex[size, size];
            for (int k = 0; k < size; k++)
            {
                for (int w = 0; w < size; w++)
                {
                    Vandermonde[k, w] = new Complex(w + 1, k + 1);
                    Vandermonde[k, w] = Math.Pow((k + 1), w);
                }
            }
            AxB(Vandermonde);
        }


    }
}

//komentarze, wygląd