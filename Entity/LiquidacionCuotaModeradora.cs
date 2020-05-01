using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class LiquidacionCuotaModeradora
    {
        public string NumeroLiquidacion { get; set; }
        public DateTime FechaLiquidacion { get; set; }
        public string Identificacion { get; set; }
        public string TipoAfiliacion { get; set; }
        public double SalarioDevengado { get; set; }
        public double ValorServicioHospitalizacion { get; set; }
        public double CuotaModeradoraFinal { get; set; }
        public double CuotaModeradoraReal { get; set; }
        public double Tarifa { get; set; }
        public string AplicaTope { get; set; }
        public double SalarioMinimo;
        public abstract void CalcularTarifa();
        public override string ToString()
        {
            return $"{NumeroLiquidacion};{FechaLiquidacion};{Identificacion};{TipoAfiliacion};{SalarioDevengado};{ValorServicioHospitalizacion};{CuotaModeradoraFinal};{CuotaModeradoraReal};{Tarifa};{AplicaTope}";
        }
    }
}
