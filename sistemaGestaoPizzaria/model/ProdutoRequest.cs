using System.Xml.Serialization;

namespace sistemaGestaoPizzaria.model
{
    [XmlRoot("produto")]
    public class ProdutoRequest
    {
        [XmlElement("nome")]
        public string nome { get; set; }

        [XmlElement("tempoDePreparo")]
        public int tempoDePreparo { get; set; }
    }
}
