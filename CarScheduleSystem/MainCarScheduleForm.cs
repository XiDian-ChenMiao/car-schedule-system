using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarScheduleSystem.Models;
using CarScheduleSystem.HelperUtils;
using CarScheduleSystem.DialogForms;
using System.Timers;
namespace CarScheduleSystem
{
    /// <summary>
    /// 西宝高速车辆调度显示主窗体
    /// </summary>
    public partial class MainCarScheduleForm : Form
    {
        public BJ2XNSchedule bj2xnSchedule { set; get; }
        public XN2BJSchedule xn2bjSchedule { set; get; }
        
        private IJoinQueueStrategy joinStrategyByTime;
        private IJoinQueueStrategy joinStrategyByDistance;
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public MainCarScheduleForm()
        {
            InitializeComponent();
            joinStrategyByTime = new JoinQueueByStartEngineTime();
            joinStrategyByDistance = new JoinQueueByDistanceToDestination();
        }
        /// <summary>
        /// 更新系统时间的定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateSysTimeTimer_Tick(object sender, EventArgs e)
        {
            this.sysTimeShowLabel.Text = ISystemConfig.SYSTEM_TIME_INTRODUCTION + DateTime.Now.ToString(ISystemConfig.SYSTEM_TIME_FORMAT);
            //根据频率检查是否有车到站
            changeStationWhenCarToDestination(bj2xnSchedule, xn2bjSchedule);
        }
        /// <summary>
        /// 主窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainCarScheduleForm_Load(object sender, EventArgs e)
        {
            //界面上显示系统时间
            this.sysTimeShowLabel.Text = ISystemConfig.SYSTEM_TIME_INTRODUCTION + DateTime.Now.ToString(ISystemConfig.SYSTEM_TIME_FORMAT);
            //设置系统时间的更新频率
            this.updateSysTimeTimer.Interval = ISystemConfig.SYSTEM_TIME_UPDATE_DURRENCY;
            //设置宝鸡到西安的面板的更新频率
            this.updateBJ2XNScheduleTimer.Interval = ISystemConfig.BJ2XN_SCHEDULE_UPDATE_DURRENCY;
            //设置西安到宝鸡的面板的更新频率
            this.updateXN2BJScheduleTimer.Interval = ISystemConfig.XN2BJ_SCHEDULE_UPDATE_DURRENCY;

            //启动所有的定时器
            this.updateSysTimeTimer.Start();
            this.updateXN2BJScheduleTimer.Start();
            this.updateBJ2XNScheduleTimer.Start();
        }
        /// <summary>
        /// 改变到站情况
        /// </summary>
        /// <param name="firstSchedule"></param>
        /// <param name="secdSchedule"></param>
        private void changeStationWhenCarToDestination(BaseSchedule firstSchedule,BaseSchedule secdSchedule)
        {
            //如果第一个调度中发现有到站车辆，则第一个调度将自身的到站列表传入第二个调度的addDaoZhanListInWaitQueue方法中
            if (firstSchedule.daoZhanList.Count != 0)
            {
                secdSchedule.addDaoZhanListInWaitQueue(firstSchedule.daoZhanList);
            }
            //如果第二个调度中发现有到站车辆，则第二个调度将自身的到站列表传入第一个调度的addDaoZhanListInWaitQueue方法中
            if (secdSchedule.daoZhanList.Count != 0)
            {
                firstSchedule.addDaoZhanListInWaitQueue(secdSchedule.daoZhanList);
            }
        }
        /// <summary>
        /// 宝鸡到西安面板调度定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateBJ2XNScheduleTimer_Tick(object sender, EventArgs e)
        {
            Queue<CarModel> bj2xnVoVWaitQueue = bj2xnSchedule.vovWaitQueue;
            Queue<CarModel> bj2xnYWKWaitQueue = bj2xnSchedule.ywkWaitQueue;
            Queue<CarModel> bj2xnVoVRunQueue = bj2xnSchedule.vovRunQueue;
            Queue<CarModel> bj2xnYWKRunQueue = bj2xnSchedule.ywkRunQueue;
            Queue<CarModel> timeResult = joinStrategyByTime.joinQueue(bj2xnVoVWaitQueue, bj2xnYWKWaitQueue);
            Queue<CarModel> distanceResult = joinStrategyByDistance.joinQueue(bj2xnVoVRunQueue, bj2xnYWKRunQueue);

            GridViewHelper.bindWaitQueueForGridView(bj2xnWaitGridView,timeResult);
            GridViewHelper.bindRunQueueForGridView(bj2xnRunGridView,distanceResult);
        }
        /// <summary>
        /// 西安到宝鸡面板调度定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateXN2BJScheduleTimer_Tick(object sender, EventArgs e)
        {
            Queue<CarModel> xn2bjVoVWaitQueue = xn2bjSchedule.vovWaitQueue;
            Queue<CarModel> xn2bjYWKWaitQueue = xn2bjSchedule.ywkWaitQueue;
            Queue<CarModel> xn2bjVoVRunQueue = xn2bjSchedule.vovRunQueue;
            Queue<CarModel> xn2bjYWKRunQueue = xn2bjSchedule.ywkRunQueue;
            Queue<CarModel> timeResult = joinStrategyByTime.joinQueue(xn2bjVoVWaitQueue, xn2bjYWKWaitQueue);
            Queue<CarModel> distanceResult = joinStrategyByDistance.joinQueue(xn2bjVoVRunQueue, xn2bjYWKRunQueue);

            GridViewHelper.bindWaitQueueForGridView(xn2bjWaitGridView, timeResult);
            GridViewHelper.bindRunQueueForGridView(xn2bjRunGridView, distanceResult);
        }
        /// <summary>
        /// 当宝鸡到西安等待队列的更多按钮被点击时，触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bj2xnWaitMoreTxt_Click(object sender, EventArgs e)
        {            
            new BiggerWaitQueueForm("宝鸡站到西安站","宝鸡站等待发车队列",this,ISystemConfig.STATION_BJ,ISystemConfig.STATION_XN).Show();
        }
        /// <summary>
        /// 当西安到宝鸡等待队列的更多按钮被点击时，触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xn2bjWaitMoreTxt_Click(object sender, EventArgs e)
        {
            new BiggerWaitQueueForm("西安站到宝鸡站","西安站等待发车队列", this, ISystemConfig.STATION_XN, ISystemConfig.STATION_BJ).Show();
        }
        /// <summary>
        /// 当宝鸡到西安运行队列的更多按钮被点击时，触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bj2xnRunMoreTxt_Click(object sender, EventArgs e)
        {
            new BiggerRunQueueForm("宝鸡站到西安站", "宝鸡到西安运行队列", this, ISystemConfig.STATION_BJ, ISystemConfig.STATION_XN).Show();
        }
        /// <summary>
        /// 当西安到宝鸡运行队列的更多按钮被点击时，触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xn2bjRunMoreTxt_Click(object sender, EventArgs e)
        {
            new BiggerRunQueueForm("西安站到宝鸡站", "西安到宝鸡运行队列", this, ISystemConfig.STATION_XN, ISystemConfig.STATION_BJ).Show();
        }
        /// <summary>
        /// 点击了关闭系统菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeSysMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("您确定要退出系统吗?", "退出系统", MessageBoxButtons.OKCancel);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.Dispose();
            }
        }
        /// <summary>
        /// 单元格敲击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bj2xnRunGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gridView = (DataGridView)sender;
            setCarInfoForCarStatusShowArea(getCarInfoFromGridView(gridView.CurrentCell.RowIndex,bj2xnSchedule.vovRunQueue,bj2xnSchedule.ywkRunQueue,new JoinQueueByDistanceToDestination()));
        }
        /// <summary>
        /// 为车辆状态显示区设置车辆信息
        /// </summary>
        /// <param name="car"></param>
        public void setCarInfoForCarStatusShowArea(CarModel car)
        {
            if (car != null)
            {
                this.carModel.Text = car.carModelName;
                this.carStus.Text = car.carStatus;
                this.disToEnd.Text = Math.Round(car.distanceToEnd, 1) + ISystemConfig.SYSTEM_KILOMETERS_SHOW;
                this.carNumber.Text = car.carNumber;
                this.loadPersonCount.Text = car.personInCar.Count + "位乘客";
                this.carSpeed.Text = car.kilosPerMinute + "公里/每分钟";
                this.startTime.Text = car.startEngineTime.ToString(ISystemConfig.SYSTEM_PANEL_SHOW_TIME_FORMAT);
                this.currentLocation.Text = car.currentLoc;
            }
        }
        /// <summary>
        /// 通过行索引来从GridView中获取信息
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private CarModel getCarInfoFromGridView(int rowIndex,Queue<CarModel> q1,Queue<CarModel> q2,IJoinQueueStrategy joinStrategy)
        {
            Queue<CarModel> result = joinStrategy.joinQueue(q1,q2);
            return result.ElementAt(rowIndex) != null ? result.ElementAt(rowIndex) : null;
        }

        private void xn2bjRunGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gridView = (DataGridView)sender;
            setCarInfoForCarStatusShowArea(getCarInfoFromGridView(gridView.CurrentCell.RowIndex, xn2bjSchedule.vovRunQueue, xn2bjSchedule.ywkRunQueue, new JoinQueueByDistanceToDestination()));
        }

        private void bj2xnWaitGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gridView = (DataGridView)sender;
            setCarInfoForCarStatusShowArea(getCarInfoFromGridView(gridView.CurrentCell.RowIndex, bj2xnSchedule.vovWaitQueue, bj2xnSchedule.ywkWaitQueue, new JoinQueueByStartEngineTime()));
        }

        private void xn2bjWaitGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gridView = (DataGridView)sender;
            setCarInfoForCarStatusShowArea(getCarInfoFromGridView(gridView.CurrentCell.RowIndex, xn2bjSchedule.vovWaitQueue, xn2bjSchedule.ywkWaitQueue, new JoinQueueByStartEngineTime()));
        }
        /// <summary>
        /// 点击系统信息菜单触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sysInfoMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messBoxBtn = MessageBoxButtons.OK;
            MessageBox.Show(ISystemConfig.SYSTEM_TIPS_CONTENT, ISystemConfig.SYSTEM_TIPS, messBoxBtn);
        }
    }
}
