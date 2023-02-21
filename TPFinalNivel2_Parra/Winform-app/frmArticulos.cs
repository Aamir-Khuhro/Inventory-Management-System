﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Business;

namespace Winform_app
{
    public partial class frmArticulos : Form
    {
        //se va utilizar varias veces este atributo

        private List<Articulo> articuloList;
        public frmArticulos()
        {
            InitializeComponent();
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            try
            {
                ArticuloBusiness business = new ArticuloBusiness();
                articuloList = business.listarArticulo();
                dgvArticulos.DataSource = articuloList;
                cargarImagen(articuloList[0].ImagenUrl);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        //cambia la imagen cuando cambia la celda seleccionada
        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Articulo seleccionadoRow;
                seleccionadoRow = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionadoRow.ImagenUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                
            }
            
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulos.Load(imagen);

            }
            catch (Exception)
            {
                pbxArticulos.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");

            }
        }
    }
}
