using System;

namespace ATM;

enum Baslik
{
    Cizgi,
    Gecersiz
}

static class Sistem
{
    static string[] ifadeler;

    static Sistem() => ifadeler = 
    [
        "-----------------------------------------",
        "Geçersiz seçim yaptınız!"
    ];

    internal static void Yazdir(Baslik talep) => Console.WriteLine(ifadeler[(int)talep]);
    internal static void Yazdir(string mesaj)
    {
        Console.WriteLine();
        Console.WriteLine(mesaj);
        Console.WriteLine(ifadeler[(int)Baslik.Cizgi]);
    }

    internal static void Bekle(string mesaj, int sure = 5000)
    {
        Console.WriteLine(mesaj);
        System.Threading.Thread.Sleep(sure);
    }

    internal static bool DevamEt()
    {
        SecimYap:
        Console.WriteLine("Tekrar işlem yapmak ister misiniz? E: Evet / H: Hayır");
        switch (Console.ReadLine().ToLower())
        {
            case "e":
                return true;
            case "h": 
                Bekle("Oturum sonlandırılıyor ...", 2000);
                return false;
            default: 
                Yazdir(Baslik.Gecersiz);
                goto SecimYap;
        }
    }
}