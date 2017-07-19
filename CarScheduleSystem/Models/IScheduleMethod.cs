using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarScheduleSystem.Models
{
    /// <summary>
    /// 调度方法接口
    /// </summary>
    public interface IScheduleMethod
    {
        CarModel removeVOVCarFromWaitQueue();
        CarModel removeVOVCarFromRunQueue();
        void addVOVCarModelInRunQueue(CarModel carModel);
        void addVOVCarModelInWaitQueue(CarModel carModel);

        CarModel removeYWKCarFromWaitQueue();
        CarModel removeYWKCarFromRunQueue();
        void addYWKCarModelInRunQueue(CarModel carModel);
        void addYWKCarModelInWaitQueue(CarModel carModel);
        void addDaoZhanListInWaitQueue(List<CarModel> carList);
        void addPersonsInWaitQueue(List<Person> persons);
    }
}
