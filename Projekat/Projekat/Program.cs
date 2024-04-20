

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


StudentBudzet Luka = new StudentBudzet("Menza", "12/03/2025", 1, true, "Luka", "Milic", "IT19/23", 1, 87, 153);
StudentSF Nikola = new StudentSF("Menza", "01/11/2024", 2, false, "Nikola", "Peric", "ET115/22", 2, 80000, 5);
Ucenik Lana = new Ucenik("Menza", "30/05/2025", 3, true, "Lana", "Lazic", 2, "Medicinska sestra");



Luka.Ispis();
Nikola.Ispis();
Lana.Ispis();

Luka.UplatiNovac(2000);
Nikola.UplatiNovac(1000);
Luka.PodaciKartice();
Nikola.PodaciKartice();
Lana.PodaciKartice();

Luka.Kupi("Rucak", 5);
Nikola.Kupi("Dorucak", 2);
Lana.Kupi("Vecera", 2);
Luka.PodaciKartice();
Nikola.PodaciKartice();
Lana.PodaciKartice();

Luka.Potrosi("Rucak");
Nikola.Potrosi("Dorucak");
Lana.Potrosi("Dorucak");
Luka.PodaciKartice();
Nikola.PodaciKartice();
Lana.PodaciKartice();




public abstract class Kartica 
{
    protected int ID { get; set; }
    protected string Ustanova { get; set; }
    protected string VaziDo { get; set; }
    public Kartica(string u, string vd, int id)
    {
        Ustanova = u;
        VaziDo = vd;
        ID = id;
        
    }
}

interface Transakcije 
{
    void Kupi(string Obrok, int Kolicina);
    void Potrosi(string Obrok);
    void UplatiNovac(int Kolicina);
    
    int Stanje { get; set; }

}

public class KarticaMenza : Kartica, Transakcije
{
    public int Dorucak { get; set; }
    public int Rucak{ get; set; }
    public int Vecera { get; set; }
    public bool Budzet { get; set; }
    public int Stanje { get; set; }
    
    public KarticaMenza(string u, string vd, int id, bool budzet) : base(u, vd, id)
    {
        Dorucak = 0;
        Rucak = 0;
        Vecera = 0;
        Stanje = 0;
        Budzet = budzet;
    }

    public void Kupi(string Obrok, int Kolicina) 
    {
        if (Budzet==true)
        {
            if (Obrok=="Dorucak")
            {
                if (Stanje>Kolicina*56)
                {
                    Dorucak += Kolicina;
                    Stanje -= Kolicina * 56;
                    Console.WriteLine($"Kupili ste {Kolicina} Dorucka");
                }
                else
                {
                    Console.WriteLine("Nema dovoljno novca na kartici");
                }
            }
            else if (Obrok=="Rucak")
            {
                if (Stanje > Kolicina * 120)
                {
                    Rucak += Kolicina;
                    Stanje -= Kolicina * 120;
                    Console.WriteLine($"Kupili ste {Kolicina} Rucka");
                }
                else
                {
                    Console.WriteLine("Nema dovoljno novca na kartici");
                }
            }
            else if (Obrok=="Vecera")
            {
                if (Stanje > Kolicina * 100)
                {
                    Vecera += Kolicina;
                    Stanje -= Kolicina * 100;
                    Console.WriteLine($"Kupili ste {Kolicina} vecere");
                }
                else
                {
                    Console.WriteLine("Nema dovoljno novca na kartici");
                }
            }
            else
            {
                Console.WriteLine("Odaberite obrok: Dorucak, Rucak ili Vecera");
            }

        }
        else
        {
            if (Obrok == "Dorucak")
            {
                if (Stanje > Kolicina * 120)
                {
                    Dorucak += Kolicina;
                    Stanje -= Kolicina * 120;
                    Console.WriteLine($"Kupili ste {Kolicina} dorucka");
                }
                else
                {
                    Console.WriteLine("Nema dovoljno novca na kartici");
                }
            }
            else if (Obrok == "Rucka")
            {
                if (Stanje > Kolicina * 300)
                {
                    Rucak += Kolicina;
                    Stanje -= Kolicina * 300;
                    Console.WriteLine($"Kupili ste {Kolicina} rucka");
                }
                else
                {
                    Console.WriteLine("Nema dovoljno novca na kartici");
                }
            }
            else if (Obrok == "Vecera")
            {
                if (Stanje > Kolicina * 220)
                {
                    Vecera += Kolicina;
                    Stanje -= Kolicina * 220;
                    Console.WriteLine($"Kupili ste {Kolicina} vecere");
                }
                else
                {
                    Console.WriteLine("Nema dovoljno novca na kartici");
                }
            }
            else
            {
                Console.WriteLine("Odaberite obrok: Dorucak, Rucak ili Vecera");
            }
        }
    }

    public void Potrosi(string Obrok)
    {
        if (Obrok=="Dorucak")
        {
            if (Dorucak > 0)
            {
                Dorucak--;
                Console.WriteLine($"Potrosli ste jedan dorucak.");
            }
            else { Console.WriteLine("Nemate ni jedan kupljen Dorucak"); }
        }
        else if (Obrok == "Rucak")
        {
            if (Rucak > 0)
            {
                Rucak--;
                Console.WriteLine($"Potrosli ste jedan rucak.");
            }
            else { Console.WriteLine("Nemate ni jedan kupljen Rucak"); }
        }
        else if (Obrok == "Vecera")
        {
            if (Vecera > 0)
            {
                Vecera--;
                Console.WriteLine($"Potrosli ste jedan vecere.");
            }
            else { Console.WriteLine("Nemate ni jednu kupljenu Veceru"); }
        }
        else { Console.WriteLine("Odaberite obrok: Dorucak, Rucak ili Vecera"); }
    }

    public void UplatiNovac(int KOlicina) 
    {
        Stanje += KOlicina;
    }

    public void PodaciKartice()
    {
        Console.WriteLine($"ID: {ID}   Ustanova: {Ustanova}   Vazi do: {VaziDo}");
        Console.WriteLine($"Stanje:{Stanje}din \nDorucak:{Dorucak} \nRucak:{Rucak} \nVecera:{Vecera}");
    }
}

interface Student
{
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public string Index { get; set; }
    public int Godina { get; set; }

    public void Ispis();

}

public class StudentBudzet : KarticaMenza, Student
{
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public string Index { get; set; }
    public int Godina { get; set; }
    public int BrojBodova { get; set; }
    public int MestoNaListi { get; set; }

   

    public StudentBudzet(string u, string vd, int id, bool budzet, string ime, string prezime, string index, int godina, int brojbodova, int mestonalisti) : base(u, vd, id, budzet)
    {
        Ime=ime;
        Prezime=prezime;
        Index=index;
        Godina=godina;
        BrojBodova=brojbodova;
        MestoNaListi = mestonalisti;
    }
    public void Ispis()
    {
        Console.WriteLine($"Ime:{Ime}   Prezime:{Prezime}   Index:{Index}   Broj bodova:{BrojBodova}   Mesto na listi:{MestoNaListi}   ID kartice:{ID}");

    }
}

public class StudentSF : KarticaMenza, Student
{
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public string Index { get; set; }
    public int Godina { get; set; }
    public int CenaSkolarine { get; set; }
    
    public int PlaceneRate { get; set; }

    public StudentSF(string u, string vd, int id, bool budzet, string ime, string prezime, string index, int godina, int cena, int rate) : base(u, vd, id, budzet)
    {
        Ime = ime;
        Prezime = prezime;
        Index = index;
        Godina = godina;
        CenaSkolarine = cena;
        PlaceneRate = rate;
    }
    public void Ispis()
    {
        Console.WriteLine($"Ime:{Ime}   Prezime:{Prezime}   Index:{Index}   Cena skolarine:{CenaSkolarine}   Placenih rata:{PlaceneRate}/12   ID kartice:{ID}" );

    }
}

public class Ucenik : KarticaMenza
{

    public string Ime { get; set; }
    public string Prezime { get; set; }
    public int Razred { get; set; }
    public string Smer { get; set; }
    public Ucenik(string u, string vd, int id, bool budzet, string ime, string prezime, int razred, string smer) : base(u, vd, id, budzet)
    {
        Ime= ime;
        Prezime= prezime;
        Razred = razred;
        Smer = smer;
    }
    public void Ispis()
    {
        Console.WriteLine($"Ime:{Ime}   Prezime:{Prezime}   Razred:{Razred}   Smer:{Smer}   ID kartice:{ID}");

    }
}