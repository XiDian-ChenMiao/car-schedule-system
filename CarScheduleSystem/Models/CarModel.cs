using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarScheduleSystem.Models
{
    /// <summary>
    /// 定义CarModel类作为沃尔沃车型和依维柯车型的父类
    /// </summary>
    public abstract class CarModel
    {
        /// <summary>
        /// 当前位置
        /// </summary>
        public string currentLoc { set; get; }
        /// <summary>
        /// 停车计数器
        /// </summary>
        public int stopCarCounter { set; get; }
        /// <summary>
        /// 车型名称
        /// </summary>
        public string carModelName { set; get; }
        /// <summary>
        /// 车牌编号
        /// </summary>
        public string carNumber { set; get; }
        /// <summary>
        /// 车辆状态
        /// </summary>
        public string carStatus { set; get; }
        /// <summary>
        /// 始发站名称
        /// </summary>
        public string startFrom { set; get; }
        /// <summary>
        /// 终点站名称
        /// </summary>
        public string goTo { set; get; }
        /// <summary>
        /// 速度
        /// </summary>
        public double kilosPerMinute { set; get; }
        /// <summary>
        /// 发车时间
        /// </summary>
        public DateTime startEngineTime { set; get; }
        /// <summary>
        /// 最大核载人数
        /// </summary>
        public int maxLoadPerson { set; get; }
        /// <summary>
        /// 在车上的人员
        /// </summary>
        public List<Person> personInCar { set; get; }
        /// <summary>
        /// 距起点距离
        /// </summary>
        public double distanceToStart { set; get; }
        /// <summary>
        /// 距终点距离
        /// </summary>
        public double distanceToEnd { set; get; }
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public CarModel() { }
        /// <summary>
        /// 通过车牌号构造车型对象
        /// </summary>
        /// <param name="_carNumber"></param>
        public CarModel(string _carNumber)
        {
            this.carNumber = _carNumber;
            this.carStatus = ICarStatus.WAIT;
            this.distanceToStart = 0.0;
            this.distanceToEnd = ISystemConfig.TOTAL_DISTANCE;
            this.stopCarCounter = ISystemConfig.STOP_TIMER;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_carNumber">车牌号</param>
        /// <param name="_carStatus">车辆状态</param>
        /// <param name="_startFrom">发车车站</param>
        /// <param name="_goTo">终点车站</param>
        public CarModel(string _carNumber, string _carStatus, string _startFrom, string _goTo)
        {
            this.carNumber = _carNumber;
            this.carStatus = _carStatus;
            this.startFrom = _startFrom;
            this.goTo = _goTo;
            this.distanceToStart = 0.0;
            this.distanceToEnd = ISystemConfig.TOTAL_DISTANCE;
            this.stopCarCounter = ISystemConfig.STOP_TIMER;
            this.personInCar = new List<Person>();
        }
    }
}
