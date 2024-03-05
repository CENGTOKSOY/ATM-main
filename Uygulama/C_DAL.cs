using System.Collections.Generic;

namespace ATM;

sealed class DAL // Data Access Layer - Veri Erişim Katmanı
{ 
    internal Kullanici[] Kullanicilar { get; private set; }

    internal DAL()
    {
        Kullanicilar = [new(), new(), new(), new(), new(), new(), new(), new(), new(), new()];
    }
}