using DemoHugo.Helpers;
using DemoHugo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DemoHugo.ViewModels
{
    public class UpCommingViewModel: INotifyPropertyChanged
    {
        List<UpComing.Result> source;
        UpComing selectedMonkey;
        int selectionCount = 1;
        public ObservableCollection<UpComing> UpComings { get; private set; }
        public IList<UpComing> EmptyUpComing { get; private set; }

        public UpComing SelectedUpComing
        {
            get
            {
                return SelectedUpComing;
            }
            set
            {
                if (SelectedUpComing != value)
                {
                    SelectedUpComing = value;
                }
            }
        }


        ObservableCollection<object> selectedUpComings;

        public ObservableCollection<object> SelectedUpComings
        {
            get
            {
                return selectedUpComings;
            }
            set
            {
                if (selectedUpComings != value)
                {
                    selectedUpComings = value;
                }
            }
        }
        public string SelectedUpComingMessage { get; private set; }
        //public ICommand DeleteCommand => new Command<UpComing>(RemoveUpComing);
        //public ICommand FavoriteCommand => new Command<UpComing>(FavoriteUpComing);
        public ICommand FilterCommand => new Command<string>(FilterItems);
        //public ICommand MonkeySelectionChangedCommand => new Command(UpComingSelectionChanged);
        public  UpCommingViewModel()
        {
            source = new List<UpComing.Result>();
           
         
          CreateUpCoommingCollection();
        }
        async Task CreateUpCoommingCollection()
        {
            UpComing items = await MyHttp.GetUpComming();

            foreach (var item in items.results)
            {
                source.Add(item);
            }

            UpComings = new ObservableCollection<UpComing>((IEnumerable<UpComing>)source);
        }


        void FilterItems(string filter)
        {
           
        }

      

      

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


    }
}
