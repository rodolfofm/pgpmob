using System.Collections.Generic;
using System.Threading.Tasks;
using PGPMob.Models;

namespace PGPMob.Services
{
    public interface IPGPMobApiService
    {
        Task<Usuario> PostValidaUsuario(string usuario, string senha);
        Task<Pedido[]> PostConsultaPedidoAsync(string searchTerm);
    }
}