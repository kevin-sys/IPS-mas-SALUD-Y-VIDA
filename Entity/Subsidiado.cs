using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Subsidiado : LiquidacionCuotaModeradora
    {
        public override void CalcularTarifa()
        {
            Tarifa = 5;

            CuotaModeradoraReal = ValorServicioHospitalizacion * Tarifa / 100;
            double Tope = 200000;
            if (CuotaModeradoraReal > Tope)
            {
                CuotaModeradoraFinal = Tope;
                AplicaTope = "SI";

            }
            else
            {
                CuotaModeradoraFinal = CuotaModeradoraReal;
                AplicaTope = "NO";

            }
            Tarifa = Tarifa;

        }
    }
}
