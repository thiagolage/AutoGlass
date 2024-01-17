using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGlass.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string Descricao { get; set; } = null!;

        public bool Ativo { get; set; }

        public DateTimeOffset? DataFabricacao { get; set; }

        public DateTimeOffset? DataValidade { get; set; }

        public int? IdFornecedor { get; set; }

        public string? DescricaoFornecedor { get; set; }

        public string? CNPJFornecedor { get; set; }

    }
}
