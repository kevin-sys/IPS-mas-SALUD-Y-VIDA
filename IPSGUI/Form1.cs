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
    public partial class FrmLiquidacion : Form
    {
        LiquidacionCuotaModeradora liquidacion;
        public FrmLiquidacion()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            LiquidacionCuotaModeradoraService service = new LiquidacionCuotaModeradoraService();
            LiquidacionCuotaModeradora cuotaModeradora = MapearLiquidacion();
            cuotaModeradora.CalcularTarifa();
            string mensaje = service.Guardar(cuotaModeradora);
            MessageBox.Show(mensaje, "MENSAJE DE GUARDADO", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private LiquidacionCuotaModeradora MapearLiquidacion()
        {
            if (CmbTipoAfiliacion.Text.Equals("Contributivo"))
            {
                liquidacion = new Contributivo();
                liquidacion.NumeroLiquidacion = TxtNumeroLiquidacion.Text;
                liquidacion.FechaLiquidacion = DtpFechaLiquidacion.Value.Date;
                liquidacion.Identificacion = TxtIdentificacion.Text;
                liquidacion.TipoAfiliacion = CmbTipoAfiliacion.Text;
                liquidacion.SalarioDevengado = double.Parse(TxtSalarioDevengado.Text);
                liquidacion.ValorServicioHospitalizacion = double.Parse(TxtValorHospitalizacion.Text);
                return liquidacion;
            }
            if (CmbTipoAfiliacion.Text.Equals("Subsidiado"))
            {
                liquidacion = new Subsidiado();
                liquidacion.NumeroLiquidacion = TxtNumeroLiquidacion.Text;
                liquidacion.FechaLiquidacion = DtpFechaLiquidacion.Value.Date;
                liquidacion.Identificacion = TxtIdentificacion.Text;
                liquidacion.TipoAfiliacion = CmbTipoAfiliacion.Text;
                liquidacion.SalarioDevengado = double.Parse(TxtSalarioDevengado.Text);
                liquidacion.ValorServicioHospitalizacion = double.Parse(TxtValorHospitalizacion.Text);
                return liquidacion;
            }
            return null;
        }
    }
}
