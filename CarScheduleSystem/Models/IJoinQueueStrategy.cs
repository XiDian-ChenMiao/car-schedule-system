using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarScheduleSystem.Models
{
    /// <summary>
    /// 合并队列时使用的合并策略接口
    /// </summary>
    public interface IJoinQueueStrategy
    {
        /// <summary>
        /// 合并队列的方法
        /// </summary>
        /// <param name="headQueue">前一个队列</param>
        /// <param name="tailQueue">后一个队列</param>
        /// <param name="finalQueue">目标合成队列</param>
        Queue<CarModel> joinQueue(Queue<CarModel> headQueue, Queue<CarModel> tailQueue);
    }
}
