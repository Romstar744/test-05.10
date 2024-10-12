using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private List<Person> people;
        private BindingSource bindingSource;
        public Form1()
        {
            bindingSource = new BindingSource();
            people = new List<Person>();
            bindingSource.DataSource = people;

            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingSource;
            SetStatus();

        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
           var personForm = new PersonForm();
           if(personForm.ShowDialog(this) == DialogResult.OK)
           {
                people.Add(personForm.Person);
                bindingSource.ResetBindings(false);
                SetStatus();
           }
        }

		private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
            if (dataGridView1.Columns[e.ColumnIndex].Name == "ExpelledColumn")
            {
                var data = (Person)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                e.Value = data.Expelled ? "Да" : string.Empty;
            }
			if (dataGridView1.Columns[e.ColumnIndex].Name == "DeptColumn")
			{
				var data = (Person)dataGridView1.Rows[e.RowIndex].DataBoundItem;
				e.Value = data.Dept ? "Да" : string.Empty;
			}
		}

		private void toolStripDelete_Click(object sender, EventArgs e)
		{
            if(dataGridView1.SelectedRows.Count != 0)
            {
                var data = (Person)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
                if (MessageBox.Show($"Вы действительно хотите удалить {data.Name}?", "Удаление записи", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    people.Remove(data);
                    bindingSource.ResetBindings(false);
                    SetStatus();
                }
			}
            
		}

		private void toolStripEdit_Click(object sender, EventArgs e)
		{
            if (dataGridView1.SelectedRows.Count != 0)
            {
                var data = (Person)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
                var personForm = new PersonForm(data);
                if (personForm.ShowDialog(this) == DialogResult.OK)
                {
                    data.Name = personForm.Person.Name;
                    data.Gender = personForm.Person.Gender;
                    data.AvgGrade = personForm.Person.AvgGrade;
                    data.Birthday = personForm.Person.Birthday;
                    data.Dept = personForm.Person.Dept; 
                    data.Expelled = personForm.Person.Expelled;
					bindingSource.ResetBindings(false);
                    SetStatus();
				}
			}
		}

        public void SetStatus()
        {
            toolStripStatusLabel1.Text = $"Всего: {people.Count}";
            toolStripStatusLabel2.Text = $"{people.Where(x => x.Gender == Gender.Female).Count()} Ж/{people.Where(x => x.Gender == Gender.Male).Count()} М";
            toolStripStatusLabel3.Text = $"Отчисленных: {people.Where(x => x.Expelled).Count()}";
            toolStripStatusLabel4.Text = $"Должников: {people.Where(x => x.Dept).Count()}";
            toolStripStatusLabel5.Text = $"Средняя оценка: {people.DefaultIfEmpty(new Person()).Average(x => x.AvgGrade)}";
        }
	}
}
