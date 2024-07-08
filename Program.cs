using System;

public class Persoana
{
    private string id;
    private string name;

    public Persoana(string Id, string Name)
    {
        id = Id;
        name = Name;
    }
    public string GetId()
    {
        return id;
    }
    public string GetName()
    {
        return name;
    }

    public class ContBancar
    {
        private DateTime dataCrearii;
        private Persoana proprietar;
        private string numarCont;
        private string moneda;
        private string pin;
        private Stack<double> tranzactii;

        public ContBancar(DateTime DataCrearii, Persoana Proprietar, string NumarCont, string Moneda, string Pin)
        {
            dataCrearii = DataCrearii;
            proprietar = Proprietar;
            numarCont = NumarCont;
            moneda = Moneda;
            pin = Pin;
            tranzactii = new Stack<double>();
        }

        public double DetermineSold()
        {
            double sold = 0;
            foreach (double tranzactie in tranzactii)
            {
                sold += tranzactie;
            }
            return sold;
        }

        public void AlimentareCont(double suma)
        {
            tranzactii.Push(suma);
        }

        public void ExtrageFond(double suma)
        {
            tranzactii.Push(-suma);
        }

        public void AfisareDetalii()
        {
            Console.WriteLine($"Numar Cont: {numarCont}, Proprietar: {proprietar.GetName()}, Sold Curent: {DetermineSold()} {moneda}");
        }

        public class Program
        {
            public static void Main(string[] args)
            {
                Persoana persoana1 = new Persoana("123456789", "Ion Popescu");

                ContBancar contBancar = new ContBancar(DateTime.Now, persoana1, "RO123456789", "MDL", "1234");

                contBancar.AlimentareCont(1000);
                contBancar.AlimentareCont(500);
                contBancar.ExtrageFond(200);

                contBancar.AfisareDetalii();
            }
        }
    }
}