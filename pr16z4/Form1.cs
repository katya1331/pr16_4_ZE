using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace pr16z4
{
    public partial class Form1 : Form
    {
        class Country
        {
            public string Name { get; set; }
            public int Population  { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (File.Exists("1.txt"))
            {
                int chislenost = (int)numericUpDown1.Value;
                if (chislenost != 0)
                {
                    List<Country> countries = File.ReadAllLines("1.txt")
                    .Select(line => line.Split(' '))
                    .Select(parts => new Country { Name = parts[0], Population = Convert.ToInt32(parts[1]) }).ToList();
                foreach (var cc in countries)
                {
                    listBox1.Items.Add(cc.Name + " " + cc.Population);
                }
                listBox1.Items.Add("");
                listBox1.Items.Add($"Упорядоченный список стран, у которых численность больше {chislenost}:");
                
                    var SortCountry = countries.Where(x => x.Population > chislenost)
                        .OrderBy(x => x.Name.Length)
                        .ThenBy(x => x.Name)
                        .ToList();
                    foreach (var cc in SortCountry)
                    {
                        listBox1.Items.Add(cc.Name + " " + cc.Population);
                    }
                }
                else MessageBox.Show("ВВедите число,отичное от нуля");
            }
            else MessageBox.Show("File don't exist");
        }

    }
}
