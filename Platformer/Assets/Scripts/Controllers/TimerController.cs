using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class TimerController: IUpdateble
    {
        private const float REQUIRED_FOR_DELETING_TIMER_TIME = 20f;

        public void Update(float deltaTime)
        {
            for (int i = 0; i < TimersList.Timers.Count; i++)
            {
                if ((Time.time - TimersList.Timers[i].GetStartTime) >= TimersList.Timers[i].GetDeltaTime && !TimersList.Timers[i].IsTimerEndStatus)
                {
                    TimersList.Timers[i].InvokeTimerEnd();
                }

                if ((Time.time - TimersList.Timers[i].GetStartTime) >= REQUIRED_FOR_DELETING_TIMER_TIME)
                {
                    TimersList.RemoveTimer(TimersList.Timers[i]);
                }
            }
        }
    }
}
