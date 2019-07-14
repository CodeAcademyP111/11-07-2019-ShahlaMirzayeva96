using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1
{

    public class Pharmacy { 



    
        private static int _id = 0;
        public int ID { get; set; }
        public string Name { get; set; }

        private List<Medicine> medicines;



        public Pharmacy(string name)
        {

            _id++;
            ID = _id;
            Name = name;
            medicines = new List<Medicine>()
            {
                new Medicine{Name="Korvalol",Type="heart",Price="8azn"},
                new Medicine{Name="Aspirine Cardio",Type="heart",Price="2azn"},
                new Medicine{Name="Atorvastatin",Type="heart",Price="9azn"}

            };
           



        }


        public List<Medicine> GetMedicines()
        {
            return medicines;
        }
    
        public void AddMedicine(Medicine medicine)
        {
            if (medicines.Capacity < 6)
            {
                medicines.Add(medicine);
            }
            
            
        }


        public void DeleteMedicine(int id)
        {

            for (int i = 0; i < medicines.Count; i++)
            {
                if (id == medicines[i].ID)
                {
                    medicines.RemoveAt(i);
                    return;
                }

            }


        }
        public void UpdateMedicine(int id,string name,string type,string price)
        {
            Medicine medicine = GetMedicine(id);
            medicine.Name = name;
            medicine.Type= type;
            medicine.Price= price;

        }
        public Medicine GetMedicine(int id)
        {
            Medicine result = null;
            for (int i = 0; i < medicines.Count; i++)
            {
                if (id == medicines[i].ID)
                {
                    result = medicines[i];
                }

            }
            return result;

        }

    }

    

}

