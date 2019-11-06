using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
  public class Texto : IArchivo<string>
  {
    public bool Guardar(string archivo, string datos)
    {
      bool todoOk = true;

      try
      {

        StreamWriter escribir = new StreamWriter(archivo);
        escribir.WriteLine(datos);
        escribir.Close();

      }
      catch (Exception)
      {

        todoOk = false;
      }

      return todoOk;

    }

    public bool Leer(string archivo, out string datos)
    {

      bool todoOk = true;
      string dato = "";
      

      try
      {
        StreamReader leer = new StreamReader(archivo);

        while (!leer.EndOfStream)
        {
          dato +=leer.ReadLine() + "\n";
        }
        leer.Close();
      }
      catch (Exception)
      {
        todoOk = false;

      }

      datos = dato;

      return todoOk;
    }


  }
}
