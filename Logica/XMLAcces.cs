using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Linq;
using System.Xml;
using Items;
using EntidadesCompartidas;


namespace Logica
{
    public class XMLAcces
    {
        public static string buscarEnXML(string idempleado)
        {
            XDocument miXML = XDocument.Load(@"D:\\Documentos\\Visual Studio 2010\\Projects\\LeerXML\\Sob_219999830019_20150423_1.xml"); //Cargar el documento

            XNamespace nsy = "http://cfe.dgi.gub.uy";

            var CFEs = from xml in miXML.Descendants(nsy + "EnvioCFE_entreEmpresas") select xml;
            string Message = "";
            foreach (XElement minom in CFEs.Elements(nsy + "CFE_Adenda"))
            {
                Message += minom.Element(nsy + "CFE").Value + "\n"; //Mostramos un mensaje con el nombre del empleado que corresponde
            }
            XDocument doc = new XDocument(Message);

            return Message;
        }
    }
}
