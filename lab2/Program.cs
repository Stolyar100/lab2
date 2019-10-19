using System;

namespace lab2
{
    public class Clock
    {
        private bool isPowerEnabled;
        private bool isHalfDayEnabled;
        private int[] currentTime = new int[2];
        private bool isAlarmEnabled;
        private int[] alarmTime = new int[2];


        public Clock()
        {
            isPowerEnabled = true;
            isHalfDayEnabled = false;
            currentTime[0] = DateTime.Now.Hour;
            currentTime[1] = DateTime.Now.Minute;
            isAlarmEnabled = true;
            alarmTime[0] = currentTime[0];
            alarmTime[1] = currentTime[1] + 1;
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
    internal class Program
    {
        public static void setHalfDayModeCase(Clock myClock) {
            Console.WriteLine("Enter:{0}" +
                              "0 - to cancel{0}" +
                              "1 - to set half day mode on{0}" +
                              "2 - to set half day mode off{0}", Environment.NewLine);
            int itemId = Int32.Parse(Console.ReadLine());
            switch (itemId)
            {
                case 0:
                    break;
                case 1:
                    myClock.setDayMode(true);
                    break;
                case 2: 
                    myClock.setDayMode(false);
                    break;
                default:
                    Console.WriteLine("You`ve entered wrong number");
                    break;
            }
        }

        public static void setTimeCase(Clock myClock)
        {
            if (myClock.IsHalfDayEnabled)
            {
                Console.WriteLine("Enter hour");
                int hour = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter minute");
                int minute = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter 0 if am, 1 if pm");
                int timeItemId = Int32.Parse(Console.ReadLine());
                switch (timeItemId)
                {
                    case 0:
                        myClock.setHalfTime(hour, minute, false);
                        break;
                    case 1:
                        myClock.setHalfTime(hour, minute, true);
                        break;
                    default:
                        Console.WriteLine("You`ve entered wrong number");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Enter hour");
                int hour = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter minute");
                int minute = Int32.Parse(Console.ReadLine());
                            
                myClock.setFullTime(hour,minute);   
            }
        }

        public static void setAlarmStatusCase(Clock myClock)
        {
            Console.WriteLine("Enter:{0}" +
                              "0 - to cancel{0}" +
                              "1 - to set alarm on{0}" +
                              "2 - to set alarm off{0}", Environment.NewLine);
            int alarmItemId = Int32.Parse(Console.ReadLine());
            switch (alarmItemId)
            {
                case 0:
                    break;
                case 1:
                    myClock.setAlarm(true);
                    break;
                case 2: 
                    myClock.setAlarm(false);
                    break;
                default:
                    Console.WriteLine("You`ve entered wrong number");
                    break;
            }
        }

        public static void setAlarmTimeCase(Clock myClock)
        {
            if (myClock.IsHalfDayEnabled)
            {
                Console.WriteLine("Enter hour");
                int hour = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter minute");
                int minute = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter 1 if am, 0 if pm");
                bool isAfternoon = bool.Parse(Console.ReadLine());

                myClock.setHalfAlarm(hour,minute, isAfternoon);
            }
            else
            {
                Console.WriteLine("Enter hour");
                int hour = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter minute");
                int minute = Int32.Parse(Console.ReadLine());
                            
                myClock.setFullAlarm(hour,minute);   
            }
        }

        public static void setPowerStatusCase(Clock myClock)
        {
            Console.WriteLine("Enter:{0}" +
                              "0 - to cancel{0}" +
                              "1 - to set power on{0}" +
                              "2 - to set power off{0}", Environment.NewLine);
            int alarmMenu = Int32.Parse(Console.ReadLine());
            switch (alarmMenu)
            {
                case 0:
                    break;
                case 1:
                    myClock.setPower(true);
                    break;
                case 2: 
                    myClock.setPower(false);
                    break;
                default:
                    Console.WriteLine("You`ve entered wrong number");
                    break;
            }
        }
        public static void Main(string[] args)
        {
            Clock myClock = new Clock();
            bool condition = true;
            while (condition)
            {
                Console.WriteLine("A congratulations! It`s main menu, enter: {0} " +
                                  "0 - to see clock status {0}" +
                                  "1 - to refresh time {0}" +
                                  "2 - to set half day mode {0}" +
                                  "3 - to set power status {0}" +
                                  "4 - to set time {0}" +
                                  "5 - to set alarm status {0}" +
                                  "6 - to set alarm time {0}" +
                                  "7 - cancel{0}", Environment.NewLine);
                int item_id = Int32.Parse(Console.ReadLine());

                switch (item_id)
                {
                    case 0:
                        myClock.statusInfo();
                        break;
                    case 1:
                        myClock.refreshTime();
                        break;
                    case 2:
                        setHalfDayModeCase(myClock);
                        break;
                    case 3:
                        setPowerStatusCase(myClock);
                        break;
                    case 4:
                        setTimeCase(myClock);
                        break;
                    case 5:
                        setAlarmStatusCase(myClock);
                        break;
                    case 6:
                        setAlarmStatusCase(myClock);
                        break;
                    case 7:
                        condition = false;
                        break;

                    default:
                        Console.WriteLine("You`ve entered wrong number");
                        break;
                }
                Console.WriteLine("{0} -------------------------------------------------- {0}",
                    Environment.NewLine);
            } 
        }
    }
}