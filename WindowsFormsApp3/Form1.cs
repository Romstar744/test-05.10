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
        private List<Person> people = new List<Person>();
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
           var personForm= new PersonForm();
           if(personForm.ShowDialog(this) == DialogResult.OK)
           {
                people.Add(personForm.Person);
           }
        }
    }
}
