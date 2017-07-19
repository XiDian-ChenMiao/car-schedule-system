using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarScheduleSystem.Models
{
    /// <summary>
    /// 宝鸡到西安的调度类
    /// </summary>
    public class BJ2XNSchedule : BaseSchedule
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public BJ2XNSchedule() { }
        /// <summary>
        /// 传参构造函数
        /// </summary>
        /// <param name="_vovWaitQueue">沃尔沃车等待队列</param>
        /// <param name="_ywkWaitQueue">依维柯等待队列</param>
        /// <param name="_vowRunQueue">沃尔沃运行队列</param>
        /// <param name="_ywkRunQueue">依维柯运行队列</param>
        public BJ2XNSchedule(Queue<CarModel> _vovWaitQueue, Queue<CarModel> _ywkWaitQueue, Queue<CarModel> _vowRunQueue, Queue<CarModel> _ywkRunQueue)
            : base(_vovWaitQueue, _ywkWaitQueue, _vowRunQueue, _ywkRunQueue)
        {          
        }
        /// <summary>
        /// 处理由西安来车的车辆集合
        /// </summary>
        /// <param name="car"></param>
        protected override void changeDaoZhanCarInfo(CarModel car)
        {
            car.carStatus = ICarStatus.WAIT;
            car.distanceToEnd = ISystemConfig.TOTAL_DISTANCE;
            car.distanceToStart = 0.0;
            car.goTo = ISystemConfig.STATION_XN;
            car.startFrom = ISystemConfig.STATION_BJ;
        }
        /// <summary>
        /// 将每次触发的具体动作交由子类完成——BJ2XNSchedule
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected override void concerateOptions(object sender, System.Timers.ElapsedEventArgs args)
        {
            //添加进站人的集合
            addPersonsInWaitQueue(this.generatePersonFactory.generatePerson());
            //判断是否有车辆到站，如果有，则加入到到站集合当中
            CarModel daoZhanVoVCar = justifyVOVCarDaoZhanFromVoVRunQueue();
            CarModel daoZhanYWKCar = justifyYWKCarDaoZhanFromYWKRunQueue();
            if (daoZhanVoVCar != null)
                daoZhanList.Add(daoZhanVoVCar);
            if (daoZhanYWKCar != null)
                daoZhanList.Add(daoZhanYWKCar); 
            //随着频率更改运行队列中车辆的信息
            if(this.vovRunQueue.Count != 0)
                changeVOVRunQueue();
            if(this.ywkRunQueue.Count != 0)
                changeYWKRunQueue();
            //判断是否等待队列中的车到点发车
            justifyYWKWaitQueueHasCarModelToRun();
            justifyVOVWaitQueueHasCarModelToRun();
            //乘客上车
            personUpCar();
            
        }
    }
}
