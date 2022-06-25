using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Note_Taking_App
{
    public partial class Form1 : Form
    {
        List<string> titleTextList = new List<string>();
        List<string> noteTextList = new List<string>();

        int currentItemCounter = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Title.Text == "" && Note.Text == "")
                MessageBox.Show("Please fill the 'Title' and 'Note' area.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (Title.Text == "")
                MessageBox.Show("Please fill the 'Title' area.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (Note.Text == "")
                MessageBox.Show("Please fill the 'Note' area.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                listAdder();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Load.SelectedIndex != -1)
            {
                Title.Text = titleTextList[Load.SelectedIndex];
                Note.Text = noteTextList[Load.SelectedIndex];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Load.SelectedIndex != -1)
            {
                titleTextList.RemoveAt(Load.SelectedIndex);
                noteTextList.RemoveAt(Load.SelectedIndex);
                Load.Items.Remove(Load.Items[Load.SelectedIndex]);
                currentItemCounter -= 1;

                if (Load.Items.Count == 0)
                {
                    Title.Clear();
                    Note.Clear();
                }
            }
        }

        private void New_Click(object sender, EventArgs e)
        {
            if (Note.TextLength > 0)
            {
                DialogResult sonuc = MessageBox.Show("Do you want to delete current note?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (sonuc == DialogResult.Yes)
                {
                    Note.Clear();
                    Title.Clear();
                }
            }
        }

        private void listAdder()
        {
            currentItemCounter += 1;

            titleTextList.Add(Title.Text);
            noteTextList.Add(Note.Text);
            Load.Items.Add(titleTextList[currentItemCounter]);
        }
    }
}