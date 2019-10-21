using System;

namespace lab2
{
    public class Clock
    {
        private string name;
        private bool isPowerEnabled;
        private bool isHalfDayEnabled;
        private int[] currentTime = new int[2];
        private bool isAlarmEnabled;
        private int[] alarmTime = new int[2];


        public Clock(string clockName)
        {
            name = clockName;
            isPowerEnabled = true;
            isHalfDayEnabled = false;
            currentTime[0] = DateTime.Now.Hour;
            currentTime[1] = DateTime.Now.Minute;
            isAlarmEnabled = true;
            alarmTime[0] = currentTime[0];
            alarmTime[1] = currentTime[1] + 1;
        }
        
        public Clock(string clockName, int hours, int minutes)
        {
            name = clockName;
            isPowerEnabled = true;
            isHalfDayEnabled = false;
            currentTime[0] = hours;
            currentTime[1] = minutes;
            isAlarmEnabled = false;
            
        }
        
        public Clock(string clockName, int hours, int minutes, int alarmHours, int alarmMinutes)
        {
            name = clockName;
            isPowerEnabled = true;
            isHalfDayEnabled = false;
            currentTime[0] = hours;
            currentTime[1] = minutes;
            isAlarmEnabled = true;
            alarmTime[0] = alarmHours;
            alarmTime[1] = alarmMinutes;

        }
        
        public Clock(string clockName, int hours, int minutes, bool isAfternoon)
        {
            name = clockName;
            isPowerEnabled = true;
            isHalfDayEnabled = true;
            currentTime[0] = hours;
            currentTime[1] = minutes;
            isAlarmEnabled = false;
            setHalfTime(hours, minutes, isAfternoon);
        }
        
        public Clock(string clockName, int hours, int minutes, bool isAfternoon, int alarmHours, int alarmMinutes, bool alarmIsAfternoon)
        {
            name = clockName;
            isPowerEnabled = true;
            isHalfDayEnabled = true;
            currentTime[0] = hours;
            currentTime[1] = minutes;
            isAlarmEnabled = true;
            setHalfTime(hours, minutes, isAfternoon);
            setHalfAlarm(alarmHours, alarmMinutes, alarmIsAfternoon);
        }

        public string Name
        {
            get => name;
        }

        public bool IsHalfDayEnabled
        {
            get => isHalfDayEnabled;
        }
        public void setAlarm(bool isEnabled)
        {
            isAlarmEnabled = isEnabled;
        }

        public void statusInfo()
        {
            Console.WriteLine($"Name: {name};");
            if (isPowerEnabled)
            {
                Console.WriteLine("Power: Enabled;");
                if (isHalfDayEnabled)
                {
                    if (currentTime[0] > 12)
                    {
                        Console.WriteLine($"Current Time: {currentTime[0] - 12}:{currentTime[1]} PM");
                    }
                    else
                    {
                        Console.WriteLine($"Current Time: {currentTime[0]}:{currentTime[1]} AM");
                    }
                }
                else
                {
                    Console.WriteLine($"Current Time: {currentTime[0]}:{currentTime[1]}");
                }

                if (isAlarmEnabled)
                {
                    Console.WriteLine("Alarm: Eabled");
                    if (isHalfDayEnabled)
                    {
                        if (currentTime[0] > 12)
                        {
                            Console.WriteLine($"Alarm Time: {alarmTime[0] - 12}:{alarmTime[1]} PM");
                        }
                        else
                        {
                            Console.WriteLine($"Alarm Time: {alarmTime[0]}:{alarmTime[1]} AM");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Alarm Time: {alarmTime[0]}:{alarmTime[1]}");
                    }
                    if ((currentTime[0] == alarmTime[0]) && (currentTime[1] == alarmTime[1]))
                    {
                        Console.WriteLine("BEEP! BEEP! BEEP! BEEP! BEEEP!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Alarm: Disabled;");
            }
        }

        public void refreshTime()
        {
            currentTime[0] = DateTime.Now.Hour;
            currentTime[1] = DateTime.Now.Minute;
        }
        
        public void setPower(bool isEnabled)
        {
            if (isEnabled)
            {
                isPowerEnabled = isEnabled;
            }
            else
            {
                isAlarmEnabled = false;
                currentTime[0] = 0;
                currentTime[1] = 0;
                alarmTime[0] = 0;
                alarmTime[1] = 0;                
                isPowerEnabled = isEnabled;
                isHalfDayEnabled = false;
            }
        }

        public void setDayMode(bool isEnabled)
        {
            isHalfDayEnabled = isEnabled;
        }
        
        public void setFullTime(int hours, int minutes)
        {
            currentTime[0] = hours;
            currentTime[1] = minutes;
        }
        
        public void setHalfTime(int hours, int minutes, bool isAfternoon)
        {
            if (isAfternoon)
            {
                currentTime[0] = hours + 12;
                currentTime[1] = minutes;
            }
            else
            {
                currentTime[0] = hours;
                currentTime[1] = minutes;
            }
            
        }
        public void setFullAlarm(int hours, int minutes)
        {
            alarmTime[0] = hours;
            alarmTime[1] = minutes;
        }
        
        public void setHalfAlarm(int hours, int minutes, bool isAfternoon)
        {
            if (isAfternoon)
            {
                alarmTime[0] = hours + 12;
                alarmTime[1] = minutes;
            }
            else
            {
                alarmTime[0] = hours;
                alarmTime[1] = minutes;
            }
            
        }
    }
}