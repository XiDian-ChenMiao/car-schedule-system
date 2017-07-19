using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarScheduleSystem.Models
{
    /// <summary>
    /// 系统配置
    /// </summary>
    public class ISystemConfig
    {
        #region 系统配置数字参数
        /// <summary>
        /// 西宝线总里程
        /// </summary>
        public static double TOTAL_DISTANCE = 174.0;
        /// <summary>
        /// 停车时间
        /// </summary>
        public static int STOP_TIMER = 6;
        /// <summary>
        /// 站点总数
        /// </summary>
        public static int TOTAL_STATION_COUNT = 6;
        /// <summary>
        /// 沃尔沃车的速度
        /// </summary>
        public static double VOV_SPEED = 1.9;
        /// <summary>
        /// 沃尔沃车最大的承载人数
        /// </summary>
        public static int VOV_MAX_LOAD_PERSON = 48;
        /// <summary>
        /// 依维柯车的速度
        /// </summary>
        public static double YWK_SPEED = 1.4;
        /// <summary>
        /// 依维柯车最大的承载人数
        /// </summary>
        public static int YWK_MAX_LOAD_PERSON = 21;
        /// <summary>
        /// 初始化每分钟宝鸡车站产生的等车的人数
        /// </summary>
        public static int BJ2XN_PERSON_COUNT_PER_MINUTE_TO_STATION = 5;
        /// <summary>
        /// 初始化每分钟西安车站产生的等车的人数
        /// </summary>
        public static int XN2BJ_PERSON_COUNT_PER_MINUTE_TO_STATION = 5;
        /// <summary>
        /// 测试环境中代替实际情况每分钟需要的秒数
        /// </summary>
        public static int REPLACE_ONE_MINUTE_BY = 1;
        /// <summary>
        /// 宝鸡到西安面板刷新频率
        /// </summary>
        public static int BJ2XN_SCHEDULE_UPDATE_DURRENCY = 2000;
        /// <summary>
        /// 西安到宝鸡面板刷新频率
        /// </summary>
        public static int XN2BJ_SCHEDULE_UPDATE_DURRENCY = 2000;
        /// <summary>
        /// 系统时间更新频率
        /// </summary>
        public static int SYSTEM_TIME_UPDATE_DURRENCY = 1000;
        /// <summary>
        /// 宝鸡到西安依维柯发车频率
        /// </summary>
        public static int BJ2XN_YWK_STARTENGINE_DURRENCY = 4;
        /// <summary>
        /// 宝鸡到西安沃尔沃发车频率
        /// </summary>
        public static int BJ2XN_VOV_STARTENGINE_DURRENCY = 8;
        /// <summary>
        /// 西安到宝鸡依维柯发车频率
        /// </summary>
        public static int XN2BJ_YWK_STARTENGINE_DURRENCY = 4;
        /// <summary>
        /// 西安到宝鸡沃尔沃发车频率
        /// </summary>
        public static int XN2BJ_VOV_STARTENGINE_DURRENCY = 8;
        /// <summary>
        /// 西安到宝鸡初始化西安车站的进站人数
        /// </summary>
        public static int XN2BJ_INITIZE_PERSONSINSTATION = 0;
        /// <summary>
        /// 宝鸡到西安初始化宝鸡车站的进站人数
        /// </summary>
        public static int BJ2XN_INITIZE_PERSONSINSTATION = 0;
        /// <summary>
        /// 如果所到车站等待队列中没车，设置缓冲停车时间
        /// </summary>
        public static int DAOZHAN_BUFFER_TIME = 5;
        #endregion

        #region 系统中使用文字参数
        /// <summary>
        /// 系统提示标头
        /// </summary>
        public static string SYSTEM_TIPS = "系统须知";
        /// <summary>
        /// 系统提示内容
        /// </summary>
        public static string SYSTEM_TIPS_CONTENT = "Developed on the .NET 4.5 Framework and microsoft visual studio 2012 by Chen Miao ";
        /// <summary>
        /// 系统时间显示说明
        /// </summary>
        public static string SYSTEM_TIME_INTRODUCTION = "当前系统时间为：";
        /// <summary>
        /// 系统时间显示规范
        /// </summary>
        public static string SYSTEM_TIME_FORMAT = "yyyy年MM月dd日 HH:mm:ss";
        /// <summary>
        /// 总控制台面板显示时间格式
        /// </summary>
        public static string SYSTEM_PANEL_SHOW_TIME_FORMAT = "HH:mm:ss";
        /// <summary>
        /// 系统距离单位公里的显示方式
        /// </summary>
        public static string SYSTEM_KILOMETERS_SHOW = "公里";
        #endregion

        #region 西安到宝鸡方向各车站乘客下车可能性
        public static double XN2BJ_BJ_POSIBILITY = 0.25;
        public static double XN2BJ_GZ_POSIBILITY = 0.20;
        public static double XN2BJ_CP_POSIBILITY = 0.20;
        public static double XN2BJ_WG_POSIBILITY = 0.15;
        public static double XN2BJ_XP_POSIBILITY = 0.15;
        public static double XN2BJ_XY_POSIBILITY = 0.05;
        #endregion

        #region 宝鸡到西安方向各车站乘客下车可能性
        public static double BJ2XN_GZ_POSIBILITY = 0.05;
        public static double BJ2XN_CP_POSIBILITY = 0.15;
        public static double BJ2XN_WG_POSIBILITY = 0.15;
        public static double BJ2XN_XP_POSIBILITY = 0.20;
        public static double BJ2XN_XY_POSIBILITY = 0.20;
        public static double BJ2XN_XN_POSIBILITY = 0.25;
        #endregion

        #region 初始化配置车辆的数量
        /// <summary>
        /// 初始状态西安车站沃尔沃数量
        /// </summary>
        public static int XN2BJ_VOV_COUNT = 2;
        /// <summary>
        /// 初始状态西安车站依维柯数量
        /// </summary>
        public static int XN2BJ_YWK_COUNT = 2;
        /// <summary>
        /// 初始状态宝鸡车站沃尔沃数量
        /// </summary>
        public static int BJ2XN_VOV_COUNT = 2;
        /// <summary>
        /// 初始状态宝鸡车站依维柯数量
        /// </summary>
        public static int BJ2XN_YWK_COUNT = 2;
        #endregion

        #region 沿途站点名称
        public static string STATION_XN = "西安";
        public static string STATION_XY = "咸阳";
        public static string STATION_XP = "兴平";
        public static string STATION_WG = "武功";
        public static string STATION_CP = "蔡家坡";
        public static string STATION_GZ = "虢镇";      
        public static string STATION_BJ = "宝鸡";
        #endregion

        #region 宝鸡到西安方向车站之间距离
        public static int BJ2GZ = 24;
        public static int BJ2CP = 45;
        public static int BJ2WG = 107;
        public static int BJ2XP = 128;
        public static int BJ2XY = 152;
        public static int BJ2XN = 174;
        #endregion

        #region 西安到宝鸡方向车站之间距离
        public static int XN2XY = 22;
        public static int XN2XP = 46;
        public static int XN2WG = 67;
        public static int XN2CP = 129;
        public static int XN2GZ = 150;
        public static int XN2BJ = 174;
        #endregion

        #region 西宝线各站距离起点的距离
        public static int[] XN2BJ_STATION_DISTANCE = { 22, 46, 67, 129, 150, 174 };
        public static int[] BJ2XN_STATION_DISTANCE = { 24, 45, 107, 128, 152, 174 };
        #endregion
    }
}
