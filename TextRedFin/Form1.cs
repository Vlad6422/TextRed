using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextRedFin
{

    public partial class Form1 : Form
    {
        private string fn = string.Empty;
        private bool docChanged = false;





        private void OpenDocument()
        {
            openFileDialog1.FileName = string.Empty;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fn = openFileDialog1.FileName;

                this.Text = fn;
                try
                {

                    System.IO.StreamReader sr = new System.IO.StreamReader(fn);
                    textBox1.Text = sr.ReadToEnd();
                    textBox1.SelectionStart = textBox1.TextLength;
                    sr.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Ошибка чтения файла.\n" +
                    exc.ToString(), "MEdit",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
        private int SaveDocument()
        {
            int result = 0;
            if (fn == string.Empty)
            {
              
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                   
                    fn = saveFileDialog1.FileName;
                    this.Text = fn;
                }
                else result = -1;
            }
         
            if (fn != string.Empty)
            {
                try
                {
                  
                    System.IO.FileInfo fi = new System.IO.FileInfo(fn);
                    
                    System.IO.StreamWriter sw = fi.CreateText();
                  
                    sw.Write(textBox1.Text);
                   
                    sw.Close();
                    result = 0;
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString(), "NkEdit",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return result;
        }






        public Form1()
        {
            InitializeComponent();
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Text = string.Empty;
            this.Text = "TxtEditor - Новый документ";
            toolStrip1.Visible = true;
        
            //
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "текст|*.txt";
            openFileDialog1.Title = "Открыть документ";
            openFileDialog1.Multiselect = false;
            //
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "текст|*.txt";
            saveFileDialog1.Title = "Сохранить документ";
            //

        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OpenDocument();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (docChanged)
            {
                DialogResult dr;
                dr = MessageBox.Show("Сохранить изменения ?", "NkEdit",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);
                switch (dr)
                {
                    case DialogResult.Yes:
                        if (SaveDocument() == 0)
                        {
                            textBox1.Clear();
                            docChanged = false;
                        }
                        break;
                    case DialogResult.No:
                        textBox1.Clear();
                        docChanged = false;
                        break;
                    case DialogResult.Cancel:
                        //
                        break;
                };
            }

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = textBox1.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
            }

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (docChanged)
            {
                DialogResult dr;
                dr = MessageBox.Show("Сохранить изменения?", "NkEdit",
                MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Warning);
                switch (dr)
                {
                    case DialogResult.Yes:
                        if (SaveDocument() != 0)

                            e.Cancel = true;
                        break;
                    case DialogResult.No:
                        ;
                        break;
                    case DialogResult.Cancel:

                        e.Cancel = true;
                        break;
                };
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            docChanged = true;

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            toolStrip1.Visible = !toolStrip1.Visible;
            paramToolStripMenuItem.Checked = !paramToolStripMenuItem.Checked;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 about = new Form2();
            about.ShowDialog();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Справка в редакторе???)))");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (docChanged)
            {
                DialogResult dr;
                dr = MessageBox.Show("Сохранить изменения ?", "NkEdit",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);
                switch (dr)
                {
                    case DialogResult.Yes:
                        if (SaveDocument() == 0)
                        {
                            textBox1.Clear();
                            docChanged = false;
                        }
                        break;
                    case DialogResult.No:
                        textBox1.Clear();
                        docChanged = false;
                        break;
                    case DialogResult.Cancel:
                        //
                        break;
                };
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenDocument();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }
    }
}
