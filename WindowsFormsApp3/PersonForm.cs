﻿using System;
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
            this.person = person ?? DataGenerator.CreatePerson(x =>
            {
                x.Name = "Иванов";
                x.Gender = Gender.Dog;
            });
            InitializeComponent();

            foreach (var item in Enum.GetValues(typeof(Gender)))
            {
                comboBox1.Items.Add(item);
            }
            if(comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }

            textBox1.AddBinding(x => x.Text, this.person, x => x.Name);
            comboBox1.AddBinding(x => x.SelectedItem, this.person, x => x.Gender);
            dateTimePicker1.AddBinding(x => x.Value, this.person, x => x.Birthday);
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