using System;

namespace ATM;

sealed class ATM
{
    decimal para; // ATM içerisindeki para
    internal Kullanici kullanici; // ATM üzerinde işlem yapan kullanıcı

    internal ATM()
    {
        para = 120000;
    }

    internal void IslemBasla()
    {
        KullaniciBilgiGoruntule();

        switch (kullanici.talep)
        {
            case KullaniciIslem.ParaCek:
                ParaVer();
                break;
            case KullaniciIslem.ParaYatir:
                ParaAl();
                break;
            case KullaniciIslem.OdemeYap:
                OdemeYap();
                break;
            case KullaniciIslem.GecmisiGoruntule:
                GecmisiGoruntule();
                break;
        }

        KullaniciBilgiGoruntule();
    }

    decimal MiktarBelirle()
    {
    Baslangic:
        Console.Write("Miktar: ");
        bool sonuc = SayiKontrol.Cevir(Console.ReadLine(), out decimal miktar);

        switch (sonuc)
        {
            case true: return kullanici.IslemPara = miktar;
            case false: goto Baslangic;
        }
    }

    void ParaVer()
    {
        Sistem.Yazdir("Çekmek istediğiniz miktarı giriniz!");
        kullanici.IslemPara = MiktarBelirle();
        decimal hesaptaKalan = kullanici.Para - kullanici.IslemPara;

        if (hesaptaKalan < 0)
            Console.WriteLine("Bu işlemi yapmak için hesabınızda yeteri kadar para yok!");
        else
        {
            Sistem.Bekle("Paranız hazırlanıyor ...");
            kullanici.Para = hesaptaKalan; // çekilen para kullanıcının hesabından düşülüyor
            para -= kullanici.IslemPara; //çekilen para ATM'deki paradan düşülüyor
            Sistem.Yazdir("Para çekme işleminiz tamamlandı!");

            Logger.DosyaYaz(kullanici.IslemPara + " TL çekildi");
        }
    }

    void ParaAl()
    {
        Sistem.Yazdir("Yatırmak istediğiniz parayı hazneye yerleştirip bekleyin!");
        // kullanici.ParaMiktar += gelenPara;
        Sistem.Bekle("Paranız yatırılıyor ...");
        Sistem.Yazdir("Paranız hesaba yatırıldı!");
        Logger.DosyaYaz(kullanici.IslemPara + " TL yatırıldı");
    }

    void OdemeYap()
    {
        KullaniciBilgiGoruntule();
        Sistem.Yazdir("Ödemek istediğiniz borç miktarını giriniz!");
        kullanici.IslemPara = MiktarBelirle();
        decimal hesaptaKalan = kullanici.Para - kullanici.IslemPara;

        if (hesaptaKalan < 0)
            Console.WriteLine("Bu işlemi yapmak için hesabınızda yeteri kadar para yok!");
        else
        {
            Sistem.Bekle("Borcunuz ödeniyor ...");
            kullanici.BorcMiktar -= kullanici.IslemPara;
            kullanici.Para = hesaptaKalan;
            para += kullanici.IslemPara; // Borç ödendiğinde ATM'de bulunan para artıyor.
            Sistem.Yazdir("Borcunuz ödendi!");
            Logger.DosyaYaz(kullanici.IslemPara + " TL borç ödendi");
        }
    }

    void GecmisiGoruntule()
    {
        string veri = Logger.DosyaOku();
        
        if (!string.IsNullOrEmpty(veri))
            Console.WriteLine(veri);
        else
            Console.WriteLine("\nŞuan geçmiş kaydınız yok!\n");
    }

    void KullaniciBilgiGoruntule()
    {
        Console.WriteLine($"Kullanici Bilgileri \n{kullanici} \nHesaptaki Para: {kullanici.Para} TL \nToplam Borç: {kullanici.BorcMiktar} TL");
    }

    internal int TalepAl()
    {
    SecimYap:
        Sistem.Yazdir("Lütfen yapmak istediğiniz işlemi seçiniz! \n 1.Para Çek \n 2.Para Yatır \n 3.Ödeme Yap \n 4.Geçmişi Görüntüle");
        SayiKontrol.Cevir(Console.ReadLine(), out int secim);

        if (secim > 0 && secim < 5) return secim;
        else Sistem.Yazdir(Baslik.Gecersiz);

        goto SecimYap;
    }

    internal void IslemYap(Kullanici K)
    {
        kullanici = K;

        if (IslemOnay()) IslemBasla();
        else 
        {
            Console.WriteLine("Hatalı şifre girdiniz!");
            Logger.DosyaYaz("Hatalı şifre girildi!");
        }
    }

    bool IslemOnay()
    {
        kullanici.Sifre = SifreOlustur();

        kullanici.SifreOku();
        Sistem.Yazdir("Lütfen telefonunuza gönderilen kodu giriniz!");
        string girilen = Console.ReadLine();

        if (kullanici.Sifre == girilen) return true;
        else return false;
    }

    string SifreOlustur() => SayiKontrol.Uret(100000, 999999).ToString();

    internal Kullanici KullaniciKontrol(string tcKimlikNo, Kullanici[] dizi)
        => Array.Find(dizi, K => K.TCKimlikNo == tcKimlikNo);

    internal string KimlikNoAl()
    {
        bool durum;

    VeriAl:
        Sistem.Yazdir("TC Kimlik Numaranızı giriniz!");
        durum = SayiKontrol.Cevir(Console.ReadLine(), out long tc);
        switch (durum)
        {
            case true:
                switch (KimlikNoKontrol(tc))
                {
                    case true:
                        break;
                    case false:
                        Console.WriteLine("Eksik veri girdiniz!");
                        goto VeriAl;
                }
                break;
            case false:
                goto VeriAl;
        }

        return tc.ToString();
    }

    bool KimlikNoKontrol(long tcKimlikNo)
    {
        if (tcKimlikNo < 10000000000) return false;
        else return true;
    }
}