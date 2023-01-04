using System.ComponentModel.DataAnnotations;

namespace BibliotekaKlas.Classes
{
    public class KartaKredytowa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PIN { get; set; }

        [Required]
        public int AccountId { get; set; }

        public virtual Konto Account { get; set; }

        public bool checkPIN(string pin,string key) {

            var decryptedString = AesOperation.DecryptString(key, this.PIN);

            if (decryptedString.Equals(pin))
            {
                return true;
            }
            else return false;
        }

        public bool requiredPIN(float value) {

            if (value >= 100)
            {
                return true;
            }
            else return false;

        }
    }
}
