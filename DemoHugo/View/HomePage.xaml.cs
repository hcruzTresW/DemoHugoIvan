using DemoHugo.Helpers;
using DemoHugo.Models;
using DemoHugo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoHugo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private UpCommingViewModel UpComingViewModel;
        public List<UpComing> tempdata;
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new UpCommingViewModel();
          
            //listUpComing.ItemsSource = ServicioViewModel.Servicios;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = new UpCommingViewModel();
        }
       
      
    }
}