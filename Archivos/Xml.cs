using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace Archivos
{
  public class Xml<T> : IArchivo<T>
  {
    public bool Guardar(string archivo, T dato)
    {

      bool todoOk = true;


      try
      {

        XmlTextWriter writer;
        writer = new XmlTextWriter(archivo, System.Text.Encoding.UTF8);
        XmlSerializer ser;
        ser = new XmlSerializer(typeof(T));
        ser.Serialize(writer, dato);

      }
      catch (Exception)
      {
        todoOk = false;
      }

      return todoOk;
    }

    public bool Leer(string archivo, out T datos)
    {
      bool todoOk = true;
      

      try
      {
        XmlTextReader reader;
        reader = new XmlTextReader(archivo);

        XmlSerializer ser = new XmlSerializer(typeof(T));
        datos = (T)ser.Deserialize(reader);

        reader.Close();

      }
      catch (Exception)
      {
        todoOk = false;
        datos = default(T);
        
      }

      return todoOk;
    }



  }
}
