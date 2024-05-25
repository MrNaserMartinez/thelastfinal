using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thelastofus.datanice;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static thelastofus.datanice.final;

namespace thelastofus
{
    public partial class Form1 : Form
    {
        private final consolac;
        public Form1()
        {
            InitializeComponent();
            consolac = new final();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeComponent();
        }

        private void bconexion_Click(object sender, EventArgs e)
        {
            if (consolac.ProbarConexion())
            {
                MessageBox.Show("Good ending");
            }
            else
            {
                MessageBox.Show("Bad ending");
            }

        }

        private void mostrar_Click(object sender, EventArgs e)
        {
            DataTable dt = consolac.LeerPersonajes();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idPersonajeBuscar = int.Parse(textBox1.Text);
            DataTable personajeEncontrado = consolac.BuscarPersonajePorId(idPersonajeBuscar);
            if (personajeEncontrado.Rows.Count > 0)
            {
                string nombre_consola = personajeEncontrado.Rows[0]["nombre_consola"].ToString();
                string compania = personajeEncontrado.Rows[0]["compania"].ToString();
                int anio_lanzamiento = int.Parse(personajeEncontrado.Rows[0]["anio_lanzamiento"].ToString());
                int generacion = int.Parse(personajeEncontrado.Rows[0]["generacion"].ToString());


                textBox2.Text = nombre_consola;
                comboBox1.Text = compania;
                textBox4.Text = Convert.ToString(anio_lanzamiento);
                textBox5.Text = Convert.ToString(generacion);

            }
            else
            {
                MessageBox.Show("No se encontro codigo");
            }
        }

        private void bcrear_Click(object sender, EventArgs e)
        {

            string nombre_consola = textBox2.Text;
            string compania = comboBox1.Text;
            string anio_lanzamiento = textBox4.Text;
            string generacion = textBox5.Text;



            int respuesta = consolac.CrearPersonaje(nombre_lanzamiento, , nivelpoder, fecha_creacion, historia);
            if (respuesta > 0)
            {
                MessageBox.Show("Good ending x2");
                personajesdatos.DataSource = personaje.LeerPersonajes();
            }
            else
            {
                MessageBox.Show("BAD ENDING DE NUEVO");
            }
        }
    }


    }
}
