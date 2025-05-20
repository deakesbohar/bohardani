using Microsoft.Win32.SafeHandles;
using System.Runtime.CompilerServices;

namespace muzeum
{
    internal class Program
    {
        class adat
        {
            public string TeremAZ {  get; set; }
            public string Muveszneve { get; set; }
            public string Alkotascime { get; set; }
            public string Tipusa { get; set; }
        }
       static List<adat> adatok = new List<adat>();
        static void Main(string[] args)
        {
            void elsofeladat()
            {
                StreamReader olvaso = new StreamReader("muzeum.csv");
                olvaso.ReadLine();
                while (!olvaso.EndOfStream) {
                    string[] sor = olvaso.ReadLine().Split(";");
                    adat rekord = new adat();
                    rekord.TeremAZ = sor[0];
                    rekord.Muveszneve = sor[1];
                    rekord.Alkotascime = sor[2];
                    rekord.Tipusa = sor[3];
                    adatok.Add(rekord);
                }
                olvaso.Close();
                
            }
            void masodikfeladat()
            {
                Console.WriteLine("2. feladat");
                HashSet<string> termek = new HashSet<string>();
                for (int i = 0; i < adatok.Count; i++)
                {
                    termek.Add(adatok[i].TeremAZ);

                }
                Console.WriteLine($"{termek.Count} féle terem van.");
            }
            void harmadikfeladat()
            {
                Console.WriteLine("\n3. feladat");
                Dictionary<string,int> muveszekmuvei = new Dictionary<string,int>();
                HashSet<string> muveszek = new HashSet<string>();
                for (int i = 0; i < adatok.Count; i++)
                {
                    muveszek.Add(adatok[i].Muveszneve);

                }
                foreach (var item in muveszek)
                {
                    muveszekmuvei.Add(item, 0);
                    
                }
                for (int i = 0;i < adatok.Count; i++)
                {
                    if (muveszekmuvei.ContainsKey(adatok[i].Muveszneve))
                    {
                        muveszekmuvei[adatok[i].Muveszneve]++;

                    }
                }
                foreach (var item in muveszekmuvei)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                    
                }


            }
            elsofeladat();
            masodikfeladat();
            harmadikfeladat();
        }
    }
}
