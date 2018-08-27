using databiding.datamodel;
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

namespace databiding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   // 

    public partial class MainWindow : Window
    {
        private Person _person;

        public MainWindow()
        {
            InitializeComponent();
            //ManyallyMoveData();
            //BindInCode();
            BindInXaml();
        }

        private void ManyallyMoveData()
        {
            _person = new Person
            {
                FirstName = "Piotr",
                LastName = "Kwiatkowski"
            };

            this.firstNameTextBox.Text = _person.FirstName;
            this.lastNameTextBox.Text = _person.LastName;
            this.firstNameTextBox.Text = _person.FullName;

            this.firstNameTextBox.TextChanged += firstNameTextBox_TextChanged;
            this.lastNameTextBox.TextChanged += lastNameTextBox_TextChanged;
        }

        void lastNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _person.LastName = this.lastNameTextBox.Text;
            this.fullNameTextBlock.Text = _person.FullName;
        }

        void firstNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _person.FirstName = this.firstNameTextBox.Text;
            this.fullNameTextBlock.Text = _person.FullName;
        }

        private void BindInCode()
        {
            var person = new Person
            {
                FirstName = "John",
                LastName = "Julits"
            };

            Binding b = new Binding();
            b.Source = person;
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            b.Path = new PropertyPath("FirstName");
            this.firstNameTextBox.SetBinding(TextBox.TextProperty, b);

            b = new Binding();
            b.Source = person;
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            b.Path = new PropertyPath("LastName");
            this.lastNameTextBox.SetBinding(TextBox.TextProperty, b);

            b = new Binding();
            b.Source = person;
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            b.Path = new PropertyPath("FullName");
            this.fullNameTextBlock.SetBinding(TextBlock.TextProperty, b);
        }        

        private void BindInXaml()
        {
            base.DataContext = new Person
            {
                FirstName = "Jacek",
                LastName = "Trefon"
            };
        }
    }
}
