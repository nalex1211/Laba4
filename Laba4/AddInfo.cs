using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;
using System.ComponentModel;

namespace Laba4
{
    public partial class AddInfo : Form
    {
        public Info info { get; set; } = new Info();
        
        public AddInfo()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            info.Name = txtName.Text;
            info.MiddleName = txtMiddleName.Text;
            info.LastName = txtLastName.Text;
            info.Sex = chooseSex.Text;
            info.DateOfBirth = datePick.Text;
            info.Faculty = txtFaculty.Text;
            info.Departament = txtDepartament.Text;
            Close();
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
