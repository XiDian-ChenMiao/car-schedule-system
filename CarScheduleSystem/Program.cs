using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarScheduleSystem.Models;
using CarScheduleSystem.HelperUtils;

namespace CarScheduleSystem
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region 初始化车辆区
            List<CarModel> bj2xnYWKList = new List<CarModel>();
            List<CarModel> bj2xnVOVList = new List<CarModel>();

            List<CarModel> xn2bjYWKList = new List<CarModel>();
            List<CarModel> xn2bjVOVList = new List<CarModel>();
            for (int i = 1; i <= ISystemConfig.BJ2XN_YWK_COUNT; ++i)
                bj2xnYWKList.Add(new YWKCar("陕C-YWK-" + i, ICarStatus.WAIT, ISystemConfig.STATION_BJ, ISystemConfig.STATION_XN));
            for (int i = 1; i <= ISystemConfig.BJ2XN_VOV_COUNT; ++i)
                bj2xnVOVList.Add(new VoVCar("陕C-VOV-" + i, ICarStatus.WAIT, ISystemConfig.STATION_BJ, ISystemConfig.STATION_XN));

            for (int i = 1; i <= ISystemConfig.XN2BJ_YWK_COUNT; ++i)
                xn2bjYWKList.Add(new YWKCar("陕A-YWK-" + i, ICarStatus.WAIT, ISystemConfig.STATION_XN, ISystemConfig.STATION_BJ));
            for (int i = 1; i <= ISystemConfig.XN2BJ_VOV_COUNT; ++i)
                xn2bjVOVList.Add(new VoVCar("陕A-VOV-" + i, ICarStatus.WAIT, ISystemConfig.STATION_XN, ISystemConfig.STATION_BJ));
            #endregion

            #region 初始化队列区
            Queue<CarModel> bj2xnYWKWaitQueue = new Queue<CarModel>(ISystemConfig.BJ2XN_YWK_COUNT);
            Queue<CarModel> bj2xnVOVWaitQueue = new Queue<CarModel>(ISystemConfig.BJ2XN_VOV_COUNT);
            Queue<CarModel> bj2xnYWKRunQueue = new Queue<CarModel>(0);
            Queue<CarModel> bj2xnVOVRunQueue = new Queue<CarModel>(0);
            QueueHelper.addListInQueue(bj2xnYWKWaitQueue, bj2xnYWKList);
            QueueHelper.addListInQueue(bj2xnVOVWaitQueue, bj2xnVOVList);

            Queue<CarModel> xn2bjYWKWaitQueue = new Queue<CarModel>(ISystemConfig.XN2BJ_YWK_COUNT);
            Queue<CarModel> xn2bjVOVWaitQueue = new Queue<CarModel>(ISystemConfig.XN2BJ_VOV_COUNT);
            Queue<CarModel> xn2bjYWKRunQueue = new Queue<CarModel>(0);
            Queue<CarModel> xn2bjVOVRunQueue = new Queue<CarModel>(0);
            QueueHelper.addListInQueue(xn2bjYWKWaitQueue, xn2bjYWKList);
            QueueHelper.addListInQueue(xn2bjVOVWaitQueue, xn2bjVOVList);

            #endregion

            #region 初始化产生乘客的工厂类实例区
            IPersonFactory xn2bjPersonFactory = new XN2BJPersonFactory();
            IPersonFactory bj2xnPersonFactory = new BJ2XNPersonFactory();
            #endregion

            #region 初始化调度区
            BJ2XNSchedule bj2xnSchedule = new BJ2XNSchedule(bj2xnYWKWaitQueue, bj2xnVOVWaitQueue, bj2xnYWKRunQueue, bj2xnVOVRunQueue);
            XN2BJSchedule xn2bjSchedule = new XN2BJSchedule(xn2bjYWKWaitQueue, xn2bjVOVWaitQueue, xn2bjYWKRunQueue, xn2bjVOVRunQueue);
            bj2xnSchedule.generatePersonFactory = bj2xnPersonFactory;
            xn2bjSchedule.generatePersonFactory = xn2bjPersonFactory;
            #endregion

            #region 主窗体配置及执行区
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainCarScheduleForm mainform = new MainCarScheduleForm();

            mainform.bj2xnSchedule = bj2xnSchedule;
            mainform.xn2bjSchedule = xn2bjSchedule;

            Application.Run(mainform);
            #endregion
        }
    }
}
