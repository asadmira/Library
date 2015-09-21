using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VeryfyFirstName();
                VeryfyLastName();
                VerifyBirthDate();
                VeryfyPhone();
                VeryfyEmail();

                User user = UserController.CreateUser(
                    tBoxName.Text,
                    tBoxSurname.Text,
                    dPickerBirthDate.SelectedDate.Value.ToShortDateString(),
                    tBoxPhone.Text,
                    tBoxEmail.Text);
                ProgramData.data.users.Add(user);
                this.Close();
            }
            catch (PhoneFormatException)
            {
                MessageBox.Show("Телефон должен содержать 11 цифр!", "Неверный формат телефона.", MessageBoxButton.OK, MessageBoxImage.Error);
                FocusManager.SetFocusedElement(this, tBoxPhone);
                tBoxPhone.SelectAll();
            }
            catch (FirstNameFormatException)
            {
                MessageBox.Show("Имя содержит только буквы!", "Неверный формат имени.", MessageBoxButton.OK, MessageBoxImage.Error);
                FocusManager.SetFocusedElement(this, tBoxName);
                tBoxName.SelectAll();
            }
            catch (LastNameFormatException)
            {
                MessageBox.Show("Фамилия содержит только буквы!", "Неверный формат фамилии.", MessageBoxButton.OK, MessageBoxImage.Error);
                FocusManager.SetFocusedElement(this, tBoxSurname);
                tBoxSurname.SelectAll();
            }
            catch (EmailFormatException)
            {
                MessageBox.Show("Неверный формат почты!", "Неверный формат email.", MessageBoxButton.OK, MessageBoxImage.Error);
                FocusManager.SetFocusedElement(this, tBoxEmail);
                tBoxEmail.SelectAll();
            }
            catch (BirthDateFormatException)
            {
                MessageBox.Show("Заполните дату рождения!", "Неверный формат даты рождения.", MessageBoxButton.OK, MessageBoxImage.Error);
                FocusManager.SetFocusedElement(this, dPickerBirthDate);
            }
        }

        private void VeryfyPhone()
        {
            Regex phoneRegex = new Regex(@"[0-9]{11}");
            if (!(phoneRegex.IsMatch(tBoxPhone.Text) && tBoxPhone.Text.Length == 11))
            {
                throw new PhoneFormatException();
            };
        }

        private void VeryfyEmail()
        {
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!emailRegex.IsMatch(tBoxEmail.Text))
            {
                throw new EmailFormatException();
            };
        }

        private void VeryfyFirstName()
        {
            Regex nameRegex = new Regex(@"^[a-z -']+$");
            if (!nameRegex.IsMatch(tBoxName.Text))
            {
                throw new FirstNameFormatException();
            };
        }

        private void VeryfyLastName()
        {
            Regex nameRegex = new Regex(@"^[a-z -']+$");
            if (!nameRegex.IsMatch(tBoxSurname.Text))
            {
                throw new LastNameFormatException();
            };
        }

        private void VerifyBirthDate()
        {
            if (dPickerBirthDate.SelectedDate == null)
            {
                throw new BirthDateFormatException();
            };
        }
    }
}
