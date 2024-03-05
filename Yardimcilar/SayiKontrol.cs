using System;

namespace ATM;

static class SayiKontrol
{
    static Random rnd;

    static SayiKontrol() => rnd = new Random();

    internal static long Uret(long min, long max) => rnd.NextInt64(min, max);

    internal static bool Cevir(string deger, out int sayi)
    {
        bool durum = int.TryParse(deger, out sayi);
        CevirmeDurum(durum);
        return durum;
    }

    internal static bool Cevir(string deger, out long sayi)
    {
        bool durum = long.TryParse(deger, out sayi);
        CevirmeDurum(durum);
        return durum;
    }

    internal static bool Cevir(string deger, out decimal sayi)
    {
        bool durum = decimal.TryParse(deger, out sayi);
        CevirmeDurum(durum);
        return durum;
    }

    static void CevirmeDurum(bool durum) { if (!durum) Console.WriteLine("Hatalı veri girdiniz!"); }
}