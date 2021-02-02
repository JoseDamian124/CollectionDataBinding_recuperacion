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
using System.Collections.ObjectModel;
using ChangeNotificationSample;

namespace CollectionDaraBinding_recuperacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<User>users;
        public MainWindow()
        {
            InitializeComponent();
            LoadUsers();
            DataContext = users;
        }
        private void LoadUsers()
        {
            users = new ObservableCollection <User>();
            users.Add(new User() { Name = "Peter Parker"});
            users.Add(new User() { Name = "Tony Stark" });
            users.Add(new User() { Name = "Natasha Romanoff" });

           // lista.ItemsSource = users;
        }

        private void agregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(userTextBox.Text))
            {
                User user = new User() { Name = userTextBox.Text };
                users.Add(user);
                lista.SelectedItem = user;
                UpdateView();
            }
        }

        private void modificarButton_Click(object sender, RoutedEventArgs e)
        {
            User user = new User() { Name = "Nuevo usuario" };
            users.Add(user);
            lista.SelectedItem = user;
            UpdateView();
        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if(lista.SelectedItem !=null)
            {
                users.Remove(lista.SelectedItem as User);
                //userTextBox.Text = "";
                UpdateView();
            }
            
        }
        private void UpdateView()
        {
            lista.Items.Refresh();
            if(users.Count > 0)
            {
                eliminarButton.IsEnabled = true;
                modificarButton.IsEnabled = true;
            }
            else
            {
                lista.SelectedIndex = -1;
                eliminarButton.IsEnabled = false;
                agregarButton.IsEnabled = false;
            }
        }

        private void lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lista.SelectedItem !=null)
            {
                userTextBox.Text = (lista.SelectedItem as User).Name;
            }
        }
    }
}
