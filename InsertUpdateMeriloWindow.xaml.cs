using ServisVaga.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ServisVaga
{
    /// <summary>
    /// Interaction logic for InsertUpdateMeriloWindow.xaml
    /// </summary>
    public partial class InsertUpdateMeriloWindow : Window
    {
        public List<Klijent> Klijenti { get; set; } = new();
        public List<int> Years { get; set; } = new();
        int currentYear = DateTime.Now.Year;

        public InsertUpdateMeriloWindow()
        {
            InitializeComponent();
            for(int i = currentYear; i >= 1900; i--)
            {
                Years.Add(i);
            }
            godinaProizvodnjeComboBox.ItemsSource = Years;
            Klijenti = KlijentDAO.UcitajKlijente();
            klijentiComboBox.ItemsSource = Klijenti;
        }

        private void EnterMeriloData_Click(object sender, RoutedEventArgs e)
        {
            Merilo newMerilo = new Merilo()
            {
                Imalac = (Klijent)klijentiComboBox.SelectedValue,
                Naziv = nazivMerilaTextBox.Text,
                Proizvodjac = proizvodjacTextBox.Text,
                Tip = tipTextBox.Text,
                SerijskiBroj = serijskiBrojTextBox.Text,
                GodinaProizvodnje = (int)godinaProizvodnjeComboBox.SelectedValue,
                SluzbenaOznaka = sluzbenaOznakaTextBox.Text,
                OpsegMerenja = opsegMerenjaTextBox.Text,
                NajmanjiPodeok = najmanjiPodeokTextBox.Text,
                KlasaTacnosti = klasaTacnostiTextBox.Text
            };
            MeriloDAO.UnesiMerilo(newMerilo);

        }

    }
}
