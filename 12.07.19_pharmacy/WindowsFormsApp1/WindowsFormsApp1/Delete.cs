using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Delete : Form

       
    { private Pharmacy pharmacy;
        private DataGridView dGridView;
        public Delete(Pharmacy ph,DataGridView dataGridView)
        {
            InitializeComponent();
            pharmacy = ph;
            dGridView = dataGridView;
            txtCmbox.DataSource = pharmacy.GetMedicines();

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
          int id= int.Parse(txtCmbox.SelectedValue.ToString().Substring(0,2).Trim());
            pharmacy.DeleteMedicine(id);

            txtCmbox.DataSource = null;
            txtCmbox.DataSource = pharmacy.GetMedicines();

            dGridView.DataSource = null;
            dGridView.DataSource = pharmacy.GetMedicines();
        }


    }
}
