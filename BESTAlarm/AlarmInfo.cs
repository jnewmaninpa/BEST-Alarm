using System;
using System.IO;
namespace BESTAlarm
{
    class AlarmInfo
    {
        String[] alarmButtonImageFileName;
        TimeSpan[] alarmButtonTime;

        public String[] GetAlarmButtonImageFileName()
        {
            return alarmButtonImageFileName;
        }

        public void SetAlarmButtonImageFileName(String[] newAlarmButtonImageFileName)
        {
            alarmButtonImageFileName = newAlarmButtonImageFileName;
        }

        public void SetAlarmButtonImageFileName(String newAlarmButtonImageFileName, int index)
        {
            alarmButtonImageFileName[index] = newAlarmButtonImageFileName;
        }

        public TimeSpan[] GetAlarmButtonTime()
        {
            return alarmButtonTime;
        }

        public void SetAlarmButtonTime(TimeSpan[] newAlarmButtonTime)
        {
            alarmButtonTime = newAlarmButtonTime;
        }

        public void SetAlarmButtonTime(TimeSpan newAlarmButtonTime, int index)
        {
            alarmButtonTime[index] = newAlarmButtonTime;
        }

        public Boolean SaveToFile()
        {
            String data = "";

            for (int i = 0; i < 9; i++)
            {
                data += (alarmButtonImageFileName[i] + ",");
                data += (alarmButtonTime.ToString() + ",");
            }

            //File.WriteAllText("tempFile", data);

            return true;
        }

    }
}
