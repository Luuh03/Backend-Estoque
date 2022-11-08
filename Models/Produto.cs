namespace AplicacaoEstoque.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public float Preco { get; set; }
        public int qtdeEstoque { get; set; }
        public string? Fabricante { get; set; }
    }
}
