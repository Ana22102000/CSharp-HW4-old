using System;
using System.Threading;

namespace CSharpHomework.Model
{
    internal class Person
    {
        public Person(string name, string surname, string email, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Birthday = birthday;

            Thread myThread = new Thread(new ThreadStart(Count));
            myThread.Start();
            myThread.Join();
            //todo throw exceptions

        }


        public Person(string name, string surname, string email) :
            this(name, surname, email, DateTime.Today)
        {
        }

        public Person(string name, string surname, DateTime birthday) :
            this(name, surname, "", birthday)
        {
        }


        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public DateTime Birthday { get; set; }

        public bool IsAdult { get; private set; }
        public string SunSign { get; private set; }

        public string ChineseSign { get; private set; }

        public bool IsBirthday { get; private set; }

        private void Count()
        {
            DateTime now = DateTime.Now;

            int age = now.Year - Birthday.Year;

            // for leap years we need this
            if (Birthday > now.AddYears(-age)) age--;
            // don't use:
            // if (birthDate.AddYears(age) > now) age--;

            Thread myThread = new Thread(new ThreadStart(CountSunSign));
                myThread.Start();
                myThread.Join();

                myThread = new Thread(new ThreadStart(CountChineseSign));
                myThread.Start();
                myThread.Join();


                if (Birthday.Day == now.Day && Birthday.Month == now.Month)
                {
                    IsBirthday = true;
                }
                else
                {
                    IsBirthday = false;
                }

                if (age >= 18)
                    IsAdult = true;
                else IsAdult = false;
        }

        private void CountSunSign()
        {
            switch (Birthday.Month)
            {
                case 1:
                    if (Birthday.Day <= 20)
                    {
                        SunSign = "Your zodiac sign is Capricorn";
                    }
                    else
                    {
                        SunSign = "Your zodiac sign is Aquarius";
                    }

                    break;
                case 2:
                    if (Birthday.Day <= 19)
                    {
                        SunSign = "Your zodiac sign is Aquarius";
                    }
                    else
                    {
                        SunSign = "Your zodiac sign is Pisces";
                    }

                    break;
                case 3:
                    if (Birthday.Day <= 20)
                    {
                        SunSign = "Your zodiac sign is Pisces";
                    }
                    else
                    {
                        SunSign = "Your zodiac sign is Aries";
                    }

                    break;
                case 4:
                    if (Birthday.Day <= 20)
                    {
                        SunSign = "Your zodiac sign is Aries";
                    }
                    else
                    {
                        SunSign = "Your zodiac sign is Taurus";
                    }

                    break;
                case 5:
                    if (Birthday.Day <= 21)
                    {
                        SunSign = "Your zodiac sign is Taurus";
                    }
                    else
                    {
                        SunSign = "Your zodiac sign is Gemini";
                    }

                    break;
                case 6:
                    if (Birthday.Day <= 22)
                    {
                        SunSign = "Your zodiac sign is Gemini";
                    }
                    else
                    {
                        SunSign = "Your zodiac sign is Cancer";
                    }

                    break;
                case 7:
                    if (Birthday.Day <= 22)
                    {
                        SunSign = "Your zodiac sign is Cancer";
                    }
                    else
                    {
                        SunSign = "Your zodiac sign is Leo";
                    }

                    break;
                case 8:
                    if (Birthday.Day <= 23)
                    {
                        SunSign = "Your zodiac sign is Leo";
                    }
                    else
                    {
                        SunSign = "Your zodiac sign is Virgo";
                    }

                    break;
                case 9:
                    if (Birthday.Day <= 23)
                    {
                        SunSign = "Your zodiac sign is Virgo";
                    }
                    else
                    {
                        SunSign = "Your zodiac sign is Libra";
                    }

                    break;
                case 10:
                    if (Birthday.Day <= 23)
                    {
                        SunSign = "Your zodiac sign is Libra";
                    }
                    else
                    {
                        SunSign = "Your zodiac sign is Scorpio";
                    }

                    break;
                case 11:
                    if (Birthday.Day <= 22)
                    {
                        SunSign = "Your zodiac sign is Scorpio";
                    }
                    else
                    {
                        SunSign = "Your zodiac sign is Sagittarius";
                    }

                    break;
                case 12:
                    if (Birthday.Day <= 21)
                    {
                        SunSign = "Your zodiac sign is Sagittarius";
                    }
                    else
                    {
                        SunSign = "Your zodiac sign is Capricorn";
                    }

                    break;

            }
        }

        private void CountChineseSign()
        {

            switch (Birthday.Year % 12)
            {
                case 0:
                    ChineseSign = "Your zodiak year is Monkey";
                    break;
                case 1:
                    ChineseSign = "Your zodiak year is Rooster";
                    break;
                case 2:
                    ChineseSign = "Your zodiak year is Dog";
                    break;
                case 3:
                    ChineseSign = "Your zodiak year is Pig";
                    break;
                case 4:
                    ChineseSign = "Your zodiak year is Rat";
                    break;
                case 5:
                    ChineseSign = "Your zodiak year is Ox";
                    break;
                case 6:
                    ChineseSign = "Your zodiak year is Tiger";
                    break;
                case 7:
                    ChineseSign = "Your zodiak year is Rabbit";
                    break;
                case 8:
                    ChineseSign = "Your zodiak year is Dragon";
                    break;
                case 9:
                    ChineseSign = "Your zodiak year is Snake";
                    break;
                case 10:
                    ChineseSign = "Your zodiak year is Horse";
                    break;
                case 11:
                    ChineseSign = "Your zodiak year is Goat";
                    break;
            }

        }

    }
}
    

