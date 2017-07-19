using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarScheduleSystem.Models
{
    /// <summary>
    /// 通过距离终点站的距离来合并两个队列
    /// </summary>
    class JoinQueueByDistanceToDestination : IJoinQueueStrategy
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
                //距离终点站距离越近的车辆越优先插入队列
                if (headModel.distanceToEnd < tailModel.distanceToEnd)
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
