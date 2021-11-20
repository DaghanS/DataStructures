using System;
using System.Collections;
using System.Collections.Generic;
namespace DataStructures
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            int turn;
            double width;
            double length;
            Console.WriteLine("oluşturulacak nokta sayısı");
            turn = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("x ekseni");
            width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("y ekseni");
            length = Convert.ToDouble(Console.ReadLine());  
            var asd = input(turn, width, length);

            for(int say = 0; turn > say; say++)
            {
                Console.WriteLine(asd[say, 0] + " , " + asd[say, 1]);
            }
            
            for (int i = 0; i < 10; i++)
            {
                var asde = input(turn, width, length);
                double[,] uzakliktablo2 = uzaklıkhesaplama(asde, turn);
                printer(uzakliktablo2, turn);
                noktalaridolasma(asde, uzakliktablo2, turn);
            }
            //double[,] uzakliktablo = uzaklıkhesaplama(asd, turn);
            //printer(uzakliktablo, turn);
            //noktalaridolasma(asd, uzakliktablo, turn);

            
        }
        static double[,] input(int turn, double width, double length)
        {
            double x, y;
            double[,] matriscoordinate = new double[turn,2];


            for (int i = 0; i < turn; i++)
            {
                x = (random.NextDouble() * 100000000000000) % width;
                y = (random.NextDouble() * 100000000000000) % length;
                x = Math.Round(x, 2);
                y = Math.Round(y, 2);
                matriscoordinate[i, 0] = x;
                matriscoordinate[i,1] = y;
            }
            return matriscoordinate;
        }
        static double[,] uzaklıkhesaplama(double[,] asd, int noktaSay)
        {
            double[,] uzakliktablo = new double[noktaSay, noktaSay];

            for(int i = 0; i < noktaSay; i++)
            {
                for (int j = 0; j < noktaSay; j++)
                {

                    double p1x= asd[i, 0];
                    double p1y = asd[i, 1];
                    double[] p1 = new double[2];
                    p1[0] = p1x;
                    p1[1] = p1y;

                    double p2x = asd[j, 0];
                    double p2y = asd[j, 1];
                    double[] p2 = new double[2];
                    p2[0] = p2x;
                    p2[1] = p2y;


                    double uzaklik = Math.Sqrt(Math.Pow(p1[0] - p2[0], 2) + Math.Pow(p1[1] - p2[1], 2)); // uzaklık hesaplama işlemi
                    uzaklik = Math.Round(uzaklik, 2);
                    uzakliktablo[i, j] = uzaklik;

                    //Console.WriteLine(i + ". Elemanın" + j + ". Elemana Uzaklığı = " + uzaklik);
                }
            }
            return uzakliktablo;
        }

        static void noktalaridolasma(double[,] asd, double[,] matristablosu, int noktaSay)
        {
            double sontoplam = 0;

            Random r = new Random();
            int rInt = r.Next(0, noktaSay); //for ints
            List<double[]> asdcopy = new List<double[]>(noktaSay); // listenin oluşturulma yönetmini değiştirdim
            int baslangicIndex = rInt;
            

            List<int> kaldırılanlar = new List<int>();
            for(int mcount = 0; mcount < noktaSay; mcount++)
            {
                int gidisIndex = -1;
                double enkucukdeger = -1;
                //asdcopy.RemoveAt(secilmisIndex);
                // kaldırılanlar listesinde daha önce seçilen noktaların kullanılmasını zaten engellediğimiz için
                // kopya bir liste oluşuturup ondan eleman silmemize gerek yok, işi kompleksleştiriyor
                kaldırılanlar.Add(baslangicIndex);

                for (int count = 0; noktaSay > count; count++ ) // matristen seçilen noktanın diğer tüm noktalar uzaklığından en küçüğü bulma
                {
                    double uzunluk = matristablosu[baslangicIndex, count];  // UZUNLUK HESABINDA BİR PROBLEM VAR ONU ÇÖZZZZZZ !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    if (kaldırılanlar.Contains(count))
                    {
                        continue;
                    }
                    else if (enkucukdeger == -1)
                    {
                        enkucukdeger = uzunluk;  // secilmis değişince yanlış değer almaya başlıyor mesela 3le başladık 3le 0 ı karşılaştırdı her türlü 0 ın uzaklığını alıyor
                        gidisIndex = count;
                    }
                    else if (uzunluk <= enkucukdeger)
                    {
                        enkucukdeger = uzunluk;
                        gidisIndex = count;
                    }
                }
                double finalenkucuk = enkucukdeger;
                if (kaldırılanlar.Count == noktaSay) continue;

                sontoplam += finalenkucuk;
                sontoplam = Math.Round(sontoplam, 2);
                //Console.WriteLine(baslangicIndex + "Baslangic indexine en yakın nokta: " + gidisIndex + ". Indexteki nokta , aralarındaki uzaklık: " +
                //    finalenkucuk);
                baslangicIndex = gidisIndex;
            }
            


            for (int kaldirilanSay = 0; kaldirilanSay < kaldırılanlar.Count; kaldirilanSay++)
            {
                
                Console.Write(" ==> " + kaldırılanlar[kaldirilanSay]);
            }
            Console.WriteLine("");
            Console.WriteLine(sontoplam);
        }

        static void printer(double[,] uzakliktablo, int turn)
        {
            for (int i = 0; i < turn; i++)
            {
                Console.Write("  |" + i);
            }

            Console.WriteLine("");
            for (int i = 0; i < turn; i++)
            {
                Console.Write(i);
                for (int j = 0; j < turn; j++)
                {
                    Console.Write("  |" + uzakliktablo[i, j]);
                }
                Console.WriteLine("");
            }
        }
    }
}