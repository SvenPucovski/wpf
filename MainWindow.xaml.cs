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

namespace WpfAppSven
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> subjectNames = new List<string>()
        {
            "Hrvatski jezik",
            "Englenski jezik",
            "Tjelesna i zdravstvena kultura",
            "Vjeronauk",
            "Matematika",
            "Fizika",
            "Građa računala",
            "Operacijski sustavi",
            "Računalne mreže",
            "Mikroupravčljači",
            "Dizajn baza podataka",
            "Skriptni jezici i web programiranje",
            "Primjenjena matematika",
            "Napredno i objektno programiranje",
            "Web dizajn"
        };
        List<Predmet> allsubjects = new List<Predmet>();
        public MainWindow()
        {
            InitializeComponent();
            foreach (var item in subjectNames)
            {
                allsubjects.Add(new Predmet(item, new List<double>() { }));
            }

            foreach (string predmet in subjectNames)
            {
                predmeti.Items.Add(predmet);
            }
            predmeti.Items.Add(subjectNames);
        }

        
        private void DodajOcjenu(object sender, RoutedEventArgs e)
        {
            try
            {
                string predmet = predmeti.SelectedValue.ToString();
                foreach (var item in allsubjects)
                {
                    if (item.subjectName == predmet)
                    {
                        item.marks.Add(Double.Parse(ocjena.Text));

                        double prosjek = 0;
                        foreach (double ocjena in item.marks)
                        {
                            prosjek += ocjena;
                        }
                        prosjek /= item.marks.Count;
                        rezultat.Content = Math.Round(prosjek, 2);

                        
                    }
                }
            }
            catch (Exception)
            {

               
            }
        }
    }
}
