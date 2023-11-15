using System;
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
            //dGV1 odpowiada za wyswietlenie wybranej przez uzytkownika macierzy A
            //Okreslenie ilosci komorek w kolumnie i wierszu oraz rozmiaru komorek w macierzy A
            dGV1.RowCount = size;
            dGV1.ColumnCount = size;
            dGV1.RowHeadersWidth = 80;

            //Wyswietlenie do utworzonej macierzy A wartosci oraz ponumerowanie naglowkow danej pozycji
            for (int k = 0; k < size; k++)
            {
                dGV1.Columns[k].HeaderCell.Value = " k" + k.ToString();
                for (int w = 0; w < size; w++)
                {
                    dGV1.Rows[w].HeaderCell.Value = " w" + w.ToString();
                    dGV1.Rows[w].Cells[k].Value = A[w, k].ToString();
                }
            }

            //dGV2 wyswietlenie wektora ukrytych x
            //Okreslenie ilosci komorek w kolumnie i rozmiaru komorek w wektorze ukrytych x
            dGV2.RowCount = size;
            dGV2.ColumnCount = 1;
            dGV2.RowHeadersWidth = 80;

            //Wyswietlenie utworzonego wektora ukrytych x ciagu arytmetycznego oraz ponumerowanie naglowkow danej pozycji
            for (int k = 0; k < size; k++)
            {
                dGV2.Rows[k].HeaderCell.Value = " x" + (k + 1).ToString();
                dGV2.Rows[k].Cells[0].Value = (k + 1).ToString();
            }

            //dGV3 wyswietlenie dzialania A*x=B jako wektor wynikowy B
            //Okreslenie ilosci komorek w kolumnie i rozmiaru komorek w wektorze wynikowym B
            dGV3.RowCount = size;
            dGV3.ColumnCount = 1;
            dGV3.RowHeadersWidth = 80;

            //Wyswietlenie do utworzonego wektora wynikowego B wynikow oraz ponumerowanie naglowkow danej pozycji
            for (int k = 0; k < size; k++)
            {
                dGV3.Rows[k].HeaderCell.Value = " b" + (k + 1).ToString();
                dGV3.Rows[k].Cells[0].Value = B[k].ToString();
            }
        }

        //Mnożenie macierzy z wektorem
        void AxB(Complex[,] A)
        {
            //Stworzenie wektora, do ktorego zapisywany jest wynik działania A*x=B
            Complex[] wynik = new Complex[size];

            //Wpisanie do wektora wynikow dzialania A*x=B
            for (int k = 0; k < size; k++)
            {
                x++;
                for (int w = 0; w < size; w++)
                {
                    wynik[k] += A[k, w] * x;
                }
            }
            x = 0;

            //Wywolanie funkcji odpowiadajace za wyswietlenie wynikow na ekranie
            Print_dGV(A, wynik);
        }

        //Zmiana rozmiaru macierzy
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //Na bierzaco pobiera podana przez uzytkownika liczbe odpowiadajaca rozmiarom macierzy i wektorow
            size = (int)numericUpDown1.Value;
        }
        
        //Macierz Gaussa
        private void Gauss(object sender, EventArgs e)
        {
            //Utworzenie macierzy Gaussa z wymiarami podanymi przez uzytkownika
            Complex[,] Gauss = new Complex[size, size];

            //Wypelnienie macierzy wybranymi wartosciami
            for (int k = 0; k < size; k++)
            {
                for (int w = 0; w < size; w++)
                {
                    Gauss[w, k] = new Complex(w + 1, k + 1);
                }
            }

            //Wywolanie funkcji odpowiadajacej za mnozenie A*x=B dla danej macierzy
            AxB(Gauss);

            //Zmiana tekstu wypisanego nad podana macierza
            label1.Text = "Macierz Gaussa";
        }

        //Macierz Hilberta
        private void Hilbert(object sender, EventArgs e)
        {
            //Utworzenie macierzy Hilberta z wymiarami podanymi przez uzytkownika
            Complex[,] Hilbert = new Complex[size, size];

            //Wypelnienie macierzy wybranymi wartosciami zgodnie ze wzorem Hilberta
            for (int k = 0; k < size; k++)
            {
                for (int w = 0; w < size; w++)
                {
                    Hilbert[k, w] = Math.Round((double)1 / (k + w + 1), 5);
                }
            }

            //Wywolanie funkcji odpowiadajacej za mnozenie A*x=B dla danej macierzy
            AxB(Hilbert);

            //Zmiana tekstu wypisanego nad podana macierza
            label1.Text = "Macierz Hilberta";
        }

        // Macierz cykliczna
        private void Cykliczna(object sender, EventArgs e)
        {
            //zmienna urojona do przesuwania liczb w macierzy
            Complex cykl;

            //Utworzenie macierzy cyklicznej z wymiarami podanymi przez uzytkownika
            Complex[,] cykliczna = new Complex[size, size];

            //Wypelnienie macierzy wybranymi wartosciami zgodnie z zasada dzialania macierzy cyklicznej
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
            //Wywolanie funkcji odpowiadajacej za mnozenie A*x=B dla danej macierzy
            AxB(cykliczna);

            //Zmiana tekstu wypisanego nad podana macierza
            label1.Text = "Macierz cykliczna";
        }

        //Macierz Vandermonda
        private void Vandermonde(object sender, EventArgs e)
        {
            //Utworzenie macierzy Vandemondea z wymiarami podanymi przez uzytkownika
            Complex[,] Vandermonde = new Complex[size, size];

            //Wypelnienie macierzy wybranymi wartosciami zgodnie ze wzorem Vandemondea
            for (int k = 0; k < size; k++)
            {
                for (int w = 0; w < size; w++)
                {
                    Vandermonde[k, w] = new Complex(w + 1, k + 1);
                    Vandermonde[k, w] = Math.Pow((k + 1), w);
                }
            }

            //Wywolanie funkcji odpowiadajacej za mnozenie A*x=B dla danej macierzy
            AxB(Vandermonde);

            //Zmiana tekstu wypisanego nad podana macierza
            label1.Text = "Macierz Vandermonda";
        }
    }
}