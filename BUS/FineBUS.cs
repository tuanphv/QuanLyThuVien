using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class FineBUS
    {
        private readonly FineDAO fineDAO = new FineDAO();
        public bool AddFine(FineDTO fine)
        {
            return fineDAO.AddFine(fine);
        }
        public List<FineDTO> GetAllFines()
        {
            return fineDAO.GetAllFines();
        }

        public List<FineDTO> SearchFinesByReader(string keyword)
        {
            return fineDAO.SearchFinesByReader(keyword);
        }

    }
}
