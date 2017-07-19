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
namespace CarScheduleSystem.DialogForms
{
    /// <summary>
    /// 运行队列放大窗体
    /// </summary>
    public partial class BiggerRunQueueForm : Form
    {
        #region 私有属性
        private MainCarScheduleForm parentForm;
        private string StartFrom;
        private string GoTo;
        #endregion
        /// <summary>
        /// 运行窗体的构造函数
        /// </summary>
        /// <param name="formHeader">窗体名称</param>
        /// <param name="headerTxt">窗体中头部面板文字</param>
        /// <param name="_parentForm">父窗体引用</param>
        /// <param name="startFrom">出发地</param>
        /// <param name="goTo">目的地</param>
        public BiggerRunQueueForm(string formHeader, string headerTxt, MainCarScheduleForm _parentForm, string startFrom, string goTo)
        {
            InitializeComponent();
            if (headerTxt != null && !"".Equals(headerTxt) && formHeader != null && !"".Equals(formHeader))
            {
                this.Text = formHeader;
                this.waitHeaderTxt.Text = headerTxt;
            }
            if (startFrom != null && !"".Equals(startFrom) && goTo != null && !"".Equals(goTo))
            {
                this.StartFrom = startFrom;
                this.GoTo = goTo;
            }
            if (_parentForm != null)
                this.parentForm = _parentForm;
            if (ISystemConfig.STATION_BJ.Equals(startFrom) && ISystemConfig.STATION_XN.Equals(goTo))
                this.updateGridViewTimer.Interval = ISystemConfig.BJ2XN_SCHEDULE_UPDATE_DURRENCY;
            else if (ISystemConfig.STATION_XN.Equals(startFrom) && ISystemConfig.STATION_BJ.Equals(goTo))
                this.updateGridViewTimer.Interval = ISystemConfig.XN2BJ_SCHEDULE_UPDATE_DURRENCY;
            this.updateGridViewTimer.Start();
        }
        /// <summary>
        /// 关闭操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        /// <summary>
        /// 更新GridView事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateGridViewTimer_Tick(object sender, EventArgs e)
        {
            bindQueueForGridView();
        }
        /// <summary>
        /// 窗体加载完执行的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BiggerWaitQueueForm_Load(object sender, EventArgs e)
        {
            bindQueueForGridView();
        }
        /// <summary>
        /// 绑定运行队列到GridView
        /// </summary>
        private void bindQueueForGridView()
        {
            if (this.parentForm != null)
            {
                Queue<CarModel> runQueue1 = null, runQueue2 = null;
                if (ISystemConfig.STATION_BJ.Equals(StartFrom) && ISystemConfig.STATION_XN.Equals(GoTo))
                {
                    runQueue1 = parentForm.bj2xnSchedule.vovRunQueue;
                    runQueue2 = parentForm.bj2xnSchedule.ywkRunQueue;
                }
                else if (ISystemConfig.STATION_XN.Equals(StartFrom) && ISystemConfig.STATION_BJ.Equals(GoTo))
                {
                    runQueue1 = parentForm.xn2bjSchedule.vovRunQueue;
                    runQueue2 = parentForm.xn2bjSchedule.ywkRunQueue;
                }
                //给运行队列按照距离终点站的远近排序合并
                IJoinQueueStrategy joinStrategyByTime = new JoinQueueByDistanceToDestination();
                Queue<CarModel> distanceResult = joinStrategyByTime.joinQueue(runQueue1, runQueue2);
                //绑定合并后的队列
                GridViewHelper.bindRunQueueForGridView(this.waitQueueDataGridView, distanceResult);
            }
        }

        private void runQueueDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gridView = (DataGridView)sender;
            //宝鸡到西安方向
            if (ISystemConfig.STATION_BJ.Equals(StartFrom) && ISystemConfig.STATION_XN.Equals(GoTo))
            {
                CarModel car = getCarInfoFromGridView(gridView.CurrentCell.RowIndex, parentForm.bj2xnSchedule.ywkRunQueue, parentForm.bj2xnSchedule.vovRunQueue, new JoinQueueByDistanceToDestination());
                //回调主界面的显示车辆信息函数
                this.parentForm.setCarInfoForCarStatusShowArea(car);
            }
            //西安到宝鸡方向
            else if (ISystemConfig.STATION_BJ.Equals(GoTo) && ISystemConfig.STATION_XN.Equals(StartFrom))
            {
                CarModel car = getCarInfoFromGridView(gridView.CurrentCell.RowIndex, parentForm.xn2bjSchedule.ywkRunQueue, parentForm.xn2bjSchedule.vovRunQueue, new JoinQueueByDistanceToDestination());
                //回调主界面的显示车辆信息函数
                this.parentForm.setCarInfoForCarStatusShowArea(car);
            }
        }
        /// <summary>
        /// 通过行索引来从GridView中获取信息
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private CarModel getCarInfoFromGridView(int rowIndex, Queue<CarModel> q1, Queue<CarModel> q2, IJoinQueueStrategy joinStrategy)
        {
            Queue<CarModel> result = joinStrategy.joinQueue(q1, q2);
            return result.ElementAt(rowIndex) != null ? result.ElementAt(rowIndex) : null;
        }
    }
}
