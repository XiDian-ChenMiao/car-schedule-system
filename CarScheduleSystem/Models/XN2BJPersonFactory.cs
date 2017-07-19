using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarScheduleSystem.Models
{
    /// <summary>
    /// 西安去宝鸡方向产生乘客的工厂类
    /// </summary>
    class XN2BJPersonFactory : IPersonFactory
    {
        /// <summary>
        /// 宝鸡车站生成乘客的工厂类构造函数
        /// </summary>
        public XN2BJPersonFactory() : base()
        {
            this.maxPersonPerMinuteToStation = ISystemConfig.XN2BJ_PERSON_COUNT_PER_MINUTE_TO_STATION;
        }
        /// <summary>
        /// 设置去沿途站点的可能性
        /// </summary>
        public override void setDownCarPossibility()
        {
            Random random = new Random();
            //西安到咸阳方向的可能性设置
            downCarWhenInDestination[0] = Math.Round(0.0 + random.NextDouble() * (ISystemConfig.XN2BJ_XY_POSIBILITY - 0.0), 2);
            //西安去兴平方向的可能性设置
            downCarWhenInDestination[1] = Math.Round(ISystemConfig.XN2BJ_XY_POSIBILITY + random.NextDouble() * (ISystemConfig.XN2BJ_XP_POSIBILITY - ISystemConfig.XN2BJ_XY_POSIBILITY), 2);
            //西安去兴武功向的可能性设置
            downCarWhenInDestination[2] = Math.Round(ISystemConfig.XN2BJ_XP_POSIBILITY + random.NextDouble() * (ISystemConfig.XN2BJ_WG_POSIBILITY - ISystemConfig.XN2BJ_XP_POSIBILITY), 2);
            //西安去蔡家坡方向的可能性设置
            downCarWhenInDestination[3] = Math.Round(ISystemConfig.XN2BJ_WG_POSIBILITY + random.NextDouble() * (ISystemConfig.XN2BJ_CP_POSIBILITY - ISystemConfig.XN2BJ_WG_POSIBILITY), 2);
            //西安去虢镇方向的可能性设置
            downCarWhenInDestination[4] = Math.Round(ISystemConfig.XN2BJ_CP_POSIBILITY + random.NextDouble() * (ISystemConfig.XN2BJ_GZ_POSIBILITY - ISystemConfig.XN2BJ_CP_POSIBILITY), 2);
            double totalOtherPossibility = 0.0;
            for (int i = 0; i < ISystemConfig.TOTAL_STATION_COUNT - 1; i++)
            {
                totalOtherPossibility += downCarWhenInDestination[i];
            }
            //西安去宝鸡方向的可能性设置
            downCarWhenInDestination[5] = 1.0 - totalOtherPossibility;
        }
        /// <summary>
        /// 西安车站按照频率要求生成的进站人数
        /// </summary>
        /// <returns></returns>
        public override List<Person> generatePerson()
        {
            List<Person> persons = new List<Person>();
            Random random = new Random();
            //随机在西安站产生去宝鸡方向的进站人数
            int randomInStation = random.Next(1,ISystemConfig.XN2BJ_PERSON_COUNT_PER_MINUTE_TO_STATION);
            for (int i = 0; i < randomInStation; ++i)
            {
                Person person = new Person(this.downCarWhenInDestination, ISystemConfig.STATION_XN, ISystemConfig.STATION_BJ);
                persons.Add(person);
            }
            return persons;
        }
    }
}
