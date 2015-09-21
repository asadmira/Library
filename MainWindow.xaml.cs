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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.IO;
using System.Threading;


namespace Library
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        public MainWindow()
        {
            //            User user = UserController.CreateUser();
            
            
            InitializeComponent();

            MenuItem menuFileRefresh = new MenuItem();
            menuFileRefresh.Header = "Обновить";
            menuFileRefresh.Click += new RoutedEventHandler(Refresh);


            MenuItem menuFileAddUser = new MenuItem();
            menuFileAddUser.Header = "Добавить пользователя";
            menuFileAddUser.Click += new RoutedEventHandler(AddUser);

            MenuItem menuFileDeleteUser = new MenuItem();
            menuFileDeleteUser.Header = "Удалить пользователя";
            menuFileDeleteUser.Click += new RoutedEventHandler(DeleteUser);

            MenuItem menuFileClose = new MenuItem();
            menuFileClose.Header = "Выход";
            menuFileClose.Click += new RoutedEventHandler(Close);

            menuFile.Items.Add(menuFileRefresh);
            menuFile.Items.Add(menuFileAddUser);
            menuFile.Items.Add(menuFileDeleteUser);
            menuFile.Items.Add(new Separator());
            menuFile.Items.Add(menuFileClose);

            DataGridTextColumn col1 = new DataGridTextColumn();
            DataGridTextColumn col2 = new DataGridTextColumn();
            DataGridTextColumn col3 = new DataGridTextColumn();
            DataGridTextColumn col4 = new DataGridTextColumn();
            DataGridTextColumn col5 = new DataGridTextColumn();
            dataGrid.Columns.Add(col1);
            dataGrid.Columns.Add(col2);
            dataGrid.Columns.Add(col3);
            dataGrid.Columns.Add(col4);
            dataGrid.Columns.Add(col5);
            col1.Binding = new Binding("FirstName");
            col2.Binding = new Binding("LastName");
            col3.Binding = new Binding("BirthDate");
            col4.Binding = new Binding("PhoneNumber");
            col5.Binding = new Binding("Email");
            col1.Header = "Имя";
            col2.Header = "Фамилия";
            col3.Header = "Дата рождения";
            col4.Header = "Телефон";
            col5.Header = "Почта";
        }

        public void Refresh(object obj, RoutedEventArgs args)
        {
            dataGrid.Items.Clear();
            foreach (User user in ProgramData.data.users)
            {
                dataGrid.Items.Add(new User { FirstName = user.FirstName, LastName = user.LastName, BirthDate = user.BirthDate, PhoneNumber = user.PhoneNumber, Email = user.Email });
            }
        }

        public void AddUser(object obj, RoutedEventArgs args)
        {
            AddUserWindow auw = new AddUserWindow();
            auw.Owner = this;
            auw.ShowDialog();
            Refresh(null, null);
        }

        public void DeleteUser(object obj, RoutedEventArgs args)
        {
            int index = 0;
            index = dataGrid.SelectedIndex;
            if (index != -1)
            {
                User data = new User();
                data = (User)dataGrid.SelectedItem;
                Console.WriteLine(index);
                Console.WriteLine(data.FirstName + " " + data.LastName + " " + data.BirthDate + " " + data.PhoneNumber + " " + data.Email);

                ProgramData.data.users.Remove(ProgramData.data.users.Single(user => user.FirstName == data.FirstName && user.LastName == data.LastName && user.BirthDate == data.BirthDate && user.PhoneNumber == data.PhoneNumber && user.Email == data.Email));

            }
            else
            {
                Console.WriteLine("none");
            }

            Refresh(null, null);

        }

        public void Close(object obj, RoutedEventArgs args)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var ser = new XmlSerializer(typeof(Data));
            StreamWriter sw = new StreamWriter("data.xml");
            ser.Serialize(sw, ProgramData.data);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try {
                var ser = new XmlSerializer(typeof(Data));
                StreamReader sr = new StreamReader("data.xml");
                ProgramData.data = (Data)ser.Deserialize(sr);
                Refresh(null, null);
            } catch (IOException)
            {
                MessageBox.Show("NO FILE");
            } catch (InvalidOperationException)
            {
                MessageBox.Show("INVALID FILE");
            }
        }

        
    }
}



