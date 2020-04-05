using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
namespace BLL
{
    public class LiquidacionCuotaModeradoraService
    {
        private LiquidacionCuotaRepository cuotaRepository;
        public LiquidacionCuotaModeradoraService()
        {
            cuotaRepository = new LiquidacionCuotaRepository();
        }
        const double SALARIOMINIMO = 900000;

        public void calcularLiquidacion(LiquidacionCuotaModeradora liquidacion)
        {
            LiquidarContributivo(liquidacion);
            LiquidarSubsidiado(liquidacion);
        }

        private void LiquidarContributivo(LiquidacionCuotaModeradora liquidacion)
        {
            if (liquidacion.TipoAfiliacion.Equals("RC"))
            {
                if (liquidacion.SalarioDevengado < SALARIOMINIMO * 2)
                {
                    double Tarifa = 15;
                    liquidacion.CuotaModeradoraReal = liquidacion.ValorServicioHospitalizacion * Tarifa / 100;
                    double TOPE = 250000;
                    if (liquidacion.CuotaModeradoraReal > TOPE)
                    {
                        liquidacion.CuotaModeradoraFinal = TOPE;
                        liquidacion.Tope = "SI";
                    }
                    else
                    {
                        liquidacion.Tope = "NO";
                        liquidacion.CuotaModeradoraFinal = liquidacion.CuotaModeradoraReal;
                    }
                    liquidacion.Tarifa = Tarifa;
                   
                }

                if (liquidacion.SalarioDevengado >= SALARIOMINIMO * 2 && liquidacion.SalarioDevengado <= SALARIOMINIMO * 5)
                {
                    double Tarifa = 20;
                    liquidacion.CuotaModeradoraReal = liquidacion.ValorServicioHospitalizacion * Tarifa / 100;
                    double TOPE = 900000;
                    if (liquidacion.CuotaModeradoraReal > TOPE)
                    {
                        liquidacion.CuotaModeradoraFinal = TOPE;
                        liquidacion.Tope = "SI";
                    }
                    else
                    {
                        liquidacion.Tope = "NO";
                        liquidacion.CuotaModeradoraFinal = liquidacion.CuotaModeradoraReal;
                    }
                    liquidacion.Tarifa = Tarifa;
                }

                if (liquidacion.SalarioDevengado > SALARIOMINIMO * 5)
                {
                    double Tarifa = 25;
                    liquidacion.CuotaModeradoraReal = liquidacion.ValorServicioHospitalizacion * Tarifa / 100;
                    double TOPE = 1500000;
                    if (liquidacion.CuotaModeradoraReal > TOPE)
                    {
                        liquidacion.CuotaModeradoraFinal = TOPE;
                        liquidacion.Tope = "SI";
                    }
                    else
                    {
                        liquidacion.Tope = "NO";
                        liquidacion.CuotaModeradoraFinal = liquidacion.CuotaModeradoraReal;
                    }
                    liquidacion.Tarifa = Tarifa;
                }

            }
        }

        private void LiquidarSubsidiado(LiquidacionCuotaModeradora liquidacion)
        {
            double Tarifa = 5;
            if (liquidacion.TipoAfiliacion.Equals("RS"))
            {
                liquidacion.CuotaModeradoraReal = liquidacion.ValorServicioHospitalizacion * Tarifa/100;
                double Tope = 200000;
                if (liquidacion.CuotaModeradoraReal > Tope)
                {
                    liquidacion.CuotaModeradoraFinal = Tope;
                    liquidacion.Tope = "SI";
                }
                else
                {
                    liquidacion.Tope = "NO";
                    liquidacion.CuotaModeradoraFinal = liquidacion.CuotaModeradoraReal;
                }
                liquidacion.Tarifa = Tarifa;
            }
        }

        public string Guardar(LiquidacionCuotaModeradora liquidacion)
        {
            try
            {
                if (cuotaRepository.Buscar(liquidacion.NumeroLiquidacion)==null)
                {
                    cuotaRepository.Guardar(liquidacion);
                    return "Los Datos han sido guardados satisfactoriamente";
                }
                else
                {
                    return $"El numero de liquidacion: {liquidacion.NumeroLiquidacion} Ya se encuentra registrado en el sistema";
                }
                
            }
            catch (Exception e)
            {

                return "Error de Datos: " + e.Message;
            }
        }

        public string Eliminar(string numeroLiquidacion)
        {
            try
            {
                if (cuotaRepository.Buscar(numeroLiquidacion)!=null)
                {
                    cuotaRepository.Eliminar(numeroLiquidacion);
                    return $"se elimino la liquidacion numero: {numeroLiquidacion} correctamente";
                }
                return $"El numero de liquidacion no esta registrado en el sistema";
            }
            catch (Exception e)
            {
                return $"ERROR" + e.Message;
            }
        }

        public RespuestaConsulta ConsultarConsultaGeneral()
        {
            RespuestaConsulta respuesta = new RespuestaConsulta();
            try
            {
                respuesta.Error = false;
                respuesta.liquidaciones = cuotaRepository.Consultar();
                if (respuesta.liquidaciones!=null)
                {
                    respuesta.Mensaje = "LISTADO DE LIQUIDACIONES";
                }
                else
                {
                    respuesta.Mensaje = "NO HAY DATOS";
                }
            }
            catch (Exception e)
            {

                respuesta.Error = true;
                respuesta.Mensaje = $"ERROR" + e.Message;
            }
            return respuesta;
        }

        public string Modificar(LiquidacionCuotaModeradora liquidacion)
        {
            try
            {
                if (cuotaRepository.Buscar(liquidacion.NumeroLiquidacion)!=null)
                {
                    cuotaRepository.Modificar(liquidacion);
                    return $"la liquidacion numero: {liquidacion.NumeroLiquidacion} ha sido modificada con exito!";

                }
                return $"El numero de liquidacion: {liquidacion.NumeroLiquidacion} no se encuentra registrada por favor verifique los datos";

            }
            catch (Exception e)
            {

                return "Error de datos" + e.Message;
            }
        }

        public LiquidacionCuotaModeradora BuscarID(string numeroLiquidacion)
        {
            LiquidacionCuotaModeradora liquidacion = new LiquidacionCuotaModeradora();
            try
            {
                return cuotaRepository.Buscar(numeroLiquidacion);
            }
            catch (Exception e)
            {
                string mensaje = " ERROR" + e.Message;
                return null;
            }
        }

        public RespuestaBusqueda Buscar(string numeroLiquidacion)
        {
            RespuestaBusqueda respuesta = new RespuestaBusqueda();
            try
            {
                respuesta.Error = false;
                respuesta.liquidacion = cuotaRepository.Buscar(numeroLiquidacion);
                if (respuesta.liquidacion!=null)
                {
                    respuesta.Mensaje = "Se encontro una liquidación, proceda...";
                }
                else
                {
                    respuesta.Mensaje = "No hay una liquidacion asociada al numero digitado, VERIFIQUE!";
                }
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Error = true;
                respuesta.Mensaje = "ERROR: " + e.Message;
                respuesta.liquidacion = null;
                return respuesta;
            }
        }
        
    }

    public class RespuestaBusqueda
    {
        public string Mensaje { get; set; }
        public LiquidacionCuotaModeradora liquidacion { get; set; }
        public bool Error { get; set; }
    }

    public class RespuestaConsulta
    {
        public string Mensaje { get; set; }
        public List<LiquidacionCuotaModeradora> liquidaciones { get; set; }
        public bool Error { get; set; }
    }
}
