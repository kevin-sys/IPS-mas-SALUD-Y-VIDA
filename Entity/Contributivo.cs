using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Contributivo : LiquidacionCuotaModeradora
    {
        public override void CalcularTarifa()
        {
            SalarioMinimo = 877803;
            if (SalarioDevengado < SalarioMinimo * 2)
            {
                Tarifa = 15;
                CuotaModeradoraReal = ValorServicioHospitalizacion * Tarifa / 100;
                double TOPE = 250000;
                if (CuotaModeradoraReal > TOPE)
                {
                    CuotaModeradoraFinal = TOPE;
                    AplicaTope = "SI";

                }
                else
                {
                    CuotaModeradoraFinal = CuotaModeradoraReal;
                    AplicaTope = "NO";

                }

            }

            if (SalarioDevengado >= SalarioMinimo * 2 && SalarioDevengado <= SalarioMinimo * 5)
            {
                Tarifa = 20;
                CuotaModeradoraReal = ValorServicioHospitalizacion * Tarifa / 100;
                double TOPE = 900000;
                if (CuotaModeradoraReal > TOPE)
                {
                    CuotaModeradoraFinal = TOPE;
                    AplicaTope = "SI";

                }
                else
                {
                    CuotaModeradoraFinal = CuotaModeradoraReal;
                    AplicaTope = "NO";

                }
            }

            if (SalarioDevengado > SalarioMinimo * 5)
            {
                Tarifa = 25;
                CuotaModeradoraReal = ValorServicioHospitalizacion * Tarifa / 100;
                double TOPE = 1500000;
                if (CuotaModeradoraReal > TOPE)
                {
                    CuotaModeradoraFinal = TOPE;
                    AplicaTope = "SI";

                }
                else
                {
                    CuotaModeradoraFinal = CuotaModeradoraReal;
                    AplicaTope = "NO";

                }
            }

        }
    }
}
