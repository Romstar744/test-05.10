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

        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
           var personForm = new PersonForm();
           if(personForm.ShowDialog(this) == DialogResult.OK)
           {
                people.Add(personForm.Person);
                bindingSource.ResetBindings(false);
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
	}
}
