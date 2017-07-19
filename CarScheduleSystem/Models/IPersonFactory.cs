using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
namespace CarScheduleSystem.Models
{
    /// <summary>
    /// 产生去车站人的工厂抽象类
    /// </summary>
    public abstract class IPersonFactory
    {
        /// <summary>
        /// 乘客到目的地后的下车可能性，沿途6个站点
        /// </summary>
        protected double[] downCarWhenInDestination;
        /// <summary>
        /// 每分钟产生的最大的进站人数
        /// </summary>
        public int maxPersonPerMinuteToStation { set; get; }
        /// <summary>
        /// 设置无参构造函数
        /// </summary>
        public IPersonFactory()
        {
            //初始化沿途六个站点的可能性
            downCarWhenInDestination = new double[ISystemConfig.TOTAL_STATION_COUNT];
            //设置可能性
            setDownCarPossibility();
        }
        /// <summary>
        /// 由子类去设置站点间的具体可能性
        /// </summary>
        public abstract void setDownCarPossibility();
        /// <summary>
        /// 每分钟生成的进站人数的集合
        /// </summary>
        /// <returns></returns>
        public abstract List<Person> generatePerson();
    }
}
