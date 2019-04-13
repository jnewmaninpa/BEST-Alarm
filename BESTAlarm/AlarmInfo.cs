using System;
using System.IO;
namespace BESTAlarm
{
    class AlarmInfo
    {

        String[] alarmButtonImageFileName;
        TimeSpan[] alarmButtonTime;
        Boolean[] alarmButtonIsOn;
        string[] alarmButtonID;

        public AlarmInfo()
        {
            alarmButtonImageFileName = new String[9] { "toothbrush.png", "shirt.png", "bed.png", "snitch.png", "cloud.png", "wrench.png", "plate.png", "sleep.png", "car.png" };
            alarmButtonTime = new TimeSpan[9] { (new TimeSpan(7, 0, 0)), (new TimeSpan(7, 5, 0)), (new TimeSpan(21, 30, 0)), (new TimeSpan(16, 0, 0)),
                (new TimeSpan(7, 45, 0)), (new TimeSpan(13, 0, 0)), (new TimeSpan(12, 0, 0)), (new TimeSpan(17, 0, 0)), (new TimeSpan(15, 30, 0)) };
            alarmButtonIsOn = new Boolean[9] { false, false, false, false, false, false, false, false, false };
            alarmButtonID = new string[9] { "alarm1", "alarm2", "alarm3", "alarm4", "alarm5", "alarm6", "alarm7", "alarm8", "alarm9" };
        }

        public AlarmInfo(String fileName)
        {
            alarmButtonImageFileName = new String[9];
            alarmButtonTime = new TimeSpan[9];
            alarmButtonIsOn = new Boolean[9];
            alarmButtonID = new string[9];

            String fileInfo = File.ReadAllText(fileName);

            String[] fileLine = fileInfo.Split('\n');

            for (int i = 0; i < 9; i++)
            {
                string[] info = fileLine[i].Split(',');
                alarmButtonImageFileName[i] = info[0];
                int hours = Int32.Parse(info[1]);
                int minutes = Int32.Parse(info[2]);
                int seconds = Int32.Parse(info[3]);
                alarmButtonTime[i] = new TimeSpan(hours, minutes, seconds);
                alarmButtonIsOn[i] = Boolean.Parse(info[4]);
                alarmButtonID[i] = info[5];
            }
        }

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

        public Boolean isAlarmButtonOn(int index)
        {
            return alarmButtonIsOn[index];
        }

        public void setAlarmButtonOnOff(Boolean[] onOrOff)
        {
            alarmButtonIsOn = onOrOff;
        }

        public void setAlarmButtonOnOff(Boolean onOrOff, int index)
        {
            alarmButtonIsOn[index] = onOrOff;
        }

        public string getAlarmButtonID(int index)
        {
            return alarmButtonID[index];
        }

        public void setAlarmButtonID(string id, int index)
        {
            alarmButtonID[index] = id;
        }

        public void SaveToFile(string fileName)
        {
            String data = "";

            for (int i = 0; i < 9; i++)
            {
                data += (alarmButtonImageFileName[i] + ",");
                data += (alarmButtonTime[i].Hours + ",");
                data += (alarmButtonTime[i].Minutes + ",");
                data += (alarmButtonTime[i].Seconds + ",");
                data += (alarmButtonIsOn[i] + ",");
                data += (alarmButtonID[i] + '\n');
            }

            File.WriteAllText(fileName, data);
        }

    }

}
