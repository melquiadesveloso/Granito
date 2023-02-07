using GranitoApi.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GranitoApi.Business
{
    public interface ICalculo
    {

        ResponseMessage Operacao(decimal valor, int meses);
    }
}
