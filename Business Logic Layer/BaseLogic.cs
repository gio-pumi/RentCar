
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar { 
    public class BaseLogic:IDisposable
    {
        public RentCarEntities DB = new RentCarEntities();

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}