using System;

namespace ATM;

sealed class Kullanici : Kullanici_base
{
    internal void SifreOku() => Console.WriteLine($"İşlem onayı için tek kullanımlık şifreniz: {Sifre}");

    internal void BilgileriGoster()
    {
        Console.WriteLine($"Kullanıcının, TC Kimlik No: {TCKimlikNo} - Adı: {Ad} - Soyadı: {Soyad}");
    }
}