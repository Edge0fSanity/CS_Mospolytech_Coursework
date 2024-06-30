using Kursovaya.KursovayaDBDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            show_meal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Show_progress().ShowDialog();

        }

        private void show_meal()
        {
            var food = new foodTableAdapter();
            var dt = new KursovayaDBDataSet.foodDataTable();
            try
            {
                food.RandFood(dt);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            meal_label.Text = string.Join("; ", dt.Rows[0].ItemArray);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AddExercise().ShowDialog();
        }
    }
}
