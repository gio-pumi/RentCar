using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar
{
    public class BranchLogic : BaseLogic
    {
        //Get branches
        public List<branchDTO> getBranch()
        {
            var branches = from b in DB.Branches
                          select new branchDTO
                          {
                              address = b.address,
                              exactLocation= b.location,
                              name = b.name,
                          };

            return branches.ToList();
        }
    }
}
