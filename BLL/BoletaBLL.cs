using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BoletaBLL
    {

        public DataTable GetBoletasPorPagar()
        {
            BoletaDAL bolDAL = new BoletaDAL();
            return bolDAL.BoletasPorPagar();
        }

        public bool SetPagado(int id, string v)
        {
            BoletaDAL bolDAL = new BoletaDAL();
            return  bolDAL.PagaBoleta(id, v);
        }
    }
}
