using System;

namespace Lab3
{

    class Document
    {
        protected string document;

        public Document()
        {
            document = "Default document";
            Console.WriteLine("Document constructor");
        }

        ~Document()
        {
            Console.WriteLine("Document destructor");
        }

        public void Show()
        {
            Console.WriteLine($"Document: {document}");
        }

    }

    class Nakladna : Document
    {
        private readonly double price;
        public Nakladna()
        {
            price = 5000;
            document = "Nakladna";
            Console.WriteLine("Nakladna constructor");
        }
        public new void Show()
        {
            Console.WriteLine($"Document: {document}\nPrice: {price}");
        }
        ~Nakladna()
        {
            Console.WriteLine("Nakladna destructor");
        }


    }

    class Ticket : Document
    {
        private readonly double price;
        public Ticket()
        {
            price = 250;
            document = "Ticket";
            Console.WriteLine("Ticket destructor");
        }
        public new void Show()
        {
            Console.WriteLine($"Document: {document}\nPrice: {price}");
        }

        ~Ticket()
        {
            Console.WriteLine("Ticket destructor");
        }
    }

    class Rahunok : Document
    {
        private readonly double price;
        public Rahunok()
        {
            price = 6000;
            document = "Rahunok";
            Console.WriteLine("Rahunok constructor");
        }
        public new void Show()
        {
            Console.WriteLine($"Document: {document}\nPrice: {price}");
        }

        ~Rahunok()
        {
            Console.WriteLine("Rahunok destructor");
        }
    }


    abstract class Programne_Zabezpechennya
    {
        protected DateTime useFrom;
        public abstract void Show();
        public abstract bool canUse(DateTime at);
    }

    class Vilne : Programne_Zabezpechennya
    {
        public Vilne()
        {
            useFrom = new DateTime(2020, 01, 01);
        }

        public override bool canUse(DateTime at)
        {
            if (at > useFrom) return true;
            return false;
        }

        public override void Show()
        {
            Console.WriteLine($"Vilne, can use from: {useFrom}");
        }
    }

    class Umovno_bezkoshtovne : Programne_Zabezpechennya
    {

        public Umovno_bezkoshtovne()
        {
            useFrom = new DateTime(2022, 01, 01);
        }
        public override bool canUse(DateTime at)
        {
            if (at > useFrom) return true;
            return false;
        }
        public override void Show()
        {
            Console.WriteLine($"Umovno-bezkoshtovne, can use from: {useFrom}");
        }
    }

    class Comerciyne : Programne_Zabezpechennya
    {
        public Comerciyne()
        {
            useFrom = new DateTime(2023, 01, 01);
        }
        public override bool canUse(DateTime at)
        {
            if (at > useFrom) return true;
            return false;
        }
        public override void Show()
        {
            Console.WriteLine($"Comerciyne, can use from: {useFrom}");
        }
   }

    static class Program
    {
        static void Main()
        {
            var document = new Document();
            document.Show();
            var ticket = new Ticket();
            ticket.Show();
            var rahunok = new Rahunok();
            rahunok.Show();
            var nakladna = new Nakladna();
            nakladna.Show();

            Programne_Zabezpechennya[] pz = new Programne_Zabezpechennya[3];
            pz[0] = new Vilne();
            pz[1] = new Umovno_bezkoshtovne();
            pz[2] = new Comerciyne();
            Console.WriteLine();
            Console.WriteLine("All pzs: ");
            for (int i = 0; i < 3; i++)
            {
               pz[i].Show();
            }
            Console.WriteLine();
            Console.WriteLine($"What we can use at: {DateTime.Today}");
            for(int i = 0; i < 3; i++)
            {
                if (pz[i].canUse(DateTime.Today)) pz[i].Show();
            }

        }
    }


}



