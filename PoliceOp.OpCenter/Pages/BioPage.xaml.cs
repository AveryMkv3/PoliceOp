﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using RestSharp;
using RestSharp.Authenticators;
using Enterwell.Clients.Wpf.Notifications;
using System.Windows.Navigation;

namespace PoliceOp.OpCenter.Pages
{
    /// <summary>
    /// Interaction logic for BioPage.xaml
    /// </summary>
    public partial class BioPage : Page
    {
        public Models.Personne Personne { get; set; }
        public BioPage()
        {
            InitializeComponent();

            this.DataContext = this;

            this.Loaded += BioPage_Loaded;
            
            
        }
        public BioPage(int Pid)
        {
            fecthPersonData(Pid);

            InitializeComponent();

            this.DataContext = this;

            this.Loaded += BioPage_Loaded;
        }

        public async void fecthPersonData(int Pid)
        {

            AppLevel.APIClients.AppRestClient1.Authenticator = new JwtAuthenticator(
                AppLevel.JWTAuthServices.jwtSvc.TokenizeSessionID(
                    AppLevel.CachingService.appCache.Get<Models.SessionVM>("SessionVM").SessionID, "personData"));

            var req = new RestRequest($"Identification/{Pid}", RestSharp.DataFormat.Json);

            var response = await AppLevel.APIClients.AppRestClient1.ExecuteAsync<Models.Personne>(request: req, httpMethod: Method.GET);

            if (response.IsSuccessful)
            {
                this.Personne = response.Data;
            }
            else
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    this.ShowNotification("Requête non Authorisée", "#333", "#E0A030", "Avertissement");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    this.ShowNotification("Impossible d'obtenir les informations demandées", "#F15B19", "#F15B19", "Erreur");
                }
                else
                {
                    this.ShowNotification("Une Erreur est survenue" + response.StatusDescription, "#F15B19", "#F15B19", "info");
                }
            }

        }

        private void BioPage_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private async void BtnPere_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window item in App.Current.Windows)
            {
                if (item.Title.ToLower() == "opcenter")
                {
                    (item as MainWindow).LoadingIndicator.Visibility = Visibility.Visible;

                    await System.Threading.Tasks.Task.Delay(new TimeSpan(0, 0, 2));

                    (item as MainWindow).ContentFrame.Navigate(new BioPage(Personne.PereId));
                    break;
                }
            }
        }

        private async void BtnMere_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window item in App.Current.Windows)
            {
                if (item.Title.ToLower() == "opcenter")
                {
                    (item as MainWindow).LoadingIndicator.Visibility = Visibility.Visible;

                    await System.Threading.Tasks.Task.Delay(new TimeSpan(0, 0, 2));

                    (item as MainWindow).ContentFrame.Navigate(new BioPage(Personne.MereId));
                    break;
                }
            }
        }

        private void FaceDataBtn_Click(object sender, RoutedEventArgs e)
        {
            this.FaceDataExp.IsExpanded = !this.FaceDataExp.IsExpanded;
        }

        private void FingerPrintBtn_Click(object sender, RoutedEventArgs e)
        {
            this.FingerDataExp.IsExpanded = !this.FingerDataExp.IsExpanded;
        }

        private void ShowNotification(string Message, String BgBrush, String AccentBrush, string BadgeInfo)
        {

            AppLevel.NotificationManagers.InAppNotificationsManager.CreateMessage()
                                        .Accent(AccentBrush)
                                        .Animates(true)
                                        .AnimationInDuration(0.75)
                                        .AnimationOutDuration(2)
                                        .Background(BgBrush)
                                        .HasBadge(BadgeInfo)
                                        .HasMessage(Message)
                                        .Dismiss().WithButton("Ok", button => { })
                                        .Dismiss().WithDelay(TimeSpan.FromSeconds(25))
                                        .Queue();

            AppLevel.NotificationManagers.InAppNotificationsManager = new NotificationMessageManager();
        }

    }
}
