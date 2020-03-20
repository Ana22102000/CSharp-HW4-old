using System;
using System.Text.RegularExpressions;
using System.Threading;
using CSharpHomework.Tools.MyExceptions;

namespace CSharpHomework.Model
{
    [Serializable]

    internal class Person
    {
        public Person(string name, string surname, string email, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Birthday = birthday;


            checkEmail();
            checkName();
            checkSurname();

            Thread myThread = new Thread(new ThreadStart(Count));
            myThread.Start();
            myThread.Join();


            checkAge(age);

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

        public bool IsAdult
        {
            get
            {
                if (_isAdult == null)
                {
                    if (age>=18)
                    {
                        _isAdult = true;
                    }
                    else
                    {
                        _isAdult = false;
                    }
                }
                return _isAdult.Value;
            }
            private set => _isAdult = value;
        }

        public string SunSign
        {
            get
            {
                if (_sunSign == null)
                {
                    Thread myThread = new Thread(new ThreadStart(CountSunSign));
                    myThread.Start();
                    myThread.Join();
                }

                return _sunSign;
            }
            private set => _sunSign = value;
        }

        public string ChineseSign
        {
            get
            {
                if (_chineseSign == null)
                {
                    Thread myThread = new Thread(new ThreadStart(CountChineseSign));
                    myThread.Start();
                    myThread.Join();
                }

                return _chineseSign;
            }
            private set => _chineseSign= value;
        }

        public bool IsBirthday
        {
            get
            {
                if (_isBirthday == null)
                {
                    if (Birthday.Day == DateTime.Now.Day && Birthday.Month == DateTime.Now.Month)
                    {
                        _isBirthday = true;
                    }
                    else
                    {
                        _isBirthday = false;
                    }
                }

                return _isBirthday.Value;
            }
            private set => _isBirthday = value;
        }


        private int age = 0;

        private bool? _isAdult;
        private string _sunSign=null;
        private string _chineseSign=null;
        private  Nullable<bool> _isBirthday;


        private void Count()
        {
            DateTime now = DateTime.Now;

            age = now.Year - Birthday.Year;

            // for leap years we need this
            if (Birthday > now.AddYears(-age)) age--;
            // don't use:
            // if (birthDate.AddYears(age) > now) age--;

            
        }

        private void CountSunSign()
        {
            switch (Birthday.Month)
            {
                case 1:
                    if (Birthday.Day <= 20)
                    {
                        SunSign = "Capricorn";
                    }
                    else
                    {
                        SunSign = "Aquarius";
                    }

                    break;
                case 2:
                    if (Birthday.Day <= 19)
                    {
                        SunSign = "Aquarius";
                    }
                    else
                    {
                        SunSign = "Pisces";
                    }

                    break;
                case 3:
                    if (Birthday.Day <= 20)
                    {
                        SunSign = "Pisces";
                    }
                    else
                    {
                        SunSign = "Aries";
                    }

                    break;
                case 4:
                    if (Birthday.Day <= 20)
                    {
                        SunSign = "Aries";
                    }
                    else
                    {
                        SunSign = "Taurus";
                    }

                    break;
                case 5:
                    if (Birthday.Day <= 21)
                    {
                        SunSign = "Taurus";
                    }
                    else
                    {
                        SunSign = "Gemini";
                    }

                    break;
                case 6:
                    if (Birthday.Day <= 22)
                    {
                        SunSign = "Gemini";
                    }
                    else
                    {
                        SunSign = "Cancer";
                    }

                    break;
                case 7:
                    if (Birthday.Day <= 22)
                    {
                        SunSign = "Cancer";
                    }
                    else
                    {
                        SunSign = "Leo";
                    }

                    break;
                case 8:
                    if (Birthday.Day <= 23)
                    {
                        SunSign = "Leo";
                    }
                    else
                    {
                        SunSign = "Virgo";
                    }

                    break;
                case 9:
                    if (Birthday.Day <= 23)
                    {
                        SunSign = "Virgo";
                    }
                    else
                    {
                        SunSign = "Libra";
                    }

                    break;
                case 10:
                    if (Birthday.Day <= 23)
                    {
                        SunSign = "Libra";
                    }
                    else
                    {
                        SunSign = "Scorpio";
                    }

                    break;
                case 11:
                    if (Birthday.Day <= 22)
                    {
                        SunSign = "Scorpio";
                    }
                    else
                    {
                        SunSign = "Sagittarius";
                    }

                    break;
                case 12:
                    if (Birthday.Day <= 21)
                    {
                        SunSign = "Sagittarius";
                    }
                    else
                    {
                        SunSign = "Capricorn";
                    }

                    break;

            }
        }

        private void CountChineseSign()
        {

            switch (Birthday.Year % 12)
            {
                case 0:
                    ChineseSign = "Monkey";
                    break;
                case 1:
                    ChineseSign = "Rooster";
                    break;
                case 2:
                    ChineseSign = "Dog";
                    break;
                case 3:
                    ChineseSign = "Pig";
                    break;
                case 4:
                    ChineseSign = "Rat";
                    break;
                case 5:
                    ChineseSign = "Ox";
                    break;
                case 6:
                    ChineseSign = "Tiger";
                    break;
                case 7:
                    ChineseSign = "Rabbit";
                    break;
                case 8:
                    ChineseSign = "Dragon";
                    break;
                case 9:
                    ChineseSign = "Snake";
                    break;
                case 10:
                    ChineseSign = "Horse";
                    break;
                case 11:
                    ChineseSign = "Goat";
                    break;
            }

        }


        private void checkEmail()
        {
            if (!Regex.IsMatch(Email, "^([a-z0-9+_-]+)([.]?[a-z0-9+_-]+)*@([a-z0-9-]+[.])+[a-z]{2,6}$"))

                throw new EmailException("Wrong Email");

        }
        private void checkName()
        {
            if (!Regex.IsMatch(Name, "^[a-zA-Z]+$"))
                throw new NameException("Wrong Name");
        }

        private void checkSurname()
        {
            if (!Regex.IsMatch(Surname,"^[A-Za-z ]+$"))
                throw new SurnameException("Wrong Surname");
        }


        private void checkAge(int age)
        {
            if(age<0)
                throw new NotBornException("Age<0");
            if(age>135)
                throw new TooOldException("Age>135");
        }


    }


}
    

