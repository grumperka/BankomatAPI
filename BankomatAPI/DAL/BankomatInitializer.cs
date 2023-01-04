using BibliotekaKlas.Classes;
using BankomatAPI.DAL;
using System.Data.Entity;
using BibliotekaKlas.Classes;

namespace BankomatAPI.DAL
{
    public class BankomatInitializer
    {
        private readonly BankomatContext context;

        public BankomatInitializer(BankomatContext context) { 
            this.context = context;
        }

        public void Initialize()
        {
            this.context.Database.EnsureDeleted();
            this.context.Database.EnsureCreated();

            List<Banknot> banknots = new List<Banknot>(); 

            if (!this.context.Banknots.Any()) {

                    for (int i = 0; i < 5; i++) {
                        banknots.Add(new Banknot(10));
                        banknots.Add(new Banknot(20));
                        banknots.Add(new Banknot(50));
                        banknots.Add(new Banknot(100));
                        banknots.Add(new Banknot(200));
                        banknots.Add(new Banknot(500));
                    }

                banknots.ForEach(b => this.context.Banknots.Add(b));
                this.context.SaveChanges();
            }

            ///////////////////////////
            List<Moneta> monetas = new List<Moneta>();

            if (!this.context.Monetas.Any()) {

                for (int i = 0; i < 5; i++)
                {
                    monetas.Add(new Moneta(0.01));
                    monetas.Add(new Moneta(0.02));
                    monetas.Add(new Moneta(0.05));
                    monetas.Add(new Moneta(0.1));
                    monetas.Add(new Moneta(0.2));
                    monetas.Add(new Moneta(0.5));
                    monetas.Add(new Moneta(1));
                    monetas.Add(new Moneta(2));
                    monetas.Add(new Moneta(5));
                    monetas.Add(new Moneta(5));

                    monetas.Add(new Moneta(5));
                    monetas.Add(new Moneta(5));
                    monetas.Add(new Moneta(2));
                    monetas.Add(new Moneta(1));
                    monetas.Add(new Moneta(0.5));
                    monetas.Add(new Moneta(0.2));
                    monetas.Add(new Moneta(0.1));
                    monetas.Add(new Moneta(0.05));
                    monetas.Add(new Moneta(0.02));
                    monetas.Add(new Moneta(0.01));
                }

                monetas.ForEach(m => this.context.Monetas.Add(m));
                this.context.SaveChanges();
            }
            
            ////////////////////////////

            List<Wlasciciel> wlasciciel = new List<Wlasciciel>();

            if (!this.context.Wlasciciels.Any())
            {
                var names = new string[]{ "Anna", "Ewa", "Oliwia", "Kazimiera", "Genowefa",
                                            "Tomasz", "Andrzej", "Igor", "Janusz", "Olaf"};

                var surnames = new string[] { "Johnson", "McCormick", "Evans", "Liroy", "Fork", "Walles", "Lorenz", "Bregovic", "Fritz", "Cartman" };

                for (int i = 0; i < 10; i++)
                {
                    wlasciciel.Add(new Wlasciciel { Name = names[i], Surname = surnames[i]});
                }

                wlasciciel.ForEach(w => this.context.Wlasciciels.Add(w));
                this.context.SaveChanges();
            }


            List<Konto> kontos = new List<Konto>();

            if (!this.context.Kontos.Any()) 
            {
                for (int i = 0; i < wlasciciel.Count; i++) {
                    kontos.Add(new Konto { Balance = (i+1) * 1500, Owner = wlasciciel.ElementAt(i) });
                }

                kontos.ForEach(k => this.context.Kontos.Add(k));
                this.context.SaveChanges();

            }


            List<KartaKredytowa> kartaKredytowas = new List<KartaKredytowa>();

            var pins = new int[] { 1234, 4321, 2134, 1243, 4312, 5678, 8765, 8756, 6578, 8567 };
            List<string> new_pins = new List<string>();

            foreach (int pin in pins) {
                var encryptedString = AesOperation.EncryptString(this.context.Key, pin.ToString());
                new_pins.Add(encryptedString);
            }

            if (!this.context.KartaKredytowas.Any())
            {
                for (int i = 0; i < wlasciciel.Count; i++) {
                    kartaKredytowas.Add(new KartaKredytowa { PIN = new_pins.ElementAt(i), Account = kontos[i] });
                }

                kartaKredytowas.ForEach(k => this.context.KartaKredytowas.Add(k));
                this.context.SaveChanges();
            }

            List<Portfel> portfels = new List<Portfel>();

            if (!this.context.Portfels.Any())
            {
                for (int i = 0; i < wlasciciel.Count; i++)
                {
                    List<Banknot> banknoty = new List<Banknot>();
                    banknoty.Add(banknots.ElementAt(i));
                    banknoty.Add(banknots.ElementAt(i+10));
                    banknoty.Add(banknots.ElementAt(i+20));

                    List<Moneta> monety = new List<Moneta>();
                    monety.Add(monetas.ElementAt(i));
                    monety.Add(monetas.ElementAt(i + 10));
                    monety.Add(monetas.ElementAt(i + 20));
                    monety.Add(monetas.ElementAt(i + 30));
                    monety.Add(monetas.ElementAt(i + 40));
                    monety.Add(monetas.ElementAt(i + 50));
                    monety.Add(monetas.ElementAt(i + 60));
                    monety.Add(monetas.ElementAt(i + 70));
                    monety.Add(monetas.ElementAt(i + 80));
                    monety.Add(monetas.ElementAt(i + 90));

                    portfels.Add(new Portfel { Sum = banknoty.Sum(s => s.Value) + monety.Sum(s => s.Value), Owner = wlasciciel.ElementAt(i), BanknotsList = banknoty, MonetasList = monety }); 
                }

                portfels.ForEach(p => this.context.Portfels.Add(p));
                this.context.SaveChanges();
            }


            List<Bankomat> bankomats = new List<Bankomat>();

            if (!context.Bankomats.Any()) {

                for (int i = 0; i < 5; i++) {

                    List<Banknot> banknotsBankomatowe = new List<Banknot>();

                    for (int j = 0; j < 5; j++)
                    {
                        banknotsBankomatowe.Add(new Banknot(10));
                        banknotsBankomatowe.Add(new Banknot(20));
                        banknotsBankomatowe.Add(new Banknot(50));
                        banknotsBankomatowe.Add(new Banknot(100));
                        banknotsBankomatowe.Add(new Banknot(200));
                        banknotsBankomatowe.Add(new Banknot(500));
                    }

                    banknotsBankomatowe.ForEach(b => this.context.Banknots.Add(b));
                    this.context.SaveChanges();

                    bankomats.Add(new Bankomat { Name = "Bankomat nr. " + (i + 1).ToString(), BanknotsList = banknotsBankomatowe });
                    
                }

                bankomats.ForEach(b => this.context.Bankomats.Add(b));
                this.context.SaveChanges();

            }


        }
       }
}

