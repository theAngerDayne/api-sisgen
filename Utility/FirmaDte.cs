using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace api_sisgen.Utility
{
    public class FirmaDte
    {
        private X509Certificate2 Certificado { get; set; }

        public FirmaDte(string certificatePath, string password)
        {
            Certificado = new X509Certificate2(certificatePath, password);
        }


        ///
        /// Se le pasa un xml en string y lo devuelve firmado
        /// 
        /// xml no firmado
        /// si se quiere firmar una parte del xml se debe poner el #id, si no: ""
        /// para firmar semilla se requiere, para firmar envioDTE y DTE no se requiere
        public string Firmar(string xml, string referenceUri, bool addTransform)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.PreserveWhitespace = true;
            xmlDocument.LoadXml(xml);

            SignedXml signedXml = new SignedXml(xmlDocument);
            signedXml.SigningKey = Certificado.PrivateKey;

            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(new RSAKeyValue((RSA)Certificado.PrivateKey));
            keyInfo.AddClause(new KeyInfoX509Data(Certificado));

            Reference reference = new Reference();
            reference.Uri = referenceUri;

            if (addTransform)
            {
                reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            }

            Signature signature = signedXml.Signature;
            signature.SignedInfo.AddReference(reference);
            signature.KeyInfo = keyInfo;

            // Generar firma
            signedXml.ComputeSignature();

            // Insertar la firma en xmlDocument
            xmlDocument.DocumentElement.AppendChild(xmlDocument.ImportNode(signedXml.GetXml(), true));

            return xmlDocument.InnerXml;
        }
    }
}