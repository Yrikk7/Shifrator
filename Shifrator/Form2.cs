using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shifrator
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            this.Close();           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = DataStore.ychot.Last();
            int fer = DataStore.Diffi_HelmanList.Count;
            for (int i = 0; i < fer; i++)
            {
                if (DataStore.Diffi_HelmanList[i].login == label2.Text)
                {
                    richTextBox2.Text = DataStore.Diffi_HelmanList[i].message;
                    textBox5.Text = Convert.ToString(DataStore.Diffi_HelmanList[i].black_key);
                    textBox4.Text = Convert.ToString(DataStore.Diffi_HelmanList[i].public_key);
                    textBox6.Text = Convert.ToString(DataStore.Diffi_HelmanList[i].shared_key);
                    textBox7.Text = Convert.ToString(DataStore.Diffi_HelmanList[i].from_whom);                    
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int fer = DataStore.Diffi_HelmanList.Count;
            Diffi_Helman new_people = null;
            Diffi_Helman new_people2 = null;
            for (int i = 0; i < fer; i++)
            {
                if (DataStore.Diffi_HelmanList[i].login == label2.Text)
                {
                    new_people = DataStore.Diffi_HelmanList[i];
                }
                else if (DataStore.Diffi_HelmanList[i].login == textBox1.Text) {
                    new_people2 = DataStore.Diffi_HelmanList[i];
                }
            }            
            if(radioButton1.Checked == true)
            {
                new_people.Get_Random_keys();               
            }
            else
            {
                new_people.Get_keys(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));               
            }
            new_people2.Get_Random_keys();
            new_people.Shared_black_key(new_people2, richTextBox1.Text);
            new_people.message = new_people.Encrypt_Message();
            richTextBox1.Text = new_people.message;
            textBox5.Text = Convert.ToString(new_people.black_key);
            textBox4.Text = Convert.ToString(new_people.public_key);
            textBox6.Text = Convert.ToString(new_people.shared_key);            
            new_people2.message = new_people2.Encrypt_Message();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string Encrypt_Message_mini(int sh_key, string message_0)
            {
                string encryptedMessage = "";  
                string keyString = sh_key.ToString();  

                int keyLength = keyString.Length;
                int keyIndex = 0;                
                foreach (char c in message_0)
                {                    
                    int shift = keyString[keyIndex % keyLength] - '0';  
                    char encryptedChar = (char)(c + shift);
                    encryptedMessage += encryptedChar;                    
                    keyIndex++;
                }
                return encryptedMessage;  // функція для шифрування тексту

            }
            int fer = DataStore.Diffi_HelmanList.Count;
            Diffi_Helman new_people = null;            
            for (int i = 0; i < fer; i++)
            {
                if (DataStore.Diffi_HelmanList[i].login == "Shared")
                {
                    new_people = DataStore.Diffi_HelmanList[i];
                }                
            }
            richTextBox3.Text = Encrypt_Message_mini(Convert.ToInt32(new_people.password), richTextBox3.Text);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                File.WriteAllText(filePath, richTextBox3.Text);// для збереження зашифрованого
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileContent = File.ReadAllText(filePath);
                richTextBox3.Text = fileContent;  // для показу файла в TextBox
            }
            button2.Enabled = true;
            button5.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int fer = DataStore.Diffi_HelmanList.Count;
            for (int i = 0; i < fer; i++)
            {
                if (DataStore.Diffi_HelmanList[i].login == label2.Text)
                {
                    richTextBox2.Text =  DataStore.Diffi_HelmanList[i].Decrypt_Message();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Decrypt_Message_mini(int sh_key, string message_0)
            {
                string decryptedMessage = "";  
                string keyString = sh_key.ToString(); 
                int keyLength = keyString.Length;
                int keyIndex = 0;
                
                foreach (char c in message_0)
                {                    
                    int shift = keyString[keyIndex % keyLength] - '0';  
                    char decryptedChar = (char)(c - shift);
                    decryptedMessage += decryptedChar;                    
                    keyIndex++;
                }

                return decryptedMessage;  // функція для розшифрування тексту

            }
            int fer = DataStore.Diffi_HelmanList.Count;
            Diffi_Helman new_people = null;
            for (int i = 0; i < fer; i++)
            {
                if (DataStore.Diffi_HelmanList[i].login == "Shared")
                {
                    new_people = DataStore.Diffi_HelmanList[i];
                }
            }
            richTextBox3.Text = Decrypt_Message_mini(Convert.ToInt32(new_people.password), richTextBox3.Text);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                File.WriteAllText(filePath, richTextBox3.Text);// для збереження розшифрованого
            }
        }
    }
}
