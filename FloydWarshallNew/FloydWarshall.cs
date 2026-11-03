using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorytmyStrukturyDanych1
{
    internal class FloydWarshall
    {


        // W skrócie szukamy ścieżki pomiędzy każdym możliwym punktem w grafie
        // Przechodzimy po kazym punkcie i jego strasie względem sibie, względem innych i względem celu
        // Zawsze jak znajdziemy krótszą trasę to ją ustawiamy jako najrutszą
        //brak trasy np samotny wierzchołek oznaczmy teoretycznie nieskończonośc, ale
        // tutaj robimy to jako max int
        //w ten sposób w razie problemu i tak wywali nam błąd bo pojawi się max + dystans



        //Do samej metody dostarczymy graf przerobiony na macież odległości musi być kwadratoa
        public static int[,] FloydWarshallAlgorithm(int[,] graph)
        {

            if (graph.GetLength(0) != graph.GetLength(1))
            {
                throw new ArgumentException(
                    "Macierz grafu musi być kwadratowa.",
                    nameof(graph));
            }

            int liczbaKrawedzi = graph.GetLength(0);


            //pracujemy na kopii
            int[,] odleglosci = (int[,])graph.Clone();

            // Teraz będą 3 fory 

            //Wybieramy każdy wierzchołek jako potencjalny pośredni 
            for (int k = 0; k < liczbaKrawedzi; k++)
            {

                //Wybieramy wierzchołek początkowy
                for (int i = 0; i < liczbaKrawedzi; i++)
                {

                    //Wybieramy wierzcchołek pośredni

                    for (int j = 0; j < liczbaKrawedzi; j++)
                    {

                        //Jeżeli nie istnieje drogra z i do k lub z k do j
                        //nie da się zrobić trasy  i -> k -> j
                        //max value to brak znanej trasy 

                        if (odleglosci[i, k] == int.MaxValue ||
                            odleglosci[k, j] == int.MaxValue)
                        {
                            continue;
                        }

                        //liczymy odległośc przy przejściu przez k
                        int nowaOdleglosc = odleglosci[i, k] + odleglosci[k, j];

                        //Jeżeli trasa przez k jest krótsza od dotychczasowej  to zostaje zapisana jako najkrótsza

                        if (nowaOdleglosc < odleglosci[i, j])
                        {
                            odleglosci[i, j] = nowaOdleglosc;
                        }
                    }
                }
            }

            return odleglosci;



        }
    }
}
