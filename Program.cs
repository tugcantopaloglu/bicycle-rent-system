using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

//Tuğcan Topaloğlu -05190000072
namespace ds_project_3
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] duraklar = { "İnciraltı, 28, 2, 10", "Sahilevleri, 8, 1, 11", "Doğal Yaşam Parkı, 17, 1, 6", "Bostanlı İskele, 7, 0, 5", "Fuar Basmane, 10, 0, 6", "Mavi Bahçe, 14, 0, 5", "Alaybey Tersane Cafe, 11, 0, 2", "Bayraklı İskele, 12, 0, 7", "Mavişehir, 11, 0, 0" };
            DurakAgaci durakAgaci = new DurakAgaci();
            durakAgaci = AgacaEkle(duraklar, durakAgaci); // binary treeyi ağaç ekleme metoduna ekleme
            Console.WriteLine(durakAgaci.AgacDerinliginiAl());
            durakAgaci.TraverseInOrder(durakAgaci.Root); //traverse in order sırası ile binary treede tutulan her bilgiyi yazdırma
            IDMusteriYazdir(durakAgaci);
            var yerlesmisHashTable = HashTableYerlestir(duraklar);
            yerlesmisHashTable = HashTableGuncelle(yerlesmisHashTable);
            HeapOlusturucu(duraklar,yerlesmisHashTable);
            Console.ReadKey();
        }

        static DurakAgaci AgacaEkle(String[] stringListesi, DurakAgaci durakAgaci) //parkta bulunan değerlerin de düzenlenerek stringleri de gerekli değerlere çevirerek binary treeye atama
        {
            foreach (string strButunu in stringListesi)
            {
                String[] tmpString = strButunu.Split(",");
                List<Musteri> randomMusteri = RandomMusteriOlustur(Int32.Parse(tmpString[1]));
                Durak tmpDurak = new Durak(tmpString[0], Int32.Parse(tmpString[1])-randomMusteri.Count, Int32.Parse(tmpString[2]), Int32.Parse(tmpString[3]),randomMusteri);
                durakAgaci.Ekle(tmpDurak);
            }
            return durakAgaci;
        }
        static int RandomSayi(int maksimumDeger = 20,int minimumDeger = 0)
        {
            Random random = new Random();  
            return random.Next(minimumDeger, maksimumDeger);
        }
        static List<Musteri> RandomMusteriOlustur(int bosPark) // random müşteri oluşturma maks müşteri miktarı o duraktaki boş  park sayısını aşamayacak şekilde ve random saat ve sayıda
        {
            List<Musteri> musteriListesi = new List<Musteri>();
            int musteriSayisi = RandomSayi(bosPark, 0);
            for (int i = 0; i<musteriSayisi;i++) {
                Musteri yeniMusteri = new Musteri(RandomSayi(20, 0), RandomSayi(24, 0));
                musteriListesi.Add(yeniMusteri);
            }
            return musteriListesi;
        }

        static void IDMusteriYazdir(DurakAgaci agac) //agac binary treesini alıp id girdisi de alarak agactaki müşteri listelerini dolaştıktan sonra o idye denk gelen müşteriyi buluyor ve onun kiralama saatini yazdırıyor
        {
            int idGirdisi = Convert.ToInt32(Console.ReadLine());
            foreach(Musteri item in agac.Root.Data.musteriListesi)
            {
                if (item.musteriID == idGirdisi)
                {
                    Console.WriteLine(item.kiralamaSaati);
                }
            }
        }

        static Hashtable HashTableYerlestir(String[] stringListesi) //durak adına göre durak bilgilerini hashtable'a yerleştiren metot
        {
            var hashTablosu = new Hashtable();
            foreach (string strButunu in stringListesi)
            {
                String[] tmpString = strButunu.Split(",");
                Durak tmpDurak = new Durak(tmpString[0], Int32.Parse(tmpString[1]), Int32.Parse(tmpString[2]), Int32.Parse(tmpString[3]));
                hashTablosu.Add(tmpDurak.durakAdi,tmpDurak);
            }

            return hashTablosu;
        }

        static Hashtable HashTableGuncelle(Hashtable hashTablosu)//hash tablosunda durak sınıfı sayesinde işlem yapıyoruz ve eğer boş durak değeri 5'ten fazlaysa boş durak değerine +5 ekliyoruz
        {
            foreach (DictionaryEntry item in hashTablosu)
            {
                Durak hashClassi = (Durak) item.Value; //hash içindeki class geçici bir yere aktarılıyor
                if (hashClassi.bosPark > 5)//işlem yapılıyor
                {
                    hashClassi.bosPark += 5;
                }
                hashTablosu[item.Key] = hashClassi; //class tekrar hash table'a aktarılıyor
            }
            return hashTablosu;
        }

        static void HeapOlusturucu(String[] duraklar, Hashtable hashTablosu) //heap için arrayi oluşturuyor, atıyor ve yazdırıyor.
        {
            int[] normalBisikletler = new int[duraklar.Length];
            int i = 0;
            foreach (string strButunu in duraklar)
            {
                String[] tmpString = strButunu.Split(",");
                normalBisikletler[i] = Int32.Parse(tmpString[3]);
                i++;
            }
            heapOlustur(normalBisikletler, normalBisikletler.Length);
            heapYazdir(normalBisikletler, normalBisikletler.Length);

            
            for (int f = 0; f < 3; f++)
            {
                foreach (DictionaryEntry item in hashTablosu)
                {
                    Durak hashClassi = (Durak)item.Value; //hash içindeki class geçici bir yere aktarılıyor
                    if (hashClassi.normalBisiklet == normalBisikletler[f])//işlem yapılıyor
                    {
                        Console.WriteLine(hashClassi);
                    }
                } 
            }
        }

        // düğüm i ile birleştirerek heap türüne benzetiyoruz 
        static void heapeBenzetme(int[] arr, int n, int i)
        {
            int enBuyuk = i; // enBuyuk root oluyor  
            int l = 2 * i + 1; // sol = 2*i + 1  
            int r = 2 * i + 2; // sağ = 2*i + 2  

            // sol "child" root'tan büyükse 
            if (l < n && arr[l] > arr[enBuyuk])
                enBuyuk = l;

            // sağ "child" root'tan büyükse  
            if (r < n && arr[r] > arr[enBuyuk])
                enBuyuk = r;

            // en büyük olan root değilse
            if (enBuyuk != i)
            {
                int degistir = arr[i];
                arr[i] = arr[enBuyuk];
                arr[enBuyuk] = degistir;

                heapeBenzetme(arr, n, enBuyuk);
            }
        }

        // array yapısından Maksimum heap oluşturuyoruz
        static void heapOlustur(int[] arr, int n)
        {
            // yaprak olmayan son düğümün indeksi 
            int baslangicIndexi = (n / 2) - 1;

            // ters olarak sıralayarak her düğümü heap türüne benzetiyoruz
            for (int i = baslangicIndexi; i >= 0; i--)
            {
                heapeBenzetme(arr, n, i);
            }
        }

        //Heapi array şeklinde yazdırıyoruz
        static void heapYazdir(int[] arr, int n)
        {
            Console.WriteLine("Heap'in array gibi yazdırılmış hali:");
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");

            Console.WriteLine();
        }
    }
}
