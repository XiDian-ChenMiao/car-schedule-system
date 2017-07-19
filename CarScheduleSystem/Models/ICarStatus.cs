using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarScheduleSystem.Models
{
    /// <summary>
    /// 车辆状态接口
    /// </summary>
    public class ICarStatus
    {
        public static string WAIT = "等待发车";
        public static string RUN = "正在运行";
        public static string STOP = "到站下车";
    }
}
