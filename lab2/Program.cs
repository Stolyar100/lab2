using System;
using System.Collections.Generic;

namespace lab2
{
    internal class Program
    {
        public static void setHalfDayModeCase(List<Clock> _ClocksList)
        {
            int clockIndex = enterIndex();
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
                    _ClocksList[clockIndex].setDayMode(true);
                    break;
                case 2: 
                    _ClocksList[clockIndex].setDayMode(false);
                    break;
                default:
                    Console.WriteLine("You`ve entered wrong number");
                    break;
            }
        }

        public static void setTimeCase(List<Clock> _ClocksList)
        {
            int clockIndex = enterIndex();
            if (_ClocksList[clockIndex].IsHalfDayEnabled)
            {
                Console.WriteLine("Enter hour");
                int hour = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter minute");
                int minute = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter 0 if am, 1 if pm");
                bool isEvening = parseDigitToBool(Console.ReadLine());
                _ClocksList[clockIndex].setHalfTime(hour, minute, isEvening);
            }
            else
            {
                Console.WriteLine("Enter hour");
                int hour = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter minute");
                int minute = Int32.Parse(Console.ReadLine());
                            
                _ClocksList[clockIndex].setFullTime(hour,minute);   
            }
        }

        public static void setAlarmStatusCase(List<Clock> _ClocksList)
        {
            int clockIndex = enterIndex();
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
                    _ClocksList[clockIndex].setAlarm(true);
                    break;
                case 2: 
                    _ClocksList[clockIndex].setAlarm(false);
                    break;
                default:
                    Console.WriteLine("You`ve entered wrong number");
                    break;
            }
        }

        public static void setAlarmTimeCase(List<Clock> _ClocksList)
        {
            int clockIndex = enterIndex();
            if (_ClocksList[clockIndex].IsHalfDayEnabled)
            {
                Console.WriteLine("Enter hour");
                int hour = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter minute");
                int minute = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter 1 if am, 0 if pm");
                bool isAfternoon = parseDigitToBool(Console.ReadLine());

                _ClocksList[clockIndex].setHalfAlarm(hour,minute, isAfternoon);
            }
            else
            {
                Console.WriteLine("Enter hour");
                int hour = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter minute");
                int minute = Int32.Parse(Console.ReadLine());
                            
                _ClocksList[clockIndex].setFullAlarm(hour,minute);   
            }
        }

        public static void setPowerStatusCase(List<Clock> _ClocksList)
        {
            int clockIndex = enterIndex();
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
                    _ClocksList[clockIndex].setPower(true);
                    break;
                case 2: 
                    _ClocksList[clockIndex].setPower(false);
                    break;
                default:
                    Console.WriteLine("You`ve entered wrong number");
                    break;
            }
        }

        public static void seeClocklistCase(List<Clock> _ClocksList)
        {
            foreach (Clock tempClock in _ClocksList)
            {
                Console.WriteLine($"Clock name: {tempClock.Name}, Index of object: {_ClocksList.IndexOf(tempClock)}");
            }
        }

        public static void addNewClock(List<Clock> _ClocksList)
        {
            Console.WriteLine("Enter:{0}" +
                              "0 - to create clock with default properties;{0}" +
                              "1 - to create clock with manual time setting {0}" +
                              "2 - to create clock with manual time and alarm setting{0}" +
                              "3 - to to create clock with manual time setting and 12-hour mode {0}" +
                              "4 - to to create clock with manual time and alarm setting and 12-hour mode {0}" +
                              "5 - to cancel", Environment.NewLine);
            int newClockMenu = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter clock name");
            string clockName = Console.ReadLine();
            
            switch (newClockMenu)
            {
                case 0:
                    _ClocksList.Add(new Clock(clockName));
                    break;
                case 1:
                    Console.WriteLine("Enter hour");
                    int hoursCase1 = Int32.Parse(Console.ReadLine()); 
                    Console.WriteLine("Enter minute");
                    int minutesCase1 = Int32.Parse(Console.ReadLine());
                    _ClocksList.Add(new Clock(clockName, hoursCase1, minutesCase1));
                    break;
                case 2:
                    Console.WriteLine("Enter hour");
                    int hoursCase2 = Int32.Parse(Console.ReadLine()); 
                    Console.WriteLine("Enter minute");
                    int minutesCase2 = Int32.Parse(Console.ReadLine());
                    _ClocksList.Add(new Clock(clockName, hoursCase2, minutesCase2));
                    Console.WriteLine("Enter alarm hour");
                    int alarmHoursCase2 = Int32.Parse(Console.ReadLine()); 
                    Console.WriteLine("Enter alarm minute");
                    int alarmMinutesCase2 = Int32.Parse(Console.ReadLine());
                    _ClocksList.Add(new Clock(clockName, hoursCase2, minutesCase2, alarmHoursCase2, alarmMinutesCase2));
                    break;
                case 3:
                    Console.WriteLine("Enter hour");
                    int hoursCase3 = Int32.Parse(Console.ReadLine()); 
                    Console.WriteLine("Enter minute");
                    int minutesCase3 = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter:{0}" +
                                      "0 - am{0}" +
                                      "1 - pm", Environment.NewLine);
                    bool isEveningCase3 =  parseDigitToBool(Console.ReadLine());
                    _ClocksList.Add(new Clock(clockName, hoursCase3, minutesCase3, isEveningCase3));
                    break;
                case 4:
                    Console.WriteLine("Enter hour");
                    int hoursCase4 = Int32.Parse(Console.ReadLine()); 
                    Console.WriteLine("Enter minute");
                    int minutesCase4 = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter:{0}" +
                                      "0 - am{0}" +
                                      "1 - pm", Environment.NewLine);
                    bool isEveningCase4 = parseDigitToBool(Console.ReadLine());
                    Console.WriteLine("Enter alarm hour");
                    int alarmHoursCase4 = Int32.Parse(Console.ReadLine()); 
                    Console.WriteLine("Enter alarm minute");
                    int alarmMinutesCase4 = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter:{0}" +
                                      "0 - am{0}" +
                                      "1 - pm", Environment.NewLine);
                    bool alarmIsEveningCase4 =  parseDigitToBool(Console.ReadLine());
                    _ClocksList.Add(new Clock(clockName, hoursCase4, minutesCase4, isEveningCase4,
                        alarmHoursCase4, alarmMinutesCase4, alarmIsEveningCase4));
                    break;
                case 5:
                    break;
                default: 
                    Console.WriteLine("You`ve entered wrong number");
                    break;
            }
            
        }

        public static void deleteClockCase(List<Clock> _ClocksList)
        {
            int deleteIndex = enterIndex();
            _ClocksList.RemoveAt(deleteIndex);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public static bool parseDigitToBool(string digit)
        {
            if (digit == "1")
            {
                return true;
            }
            else if (digit == "0")
            {
                return false;
            }
            else
            {
                throw new FormatException("The string is not a recognized as a valid boolean value.");
            }
        }

        public static int enterIndex()
        {
            Console.WriteLine("Enter the choosen clock index");
            return Int32.Parse(Console.ReadLine());
        }

        public static void seeClockStatus(List<Clock> _ClocksList)
        {
            int clockIndex = enterIndex();
            _ClocksList[clockIndex].statusInfo();
        }
        
        public static void refreshClockTime(List<Clock> _ClocksList)
        {
            int clockIndex = enterIndex();
            _ClocksList[clockIndex].refreshTime();
        }
        public static void Main(string[] args)
        {
            bool condition = true;
            while (condition)
            {
                Console.WriteLine("A congratulations! It`s main menu, enter: {0}" +
                                  "0 - to see clock object list {0}" +
                                  "1 - to create new clock {0}" +
                                  "2 - to delete clock {0}" +
                                  "3 - to see clock status {0}" +
                                  "4 - to refresh time {0}" +
                                  "5 - to set half day mode {0}" +
                                  "6 - to set power status {0}" +
                                  "7 - to set time {0}" +
                                  "8 - to set alarm status {0}" +
                                  "9 - to set alarm time {0}" +
                                  "10 - cancel{0}", Environment.NewLine);
                int item_id = Int32.Parse(Console.ReadLine());

                switch (item_id)
                {
                    case 0:
                        seeClocklistCase(cloclList._Clocks);
                        break;
                    case 1:
                        addNewClock(cloclList._Clocks);
                        break;
                    case 2:
                        deleteClockCase(cloclList._Clocks);
                        break;
                    case 3:
                        seeClockStatus(cloclList._Clocks);
                        break;
                    case 4:
                        refreshClockTime(cloclList._Clocks);
                        break;
                    case 5:
                        setHalfDayModeCase(cloclList._Clocks);
                        break;
                    case 6:
                        setPowerStatusCase(cloclList._Clocks);
                        break;
                    case 7:
                        setTimeCase(cloclList._Clocks);
                        break;
                    case 8:
                        setAlarmStatusCase(cloclList._Clocks);
                        break;
                    case 9:
                        setAlarmStatusCase(cloclList._Clocks);
                        break;
                    case 10:
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