using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
namespace Posnet_Admin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                try
                {
                    string[] bancas = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Bancas.txt");
                    if (bancas.Length > 0)
                    {
                        string[] Numeros = new string[bancas.Length];
                        string[] Nombres = new string[bancas.Length];
                        for (int a = 0; a < bancas.Length; a++)
                        {
                            Numeros[a] = Regex.Split(bancas[a], ",")[0];
                            Nombres[a] = Regex.Split(bancas[a], ",")[1];
                            listBox1.Items.Add(Numeros[a]+" - "+Nombres[a]);
                        }
                        label13.Text = "Bancas(" + listBox1.Items.Count + ")";
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void numericUpDown1_MouseClick(object sender, MouseEventArgs e)
        {
            numericUpDown1.Select(0, numericUpDown1.Value.ToString().Length);
        }

        private void numericUpDown1_Enter(object sender, EventArgs e)
        {
            numericUpDown1.Select(0, numericUpDown1.Value.ToString().Length);
        }

       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox1.Text = "Habilitado";
            }
            else
            {
                checkBox1.Text = "Desabilitado";
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox2.Text = "Habilitado";
            }
            else
            {
                checkBox2.Text = "Desabilitado";
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                try
                {
                    string[] bancas = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Bancas.txt");
                    if (bancas.Length > 0)
                    {

                        string[] Nombres = new string[bancas.Length];
                        for (int a = 0; a < bancas.Length; a++)
                        {

                            Nombres[a] = Regex.Split(bancas[a], ",")[1];
                        }
                        comboBox1.Focus();
                        checkBox1.Checked = true;
                        checkBox2.Checked = true;
                        comboBox1.Enabled = true;
                        numericUpDown1.Enabled = true;
                        comboBox2.Enabled = true;
                        comboBox1.Items.Clear();
                        for (int i = 0; i < bancas.Length; i++)
                        {
                            comboBox1.Items.Add(Nombres[i]);
                        }
                        comboBox1.SelectedIndex = 0;
                        comboBox2.SelectedIndex = 0;
                    }

                }
                catch (Exception)
                {
                    comboBox1.Items.Add("--NO HAY BANCAS--");
                    comboBox1.SelectedIndex = 0;
                    comboBox1.Enabled = false;
                    numericUpDown1.Enabled = false;
                    comboBox2.Enabled = false;
                }
            }

            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox2.Items.Add("P:" + listBox1.SelectedIndex);
            listBox3.Items.Clear();
            label18.Text = "";
            try
            {
                string[] NUMEROS = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Bancas.txt");
                if (NUMEROS.Length > 0)
                {
                    string[] TRANSFERMEDIA = new string[1];
                    
                    TRANSFERMEDIA[0] = Regex.Split(NUMEROS[listBox1.SelectedIndex], ",")[2];
                    string mincorte = Regex.Split(NUMEROS[listBox1.SelectedIndex], ",")[3];
                    string[] numbers = new string[Regex.Split(TRANSFERMEDIA[0],"&").Length];
                    for (int j = 0; j < numbers.Length; j++)
                    {
                        numbers[j] = Regex.Split(TRANSFERMEDIA[0], "&")[j];
                        listBox3.Items.Add(numbers[j]);
                    }
                    label18.Text = "Corta " + mincorte + " minutos antes.";
                }
                label14.Text = "Pasadores(" + listBox2.Items.Count + ")";
            }
            catch (Exception)
            {

            }
        }

      
      
    }
}
