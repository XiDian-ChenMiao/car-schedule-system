using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarScheduleSystem.Models
{
    /// <summary>
    /// 宝鸡去西安方向产生乘客的工厂类
    /// </summary>
    class BJ2XNPersonFactory : IPersonFactory
    {
        /// <summary>
        /// 宝鸡车站生成乘客的工厂类构造函数
        /// </summary>
        public BJ2XNPersonFactory() : base()
        {
            this.maxPersonPerMinuteToStation = ISystemConfig.BJ2XN_PERSON_COUNT_PER_MINUTE_TO_STATION;
        }
        /// <summary>
        /// 设置去沿途站点的可能性
        /// </summary>
        public override void setDownCarPossibility()
        {
            Random random = new Random();
            //宝鸡到虢镇方向的可能性设置
            downCarWhenInDestination[0] = Math.Round(0.0 + random.NextDouble() * (ISystemConfig.BJ2XN_GZ_POSIBILITY - 0.0), 2);
            //宝鸡到蔡家坡方向的可能性设置
            downCarWhenInDestination[1] = Math.Round(ISystemConfig.BJ2XN_GZ_POSIBILITY + random.NextDouble() * (ISystemConfig.BJ2XN_CP_POSIBILITY - ISystemConfig.BJ2XN_GZ_POSIBILITY), 2);
            //宝鸡到武功方向的可能性设置
            downCarWhenInDestination[2] = Math.Round(ISystemConfig.BJ2XN_CP_POSIBILITY + random.NextDouble() * (ISystemConfig.BJ2XN_WG_POSIBILITY - ISystemConfig.BJ2XN_CP_POSIBILITY), 2);
            //宝鸡到兴平方向的可能性设置
            downCarWhenInDestination[3] = Math.Round(ISystemConfig.BJ2XN_WG_POSIBILITY + random.NextDouble() * (ISystemConfig.BJ2XN_XP_POSIBILITY - ISystemConfig.BJ2XN_WG_POSIBILITY), 2);
            //宝鸡到咸阳方向的可能性设置
            downCarWhenInDestination[4] = Math.Round(ISystemConfig.BJ2XN_XP_POSIBILITY + random.NextDouble() * (ISystemConfig.BJ2XN_XY_POSIBILITY - ISystemConfig.BJ2XN_XP_POSIBILITY), 2);
            double totalOtherPossibility = 0.0;
            for(int i = 0;i < ISystemConfig.TOTAL_STATION_COUNT - 1;i++)
            {
                totalOtherPossibility += downCarWhenInDestination[i];
            }
            //宝鸡到西安方向的可能性设置
            downCarWhenInDestination[5] = 1.0 - totalOtherPossibility;
        }
        /// <summary>
        /// 宝鸡车站按照频率要求生成的进站人数
        /// </summary>
        /// <returns></returns>
        public override List<Person> generatePerson()
        {
            List<Person> persons = new List<Person>();
            Random random = new Random();
            //随机在宝鸡站产生去西安方向的进站人数
            int randomInStation = random.Next(1, ISystemConfig.BJ2XN_PERSON_COUNT_PER_MINUTE_TO_STATION);
            for (int i = 0; i < randomInStation; ++i)
            {
                Person person = new Person(this.downCarWhenInDestination, ISystemConfig.STATION_BJ, ISystemConfig.STATION_XN);
                persons.Add(person);
            }
            return persons;
        }
    }
}
