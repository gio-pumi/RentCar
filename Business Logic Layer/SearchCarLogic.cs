using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar
{
    public class SearchCarLogic : BaseLogic
    {
        //Search Car In DB

        public List<displayCarDTO> SearchCar(SearchCarDTO searchedCar)
        {
            var checkedCar = from c in DB.CarTypes
                             join CarFleet in DB.CarFleets on c.CarTypeID equals CarFleet.CarTypeID
                             where searchedCar.manufacturer == c.CarManufacturerName &&
                                   searchedCar.model == c.CarModelName &&
                                   searchedCar.transmission == c.GearTypeName &&
                                   searchedCar.productionYear == c.Year &&
                                   CarFleet.IsOK2Rent == true
                             && !(from orders in DB.Rentals
                                  where orders.StartDate <= searchedCar.startDate &&
                                        orders.EndDate >= searchedCar.startDate ||
                                        orders.StartDate <= searchedCar.endDate &&
                                        orders.EndDate >= searchedCar.endDate ||
                                        orders.StartDate >= searchedCar.startDate &&
                                        orders.EndDate <= searchedCar.endDate
                                  select orders.CarFleetID).ToList().Contains(CarFleet.CarFleetID)
                             select
                                    new displayCarDTO
                                    {
                                        productionYear = c.Year,
                                        pricePerDay = c.DailyCost,
                                        pricePerDayIfDalay = c.DailyLateCost,
                                        model = c.CarModelName,
                                        manufacturer = c.CarManufacturerName,
                                        transmission = c.GearTypeName,
                                        mileage = CarFleet.CarMileage,
                                        image = CarFleet.CarImage,
                                        properForRent = CarFleet.IsOK2Rent,
                                        avilable = CarFleet.CarAvilable,
                                        number = CarFleet.CarNumber,
                                        branchPlace  = CarFleet.CarBranchPlace
                                       //image = c.ImageFileName;
    };
            return checkedCar.ToList();
        }
    }
}
