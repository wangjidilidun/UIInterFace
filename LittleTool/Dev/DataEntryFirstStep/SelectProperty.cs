using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;

namespace DataEntryFirstStep
{
    public partial class SelectProperty : DockContent
    {
        public SelectProperty()
        {
            InitializeComponent();
        }

        private void SelectProperty_Load(object sender, EventArgs e)
        {
            rbtnHen.Location = new Point(30, 30);
            rbtnShu.Location = new Point(30, 60);
            rbtnPie.Location = new Point(30, 90);
            rbtnNa.Location = new Point(30, 120);
            rbtnReset.Location = new Point(30, 150);

            txtText.Location = new Point(30, 180);

            if (File.Exists(".\\Temp.txt"))
            {
                StreamReader sr = new StreamReader(".\\Temp.txt");
                string str = sr.ReadLine();
                txtText.Text = str;
                sr.Close();
            }
        }

        public string getProperty()
        {
            string strProperty = "";

            if (rbtnHen.Checked)
            {
                strProperty = "横";
            }
            if (rbtnShu.Checked)
            {
                strProperty = "竖";
            }
            if (rbtnPie.Checked)
            {
                strProperty = "撇";
            }
            if (rbtnNa.Checked)
            {
                strProperty = "捺";
            }
            if (rbtnReset.Checked)
            {
                strProperty = "reset";
            }
            return strProperty;
        }
        public string getWordContent()
        {
            string strContent = "";

            strContent = txtText.Text;

            return strContent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
