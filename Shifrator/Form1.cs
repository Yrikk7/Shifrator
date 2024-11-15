using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shifrator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            int fer = DataStore.Diffi_HelmanList.Count;
            for (int i = 0; i < fer; i++)
            {
                if (DataStore.Diffi_HelmanList[i].login == textBox1.Text && DataStore.Diffi_HelmanList[i].password == textBox2.Text)
                {
                    label5.Text = "Операція успішна";
                    DataStore.ychot.Add(textBox1.Text);                    
                    Form2 form2 = new Form2();          
                                       
                    form2.ShowDialog();                   
                }
                else
                {
                    label5.Text = "Неправильний логін або пароль";
                }
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataStore.Diffi_HelmanList.Add(new Diffi_Helman("Sec1", "Sec1032"));
            DataStore.Diffi_HelmanList.Add(new Diffi_Helman("Sec2", "Sec2056"));
            DataStore.Diffi_HelmanList.Add(new Diffi_Helman("Sec3", "Sec3065"));
            DataStore.Diffi_HelmanList.Add(new Diffi_Helman("Kadr1", "Kadr1206"));
            DataStore.Diffi_HelmanList.Add(new Diffi_Helman("Kadr2", "Kadr2309"));
            DataStore.Diffi_HelmanList.Add(new Diffi_Helman("Kadr3", "Kadr3209"));
            DataStore.Diffi_HelmanList.Add(new Diffi_Helman("Kadr4", "Kadr4107"));
            DataStore.Diffi_HelmanList.Add(new Diffi_Helman("Boss", "Bos256"));
            DataStore.Diffi_HelmanList.Add(new Diffi_Helman("Secret", "Secret1280"));
            DataStore.Diffi_HelmanList.Add(new Diffi_Helman("Marc_1", "Marc_1063"));
            DataStore.Diffi_HelmanList.Add(new Diffi_Helman("Marc_2", "Marc_2054"));
            DataStore.Diffi_HelmanList.Add(new Diffi_Helman("Marc_3", "Marc_3013"));
            DataStore.Diffi_HelmanList.Add(new Diffi_Helman("Buh_1", "Buh_1065"));
            DataStore.Diffi_HelmanList.Add(new Diffi_Helman("Buh_2", "Buh_2099"));
            DataStore.Diffi_HelmanList.Add(new Diffi_Helman("Buh_3", "Buh_3021"));
            DataStore.Diffi_HelmanList.Add(new Diffi_Helman("Buh_4", "Buh_4037"));
            DataStore.Diffi_HelmanList.Add(new Diffi_Helman("Buh2_1", "Buh2_1306"));
            DataStore.Diffi_HelmanList.Add(new Diffi_Helman("Buh2_2", "Buh2_2507"));
            DataStore.Diffi_HelmanList.Add(new Diffi_Helman("Ah1", "Ah1220"));
            DataStore.Diffi_HelmanList.Add(new Diffi_Helman("Shared", "6849"));            
        }
    }
}
