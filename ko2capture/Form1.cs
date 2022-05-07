using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ko2capture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private CaptureForm m_capture;
        private Int32 m_methodId = 1;

        private void Form1_Load(object sender, EventArgs e)
        {
            captureButton.Enabled = false;
            comboBox1.SelectedIndex = 0;

            boundaryColor.BackColor = Color.White;
        }

        private void captureButton_Click(object sender, EventArgs e)
        {
            if (m_capture == null)
            {
                m_capture = new CaptureForm();
                m_capture.Folder = folderPath.Text;
            }

            m_capture.MethodId = m_methodId;
            m_capture.CaptureScreen();
            m_capture.Show();
        }

        private void selectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Description = "フォルダを指定してください。";
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.ShowNewFolderButton = true;
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                folderPath.Text = fbd.SelectedPath;

                captureButton.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string method = comboBox1.Text.Substring(0, 2);
            m_methodId = Int32.Parse(method);
        }

        private void ChooseBoundaryColor_Click(object sender, EventArgs e)
        {
            if (m_capture == null)
            {
                m_capture = new CaptureForm();
                m_capture.Folder = folderPath.Text;
            }

            m_capture.AppForm = this;
            m_capture.MethodId = 0;
            m_capture.CaptureScreen();
            m_capture.Show();
        }

        public void SetBoundaryColor(Color c)
        {
            boundaryColor.BackColor = c;
        }
    }
}
