using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace OnPropertyChangedTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Meme> _coll;

        public ObservableCollection<Meme> Coll
        {
            get
            {
                return _coll ?? (_coll = new ObservableCollection<Meme>());
            }
            set
            {
                if(_coll != value)
                {
                    _coll = value;
                    OnPropertyChanged(nameof(Coll));
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            InitItems();
        }

        private void InitItems()
        {
            Coll.Add(new Meme { text = "what are those", num = 1 });
            Coll.Add(new Meme { text = "harambe", num = 2 });
            Coll.Add(new Meme { text = "dat boi", num = 3 });
        }

        private void ChangeStuff()
        {
            //normally those don't change the view but now they do
            Coll[1].num = 2016;
            Coll[1].text = "DED MEEM";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ChangeStuff();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }


    }

    public class Meme : INotifyPropertyChanged
    {
        private string _text;
        public string text
        {
            get
            {
                return _text;
            }
            set
            {
                if(_text!=value)
                {
                    _text = value;
                    OnPropertyChanged(nameof(text));
                }
            }
        }

        private int _num { get; set; }
        public int num
        {
            get
            {
                return _num;
            }
            set
            {
                if (_num != value)
                {
                    _num = value;
                    OnPropertyChanged(nameof(num));
                }
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }
}
