using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace $safeprojectname$
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        private void showtable()
        {
            dataGridView1.DataSource = db.tbl_users.ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            showtable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbl_user t1 = new tbl_user();
            t1.id = int.Parse(textBox1.Text);
            t1.name = textBox2.Text;
            t1.family = textBox3.Text;
            db.tbl_users.InsertOnSubmit(t1);
            db.SubmitChanges();
            showtable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbl_user t1 = db.tbl_users.FirstOrDefault(x => x.id == int.Parse(textBox1.Text));
            db.tbl_users.DeleteOnSubmit(t1);
            db.SubmitChanges();
            showtable();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           // dataGridView1.DataSource = db.tbl_users.Where(x => x.name == textBox2.Text);
            var filtername = from x in db.tbl_users
                             where x.name == textBox2.Text
                             select x;
            dataGridView1.DataSource = filtername;

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tbl_user t1 = db.tbl_users.FirstOrDefault(x => x.id == int.Parse(textBox1.Text));
            t1.name = textBox2.Text;
            t1.family = textBox3.Text;
            db.SubmitChanges();
            showtable();

        }
    }
}
