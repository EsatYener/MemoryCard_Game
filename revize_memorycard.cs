using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace ConsoleApp2
{
    static class ExtensionsClass
    {
        private static Random rand = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int i = list.Count;
            while (i > 1)
            {
                i--;
                int j = rand.Next(i + 1);
                T value = list[j];
                list[j] = list[i];
                list[i] = value;
            }
        }
    }

    public class card
    {
        public bool active;
        public string letter;
        public int number;
        public card(bool active, string letter, int number)
        {
            this.active = active;
            this.letter = letter;
            this.number = number;
        }
    }
    class Program
    {

        public void cizim(List<card> card)
        {
            for (int i = 1; i < 17; i++)
            {
                if (i < 10)
                {
                    if (card[i - 1].active == false)
                    {

                        if (i % 4 == 0)
                        {

                            Console.Write($" | {card[i - 1].letter}  |");
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.Write($" | {card[i - 1].letter} ");
                        }
                    }
                    else
                    {
                        if (i % 4 == 0)
                        {
                            Console.Write($" | {i}  |");
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.Write($" | {i} ");
                        }

                    }
                }
                else
                {
                    if (card[i - 1].active == false)
                    {

                        if (i % 4 == 0)
                        {

                            Console.Write($" | {card[i - 1].letter}  |");
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.Write($" | {card[i - 1].letter} ");
                        }
                    }
                    else
                    {
                        if (i % 4 == 0)
                        {
                            Console.Write($" | {i} |");
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.Write($" | {i}");
                        }

                    }

                }
            }
            Console.WriteLine("");
        }


        static void Main(string[] args)
        {
            Program prog = new Program();
            List<card> authors = new List<card>();
            authors.Add(new card(true, "A", 1));
            authors.Add(new card(true, "A", 2));
            authors.Add(new card(true, "B", 3));
            authors.Add(new card(true, "B", 4));
            authors.Add(new card(true, "C", 5));
            authors.Add(new card(true, "C", 6));
            authors.Add(new card(true, "D", 7));
            authors.Add(new card(true, "D", 8));
            authors.Add(new card(true, "E", 9));
            authors.Add(new card(true, "E", 10));
            authors.Add(new card(true, "F", 11));
            authors.Add(new card(true, "F", 12));
            authors.Add(new card(true, "G", 13));
            authors.Add(new card(true, "G", 14));
            authors.Add(new card(true, "H", 15));
            authors.Add(new card(true, "H", 16));

            authors.Shuffle();

            bool working = true;
            int move_count = 0;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int acilan_cards = 0;
            prog.cizim(authors);
            while (working)
            {
                Console.WriteLine("Lütfen birinci kart için bir sayı giriniz: ");
                int ilkHamle;
                string input1 = Console.ReadLine();
                while (!int.TryParse(input1, out ilkHamle) || (ilkHamle > 17 || ilkHamle < 0))
                {
                    Console.WriteLine("Lütfen 17'den küçük bir değer veya 0'dan büyük bir değer giriniz: ");
                    input1 = Console.ReadLine();
                }

                Console.WriteLine("Lütfen ikinci kart için bir sayı giriniz: ");
                int ikinciHamle;
                string input2 = Console.ReadLine();
                while (!int.TryParse(input2, out ikinciHamle) || (ikinciHamle > 17 || ikinciHamle < 0))
                {
                    Console.WriteLine("Lütfen 17'den küçük bir değer veya 0'dan büyük bir değer giriniz: ");
                    input2 = Console.ReadLine();
                }

                if (ilkHamle == ikinciHamle)
                {
                    Console.WriteLine("iki kart için de aynı sayıyı girdiniz.Yeniden işlem yapın.");
                }

                else if (authors[ilkHamle - 1].letter.Equals(authors[ikinciHamle - 1].letter))
                {
                    authors[ilkHamle - 1].active = false;
                    authors[ikinciHamle - 1].active = false;
                    acilan_cards++;
                }
                else
                {
                    if (authors[ilkHamle - 1].active == true && authors[ikinciHamle - 1].active == true)
                    {
                        authors[ilkHamle - 1].active = false;
                        authors[ikinciHamle - 1].active = false;
                        prog.cizim(authors);
                        authors[ilkHamle - 1].active = true;
                        authors[ikinciHamle - 1].active = true;
                    }
                    else
                    {
                        Console.WriteLine("Açılmış kartı tekrar kullanamazsınız. Yeni bir hamle yapın.");
                    }

                }
                move_count++;
                if (acilan_cards == 8)
                {
                    watch.Stop();
                    TimeSpan time = watch.Elapsed;
                    Console.WriteLine($"Oyun sona erdi.");
                    Console.WriteLine($"Toplam adım sayınız: {move_count}");
                    Console.WriteLine($"Toplam süreniz: {time.Minutes}:{time.Seconds}");

                    working = false;
                    break;
                }
                prog.cizim(authors);
            }

        }
    }
}
