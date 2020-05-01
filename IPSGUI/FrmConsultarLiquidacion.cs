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
        }

        private void FrmConsultarLiquidacion_Load(object sender, EventArgs e)
        {

        }

       

        private void CmbTipoAfiliacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbTipoAfiliacion.Text.Equals("Todos"))
            {
                DgvLiquidacion.DataSource = null;
                DgvLiquidacion.DataSource = LiquidacionCuotaModeradoraService.ConsultarTodos();
                TxtTotal.Text = service.TotalizarTodos().ToString();
                TxtContributivo.Text = service.TotalizarContributivo().ToString();
                TxtSubsidiado.Text = service.TotalizarSubsidiado().ToString();

                TxtValorTotalContributivo.Text = service.ValorTotalLiquidacionContributivo().ToString();
                TxtValorTotalLiquidacion.Text = service.ValorTotalLiquidacion().ToString();
                TxtValorTotalSubsidiado.Text = service.ValorTotalLiquidacionSubsidiado().ToString();
            }
            if (CmbTipoAfiliacion.Text.Equals("Contributivo"))
            {
                DgvLiquidacion.DataSource = null;
                DgvLiquidacion.DataSource = LiquidacionCuotaModeradoraService.ListarContributivo().ToList();
                TxtContributivo.Text = service.TotalizarContributivo().ToString();
                TxtValorTotalContributivo.Text = service.ValorTotalLiquidacionContributivo().ToString();
                TxtValorTotalLiquidacion.Text = "";
                TxtValorTotalSubsidiado.Text = "";
                TxtSubsidiado.Text = "";
                TxtTotal.Text = "";

            }
            if (CmbTipoAfiliacion.Text.Equals("Subsidiado"))
            {
                DgvLiquidacion.DataSource = null;
                DgvLiquidacion.DataSource = LiquidacionCuotaModeradoraService.ListarSubsidiado().ToList();
                TxtSubsidiado.Text = service.TotalizarSubsidiado().ToString();
                TxtValorTotalSubsidiado.Text = service.ValorTotalLiquidacionSubsidiado().ToString();
                TxtValorTotalContributivo.Text = "";
                TxtValorTotalLiquidacion.Text = "";
                TxtContributivo.Text = "";
                TxtTotal.Text = "";

            }
        }
    }
}
