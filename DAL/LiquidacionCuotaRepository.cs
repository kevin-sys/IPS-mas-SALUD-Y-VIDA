using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;
using System.Linq;

namespace DAL
{
    public class LiquidacionCuotaRepository
    {
        private string ruta = @"Liquidacion.txt";
        private IList<LiquidacionCuotaModeradora> liquidaciones;
        public LiquidacionCuotaRepository()
        {
            liquidaciones = new List<LiquidacionCuotaModeradora>();
        }
        public void Guardar(LiquidacionCuotaModeradora liquidacion)
        {
            FileStream fileStream = new FileStream(ruta, FileMode.Append);
            StreamWriter writer = new StreamWriter(fileStream);
            writer.WriteLine(liquidacion.ToString());
            writer.Close();
            fileStream.Close();
        }


        public IList<LiquidacionCuotaModeradora> Consultar()
        {
            liquidaciones.Clear();
            FileStream fileStream = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader streamReader = new StreamReader(fileStream);
            string linea = string.Empty;
            LiquidacionCuotaModeradora liquidacionCuotaModeradora;
            while ((linea = streamReader.ReadLine()) != null)
            {
                string[] datos = linea.Split(';');
                if (datos[2] == "Contributivo")
                {
                    liquidacionCuotaModeradora = new Contributivo();

                }
                else
                {
                    liquidacionCuotaModeradora = new Subsidiado();

                }
                liquidacionCuotaModeradora.NumeroLiquidacion = datos[0];
                liquidacionCuotaModeradora.FechaLiquidacion = DateTime.Parse(datos[1]);
                liquidacionCuotaModeradora.Identificacion = datos[2];
                liquidacionCuotaModeradora.TipoAfiliacion = datos[3];
                liquidacionCuotaModeradora.SalarioDevengado = double.Parse(datos[4]);
                liquidacionCuotaModeradora.ValorServicioHospitalizacion = double.Parse(datos[5]);
                liquidacionCuotaModeradora.CuotaModeradoraFinal = double.Parse(datos[6]);
                liquidacionCuotaModeradora.CuotaModeradoraReal = double.Parse(datos[7]);
                liquidacionCuotaModeradora.Tarifa = double.Parse(datos[8]);
                liquidacionCuotaModeradora.AplicaTope = datos[9];
                liquidaciones.Add(liquidacionCuotaModeradora);
            }
            fileStream.Close();
            streamReader.Close();
            return liquidaciones;
        }

        public void Eliminar(string numeroLiquidacion)
        {
            liquidaciones.Clear();
            liquidaciones = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in liquidaciones)
            {
                if (item.NumeroLiquidacion != numeroLiquidacion)
                {
                    Guardar(item);
                }
            }
        }

        public void Modificar(LiquidacionCuotaModeradora liquidacion)
        {
            liquidaciones.Clear();
            liquidaciones = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in liquidaciones)
            {
                if (item.NumeroLiquidacion != liquidacion.NumeroLiquidacion)
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(liquidacion);
                }
            }
        }

        public LiquidacionCuotaModeradora Buscar(string numeroLiquidacion)
        {
            liquidaciones.Clear();
            liquidaciones = Consultar();
            foreach (var item in liquidaciones)
            {
                if (item.NumeroLiquidacion.Equals(numeroLiquidacion))
                {
                    return item;
                }
            }
            return null;
        }



        public IEnumerable<LiquidacionCuotaModeradora>ListarContributivo()
        {
            return liquidaciones.Where(p => p.TipoAfiliacion.Equals("Contributivo"));
        }
        public IEnumerable<LiquidacionCuotaModeradora> ListarSubsidiado()
        {
            return liquidaciones.Where(p => p.TipoAfiliacion.Equals("Subsidiado"));
        }

        public int TotalizarContributivo()
        {
            return liquidaciones.Where(p => p.TipoAfiliacion.Equals("Contributivo")).Count();
        }
        public int TotalizarSubsidiado()
        {
            return liquidaciones.Where(p => p.TipoAfiliacion.Equals("Subsidiado")).Count();
        }


        public int TotalizarTodos()
        {
            return liquidaciones.Where(p => p.TipoAfiliacion.Equals("Subsidiado") || p.TipoAfiliacion.Equals("Contributivo")).Count();
        }

        public double ValorTotalLiquidacion()
        {
            return liquidaciones.Where(p => p.TipoAfiliacion.Equals("Contributivo") || p.TipoAfiliacion.Equals("Subsidiado") && p.CuotaModeradoraFinal.Equals(p.CuotaModeradoraFinal)).Sum(p => p.CuotaModeradoraFinal);
        }



        public double ValorTotalLiquidacionContributivo()
        {
            return liquidaciones.Where(p => p.TipoAfiliacion.Equals("Contributivo") && p.CuotaModeradoraFinal.Equals(p.CuotaModeradoraFinal)).Sum(p => p.CuotaModeradoraFinal);
        }

        public double ValorTotalLiquidacionSubsidiado()
        {
            return liquidaciones.Where(p => p.TipoAfiliacion.Equals("Subsidiado") && p.CuotaModeradoraFinal.Equals(p.CuotaModeradoraFinal)).Sum(p=> p.CuotaModeradoraFinal);
        }

    }
}
