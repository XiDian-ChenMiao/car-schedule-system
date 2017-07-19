using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarScheduleSystem.Models
{
    /// <summary>
    /// 去车站的人的封装
    /// </summary>
    public class Person
    {
        /// <summary>
        /// 乘客想要去的目的地
        /// </summary>
        public string goTo { set; get; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="everyStationDownCarPossibility">每一个站点下车的可能性数组</param>
        /// <param name="startFrom">班线的起点</param>
        /// <param name="endTo">班线的终点</param>
        public Person(double[] everyStationDownCarPossibility,string startFrom,string endTo)
        {
            //如果是西安到宝鸡方向
            if (ISystemConfig.STATION_XN.Equals(startFrom) && ISystemConfig.STATION_BJ.Equals(endTo))
            {
                Random random = new Random();
                int psCount = everyStationDownCarPossibility.Length;
                //产生出的随机可能性，且最大的概率不会超过最远站点的可能性
                double randomPs = Math.Round(random.NextDouble() * everyStationDownCarPossibility[psCount - 1], 2);
                //遍历下车可能性数组，找到下车地点
                for (int i = 0; i < psCount; i++)
                {
                    if (i == 0)
                    {
                        if (randomPs > 0.0 && randomPs <= everyStationDownCarPossibility[0])
                        {
                            this.goTo = ISystemConfig.STATION_XY;
                            break;
                        }
                    }
                    else
                    {
                        if (randomPs >= everyStationDownCarPossibility[i - 1] && randomPs <= everyStationDownCarPossibility[i])
                        {
                            setXN2BJStation(i);
                            break;
                        }
                    }
                }
            }
            //如果是宝鸡到西安方向
            else if (ISystemConfig.STATION_BJ.Equals(startFrom) && ISystemConfig.STATION_XN.Equals(endTo))
            {
                Random random = new Random();
                int psCount = everyStationDownCarPossibility.Length;
                //产生出的随机可能性，且最大的概率不会超过最远站点的可能性
                double randomPs = Math.Round(random.NextDouble() * everyStationDownCarPossibility[psCount - 1],2);
                //遍历下车可能性数组，找到下车地点
                for (int i = 0; i < psCount; i++)
                {
                    if (i == 0)
                    {
                        if (randomPs > 0.0 && randomPs <= everyStationDownCarPossibility[0])
                        {
                            this.goTo = ISystemConfig.STATION_GZ;
                            break;
                        }
                    }
                    else
                    {
                        if (randomPs >= everyStationDownCarPossibility[i - 1] && randomPs <= everyStationDownCarPossibility[i])
                        {
                            setBJ2XNStation(i);
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 设置西安到宝鸡方向的站点名称
        /// </summary>
        /// <param name="i"></param>
        private void setXN2BJStation(int i)
        {
            switch (i)
            {
                case 1:
                    this.goTo = ISystemConfig.STATION_XP;
                    break;
                case 2:
                    this.goTo = ISystemConfig.STATION_WG;
                    break;
                case 3:
                    this.goTo = ISystemConfig.STATION_CP;
                    break;
                case 4:
                    this.goTo = ISystemConfig.STATION_GZ;
                    break;
                case 5:
                    this.goTo = ISystemConfig.STATION_BJ;
                    break;
            }
        }
        /// <summary>
        /// 设置宝鸡到西安方向的站点名称
        /// </summary>
        /// <param name="i"></param>
        private void setBJ2XNStation(int i)
        {
            switch (i)
            {
                case 1:
                    this.goTo = ISystemConfig.STATION_CP;
                    break;
                case 2:
                    this.goTo = ISystemConfig.STATION_WG;
                    break;
                case 3:
                    this.goTo = ISystemConfig.STATION_XP;
                    break;
                case 4:
                    this.goTo = ISystemConfig.STATION_XY;
                    break;
                case 5:
                    this.goTo = ISystemConfig.STATION_XN;
                    break;
            }
        }
    }
}
