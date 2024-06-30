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
    public partial class AddExercise : Form
    {
        public AddExercise()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Error = "";
            float kkal = 0, weight = 0;
            if (textBox1.Text.Length > 20)
            {
                textBox1.Clear();
                Error += "Постарайтесь уместить сложность в 20 символов\n";
            }
            if (!float.TryParse(textBox2.Text, out weight))
            {
                textBox2.Clear();
                Error += "Число веса введено неверно\n";
            }
            if (!float.TryParse(textBox3.Text, out kkal))
            {
                textBox3.Clear();
                Error += "Число калорий введено неверно\n";
            }
            
            if (Error != "")
            {
                MessageBox.Show(Error, "Ошибка ввода");
            } else
            {
               exersisesTableAdapter adapter = new exersisesTableAdapter();
                adapter.Insert(kkal, textBox1.Text, weight);


                MessageBox.Show("Тренировка добавлена", "Success");
                this.Close();
            }

            
            

        }
    }
}
