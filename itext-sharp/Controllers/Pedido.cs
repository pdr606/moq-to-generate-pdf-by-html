namespace itext_sharp.Controllers
{
    public class Pedido
    {
        public int Quantidade { get; set; }
        public string Item { get; set; }
        public decimal Preco { get; set; }
    }

    public class PedidoViewModel
    {
        public string NumeroPedido { get; set; }
        public string Restaurante { get; set; }
        public string Data { get; set; }
        public string EntregaPrevista{ get; set; }
        public string Observacao { get; set; }
        public string Mesa { get; set; }
        public string Garcom { get; set; }
        public List<Pedido> Pedidos { get; set; } = new();
    }
}
