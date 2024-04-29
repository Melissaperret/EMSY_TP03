using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App_EMSY03
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        double Resultat;
        double TauxConversion;
        BitmapImage bitmapImageSwiss = new BitmapImage(); //nouvelle image
        BitmapImage bitmapImageJapon = new BitmapImage(); //nouvelle image
        BitmapImage bitmapImageUSA = new BitmapImage(); //nouvelle image
        BitmapImage bitmapImageUK = new BitmapImage(); //nouvelle image
        public MainPage()
        {
            this.InitializeComponent();
            TauxConversion = 1.02;
            bitmapImageSwiss.UriSource = new Uri(image.BaseUri, "ms-appx:///Assets/Suisse.png"); //assignation du fichier à l'image
            bitmapImageJapon.UriSource = new Uri(image.BaseUri, "ms-appx:///Assets/Japon.png"); //assignation du fichier à l'image
            bitmapImageUSA.UriSource = new Uri(image.BaseUri, "ms-appx:///Assets/USA.png"); //assignation du fichier à l'image
            bitmapImageUK.UriSource = new Uri(image.BaseUri, "ms-appx:///Assets/UK.png"); //assignation du fichier à l'image
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if (rb_Francs_Suisse.IsChecked == true)
            {
                image.Source = bitmapImageSwiss;
                TauxConversion = 1.02;
            }
            else if (rb_Us_Dollars.IsChecked == true)
            {
                image.Source = bitmapImageUSA;
                TauxConversion = 0.93;
            }
            else if (rb_Livres.IsChecked == true)
            {
                image.Source = bitmapImageUK;
                TauxConversion = 1.17;
            }
            else
            {
                image.Source = bitmapImageJapon;
                TauxConversion = 0.0060;
            }
        }
        private void bt_Conversion_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txt_Montant.Text, out double Montant))
            {
                Resultat = Montant * TauxConversion;
                txt_Resultat.Text = Resultat.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}
