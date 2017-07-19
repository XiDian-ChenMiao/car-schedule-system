using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarScheduleSystem.Models
{
    /// <summary>
    /// 通过发车时间来合并队列
    /// </summary>
    class JoinQueueByStartEngineTime : IJoinQueueStrategy
    {
        public Queue<CarModel> joinQueue(Queue<CarModel> headQueue, Queue<CarModel> tailQueue)
        {
            int headQueueCount = headQueue.Count;
            int tailQueueCount = tailQueue.Count;
            Queue<CarModel> finalQueue = new Queue<CarModel>();
            int i = 0, j = 0;
            while (i < headQueueCount && j < tailQueueCount)
            {
                CarModel headModel = headQueue.ElementAt(i);
                CarModel tailModel = tailQueue.ElementAt(j);
                //发车时间早的车辆优先插入队列
                if (headModel.startEngineTime.CompareTo(tailModel.startEngineTime) < 0)
                {
                    finalQueue.Enqueue(headModel);
                    i++;
                }
                else
                {
                    finalQueue.Enqueue(tailModel);
                    j++;
                }
            }
            while (i < headQueueCount)
                finalQueue.Enqueue(headQueue.ElementAt(i++));
            while (j < tailQueueCount)
                finalQueue.Enqueue(tailQueue.ElementAt(j++));
            return finalQueue;
        }
    }
}
