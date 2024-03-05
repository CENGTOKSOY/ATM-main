using System;

namespace ATM;

sealed class BL // Business Layer - İş Katmanı
{
    DAL dal;
    ATM atm;

    internal BL()
    {
        dal = new();
        atm = new();
    }

    internal Kullanici[] VeriGonder() => dal.Kullanicilar;

    string VeriAl() => atm.KimlikNoAl();

    Kullanici VeriKontrol(string tc) => atm.KullaniciKontrol(tc.ToString(), dal.Kullanicilar);

    internal void IslemYap(KullaniciIslem talep)
    {
        string tc = VeriAl();
        Kullanici K = VeriKontrol(tc);
        if (K != null)
        {
            K.talep = talep;
            atm.IslemYap(K);
        }
        else
            Console.WriteLine("Bu TC Kimlik Numarasına sahip biri bulunamadı!");
    }
}