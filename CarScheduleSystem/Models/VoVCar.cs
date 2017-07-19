using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarScheduleSystem.Models
{
    /// <summary>
    /// 沃尔沃车型
    /// </summary>
    class VoVCar : CarModel
    {
        /// <summary>
        /// 控制发车时间的变量
        /// </summary>
        private static int xn2bj_control_start_time = 1;
        private static int bj2xn_control_start_time = 1;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public VoVCar() { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        /// <param name="_carNumber"></param>
        /// <param name="_carStatus"></param>
        /// <param name="_startFrom"></param>
        /// <param name="_goTo"></param>
        public VoVCar(string _carNumber, string _carStatus, string _startFrom, string _goTo) : base(_carNumber,_carStatus,_startFrom,_goTo)
        {
            this.carModelName = ICarModel.VOV;
            //如果由宝鸡发车去西安
            if (ISystemConfig.STATION_BJ.Equals(_startFrom) && ISystemConfig.STATION_XN.Equals(_goTo))
            {
                this.currentLoc = ISystemConfig.STATION_BJ + "站";
                this.startEngineTime = DateTime.Now.AddSeconds(bj2xn_control_start_time * ISystemConfig.BJ2XN_VOV_STARTENGINE_DURRENCY);
            }
            //如果由西安发车去宝鸡
            else if (ISystemConfig.STATION_XN.Equals(_startFrom) && ISystemConfig.STATION_BJ.Equals(_goTo))
            {
                this.currentLoc = ISystemConfig.STATION_XN + "站";
                this.startEngineTime = DateTime.Now.AddSeconds(xn2bj_control_start_time * ISystemConfig.XN2BJ_VOV_STARTENGINE_DURRENCY);
            }
            this.kilosPerMinute = ISystemConfig.VOV_SPEED;
            this.maxLoadPerson = ISystemConfig.VOV_MAX_LOAD_PERSON;
            
            xn2bj_control_start_time++;
            bj2xn_control_start_time++;
        }
    }
}
