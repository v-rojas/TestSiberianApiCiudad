using ApiCiudad.Models;
using System.Collections.Generic;

namespace ApiCiudad.Interfaces
{
    public interface ICrudCiudad
    {
        List<Ciudad> SpMetodos(Ciudad ciudad);
    }
}
