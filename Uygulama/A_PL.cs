using System;

namespace ATM;

sealed class PL // Presentation Layer - Sunum Katmanı
{
    BL bl;
    ATM atm;

    internal PL()
    {
        bl = new();
        atm = new();
    }

    internal void KullaniciKarsila()
    {
        OrnekVeriGoster();
        KullaniciIslem talep = (KullaniciIslem)atm.TalepAl();
        bl.IslemYap(talep);
    }

    void OrnekVeriGoster()
    {
        Sistem.Yazdir("Sistemde kayıtlı kullanıcı bilgileri");
        Array.ForEach(bl.VeriGonder(), K => K.BilgileriGoster());
    }
}