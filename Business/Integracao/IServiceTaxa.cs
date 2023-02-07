using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GranitoApi.Business.Integracao
{
    public interface IServiceTaxa
    {
        decimal GetTaxa();

        HttpClient Service();
    }
}
