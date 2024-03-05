using FakeData;

namespace ATM;

abstract class Kullanici_base
{
    internal string TCKimlikNo { get; private set; }
    internal string Ad { get; private set; }
    internal string Soyad { get; private set; }
    internal string Sifre { get; set; }
    internal string TelefonNo { get; private set; }
    internal string EmailAdres { get; private set; }
    internal decimal Para { get; set; }
    internal decimal BorcMiktar { get; set; }
    internal KullaniciIslem talep { get; set; }
    internal decimal IslemPara { get; set; } // Kullanıcının işlem yaptığı miktar - Para çekme, yatırma vs.

    internal Kullanici_base()
    {
        TCKimlikNo = SayiKontrol.Uret(10000000000, 99999999999).ToString();
        Ad = NameData.GetFirstName();
        Soyad = NameData.GetSurname();
        Para = SayiKontrol.Uret(1000, 30000);
        BorcMiktar = SayiKontrol.Uret(1000, 10000);
    }

    public override string ToString()
    {
        return $"Adı Soyadı: {Ad} {Soyad}";
    }
}