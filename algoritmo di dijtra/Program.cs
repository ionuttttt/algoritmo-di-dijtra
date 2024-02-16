using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algoritmo_di_dijtra
{
    internal class Program
    {
        class Dijkstra
        {
            public static void EseguiDijkstra(int[,] grafo, int numeroNodi)
            {
                int[] distanza = new int[numeroNodi];
                int[] precedente = new int[numeroNodi];
                bool[] visitato = new bool[numeroNodi];

                for (int i = 0; i < numeroNodi; i++)
                {
                    distanza[i] = int.MaxValue;
                    precedente[i] = -1;
                    visitato[i] = false;
                }

                distanza[0] = 0;

                for (int count = 0; count < numeroNodi - 1; count++)
                {
                    int u = TrovaMinimaDistanza(distanza, visitato);
                    visitato[u] = true;

                    for (int v = 0; v < numeroNodi; v++)
                    {
                        if (!visitato[v] && grafo[u, v] > 0)
                        {
                            int nuovaDistanza = distanza[u] + grafo[u, v];
                            if (nuovaDistanza < distanza[v])
                            {
                                distanza[v] = nuovaDistanza;
                                precedente[v] = u;
                            }
                        }
                    }
                }
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                Console.WriteLine("Distanze minime dal nodo iniziale:");
                for (int i = 0; i < numeroNodi; i++)
                {
                    Console.WriteLine($"{(char)(65 + i)}: {distanza[i]}");
                }
            }

            private static int TrovaMinimaDistanza(int[] distanza, bool[] visitato)
            {
                int minimaDistanza = int.MaxValue;
                int minimoNodo = -1;

                for (int nodo = 0; nodo < distanza.Length; nodo++)
                {
                    if (!visitato[nodo] && distanza[nodo] < minimaDistanza)
                    {
                        minimaDistanza = distanza[nodo];
                        minimoNodo = nodo;
                    }
                }

                return minimoNodo;
            }
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            int numeroNodi = rnd.Next(3, 10);
            int righe = numeroNodi;
            int colonne = numeroNodi;
            int[,] matrice;
            int ascii = 65;

            Console.WriteLine($"Il numero di nodi è {numeroNodi}");
            matrice = GeneratoreMatrice(righe, colonne);
            Console.WriteLine($"Il peso dei nodi è:");
            Console.Write("\n \t");

            for (int i = 0; i < righe; i++)
            {
                Console.Write($"{(char)(ascii + i)}\t");
            }

            for (int i = 0; i < righe; i++)
            {
                Console.WriteLine("\n");
                Console.Write($"{(char)(ascii + i)}\t");

                for (int j = 0; j < colonne; j++)
                {
                    Console.Write($"{matrice[i, j]} \t");
                }
            }

            Dijkstra.EseguiDijkstra(matrice, numeroNodi);

            Console.ReadKey();
        }

        static int[,] GeneratoreMatrice(int righe, int colonne)
        {
            Random rnd = new Random();
            int[,] matrice = new int[righe, colonne];

            for (int i = 0; i < righe; i++)
            {
                for (int j = 0; j < colonne; j++)
                {
                    do
                    {
                        matrice[i, j] = rnd.Next(-1, 9);
                    }
                    while (matrice[i, j] == 0);
                }
                matrice[i, i] = 0;
            }

            return matrice;
        }
    }
}

