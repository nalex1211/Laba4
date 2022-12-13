using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Laba4
{
    public partial class Form1 : Form
    {
        private List<Info> list = new List<Info>();
        private Helper helper = new Helper();
        private readonly string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"../../", "InfoJSON.json"));

        public Form1()
        {
            InitializeComponent();
            if (new FileInfo(path).Length == 0)
            {
                return;
            }

            list.AddRange(helper.getDataFromJson(path));
            gridView.DataSource = list;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ніколенко Олександр К-27. 2022\n" +
                "Варіант 17\n" +
                "\"Кадри Науковців(Пенсія)\"");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddInfo form = new AddInfo();

            if (form.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            list.Add(form.info);
            helper.writeDataToJSON(path, list);
            gridView.DataSource = new BindingList<Info>(list);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Будь-ласка виберіть опцію сортировки");
                return;
            }

            gridView.DataSource = helper.orderBy(comboBox1.Text, list);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви впевненні?", "Підтведження", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                list.Clear();
                helper.writeDataToJSON(path, list);
                gridView.DataSource = new BindingList<Info>(list);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            helper.writeDataToJSON(path, list);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var cell = gridView.SelectedCells[0].Value.ToString();
            list.RemoveAll(x => x.Name == cell);
            helper.writeDataToJSON(path, list);
            gridView.DataSource = new BindingList<Info>(list);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("Введіть шуканий об'єкт");
                return;
            }
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Виберіть категорію пошуку у таблиці нижче");
                return;
            }
            if (helper.searchBy(comboBox1.Text, txtSearch.Text, list).Count ==0)
            {
                MessageBox.Show("Не знайдено такого об'єкту");
                return;
            }

            gridView.DataSource = new BindingList<Info>(helper.searchBy(comboBox1.Text, txtSearch.Text, list));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            gridView.DataSource = new BindingList<Info>(list);
        }
    }
}
