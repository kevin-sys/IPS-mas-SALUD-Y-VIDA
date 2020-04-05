using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;

namespace IPS
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.Clear();
            LiquidacionCuotaModeradoraService service = new LiquidacionCuotaModeradoraService();
            int opcion;
            do
            {
                Console.WriteLine("\t\t\t _______________________________");
                Console.WriteLine("\t\t\t|        MENU PRINCIPAL         |");
                Console.WriteLine("\t\t\t|_______________________________|");
                Console.WriteLine("\t\t\t|  1 Registrar una liquidacion  |");
                Console.WriteLine("\t\t\t|  2 Listado de  liquidaciones  |");
                Console.WriteLine("\t\t\t|  3 Eliminar una liquidacion   |");
                Console.WriteLine("\t\t\t|  4 Modificar una liquidacion  |");
                Console.WriteLine("\t\t\t|  5 Salir del sistema          |");
                Console.WriteLine("\t\t\t|_______________________________|");
                Console.Write("\t\t\t  Escoja una opcion: ");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Guardar(service);
                        break;
                    case 2:
                        ConsultaGeneral(service);
                        break;
                    case 3:
                        Eliminar();
                        break;
                    case 4:
                        Modificar(service);
                        break;
                    case 5:
                        Console.SetCursorPosition(25, 15);
                        Console.WriteLine("Gracias por usar el sistema");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Opcion invalida");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (opcion!=5);
        }

        private static void Guardar(LiquidacionCuotaModeradoraService service)
        {
            Console.Clear();
            string numeroLiquidacion, identificacion, nombre, tipoAfiliacion;
            double salarioDevengado, valorServicioHospitalizacion;
            Console.Write("Digite numero de liquidacion: ");
            numeroLiquidacion = Console.ReadLine();

            Console.Write("Digite identificacion: ");
            identificacion = Console.ReadLine();

            Console.Write("Digite nombre: ");
            nombre = Console.ReadLine();

            Console.Write("Digite tipo de afiliacion: ");
            tipoAfiliacion = Console.ReadLine();

            Console.Write("Digite salario devengado: ");
            salarioDevengado = double.Parse(Console.ReadLine());

            Console.Write("Digite valor servicio de hospitalizacion: ");
            valorServicioHospitalizacion = double.Parse(Console.ReadLine());

            LiquidacionCuotaModeradora liquidacion = new LiquidacionCuotaModeradora()
            {
                NumeroLiquidacion = numeroLiquidacion,
                Identificacion = identificacion,
                Nombre = nombre,
                TipoAfiliacion = tipoAfiliacion,
                SalarioDevengado = salarioDevengado,
                ValorServicioHospitalizacion = valorServicioHospitalizacion
            };

            service.calcularLiquidacion(liquidacion);
            string mensaje=service.Guardar(liquidacion);
            Console.Write(mensaje);
            Console.ReadKey();
            Console.Clear();
        }

        public static void Eliminar()
        {
            Console.Clear();
            Console.WriteLine("ELIMINAR UNA LIQUIDACION");
            LiquidacionCuotaModeradora liquidacion = new LiquidacionCuotaModeradora();
            LiquidacionCuotaModeradoraService service = new LiquidacionCuotaModeradoraService();
            Console.Write("Digite numero de liquidacion a eliminar: ");
            string numeroLiquidacion;
            numeroLiquidacion = Console.ReadLine();
            string mensaje = service.Eliminar(numeroLiquidacion);
            Console.WriteLine(mensaje);
            Console.ReadKey();
            Console.Clear();
        }

        private static void ConsultaGeneral(LiquidacionCuotaModeradoraService service)
        {
            Console.Clear();
            RespuestaConsulta respuestaConsulta = service.ConsultarConsultaGeneral();
            Console.WriteLine(respuestaConsulta.Mensaje);
            if (!respuestaConsulta.Error)
            {
                
                foreach (var item in respuestaConsulta.liquidaciones)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        private static void Modificar(LiquidacionCuotaModeradoraService service)
        {
             Console.Clear();
           
            Console.WriteLine("\tMODIFICAR UNA LIQUIDACION");
            Console.Write("\tDigite numero de liquidacion: ");
            string numeroLiquidacion;
            numeroLiquidacion = Console.ReadLine();
            RespuestaBusqueda respuestaBusqueda = service.Buscar(numeroLiquidacion);
            Console.WriteLine(respuestaBusqueda.Mensaje);

            LiquidacionCuotaModeradora liquidacion = service.BuscarID(numeroLiquidacion);
            if (liquidacion!=null)
            {
                Console.Write("Ingrese nuevo valor del servicio de hospitalizacion: ");
                liquidacion.ValorServicioHospitalizacion = double.Parse(Console.ReadLine());
                service.calcularLiquidacion(liquidacion);
                string mensaje = service.Modificar(liquidacion);
                Console.Write(mensaje);
                Console.WriteLine(liquidacion.ToString());
                Console.ReadKey();
                Console.Clear();
            }
        }

    }
}
