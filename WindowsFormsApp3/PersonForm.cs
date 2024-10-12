using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.Model;
using WindowsFormsApp3.Models;

namespace WindowsFormsApp3
{
    public partial class PersonForm : Form
    {
        private Person person;
        public PersonForm(Person person = null)
        {
            this.person = person == null
                ? DataGenerator.CreatePerson(x =>
                {
                x.Id = Guid.NewGuid();
                x.Name = "Иванов";
                x.Gender = Gender.Male;
                x.Birthday = DateTime.Now.AddYears(-12);
                })
                : new Person
                {
                    Id = person.Id,
                    Name = person.Name,
                    Gender = person.Male,
                    Birthday = person.Birthday,
                    AvgGrade = person.AvgGrade,
                    Dept = person.Dept,
                    Expelled = person.Expelled,
                };

            InitializeComponent();

            foreach (var item in Enum.GetValues(typeof(Gender)))
            {
                comboBox1.Items.Add(item);
            }
            if(comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }

            textBox1.AddBinding(x => x.Text, this.person, x => x.Name, errorProvider1);
            comboBox1.AddBinding(x => x.SelectedItem, this.person, x => x.Gender, errorProvider1);
            dateTimePicker1.AddBinding(x => x.Value, this.person, x => x.Birthday, errorProvider1);
            numericUpDown1.AddBinding(x => x.Value, this.person, x => x.AvgGrade, errorProvider1);
            checkBox1.AddBinding(x => x.Checked, this.person, x => x.Expelled, errorProvider1);
            checkBox2.AddBinding(x => x.Checked, this.person, x => x.Dept, errorProvider1);
       }

        public Person Person => person;



		private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
		{
            e.DrawBackground();
            e.Graphics.FillEllipse(Brushes.Red, new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Height - 4, e.Bounds.Height - 4));
            if (e.Index > -1)
            {
                var value = (Gender) (sender as ComboBox).Items[e.Index];
				e.Graphics.DrawString(GetDisplayValue(value),
                   e.Font,
                   new SolidBrush(e.ForeColor),
                   e.Bounds.X + 20,
                   e.Bounds.Y);
			}        
		}

        private string GetDisplayValue(Gender value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = field.GetCustomAttributes<DescriptionAttribute>(false);
            return attributes.FirstOrDefault()?.Description ?? "IDK";

        }
	}
}