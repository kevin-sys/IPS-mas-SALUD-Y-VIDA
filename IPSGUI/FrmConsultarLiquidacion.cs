using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entity;
namespace IPSGUI
{
    public partial class FrmConsultarLiquidacion : Form
    {
        LiquidacionCuotaModeradoraService service = new LiquidacionCuotaModeradoraService();
        public FrmConsultarLiquidacion()
        {
            InitializeComponent();
            LlenarTabla();
        }


        private void CmbTipoAfiliacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrepararDatos();
        }

        private void CargarContributivo()
        {
            DgvLiquidacion.DataSource = null;
            DgvLiquidacion.DataSource = LiquidacionCuotaModeradoraService.ListarContributivo().ToList();
            TxtContributivo.Text = service.TotalizarContributivo().ToString();
            TxtValorTotalContributivo.Text = service.ValorTotalLiquidacionContributivo().ToString();
            TxtValorTotalSubsidiado.Text = "";
            TxtSubsidiado.Text = "";
            LimpiarTxt();


        }
        private void CargarSubsidiado()
        {
            DgvLiquidacion.DataSource = null;
            DgvLiquidacion.DataSource = LiquidacionCuotaModeradoraService.ListarSubsidiado().ToList();
            TxtSubsidiado.Text = service.TotalizarSubsidiado().ToString();
            TxtValorTotalSubsidiado.Text = service.ValorTotalLiquidacionSubsidiado().ToString();
            TxtValorTotalContributivo.Text = "";
            TxtContributivo.Text = "";
            LimpiarTxt();
        }
        private void CargarTodos()
        {
            LlenarTabla();
            TxtTotal.Text = service.TotalizarTodos().ToString();
            TxtContributivo.Text = service.TotalizarContributivo().ToString();
            TxtSubsidiado.Text = service.TotalizarSubsidiado().ToString();
            TxtValorTotalContributivo.Text = service.ValorTotalLiquidacionContributivo().ToString();
            TxtValorTotalLiquidacion.Text = service.ValorTotalLiquidacion().ToString();
            TxtValorTotalSubsidiado.Text = service.ValorTotalLiquidacionSubsidiado().ToString();
        }
        private void LimpiarTxt()
        {
            TxtTotal.Text = "";
            TxtValorTotalLiquidacion.Text = "";
        }
        private void PrepararDatos()
        {
            if (CmbTipoAfiliacion.Text.Equals("Todos"))
            {
                CargarTodos();
            }

            if (CmbTipoAfiliacion.Text.Equals("Subsidiado"))
            {
                CargarSubsidiado();

            }
            if (CmbTipoAfiliacion.Text.Equals("Contributivo"))
            {
                CargarContributivo();
            }
        }
        private void LlenarTabla()
        {
            DgvLiquidacion.DataSource = null;
            DgvLiquidacion.DataSource = LiquidacionCuotaModeradoraService.ConsultarTodos();
        }
    }
}
