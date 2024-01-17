using System.Text.Json.Serialization;

namespace AutoGlass.API.DTOs
{
    public class ProdutoDTO
    {
        [JsonPropertyName("Descrição")]
        public string Descricao { get; set; } = null!;

        public string? Status { get; set; }

        [JsonPropertyName("Data de Fabricação")]
        public DateTimeOffset? DataFabricacao { get; set; }

        [JsonPropertyName("Data de Validade")]
        public DateTimeOffset? DataValidade { get; set; }

        [JsonPropertyName("Nome Fornecedor")]
        public string? DescricaoFornecedor { get; set; }

        [JsonPropertyName("CNPJ Fornecedor")]
        public string? CNPJFornecedor { get; set; }
    }
}
