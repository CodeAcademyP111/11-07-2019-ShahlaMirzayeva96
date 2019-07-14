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
    public partial class HomePage : Form
    {   
        private Pharmacy pharmacy;
        private DataGridView dGridview;
        public HomePage()
        {
            InitializeComponent();
            Pharmacy aptek = new Pharmacy("Aptek");
            pharmacy = aptek;
            dGridview = dataGv;
            dataGv.DataSource= pharmacy.GetMedicines();
        }

        private void btnAdd_Click(object sender, EventArgs e)

        {
            string name = txtName.Text.Trim();
            string type = txtType.Text.Trim();
            string price = txtPrice.Text.Trim();

            CheckInput(name, type, price);

               if (name != "" && type != "" && price != "")
            {
                Medicine medicine = new Medicine { Name = name, Type = type, Price = price };
                pharmacy.AddMedicine(medicine);
                EmptyAndGetList(dGridview);
            }

           
           

        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Delete delete= new Delete( pharmacy,dGridview);
            delete.Show();

        }
        private int ID = 0;
        private void DataGv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Visible = true;
            btnAdd.Visible = false;

            int id=(int)dGridview.Rows[e.RowIndex].Cells[0].Value;
            ID = id;
            Medicine medicine = pharmacy.GetMedicine(id);

            txtName.Text = medicine.Name;
            txtPrice.Text = medicine.Price;
            txtType.Text = medicine.Type;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string type = txtType.Text.Trim();
            string price = txtPrice.Text.Trim();

            CheckInput(name, type, price);


             if(name != "" && type != "" && price != "")
            {

                pharmacy.UpdateMedicine(ID,name,price,type);
                EmptyAndGetList(dGridview);
            }


        }

        private void AddListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            btnAdd.Visible = true;

          
        }

        public void CheckInput(string name,string type,string price)
        {
            
            if (name == "" || type == "" || price == "")
            {
                MessageBox.Show("Information don't filed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void EmptyAndGetList(DataGridView dGridview)
        {
         
            dGridview.DataSource = null;
            dGridview.DataSource = pharmacy.GetMedicines();

            txtName.Text = null;
            txtPrice.Text = null;
            txtType.Text = null;
        }
    }
}
