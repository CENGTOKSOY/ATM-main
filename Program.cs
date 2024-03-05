using System;

namespace ATM;

class Program
{
    static void Main(string[] args)
    {
        PL pl = new PL();

        do
            pl.KullaniciKarsila(); 
        while (Sistem.DevamEt());
    }
}
