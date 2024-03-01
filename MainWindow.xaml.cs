using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;

namespace Maksimovich_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DateChanged(object sender, RoutedEventArgs e)
        {
            
            DateTime birthDate = datePicker.SelectedDate ?? DateTime.Now;
            DateTime now = DateTime.Now;
            int age = DateTime.Today.Year - birthDate.Year;
            if (DateTime.Today < birthDate.AddYears(age))
            {
                age--;
            }
            

            if (age > 135 || age < 0)
            {
                resultTextBlock.Text = "Incorrect age";
                westernZodiacSign.Text = "";
                chinaZodiacSign.Text = "";
                MessageBox.Show("Entered date is incorrect.");
            }
            else
            {
                resultTextBlock.Text = "Your age: " + age;
                westernZodiacSign.Text = "Western zodiac sign:\n" + GetZodiacSign(birthDate);
                chinaZodiacSign.Text = "Chinese zodiac sign:\n" + GetChineseZodiacSign(birthDate);
                if (birthDate.Day == now.Day && birthDate.Month == now.Month && birthDate.Year == now.Year)
                {
                    MessageBox.Show("Greetings!");
                } 
            }
        }

        public string GetZodiacSign(DateTime birthDate)
        {
            int day = birthDate.Day;
            int month = birthDate.Month;

            if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
                return "Aries";
            else if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
                return "Taurus";
            else if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
                return "Gemini";
            else if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
                return "Cancer";
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
                return "Leo";
            else if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
                return "Virgo";
            else if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
                return "Libra";
            else if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
                return "Scorpius";
            else if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
                return "Sagittarius";
            else if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
                return "Capricorn";
            else if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
                return "Aquarius";
            else
                return "Pisces";
        }

        public string GetChineseZodiacSign(DateTime dateOfBirth)
        {
            string[] chineseZodiacSigns = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };

            int year = dateOfBirth.Year;

            int signIndex = (year - 4) % 12;

            return chineseZodiacSigns[signIndex];
        }

    }
}