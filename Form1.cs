using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace texteditor_v_1._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        // menuFileNew = menuFileNew_Click();
        }

        private void MenuFile_Click(object sender, EventArgs e)
        {

        }
        private void menuFileNew_Click(object sender, EventArgs e)
        {
            RichTextBoxStream.Clear();
        }
        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            menuFileOpen();
        }
        private void menuFileOpen()
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFileDialog1.FileName.Length > 0)
            {
                try
                {
                    RichTextBoxStream.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);
                }
                catch (System.ArgumentException ex)
                {
                    RichTextBoxStream.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
                this.Text = "Файл [" + openFileDialog1.FileName + "]";
            }
        }
        private void menuFilesave_Click(object sender, EventArgs e)
        {
            MenuFileSaveAs();
        }
        private void MenuFileSaveAs()
        {
            saveFileDialog1.Filter = "RTF files|*.rtf|Text files|*.txt";
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName.Length > 0)
            {
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        RichTextBoxStream.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                        break;
                    case 2:
                        RichTextBoxStream.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                        break;
                }
            }
            this.Text = "Файл [" + saveFileDialog1.FileName + "]";
        }

        private void menuFileFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                RichTextBoxStream.SelectionFont = fontDialog1.Font;
            }
        }

        private void MenuFileColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                RichTextBoxStream.SelectionColor = colorDialog1.Color;
            }
        }
    }
}
