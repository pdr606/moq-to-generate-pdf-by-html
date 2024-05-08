using System.Text;

namespace itext_sharp.Controllers
{
    public static class BuscarHtml
    {
        public static string LerHtmlParaString(PedidoViewModel pedido)
        {
            string htmlFilePath = "C:\\Users\\pedro.guarnieri\\source\\repos\\itext-sharp\\itext-sharp\\Controllers\\comanda.html";

            if (File.Exists(htmlFilePath))
            {
                string htmlContent = File.ReadAllText(htmlFilePath); 

                htmlContent = htmlContent.Replace("[[NUMERO_PEDIDO]]", pedido.NumeroPedido);
                htmlContent = htmlContent.Replace("[[RESTAURANTE]]", pedido.Restaurante);
                htmlContent = htmlContent.Replace("[[DATA]]", pedido.Data);
                htmlContent = htmlContent.Replace("[[ENTREGA_PREVISTA]]", pedido.EntregaPrevista);
                htmlContent = htmlContent.Replace("[[OBSERVACAO]]", pedido.Observacao);
                htmlContent = htmlContent.Replace("[[MESA]]", pedido.Mesa);
                htmlContent = htmlContent.Replace("[[GARCOM]]", pedido.Garcom);

                StringBuilder itensHtml = new StringBuilder();
                foreach (var item in pedido.Pedidos)
                {
                    itensHtml.Append($"<tr><td style='font-size:8px'>{item.Quantidade}</td><td style='font-size:8px'>{item.Item}</td><td style='font-size:8px'>R$ {item.Preco}</td></tr>");
                }
                htmlContent = htmlContent.Replace("[[ITENS_PEDIDO]]", itensHtml.ToString());

                return htmlContent;
            }
            else
            {
                throw new Exception("Arquivo HTML não encontrado.");
            }
        }
    }

}
