using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CarScheduleSystem.Models
{
    public abstract class BaseSchedule : IScheduleMethod
    {
        #region 参数设置
        
        /// <summary>
        /// 供基类自己使用的融合队列的策略
        /// </summary>
        private IJoinQueueStrategy joinQueueByStartTime;
        /// <summary>
        /// 调度计数器
        /// </summary>
        protected Timer scheduleTimer;
        /// <summary>
        /// 当到达对方车站时，将从运行队列中取到的车辆转放到此列表中，可能同一时刻有多辆车加入
        /// </summary>
        public List<CarModel> daoZhanList { set; get; }
        /// <summary>
        /// 生成乘客的工厂
        /// </summary>
        public IPersonFactory generatePersonFactory { set; get; }
        /// <summary>
        /// 车站等待发沃尔沃车队列
        /// </summary>
        public Queue<CarModel> vovWaitQueue { set; get; }
        /// <summary>
        /// 车站等待发依维柯车队列
        /// </summary>
        public Queue<CarModel> ywkWaitQueue { set; get; }
        /// <summary>
        /// 车站等待发沃尔沃车队列
        /// </summary>
        public Queue<CarModel> vovRunQueue { set; get; }
        /// <summary>
        /// 车站等待发依维柯车队列
        /// </summary>
        public Queue<CarModel> ywkRunQueue { set; get; }
        /// <summary>
        /// 车站内的等待人员队列
        /// </summary>
        public Queue<Person> waitPersonQueue { set; get; }
        #endregion
        
        #region 构造函数
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public BaseSchedule()
        {
        }
        /// <summary>
        /// 传参构造函数
        /// </summary>
        /// <param name="_vovWaitQueue">沃尔沃车等待队列</param>
        /// <param name="_ywkWaitQueue">依维柯等待队列</param>
        /// <param name="_vowRunQueue">沃尔沃运行队列</param>
        /// <param name="_ywkRunQueue">依维柯运行队列</param>
        public BaseSchedule(Queue<CarModel> _vovWaitQueue, Queue<CarModel> _ywkWaitQueue, Queue<CarModel> _vowRunQueue, Queue<CarModel> _ywkRunQueue)
        {
            this.vovWaitQueue = _vovWaitQueue;
            this.ywkWaitQueue = _ywkWaitQueue;
            this.vovRunQueue = _vowRunQueue;
            this.ywkRunQueue = _ywkRunQueue;
            this.daoZhanList = new List<CarModel>();
            this.waitPersonQueue = new Queue<Person>();
            this.joinQueueByStartTime = new JoinQueueByStartEngineTime();
            
            setScheduleTimeOptions();
        }
        #endregion
        
        #region 实现接口方法
        /// <summary>
        /// 从沃尔沃等待队列中移除车辆
        /// </summary>
        /// <returns></returns>
        public CarModel removeVOVCarFromWaitQueue()
        {
            if (vovWaitQueue.Count != 0)
                return vovWaitQueue.Dequeue();
            return null;
        }
        /// <summary>
        /// 从沃尔沃运行队列中移除车辆
        /// </summary>
        /// <returns></returns>
        public CarModel removeVOVCarFromRunQueue()
        {
            if (vovRunQueue.Count != 0)
                return vovRunQueue.Dequeue();
            return null;
        }
        /// <summary>
        /// 从依维柯等待队列中移除车辆
        /// </summary>
        /// <returns></returns>
        public CarModel removeYWKCarFromWaitQueue()
        {
            if(ywkWaitQueue.Count != 0)
                return ywkWaitQueue.Dequeue();
            return null;
        }
        /// <summary>
        /// 从依维柯运行队列中移除车辆
        /// </summary>
        /// <returns></returns>
        public CarModel removeYWKCarFromRunQueue()
        {
            if (ywkRunQueue.Count != 0)
                return ywkRunQueue.Dequeue();
            return null;
        }
        /// <summary>
        /// 依维柯车加入到运行队列中
        /// </summary>
        /// <param name="carModel"></param>
        public void addYWKCarModelInRunQueue(CarModel carModel)
        {
            if (carModel != null)
            {
                //将车辆状态更改为运行态
                carModel.carStatus = ICarStatus.RUN;
                ywkRunQueue.Enqueue(carModel);
            }
        }
        /// <summary>
        /// 将依维柯车加入到等待队列中
        /// </summary>
        /// <param name="carModel"></param>
        public void addYWKCarModelInWaitQueue(CarModel carModel)
        {
            if (carModel != null)
                ywkWaitQueue.Enqueue(carModel);
        }
        /// <summary>
        /// 将沃尔沃车加入到运行队列中
        /// </summary>
        /// <param name="carModel"></param>
        public void addVOVCarModelInRunQueue(CarModel carModel)
        {
            if (carModel != null)
            {
                //将车辆状态更改为运行态
                carModel.carStatus = ICarStatus.RUN;
                vovRunQueue.Enqueue(carModel);
            }
        }
        /// <summary>
        /// 将沃尔沃车加入到等待队列中
        /// </summary>
        /// <param name="carModel"></param>
        public void addVOVCarModelInWaitQueue(CarModel carModel)
        {
            if (carModel != null)
                vovWaitQueue.Enqueue(carModel);
        }
        /// <summary>
        /// 如果有车辆到站
        /// </summary>
        /// <param name="carList"></param>
        public void addDaoZhanListInWaitQueue(List<CarModel> carList)
        {
            foreach (CarModel car in carList)
            {
                //先改变到站车辆的基本信息
                changeDaoZhanCarInfo(car);
                //如果来车为沃尔沃车，则自动加入到沃尔沃车的等待队列中
                if (ICarModel.VOV.Equals(car.carModelName))
                {
                    changeDaoZhanVOVCarStartTimeByWaitQueue(car);
                    addVOVCarModelInWaitQueue(car);
                }
                //如果来车为依维柯车，则自动加入到依维柯车的等待队列中
                else if(ICarModel.YWK.Equals(car.carModelName))
                {
                    changeDaoZhanYWKCarStartTimeByWaitQueue(car);
                    addYWKCarModelInWaitQueue(car);
                }
            }
            //清空到站车辆集合
            carList.Clear();
        }
        /// <summary>
        /// 添加新产生的进站人进入等待队列中
        /// </summary>
        /// <param name="?"></param>
        public void addPersonsInWaitQueue(List<Person> persons)
        {
            if (persons != null && persons.Count != 0)
            {
                foreach (Person person in persons)
                {
                    //加入到等待队列中
                    waitPersonQueue.Enqueue(person);
                }
            }
        }
        #endregion
        
        #region 辅助函数
        /// <summary>
        /// 设置调度时间选项
        /// </summary>
        private void setScheduleTimeOptions()
        {
            scheduleTimer = new Timer();
            scheduleTimer.Interval = 1000;
            scheduleTimer.Elapsed += new ElapsedEventHandler(concerateOptions);
            scheduleTimer.AutoReset = true;
            scheduleTimer.Start();
        }
        /// <summary>
        /// 判断沃尔沃车是否到中途车站
        /// </summary>
        private bool justifyVoVInMiddleStation(CarModel car,ref string stationName)
        {
            if (ISystemConfig.STATION_BJ.Equals(car.startFrom) && ISystemConfig.STATION_XN.Equals(car.goTo))
            {
                int length = ISystemConfig.BJ2XN_STATION_DISTANCE.Length;
                for (int i = 0; i < length; i++)
                {
                    //如果距起点的距离与某一站点的距离差值的绝对值小于沃尔沃车速度，则认为车即将到达某一站点
                    if (Math.Abs(car.distanceToStart - ISystemConfig.BJ2XN_STATION_DISTANCE[i]) < ISystemConfig.VOV_SPEED)
                    {
                        stationName = getBJ2XNStationName(i);
                        return true;
                    }
                }
            }
            else if (ISystemConfig.STATION_XN.Equals(car.startFrom) && ISystemConfig.STATION_BJ.Equals(car.goTo))
            {
                int length = ISystemConfig.XN2BJ_STATION_DISTANCE.Length;
                for (int i = 0; i < length; i++)
                {
                    //如果距起点的距离与某一站点的距离差值的绝对值小于沃尔沃车速度，则认为车即将到达某一站点
                    if (Math.Abs(car.distanceToStart - ISystemConfig.XN2BJ_STATION_DISTANCE[i]) < ISystemConfig.VOV_SPEED)
                    {
                        stationName = getXN2BJStationName(i);
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 判断依维柯车是否到中途车站
        /// </summary>
        private bool justifyYWKInMiddleStation(CarModel car, ref string stationName)
        {
            if (ISystemConfig.STATION_BJ.Equals(car.startFrom) && ISystemConfig.STATION_XN.Equals(car.goTo))
            {
                int length = ISystemConfig.BJ2XN_STATION_DISTANCE.Length;
                for (int i = 0; i < length; i++)
                {
                    //如果距起点的距离与某一站点的距离差值的绝对值小于沃尔沃车速度，则认为车即将到达某一站点
                    if (Math.Abs(car.distanceToStart - ISystemConfig.BJ2XN_STATION_DISTANCE[i]) < ISystemConfig.YWK_SPEED)
                    {
                        stationName = getBJ2XNStationName(i);
                        return true;
                    }
                }
            }
            else if (ISystemConfig.STATION_XN.Equals(car.startFrom) && ISystemConfig.STATION_BJ.Equals(car.goTo))
            {
                int length = ISystemConfig.XN2BJ_STATION_DISTANCE.Length;
                for (int i = 0; i < length; i++)
                {
                    //如果距起点的距离与某一站点的距离差值的绝对值小于沃尔沃车速度，则认为车即将到达某一站点
                    if (Math.Abs(car.distanceToStart - ISystemConfig.XN2BJ_STATION_DISTANCE[i]) < ISystemConfig.YWK_SPEED)
                    {
                        stationName = getXN2BJStationName(i);
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 改变车辆当前的位置属性
        /// </summary>
        /// <param name="car"></param>
        private void changeCarCurrentLoc(CarModel car)
        {
            //获取到此时车辆距起点的距离
            double distanceToStart = Math.Round(car.distanceToStart,1);
            double middleDistance;
            //如果为宝鸡到西安方向
            if (ISystemConfig.STATION_BJ.Equals(car.startFrom) && ISystemConfig.STATION_XN.Equals(car.goTo))
            {
                if (distanceToStart < ISystemConfig.BJ2XN_STATION_DISTANCE[0])
                {
                    middleDistance = ISystemConfig.BJ2XN_STATION_DISTANCE[0] / 2;
                    //如果刚开始走还没经过第一站
                    car.currentLoc = distanceToStart >  middleDistance ? 
                        ISystemConfig.STATION_GZ + "以西" + Math.Round(ISystemConfig.BJ2XN_STATION_DISTANCE[0] - distanceToStart,1) + ISystemConfig.SYSTEM_KILOMETERS_SHOW
                        : ISystemConfig.STATION_BJ + "以东" + distanceToStart + ISystemConfig.SYSTEM_KILOMETERS_SHOW;
                    return;
                }
                else
                {
                    for (int i = 1; i < ISystemConfig.BJ2XN_STATION_DISTANCE.Length; i++)
                    {
                        if (ISystemConfig.BJ2XN_STATION_DISTANCE[i - 1] <= distanceToStart && distanceToStart <= ISystemConfig.BJ2XN_STATION_DISTANCE[i])
                        {
                            middleDistance = (ISystemConfig.BJ2XN_STATION_DISTANCE[i] - ISystemConfig.BJ2XN_STATION_DISTANCE[i - 1]) / 2;
                            car.currentLoc = distanceToStart > middleDistance ?
                                getBJ2XNStationName(i) + "以西" + Math.Round(ISystemConfig.BJ2XN_STATION_DISTANCE[i] - distanceToStart,1) + ISystemConfig.SYSTEM_KILOMETERS_SHOW
                                : getBJ2XNStationName(i - 1) + "以东" + distanceToStart + ISystemConfig.SYSTEM_KILOMETERS_SHOW;
                            break;
                        }
                    }
                }
            }
            //如果为西安到宝鸡方向
            else
            {
                if (distanceToStart < ISystemConfig.XN2BJ_STATION_DISTANCE[0])
                {
                    middleDistance = ISystemConfig.XN2BJ_STATION_DISTANCE[0] / 2;
                    //如果刚开始走还没经过第一站
                    car.currentLoc = distanceToStart > middleDistance ?
                        ISystemConfig.STATION_XY + "以东" + Math.Round(ISystemConfig.XN2BJ_STATION_DISTANCE[0] - distanceToStart,1) + ISystemConfig.SYSTEM_KILOMETERS_SHOW
                        : ISystemConfig.STATION_XN + "以西" + distanceToStart + ISystemConfig.SYSTEM_KILOMETERS_SHOW;
                    return;
                }
                else
                {
                    for (int i = 1; i < ISystemConfig.XN2BJ_STATION_DISTANCE.Length; i++)
                    {
                        if (ISystemConfig.XN2BJ_STATION_DISTANCE[i - 1] <= distanceToStart && distanceToStart <= ISystemConfig.XN2BJ_STATION_DISTANCE[i])
                        {
                            middleDistance = (ISystemConfig.XN2BJ_STATION_DISTANCE[i] - ISystemConfig.XN2BJ_STATION_DISTANCE[i - 1]) / 2;
                            car.currentLoc = distanceToStart > middleDistance ?
                                getBJ2XNStationName(i) + "以东" + Math.Round(ISystemConfig.XN2BJ_STATION_DISTANCE[i] - distanceToStart,1) + ISystemConfig.SYSTEM_KILOMETERS_SHOW
                                : getBJ2XNStationName(i - 1) + "以西" + distanceToStart + ISystemConfig.SYSTEM_KILOMETERS_SHOW;
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 获取西安到宝鸡方向沿途的站点名称
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private string getXN2BJStationName(int i)
        {
            switch (i)
            {
                case 0:
                    return ISystemConfig.STATION_XY;
                case 1:
                    return ISystemConfig.STATION_XP;
                case 2:
                    return ISystemConfig.STATION_WG;
                case 3:
                    return ISystemConfig.STATION_CP;
                case 4:
                    return ISystemConfig.STATION_GZ;
                case 5:
                    return ISystemConfig.STATION_BJ;
                default:
                    return ISystemConfig.STATION_XN;
            }
        }
        /// <summary>
        /// 获取宝鸡到西安方向沿途的站点名称
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private string getBJ2XNStationName(int i)
        {
            switch (i)
            {
                case 0:
                    return ISystemConfig.STATION_GZ;
                case 1:
                    return ISystemConfig.STATION_CP;
                case 2:
                    return ISystemConfig.STATION_WG;
                case 3:
                    return ISystemConfig.STATION_XP;
                case 4:
                    return ISystemConfig.STATION_XY;
                case 5:
                    return ISystemConfig.STATION_XN;
                default:
                    return ISystemConfig.STATION_BJ;
            }
        }
        /// <summary>
        /// 判断有人是否下车
        /// </summary>
        /// <returns></returns>
        private bool justifyHavePersonDownCar(CarModel vovCar,string stationName)
        {
            //将车里的乘客集合复制一份，防止多线程更改抛异常
            List<Person> newList = new List<Person>(vovCar.personInCar.ToArray());
            foreach (Person person in newList)
            {
                if (stationName.Equals(person.goTo))
                {
                    //如果车还没停止，则将车先停下
                    if (!ICarStatus.STOP.Equals(vovCar.carStatus))
                        vovCar.carStatus = ICarStatus.STOP;
                    //乘客下车
                    vovCar.personInCar.Remove(person);
                }
            }
            return true;
        }
        /// <summary>
        /// 改变沃尔沃车的运行状态
        /// </summary>
        /// <param name="vovCar"></param>
        private void changeVoVCarStatus(CarModel vovCar)
        {
            changeCarCurrentLoc(vovCar);
            string stationName = string.Empty;//获取中途的站点名称
            if (vovCar.stopCarCounter != 0 && justifyVoVInMiddleStation(vovCar, ref stationName))
            {
                if (!ICarStatus.STOP.Equals(vovCar.carStatus) && justifyHavePersonDownCar(vovCar, stationName))
                {
                    //第一次计数器减一
                    --vovCar.stopCarCounter;
                }
                else
                {
                    //第二次计数器减一
                    --vovCar.stopCarCounter;
                    return;
                }
            }
            else
            {
                vovCar.carStatus = ICarStatus.RUN;
                vovCar.stopCarCounter = ISystemConfig.STOP_TIMER;
                vovCar.distanceToStart += vovCar.kilosPerMinute;
                vovCar.distanceToEnd = ISystemConfig.TOTAL_DISTANCE - vovCar.distanceToStart <= 0 ? 0 : ISystemConfig.TOTAL_DISTANCE - vovCar.distanceToStart;
            }
        }
        /// <summary>
        /// 改变依维柯车的运行状态
        /// </summary>
        /// <param name="vovCar"></param>
        private void changeYWKCarStatus(CarModel ywkCar)
        {
            changeCarCurrentLoc(ywkCar);
            string stationName = string.Empty;//获取中途的站点名称
            if (ywkCar.stopCarCounter != 0 && justifyYWKInMiddleStation(ywkCar, ref stationName))
            {
                if (!ICarStatus.STOP.Equals(ywkCar.carStatus) && justifyHavePersonDownCar(ywkCar, stationName))
                {
                    //第一次计数器减一
                    --ywkCar.stopCarCounter;
                }
                else
                {
                    //第二次计数器减一
                    --ywkCar.stopCarCounter;
                    return;
                }
            }
            else
            {
                ywkCar.carStatus = ICarStatus.RUN;
                ywkCar.stopCarCounter = ISystemConfig.STOP_TIMER;
                ywkCar.distanceToStart += ywkCar.kilosPerMinute;
                ywkCar.distanceToEnd = ISystemConfig.TOTAL_DISTANCE - ywkCar.distanceToStart <= 0 ? 0 : ISystemConfig.TOTAL_DISTANCE - ywkCar.distanceToStart;
            }
        }
        /// <summary>
        /// 改变到站依维柯车的启动时间
        /// </summary>
        /// <param name="car"></param>
        private void changeDaoZhanYWKCarStartTimeByWaitQueue(CarModel car)
        {
            int queueCount = ywkWaitQueue.Count;
            if (ISystemConfig.STATION_BJ.Equals(car.startFrom))
            {
                if (queueCount == 0)
                    car.startEngineTime = DateTime.Now.AddSeconds(ISystemConfig.BJ2XN_YWK_STARTENGINE_DURRENCY);
                else
                    car.startEngineTime = ywkWaitQueue.Last().startEngineTime.AddSeconds(ISystemConfig.BJ2XN_YWK_STARTENGINE_DURRENCY);
            }
            else if (ISystemConfig.STATION_XN.Equals(car.startFrom))
            {
                if (queueCount == 0)
                    car.startEngineTime = DateTime.Now.AddSeconds(ISystemConfig.BJ2XN_YWK_STARTENGINE_DURRENCY);
                else
                    car.startEngineTime = ywkWaitQueue.Last().startEngineTime.AddSeconds(ISystemConfig.XN2BJ_YWK_STARTENGINE_DURRENCY);
            }
        }
        /// <summary>
        /// 改变到站沃尔沃车的启动时间
        /// </summary>
        /// <param name="car"></param>
        private void changeDaoZhanVOVCarStartTimeByWaitQueue(CarModel car)
        {
            int queueCount = vovWaitQueue.Count;
            if (ISystemConfig.STATION_BJ.Equals(car.startFrom))
            {
                if(queueCount == 0)
                    car.startEngineTime = DateTime.Now.AddSeconds(ISystemConfig.BJ2XN_VOV_STARTENGINE_DURRENCY);
                else
                    car.startEngineTime = vovWaitQueue.Last().startEngineTime.AddSeconds(ISystemConfig.BJ2XN_VOV_STARTENGINE_DURRENCY);
            }
            else if (ISystemConfig.STATION_XN.Equals(car.startFrom))
            {
                if (queueCount == 0)
                    car.startEngineTime = DateTime.Now.AddSeconds(ISystemConfig.BJ2XN_VOV_STARTENGINE_DURRENCY);
                else
                    car.startEngineTime = vovWaitQueue.Last().startEngineTime.AddSeconds(ISystemConfig.XN2BJ_VOV_STARTENGINE_DURRENCY);
            }
        }
        /// <summary>
        /// 改变依维柯运行队列中的信息
        /// </summary>
        protected void changeYWKRunQueue()
        {
            foreach (CarModel car in ywkRunQueue)
            {
                changeYWKCarStatus(car);
            }
        }
        /// <summary>
        /// 改变沃尔沃运行队列中的信息
        /// </summary>
        protected void changeVOVRunQueue()
        {
            foreach (CarModel car in vovRunQueue)
            {
                changeVoVCarStatus(car);
            }
        }
        /// <summary>
        /// 从沃尔沃的运行队列中判断是否有车已经到达对方车站
        /// </summary>
        /// <returns></returns>
        protected CarModel justifyVOVCarDaoZhanFromVoVRunQueue()
        {
            //如果沃尔沃运行队列中的第一辆车距离终点站的距离已经小于等于0.0
            if (vovRunQueue.Count != 0 && vovRunQueue.First().distanceToEnd <= 0.0)
                return vovRunQueue.Dequeue();
            return null;
        }
        /// <summary>
        /// 从依维柯的运行队列中判断是否有车已经到达对方车站
        /// </summary>
        /// <returns></returns>
        protected CarModel justifyYWKCarDaoZhanFromYWKRunQueue()
        {
            //如果依维柯运行队列中的第一辆车距离终点站的距离已经小于等于0.0
            if (ywkRunQueue.Count != 0 && ywkRunQueue.First().distanceToEnd <= 0.0)
                return ywkRunQueue.Dequeue();
            return null;
        }
        /// <summary>
        /// 检查依维柯等待队列中是否有车即将进入运行态
        /// </summary>
        protected void justifyYWKWaitQueueHasCarModelToRun()
        {
            if (ywkWaitQueue.Count != 0)
            {
                CarModel car = ywkWaitQueue.First();
                if (DateTime.Now.CompareTo(car.startEngineTime) >= 0)
                {
                    addYWKCarModelInRunQueue(removeYWKCarFromWaitQueue());
                }
            }
        }
        /// <summary>
        /// 检查沃尔沃等待队列中是否有车即将进入运行态
        /// </summary>
        protected void justifyVOVWaitQueueHasCarModelToRun()
        {
            if (vovWaitQueue.Count != 0)
            {
                CarModel car = vovWaitQueue.First();
                if (DateTime.Now.CompareTo(car.startEngineTime) >= 0)
                {
                    addVOVCarModelInRunQueue(removeVOVCarFromWaitQueue());
                }
            }
        }
        /// <summary>
        /// 判断可否上车
        /// </summary>
        /// <param name="car"></param>
        /// <param name="maxLoadPerson"></param>
        /// <returns></returns>
        private bool justifyCanUpCar(CarModel car, int maxLoadPerson)
        {
            //获取车上现有多少人数
            int personCountInCar = car.personInCar.Count;
            //如果车上的人数没有超过沃尔沃车的最大核载人数
            if (personCountInCar < maxLoadPerson)
                return true;
            return false;
        }
        /// <summary>
        /// 乘客上车的具体操作
        /// </summary>
        /// <param name="car"></param>
        /// <param name="maxLoadPerson"></param>
        private void dealWithUpCar(CarModel car, int maxLoadPerson)
        {
            //获取车上现有多少人数
            int personCountInCar = car.personInCar.Count;
            //获取到可以继续添加的人数
            int canAddPersonCount = maxLoadPerson - personCountInCar;
            //获取到等待队列的人数
            int waitPersonQueueCount = this.waitPersonQueue.Count;
            //则从等待队列中出队上车，如果车站内等待人员队列的人数少于可添加人数，则将其全部出队
            if (waitPersonQueueCount < canAddPersonCount)
            {
                for (int i = 0; i < waitPersonQueueCount; ++i)
                    car.personInCar.Add(this.waitPersonQueue.Dequeue());
            }
            else
            {
                //如果超过可添加的人数，则只增加到满载，剩下的人员从其他车辆上车
                for (int i = 0; i < canAddPersonCount; ++i)
                    car.personInCar.Add(this.waitPersonQueue.Dequeue());
            }
        }
        /// <summary>
        /// 乘客上车
        /// </summary>
        protected void personUpCar()
        {
            //如果车站内人员等待队列中有人
            if (this.waitPersonQueue.Count != 0)
            {
                if (this.vovWaitQueue.Count != 0 || this.ywkWaitQueue.Count != 0)
                {
                    //融合形成按照发车时间先后排序的队列
                    Queue<CarModel> waitQueue = joinQueueByStartTime.joinQueue(this.vovWaitQueue, this.ywkWaitQueue);
                    //让车站内的等待人员开始上车
                    foreach (CarModel car in waitQueue)
                    {
                        if (this.waitPersonQueue.Count != 0)
                        {
                            //如果为沃尔沃车
                            if (ICarModel.VOV.Equals(car.carModelName))
                            {
                                if (justifyCanUpCar(car, ISystemConfig.VOV_MAX_LOAD_PERSON))
                                {
                                    dealWithUpCar(car, ISystemConfig.VOV_MAX_LOAD_PERSON);
                                }
                                else
                                    continue;
                            }
                            //如果为依维柯车
                            else if (ICarModel.YWK.Equals(car.carModelName))
                            {
                                if (justifyCanUpCar(car, ISystemConfig.YWK_MAX_LOAD_PERSON))
                                {
                                    dealWithUpCar(car, ISystemConfig.YWK_MAX_LOAD_PERSON);
                                }
                                else
                                    continue;
                            }
                        }
                        else
                            break;
                    }
                }
            }
        }
        #endregion
        
        #region 抽象函数
        /// <summary>
        /// 具体操作选项
        /// </summary>
        protected abstract void concerateOptions(Object sender,ElapsedEventArgs args);
        /// <summary>
        /// 改变到站车辆信息
        /// </summary>
        /// <param name="car">到站车辆</param>
        protected abstract void changeDaoZhanCarInfo(CarModel car);
        #endregion   
    }
}
