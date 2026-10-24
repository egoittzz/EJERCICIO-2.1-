using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;

String ruta = ("./Gestor_de_archivos_Egoitz");
const String ruta_inicio = ("./Gestor_de_archivos_Egoitz");



if (!Directory.Exists(ruta_inicio))
{
    try
    {
        Directory.CreateDirectory(ruta_inicio);
        Console.WriteLine("El directorio a sido creado");
    }
    catch (Exception error)
    {
        Console.WriteLine("Lo sentimos se a producido un error :" + error.Message);
    }
}
try
{
    mostrar_menu();
    int decision = int.Parse(Console.ReadLine());
    Console.Clear();


    while (decision != 5)
    {


        switch (decision)
        {
            case 1:
                CrearFichero();
                break;
            case 2:
                AñadirRegistros_BorrarArchivos_borrar();
                break;
            case 3:
                crearDirectorio();
                break;
            case 4:
                Borrarcarpetas();
                break;
            default:
                Console.WriteLine("No se a encontrado el indice de la tarea");
                break;

        }
        mostrar_menu();
        decision = int.Parse(Console.ReadLine());
        Console.Clear();
    }
}
catch (Exception error)
{
    Console.WriteLine("Lo sentimos se a producido un error :" + error.Message);
}
void CrearFichero()
{
    try
    {
        Console.WriteLine("Escribe el nombre del fichero (Si quieres que se guarde en otra carpeta escribe 0 )");
        String Nombre = Console.ReadLine();
        if (Nombre == "0")
        {
            ruta = moversePorCarpetas();
            Console.WriteLine("Escribe el nombre del archivo que quieres crear");
            Nombre = Console.ReadLine();
            ruta = ruta + "/" +Nombre;
            FileStream archivo = File.Create(ruta);
            archivo.Close();
            Console.WriteLine("Tu archivo se a creado");
        }
        else
        {


            ruta = "./Gestor_de_archivos_Egoitz/" + Nombre;

            FileStream archivo = File.Create(ruta);
            archivo.Close();
            Console.WriteLine("Tu archivo" + Nombre + " se a creado");


        }
    }
    catch (Exception error)
    {
        Console.WriteLine("Lo sentimos se a producido un error :" + error.Message);
    }

}
void AñadirRegistros_BorrarArchivos_borrar()
{
    try
    {
        String carpetaActual = "./Gestor_de_archivos_Egoitz";

        String[] archivos = Directory.GetFiles(carpetaActual);

        if (archivos.Length > 0)
        {
            mostrar_opciones(archivos);
        }
        else
        {
            Console.WriteLine("No hay archivos en esta carpeta.");
        }

        Console.WriteLine("[0] Navegar a otra carpeta");
        Console.WriteLine("Elige un archivo:");
        int eleccion = int.Parse(Console.ReadLine());

        if (eleccion == 0)
        {
            carpetaActual = moversePorCarpetas();
            Console.Clear();

            archivos = Directory.GetFiles(carpetaActual);

            if (archivos.Length > 0)
            {
                mostrar_opciones(archivos);
                eleccion = int.Parse(Console.ReadLine());
                ruta = archivos[eleccion-1];
                Console.WriteLine("Que quieres hacer ?");
                Console.WriteLine("[0] Borrar contenido del archivo");
                Console.WriteLine("[1] Escribir en el archivo");
                Console.WriteLine("[2] Borrar arvhivo PERMANENTEMENTE");
                Console.WriteLine("[3] Visualizar archivo");
                int decision = int.Parse(Console.ReadLine());
                switch (decision)
                {
                    case 0:
                        File.WriteAllText(ruta, string.Empty);
                        Console.Clear();
                        break;
                    case 1:
                        escribir(ruta);
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Pulsa 0 si estas seguro de que quieres borrar el archivo, si tiene contenido detro se perdera ");
                        int deci = int.Parse(Console.ReadLine());
                        if (deci == 0)
                        {
                            File.Delete(ruta);
                        }

                        Console.WriteLine("El archivo se a borrado correctamente");
                        Console.Clear();
                        break;
                    case 3:
                        leer(ruta);
                        break;
                    default:
                        break;
                }


            }
            else
            {
                Console.WriteLine("No hay archivos en esta carpeta.");
                return;
            }
            
        }
        else
        {
            ruta = archivos[eleccion - 1];
            Console.WriteLine("Que quieres hacer ?");
            Console.WriteLine("[0] Borrar contenido del archivo");
            Console.WriteLine("[1] Escribir en el archivo");
            Console.WriteLine("[2] Borrar arvhivo PERMANENTEMENTE");
            Console.WriteLine("[3] Visualizar archivo");
            int decision = int.Parse(Console.ReadLine());

            switch (decision)
            {
                case 0:
                    File.WriteAllText(ruta, string.Empty);
                    Console.Clear();
                break;
                case 1:
                    escribir(ruta);
                    Console.Clear();
                break;
                case 2:
                    Console.WriteLine("Pulsa 0 si estas seguro de que quieres borrar el archivo, si tiene contenido detro se perdera ");
                    int deci = int.Parse(Console.ReadLine());
                    if (deci == 0)
                    {
                        File.Delete(ruta);
                    }

                    Console.WriteLine("El archivo se a borrado correctamente");
                    Console.Clear();
                    break;
                case 3:
                    leer(ruta);
                break;
                default:
                break;
            }
        }

    }
    catch (Exception error)
    {
        Console.WriteLine("Lo sentimos se ha producido un error: " + error.Message);
    }
}   

void escribir (String archivo)
{
    try
    {
        List<String> lineas = File.ReadAllLines(archivo).ToList();
        interfazDeEscritura(lineas);
        String escritura = Console.ReadLine();
        Console.Clear();


        while (escritura != "0")
        {
            lineas.Add(escritura);
            interfazDeEscritura(lineas);
            escritura = Console.ReadLine();
            Console.Clear();
        }

        File.WriteAllLines(archivo, lineas);

    }
    catch(Exception error)
    {
        Console.WriteLine("Lo sentimos se a producido un error :" + error.Message);
    }
    
}
void crearDirectorio()
{
    try
    {


        Console.WriteLine("Como quieres que se llame tu Carpeta (Si quieres que este dentro de otra carpeta pulsa 0)");
        String respuestas = Console.ReadLine();

        if (respuestas == "0")
        {
            ruta = moversePorCarpetas();
            Console.WriteLine("Como quieres que se llame la carpeta");
            respuestas = Console.ReadLine();
            ruta = ruta + "/" + respuestas;
            Directory.CreateDirectory(ruta);
            Console.WriteLine("La carpeta a sido creada correctamente");
        }
        else
        {
            ruta = "./Gestor_de_archivos_Egoitz/" + respuestas;
            Directory.CreateDirectory(ruta);
            Console.WriteLine("La carpeta a sido creada correctamente");

        }
    }
    catch (Exception error)
    {
        Console.WriteLine("Lo sentimos se a producido un error :" + error.Message);
    }
}
void Borrarcarpetas()
{
    try
    {
        Console.WriteLine("Selecciones la carpeta que quieras borrar (La carpeta Gestor_de_archivos_Egoitz no se puede borrar )");
        ruta = moversePorCarpetas();
        Console.WriteLine("Pulsa 0 si estas seguro de que quieres borrar la carpeta, si tiene contenido detro se perdera ");
        int deci = int.Parse(Console.ReadLine());
        if(deci == 0)
        {
            Directory.Delete(ruta , true);
        }

    }catch(Exception error)
    {
        Console.WriteLine("Lo sentimos se a producido un error :" + error.Message);
    }
    
    
}
String moversePorCarpetas()
{
    try
    {
        int numRuta =1;
        int contador = 1;
        Console.WriteLine("Seleciona la ruta en la que quieras crear la carpera (Pulsa 0 para no seguir escribiendo la ruta)");
        ruta = ("./Gestor_de_archivos_Egoitz");
        do
        {
            String[] archivos = Directory.GetDirectories(ruta);

            if (archivos.Length == 0)
            {
                numRuta = 0;
                Console.WriteLine("No hay mas carpetas");

            }
            else
            {
                if (numRuta != 0)
                {
                    
                    mostrar_opciones(archivos);
                    numRuta = int.Parse(Console.ReadLine());
                    ruta = archivos[numRuta - 1];
                    contador = 1;
                    Console.Clear();
                }
                else if(numRuta == 0)
                {
                    Console.WriteLine(ruta);
                    
                }
               
            }


        } while (numRuta != 0);

        Console.WriteLine(ruta);
        
    }catch(Exception error)
    {
        
    }
    return ruta;
}
void mostrar_menu()
{
    Console.Clear();
    Console.WriteLine("======================");
    Console.WriteLine("  Gestor de archivos  ");
    Console.WriteLine("======================");

    Console.WriteLine("Que opcion quieres usar (Indice) :");
    Console.WriteLine("1. Crear un nuevo fichero");
    Console.WriteLine("2. Opciones disponibles:");
    Console.WriteLine("   - Añadir texto");
    Console.WriteLine("   - Borrar datos");
    Console.WriteLine("   - Eliminar el fichero");
    Console.WriteLine("   - Visualizar fichero");
    Console.WriteLine("3. Crear una nueva Carpeta");
    Console.WriteLine("4. Borrar una carpeta.");
    Console.WriteLine("5. Cerrar la aplicación.");
    Console.Write("Elige una opción del menú: ");
}
void leer( String ruta)
{
    String[] lineas = File.ReadAllLines(ruta).ToArray();
    int linea = 1;
    leerConRuta(ruta,lineas);
    linea = 1;
    Console.WriteLine("Pulsa 1 si quieres editar cualquier parte del archivo");
    
    Console.WriteLine("Pulse 0 para volver al menú:");

    String pulsado = Console.ReadLine();
    while (pulsado != "0")
    {
        switch (pulsado)
        {
            case "1":
                Console.WriteLine("Que linea quieres editar el numero de linea lo pone entre []");
                int editable = int.Parse(Console.ReadLine());
                Console.WriteLine("------------------------------------------------------------ Linea seleccionada ------------------------------------------------------------------");
                Console.WriteLine(lineas[editable - 1]);
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Escriba la correcion");
                String correcio = Console.ReadLine();
                lineas[editable -1] = correcio;
                File.WriteAllLines(ruta, lineas);
                leerConRuta(ruta,lineas);
                Console.WriteLine("Si quieres cambiar algo mas pusla 1 si no pulsa 0");
                
                
                break;
            default:
                Console.WriteLine("Numero incorrecto pulse 0 o 1");
            break;
        }
        
        pulsado = Console.ReadLine();
    }
    Console.Clear();
}
void mostrar_opciones(String [] archivos)
{
    int contador = 1;
    foreach (String archivo in archivos)
    {
        Console.WriteLine("[" + contador + "] " + archivo);
        contador++;
    }
}
void interfazDeEscritura(List<String>lineas)
{
    Console.WriteLine("-------------------Contenido del archivo------------------------------");
        foreach (string linea in lineas)
        {
            Console.WriteLine(linea);
        }
        Console.WriteLine("-----------------------------------------------------------------------");
        Console.WriteLine("Escriba lo que quieras para terminar pulse 0");
}
void leerConRuta(String ruta, String [] lineas)
{
    int linea = 1;
    Console.WriteLine("----------------------" + ruta + "------------------------------");
    foreach (String texto in lineas)
    {
        Console.WriteLine("["+linea+"] " + texto);
        linea ++;
    }
    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------");
    linea = 1;
}


