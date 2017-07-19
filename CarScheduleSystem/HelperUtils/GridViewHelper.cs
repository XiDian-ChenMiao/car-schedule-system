using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarScheduleSystem.Models;
namespace CarScheduleSystem.HelperUtils
{
    /// <summary>
    /// 与界面层GridView控件相关的工具类
    /// </summary>
    public class GridViewHelper
    {
        /// <summary>
        /// 为GridView绑定等待队列
        /// </summary>
        /// <param name="gridView">目标显示控件</param>
        /// <param name="_queue">待绑定的队列</param>
        public static void bindWaitQueueForGridView(DataGridView gridView, Queue<CarModel> _queue)
        {
            gridView.Rows.Clear();
            //遍历队列，将其中的值赋给显示控件gridView
            for (int i = 0; i < _queue.Count; ++i)
            {
                CarModel carModel = _queue.ElementAt(i);
                DataGridViewRow row = new DataGridViewRow();
                gridView.Rows.Add(new Object[] { carModel.carModelName, carModel.carNumber, carModel.startEngineTime.ToString(ISystemConfig.SYSTEM_PANEL_SHOW_TIME_FORMAT) });
            }
        }
        /// <summary>
        /// 为GridView绑定运行队列
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="_queue"></param>
        public static void bindRunQueueForGridView(DataGridView gridView, Queue<CarModel> _queue)
        {
            gridView.Rows.Clear();
            //遍历队列，将其中的值赋给显示控件gridView
            for (int i = 0; i < _queue.Count; ++i)
            {
                CarModel carModel = _queue.ElementAt(i);
                DataGridViewRow row = new DataGridViewRow();
                //在显示距终点距离时，按照取一位小数点格式
                gridView.Rows.Add(new Object[] { carModel.carModelName, carModel.carNumber, carModel.carStatus, Math.Round(carModel.distanceToEnd,1) + ISystemConfig.SYSTEM_KILOMETERS_SHOW });
            }
        }
    }
}
