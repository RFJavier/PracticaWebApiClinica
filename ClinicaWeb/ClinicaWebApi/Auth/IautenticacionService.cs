using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaWeb.EntidadesDeNegocio;
namespace ClinicaWebApi.Auth
{
    public interface IautenticacionService
    {
        string Authenticate(Usuario pusuario);
    }
}
