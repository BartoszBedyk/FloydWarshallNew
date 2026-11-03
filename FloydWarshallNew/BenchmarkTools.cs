using FloydWarshallNew;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace AlgorytmyStrukturyDanych1
{
    internal class BenchmarkTools
    {

        // Miezrenie czasu 
        public static double MeasureTime(Action action) {
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        // Wczytanie dancyh do node z csv
        public static List<KeyValuePair<int, string>> LoadFromCsv(string path)
        {
            string[] lines = File.ReadAllLines(path);

            List<KeyValuePair<int, string>> data = new List<KeyValuePair<int, string>>();

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split(',');

                if (parts.Length != 2)
                    continue;

                if (!int.TryParse(parts[0], out int key))
                    continue;

                string value = parts[1];

                data.Add(new KeyValuePair<int, string>(key, value));
            }

            return data;
        }

        // Wczytanie dancyh do edge z csv
        public static List<(int, int, int)> LoadEdgesFromCsv(string path)
        {
            string[] lines = File.ReadAllLines(path);

            List<(int, int, int)> data = new();

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split(',');

                if (parts.Length != 3)
                    continue;

                if (!int.TryParse(parts[0], out int from))
                    continue;

                if (!int.TryParse(parts[1], out int to))
                    continue;

                if (!int.TryParse(parts[2], out int distance))
                    continue;

                data.Add((from, to, distance));
            }

            return data;
        }


        // Liczy złożoność algorytmu na podstawie dwóch pomiarów czasu dla różnych rozmiarów danych
        public static Double CalclateComplexity(int size1, double time1, int size2, double time2){
            if(size1 <= 0 || size2 <= 0 || size1 == size2)
                throw new ArgumentException("Sizes must be positive and different.");
            
            if (time1 <= 0 || time2 <= 0)
                throw new ArgumentException("Czasy pomiarów muszą być dodatnie.");

            return Math.Log(time2 / time1) / Math.Log((double)size2 / size1);
        }

public static double NewCalclateComplexity(LastTest newest, LastTest secondToNewest)
{
            if (newest.size <= 0 || secondToNewest.size <= 0)
        throw new ArgumentException("Sizes must be positive and different.");

    if (newest.timeTaken <= 0 || secondToNewest.timeTaken <= 0)
        throw new ArgumentException("Czasy pomiarów muszą być dodatnie.");

    return Math.Log(newest.timeTaken / secondToNewest.timeTaken)
         / Math.Log((double)newest.size / secondToNewest.size);
}

        // Szacuje nazwę złożoności na podstawie wartości złożoności
        public static string EstimateComplexityName(double complexity){
            switch (complexity){
                case < 0.2: return "O(1) - Stała";
                case >= 0.2 and < 0.7: return "O(sqrt(N)) - Pierwiastkowa";
                case >= 0.7 and < 1.3: return "O(N) - Liniowa";
                case >= 1.3 and < 1.7: return "O(N log N) - Liniowo-logarytmiczna";
                case >= 1.7 and < 2.3: return "O(N^2) - Kwadratowa";
                case >= 2.3 and < 3.5: return "O(N^3) - Sześcienna";
                default: return "O(2^N) lub gorsza - Wykładnicza / Silnia";
            }
        }
    }
    }
