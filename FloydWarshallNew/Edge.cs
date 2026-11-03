using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorytmyStrukturyDanych1
{


    // to takie anjbardziej basicowe zrobienia grafa na ziemi jak się tylko da bo nie potrzebujemy żadnych wygibasów
    // aogorytm jest nawet git ale nie robiłem testów w mainie zobaczę jak to rozwiązać
    // proponuję dać main page gdzie wybierach na jednym z 3 przycisków jaki algorytm tetsujemy 
    // wtedy przjdziemy do jednej z podstron z algorytmami 1 2 3 
    // i tak będzie chyba essa to do zrobienia ekrany raczej będą takie same jedynie dane z csv różne
    // ale to uszykuje jakieś grafy sam czy nawet pajtonem wygeneruje je 

    // typo kazał by była walidacja to dałem ta dwa wymogi minimum by algorytm działał poprawnie
    // ale dupy nie urywa więc możesz zerknąć 

    internal class Edge
    {

        public int from { get; }
        public int to { get; }
        public int distance { get; }

        public Edge(int from, int to, int distance)
        {
            this.from = from;
            this.to = to;
            this.distance = distance;
        }

    }

    internal class Graph
    {

        //Lista krawędzi
        private readonly List<Edge> edges = new();

        public int vertexCount { get; }

        public int size { set; get; }

        private readonly bool directed;

        public IReadOnlyList<Edge> GetEdges()
        {
            return edges.AsReadOnly();
        }

        public Graph(int vertexCount, bool directed = true)
        {
            if (vertexCount <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(vertexCount),
                    "Graf musi mieć co najmniej jeden wierzchołek.");
            }

            this.vertexCount = vertexCount;
            this.directed = directed;
        }

        public void AddEdge(int from, int to, int weight)
        { 

            if (from < 0 || from >= vertexCount ||
                to < 0 || to >= vertexCount)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(from),
                    "Indeks wierzchołka jest poza zakresem grafu.");
            }

            if (weight < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(weight),
                    "Waga krawędzi nie może być ujemna.");
            }


            edges.Add(new Edge(from, to, weight));
        }

        public int[,] toDistanceMatrix()
        {
            int[,] distances = new int[vertexCount, vertexCount];

            //Kiedy jeszcze nie znamy wagi i połączen pośrednich dajemy 0 lub max
            for (int i = 0; i < vertexCount; i++)
            {
                for (int j = 0; j < vertexCount; j++)
                {
                    distances[i, j] = int.MaxValue;  // już tlłumaczę na start żaden wierzchołek nie wie o sobie nawzajem
                    //Więc ustawiamy ich odległość jako maksymalną możliwą by każda jaką znajdziemy był mniejsza od maksymalnej
                }

                distances[i, i] = 0; // a jak to odległość od samego siebie od samego siebie no to wiadomka dajemy zero
            }

            // tutaj odczytami wagi już znamych połączeń bezpośrednich 
            foreach (Edge edge in edges)
            {

                //jak istanieją np a do b o wadze 5 i a do b o wadze 3 to wybieramy, mneijsze 
                if (edge.distance < distances[edge.from, edge.to])
                {
                    distances[edge.from, edge.to] = edge.distance;
                }

                //Na grafie w nieskierowanym działa to w obie strony 
                if (!directed && edge.distance < distances[edge.to, edge.from])
                {
                    distances[edge.to, edge.from] = edge.distance;
                }

            }

            return distances;
        }



    }
}
