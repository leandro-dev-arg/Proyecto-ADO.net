using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominios;
using negocio;


namespace Proyecto_ADO.net
{
    public partial class Form1 : Form
    {
       private List<Pokemon> listaPokemon;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio= new PokemonNegocio();
            listaPokemon= negocio.listar();
            dgvPokemons.DataSource = listaPokemon;
            dgvPokemons.Columns["UrlImagen"].Visible=false;
            cargarImagen(listaPokemon[0].UrlImagen);
        }

        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
           Pokemon Seleccionado= (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            cargarImagen(Seleccionado.UrlImagen);
        }

        private void cargarImagen(string imagen) {

            try
            {
                PbPokemon.Load(imagen);
            }
            catch (Exception ex)
            {

                PbPokemon.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRuqKNTAK2agAe2tqc7_uKuIIEG74Ydj4FMrw&usqp=CAU");
            }


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaPokemon Alta =new frmAltaPokemon();
            Alta.ShowDialog();
        }
    }
}
