using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shifrator
{
    public class Diffi_Helman
    {
        public string login;
        public string password;
        public int public_key;
        public int black_key;
        public int transport_key;
        public int shared_key;
        public string from_whom = "nobody";
        public string message = "Empty";

        public Diffi_Helman(string log, string pass)
        {
            this.login = log;
            this.password = pass;                       
        }
        static int GetRandomPrime()
        {
            Random rand = new Random();
            int number;            
            do
            {
                number = rand.Next(1000, 10000); 
            } while (!IsPrime(number)); 

            return number;
        }
        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true; 
            if (number % 2 == 0) return false; 

            
            for (int i = 3; i * i <= number; i += 2)
            {
                if (number % i == 0) return false; 
            }

            return true; 
        }
        public void Get_keys(int ss, int sd)
        {
            this.public_key = ss;
            this.black_key = sd;
        }
        public void Get_Random_keys()
        {
            this.public_key = GetRandomPrime();
            this.black_key = GetRandomPrime();
            // Убедитесь, что public_key и black_key разные
            while (this.black_key == this.public_key)
            {
                this.black_key = GetRandomPrime();
            }
        }
        public void Shared_black_key(Diffi_Helman f, string des)
        {            
            int powerResult1 = (int)Math.Pow(this.public_key, this.black_key);
            this.transport_key = powerResult1 % f.public_key;
            int powerResult2 = (int)Math.Pow(this.public_key, f.black_key);
            f.transport_key = powerResult2 % f.public_key;
            
            int powerResult1_5 = (int)Math.Pow(f.transport_key, this.black_key);
            this.shared_key = powerResult1_5 % f.public_key;

            int powerResult2_5 = (int)Math.Pow(this.shared_key, this.black_key);
            f.shared_key = powerResult2_5 % f.public_key;
            f.from_whom = this.login + " в " + Convert.ToString(DateTime.Now);
            this.message = des;
            f.message = des;            
        }
        public string Encrypt_Message()
        {
            string encryptedMessage = "";
            string keyString = this.shared_key.ToString();
            int keyLength = keyString.Length;
            int keyIndex = 0;
            int xorKey = shared_key % 256; // Используем остаток от деления shared_key на 256 для XOR-ключа

            foreach (char c in this.message)
            {
                int shift = keyString[keyIndex % keyLength] - '0';  // Циклический сдвиг
                char shiftedChar = (char)(c + shift); // Первичный сдвиг
                char encryptedChar = (char)(shiftedChar ^ xorKey); // XOR с дополнительным ключом
                encryptedMessage += encryptedChar;
                keyIndex++;
            }

            return encryptedMessage;
        }
        public string Decrypt_Message()
        {
            string decryptedMessage = "";
            string keyString = this.shared_key.ToString();
            int keyLength = keyString.Length;
            int keyIndex = 0;
            int xorKey = shared_key % 256; // Тот же XOR-ключ, что и в шифровании

            foreach (char c in this.message)
            {
                char xorChar = (char)(c ^ xorKey); // Сначала отменяем XOR
                int shift = keyString[keyIndex % keyLength] - '0';  // Циклический сдвиг
                char decryptedChar = (char)(xorChar - shift); // Отмена сдвига
                decryptedMessage += decryptedChar;
                keyIndex++;
            }

            return decryptedMessage;
        }

    }   

}
