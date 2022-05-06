using ClienteSocketUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioClienteSockets
{
    class Program
    {
        static void GenerarComunicacion(ClienteSockets clienteSockets)
        {
            Console.Clear();
            bool terminar = false;
            while (!terminar)
            {
                Console.WriteLine("Ingrese que quiere decir: ");
                string mensaje = Console.ReadLine().Trim();
                clienteSockets.Escribir(mensaje);
                if (mensaje.ToLower() == "chao")
                {
                    terminar = true;
                }
                else
                {
                    mensaje = clienteSockets.Leer();
                    if (mensaje != null)
                    {
                        Console.WriteLine("S: {0}", mensaje);
                        if (mensaje.ToLower() == "chao")
                        {
                            terminar = true;
                        }
                    }
                    else
                    {
                        terminar = true;
                    }
                }
            }
            clienteSockets.Desconectar();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese IP de Servidor");
            string servidor = Console.ReadLine().Trim();
            int puerto;

            do
            {
                Console.WriteLine("Ingrese Puerto");
            }
            while (!Int32.TryParse(Console.ReadLine().Trim(), out puerto));

            Console.WriteLine("Conectado...");

            ClienteSockets clientesockets = new ClienteSockets(servidor, puerto);

            if (clientesockets.Conectar())
            {
                GenerarComunicacion(clientesockets);
            }
            else
            {
                Console.WriteLine("Error de Coneccion");
            }
            Console.ReadKey();
        }
    }
}
