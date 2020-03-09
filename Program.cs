using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cegautoBeszed
{
  struct Adat
  {
    public int nap;     // hónap adott napja
    public string ido;  // időpont
    public string rsz;  // rendszám
    public string azon; // személy azonosítója
    public int km;      // kilométer számláló
    public int irany;   // kihajtás 0, behajtás 1
    public string sirany; // pl.-ként így is
  }

  class Program
  {
    static void Main(string[] args)
    {
      Adat[] adatok = new Adat[500];
      int db = 0; // tényleges adatmennyiség

      #region 1. feladat
      StreamReader file = new StreamReader("autok.txt");

      while (!file.EndOfStream)
      {
        string sor = file.ReadLine();
        string[] a = sor.Split(' ');

        adatok[db].nap = Convert.ToInt32(a[0]);
        adatok[db].ido = a[1];
        adatok[db].rsz = a[2];
        adatok[db].azon = a[3];
        adatok[db].km = Convert.ToInt32(a[4]);
        //1. verzió - irány számként
        adatok[db].irany = Convert.ToInt32(a[5]); // 0;1

        //2. verzió - irány szövegként
        if (a[5] == "0")
        {
          adatok[db].sirany = "ki";
        }
        else
        {
          adatok[db].sirany = "be";
        }
        db++;
      }


      file.Close(); 
      #endregion

      #region 2. feladat
      Console.WriteLine("Első öt");
      Console.WriteLine("idő   rendszám irány");
      for (int i = 0; i < 5; i++)
      {
        Console.WriteLine("{0} {1,-8} {2}",
          adatok[i].ido, adatok[i].rsz, adatok[i].sirany);
        //Console.Write("{0} {1,-8} ", adatok[i].ido, adatok[i].rsz);
        //if (adatok[i].irany == 0)
        //{
        //  Console.WriteLine("ki");
        //}
        //else
        //{
        //  Console.WriteLine("be");
        //}
      }

      Console.WriteLine("\nUtolsó öt");
      Console.WriteLine("idő   rendszám irány");
      for (int i = db-5; i < db; i++)
      {
        Console.WriteLine("{0} {1,-8} {2}",
          adatok[i].ido, adatok[i].rsz, adatok[i].sirany);
      }
      #endregion

      #region 3. feladat
      Console.Write("\nMelyik nap: ");
      int nap = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine("Forgalom a(z) {0}. napon",nap);

      for (int i = 0; i < db; i++)
      {
        if (adatok[i].nap == nap)
        {
          Console.WriteLine("{0} {1} {2}",
          adatok[i].ido, adatok[i].rsz, adatok[i].sirany);
        }
      }
      #endregion

      #region 4. feladat

      int ki = 0;
      int be = 0;
      
      for (int i = 0; i < db; i++)
      {
        if (adatok[i].irany == 0)
        {
          ki++;
        }
        else
        {
          be++;
        }
      }

      Console.WriteLine("\nJegyzett kimenet: {0}",ki);
      Console.WriteLine("Jegyzett bemenet: {0}",be);


      #endregion

      Console.ReadKey();
    }
  }
}
