using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using iText.Html2pdf;
using System.IO;

namespace itext_sharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PdfController : ControllerBase
    {

        [HttpGet]
        public FileStreamResult DowloadPDF()
        {

            var pedido = new PedidoViewModel
            {
                NumeroPedido = "#6543",
                Restaurante = "4Tables",
                Data = "01/05/2024 - 16:44:31",
                EntregaPrevista = "17:54",
                Observacao = "Solicite o codigo de confirmacao na hora da entrega.",
                Mesa = "10",
                Garcom = "Pedro Henrique",
                Pedidos = new List<Pedido>
            {
                new Pedido { Quantidade = 1, Item = "Banana", Preco = 12.60m },
                new Pedido { Quantidade = 5, Item = "Manga", Preco = 22.60m },
                new Pedido { Quantidade = 1, Item = "Banana", Preco = 12.60m },
                new Pedido { Quantidade = 1, Item = "Banana", Preco = 12.60m },
                new Pedido { Quantidade = 1, Item = "Banana", Preco = 12.60m },
                new Pedido { Quantidade = 1, Item = "Banana", Preco = 12.60m },
                new Pedido { Quantidade = 1, Item = "Banana", Preco = 12.60m },
                new Pedido { Quantidade = 1, Item = "Banana", Preco = 12.60m },
                new Pedido { Quantidade = 1, Item = "Banana", Preco = 12.60m },
                new Pedido { Quantidade = 1, Item = "Banana", Preco = 12.60m },
                new Pedido { Quantidade = 1, Item = "Banana", Preco = 12.60m },
                new Pedido { Quantidade = 1, Item = "Banana", Preco = 12.60m },
                new Pedido { Quantidade = 1, Item = "Banana", Preco = 12.60m },
                new Pedido { Quantidade = 1, Item = "Banana", Preco = 12.60m },
                new Pedido { Quantidade = 1, Item = "Banana", Preco = 12.60m },
                new Pedido { Quantidade = 1, Item = "Banana", Preco = 12.60m },
                new Pedido { Quantidade = 1, Item = "Banana", Preco = 12.60m },
                new Pedido { Quantidade = 1, Item = "Banana", Preco = 12.60m },
                new Pedido { Quantidade = 1, Item = "Banana", Preco = 12.60m },
                new Pedido { Quantidade = 1, Item = "Banana", Preco = 12.60m },
                new Pedido { Quantidade = 1, Item = "Banana", Preco = 12.60m },
                new Pedido { Quantidade = 1, Item = "Banana", Preco = 12.60m },

            }
            };

            string HTMLContent = BuscarHtml.LerHtmlParaString(pedido);

            var ms = new MemoryStream();
            TextReader textReader = new StringReader(HTMLContent);

            Document doc = new Document(PageSize.B7, 10, 10, 0, 0);
            PdfWriter pdfWriter = PdfWriter.GetInstance(doc, ms);
            pdfWriter.CloseStream = false;

            HTMLWorker hTMLWorker = new HTMLWorker(doc);

            doc.Open();
            hTMLWorker.StartDocument();
            hTMLWorker.Parse(textReader);
            hTMLWorker.EndDocument();
            hTMLWorker.Close();
            doc.Close();

            ms.Flush();
            ms.Position = 0;

            return File(ms, "application/pdf", "HelloWorld.pdf");
        }
    }
}
