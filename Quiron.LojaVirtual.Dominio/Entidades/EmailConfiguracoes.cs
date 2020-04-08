namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class EmailConfiguracoes
    {
        public string De = "quiron@quiron.com.br";
        public bool EscreverArquivo = false;
        public string Para = "pedido@quiron.com.br";
        public string PastaArquivo = @"c:\enviaremail";
        public int ServidorPorta =587;
        public string ServidorSmtp = "stmp.quiron.com.br";
        public bool UsarSsl = false;
        public string Usuario = "quiron";
    }
}