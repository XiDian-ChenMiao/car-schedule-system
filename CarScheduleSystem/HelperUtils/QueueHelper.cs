using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarScheduleSystem.Models;
namespace CarScheduleSystem.HelperUtils
{
    /// <summary>
    /// 给Queue对象中添加List集合元素工具类
    /// </summary>
    public class QueueHelper
    {
        /// <summary>
        /// 给队列中添加集合元素
        /// </summary>
        /// <param name="queue">要加入的队列</param>
        /// <param name="list">元素集合</param>
        public static void addListInQueue(Queue<CarModel> queue, List<CarModel> list)
        {
            if (queue != null && list != null && list.Count != 0)
            {
                foreach (CarModel obj in list)
                    queue.Enqueue(obj);
            }
        }
    }
}
