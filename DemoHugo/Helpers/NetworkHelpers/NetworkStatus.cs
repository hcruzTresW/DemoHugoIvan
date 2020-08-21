using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace DemoHugo.Helpers.NetworkHelpers
{
    public class NetworkStatus
    {
        bool bandera;
        public NetworkStatus()
        {
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged1;
        }

        public static bool HayInternet()
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                return true;
            }
            else
            {

                return false;
            }

        }

        private async void Connectivity_ConnectivityChanged1(object sender, ConnectivityChangedEventArgs e)
        {
            var current = e.NetworkAccess;
            var profiles = Connectivity.ConnectionProfiles;

        }
    }
}
