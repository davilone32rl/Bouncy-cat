using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MascotaVirtual
{
    public partial class Form1 : Form
    {
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);
        private ContextMenuStrip contextMenu;

        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Lime; 
            this.TransparencyKey = Color.Lime; 
            this.TopMost = true; 

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            contextMenu = new ContextMenuStrip();
            var seleccionarImagen = new ToolStripMenuItem("Select image");
            var quitmenu = new ToolStripMenuItem("Good bye...");
            seleccionarImagen.Click += SeleccionarImagen_Click;
            quitmenu.Click += exitoption;
            contextMenu.Items.Add(seleccionarImagen);
            contextMenu.Items.Add(quitmenu);
            pictureBox1.ContextMenuStrip = contextMenu; 
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseUp += PictureBox1_MouseUp;
        }


        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void SeleccionarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif|Todos los archivos|*.*";
                openFileDialog.Title = "Seleccionar Imagen";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Image imagen = Image.FromFile(openFileDialog.FileName);
                    pictureBox1.Image = imagen;

                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void exitoption(object sender, EventArgs e)
        {
            this.Close();
        } 

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
