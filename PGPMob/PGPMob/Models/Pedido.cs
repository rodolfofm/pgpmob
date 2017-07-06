using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGPMob.Models
{
    public class Pedido
    {
        public string orc_tipo { get; set; }
        public int uni_codigo { get; set; }
        public int orc_codigo { get; set; }
        public long orc_pedido { get; set; }
        public string orc_pedidoFormatado { get; set; }
        public string orc_status { get; set; }
        public DateTime orc_pedido_dh { get; set; }
        public decimal valorpedido { get; set; }
        public string cli_cpf_cnpj { get; set; }
        public string cli_tipo { get; set; }
        public string cli_codigo_nome { get; set; }
        public int cli_codigo { get; set; }
        public string cli_nome { get; set; }
        public Endereco endereco { get; set; }
        public object orcamentonfe { get; set; }
        public string nfe_status { get; set; }
        public string nfe_status_nf_codigo { get; set; }
        public string lote_status { get; set; }
        public string nfe_status_lote_codigo { get; set; }
        public string nfe_inclusaoregistro { get; set; }
        public string nfe_status_datahora { get; set; }
        public string nfe_consumidor { get; set; }
        public object[] produtos { get; set; }
    }

    public class Endereco
    {
        public string logradouro { get; set; }
        public string numero { get; set; }
        public object bairro { get; set; }
        public string complemento { get; set; }
        public string cep { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string email { get; set; }
        public int cd_municipio { get; set; }
        public string telefone { get; set; }
    }

}
