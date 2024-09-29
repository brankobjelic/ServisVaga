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
        public List<long> Years { get; set; } = new();
        int currentYear = DateTime.Now.Year;
        Merilo MeriloForEdit { get; set; }
        bool isEdit = false;

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

        public InsertUpdateMeriloWindow(Merilo meriloForEdit)
        {
            InitializeComponent();
            isEdit = true;
            MeriloForEdit = meriloForEdit;
            for (long i = currentYear; i >= 1900; i--)
            {
                Years.Add(i);
            }
            godinaProizvodnjeComboBox.ItemsSource = Years;
            Klijenti = KlijentDAO.UcitajKlijente();
            klijentiComboBox.ItemsSource = Klijenti;
            FillMeriloFields();
        }

        private void EnterMeriloData_Click(object sender, RoutedEventArgs e)
        {
            Merilo merilo = new Merilo()
            {
                Imalac = (Klijent)klijentiComboBox.SelectedValue,
                Naziv = nazivMerilaTextBox.Text,
                Proizvodjac = proizvodjacTextBox.Text,
                Tip = tipTextBox.Text,
                SerijskiBroj = serijskiBrojTextBox.Text,
                GodinaProizvodnje = (long)godinaProizvodnjeComboBox.SelectedValue,
                SluzbenaOznaka = sluzbenaOznakaTextBox.Text,
                OpsegMerenja = opsegMerenjaTextBox.Text,
                NajmanjiPodeok = najmanjiPodeokTextBox.Text,
                KlasaTacnosti = klasaTacnostiTextBox.Text
            };
            if (isEdit)
            {
                merilo.Id = MeriloForEdit.Id;
                if (MeriloDAO.AzurirajMerilo(merilo) == 1)
                {
                    MessageBox.Show("Uspešno ažuriranje merila");
                    Close();
                }
                else
                {
                    MessageBox.Show("Došlo je do greške");
                }
            }
            else
            {
                if(MeriloDAO.UnesiMerilo(merilo) == 1)
                {
                    MessageBox.Show("Uspešan unos merila");
                    Close();
                }
                else
                {
                    MessageBox.Show("Došlo je do greške");
                }
            }

        }

        private void FillMeriloFields()
        {
            List<Klijent> klijentiIzComboBoxa = klijentiComboBox.ItemsSource.Cast<Klijent>().ToList();
            Klijent izabraniKlijent = klijentiIzComboBoxa.Find(k => k.Id == MeriloForEdit.Imalac.Id);
            klijentiComboBox.SelectedItem = izabraniKlijent;
            godinaProizvodnjeComboBox.SelectedValue = MeriloForEdit.GodinaProizvodnje;
            nazivMerilaTextBox.Text = MeriloForEdit.Naziv;
            proizvodjacTextBox.Text = MeriloForEdit.Proizvodjac;
            tipTextBox.Text = MeriloForEdit.Tip;
            serijskiBrojTextBox.Text = MeriloForEdit.SerijskiBroj;
            sluzbenaOznakaTextBox.Text = MeriloForEdit.SluzbenaOznaka;
            opsegMerenjaTextBox.Text = MeriloForEdit.OpsegMerenja;
            najmanjiPodeokTextBox.Text = MeriloForEdit.NajmanjiPodeok;
            klasaTacnostiTextBox.Text = MeriloForEdit.KlasaTacnosti;
        }

    }
}
