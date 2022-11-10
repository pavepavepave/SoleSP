using System;
using System.Data;
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

namespace SoleSP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ResultButton_Click(object sender, RoutedEventArgs e) //button "Рассчитать"
        {
            double dIncomeFirstRes = double.Parse(IncomeFirstRes.Text);
            double dIncomeSecondRes = double.Parse(IncomeSecondRes.Text);
            double dIncomeThirdRes = double.Parse(IncomeThirdRes.Text);
            double dIncomeFourthRes = double.Parse(IncomeFourthRes.Text);

            double iInsuranceFirstRes = double.Parse(InsuranceFirstRes.Text);
            double iInsuranceSecondRes = double.Parse(InsuranceSecondRes.Text);
            double iInsuranceThirdRes = double.Parse(InsuranceThirthRes.Text);
            double iInsuranceFourthRes = double.Parse(InsuranceFourthRes.Text);
            //1 quarter
            double tTaxFirstRes = dIncomeFirstRes * 0.06 - iInsuranceFirstRes;
            TaxResultPrint(tTaxFirstRes, TaxFirstRes);
            if (tTaxFirstRes <= 0)
                tTaxFirstRes = 0;
            //2 quarter
            double tTaxSecondRes = (dIncomeFirstRes + dIncomeSecondRes) * 0.06 - 
                (iInsuranceFirstRes + iInsuranceSecondRes) -
                Math.Abs(tTaxFirstRes);
            if (tTaxSecondRes <= 0)
                tTaxSecondRes = 0;
            TaxResultPrint(tTaxSecondRes, TaxSecondRes);
            //3 quarter
            double tTaxThirdRes = (dIncomeFirstRes + dIncomeSecondRes + dIncomeThirdRes) * 0.06 - 
                (iInsuranceFirstRes + iInsuranceSecondRes + iInsuranceThirdRes) -
                Math.Abs(tTaxFirstRes - tTaxSecondRes);
            if (tTaxThirdRes <= 0)
                tTaxThirdRes = 0;
            TaxResultPrint(tTaxThirdRes, TaxThirdRes);
            // 4 quarter
            double tTaxFourthRes = (dIncomeFirstRes + dIncomeSecondRes + dIncomeThirdRes + dIncomeFourthRes) * 0.06 -
                (iInsuranceFirstRes + iInsuranceSecondRes + iInsuranceThirdRes + iInsuranceFourthRes) -
                Math.Abs(tTaxFirstRes + tTaxSecondRes + tTaxThirdRes);
            TaxResultPrint(tTaxFourthRes, TaxFourthRes);

            double iIncomeYearRes = dIncomeFirstRes + dIncomeSecondRes + dIncomeThirdRes + dIncomeFourthRes; //income of years
            IncomeYearRes.Text = iIncomeYearRes.ToString("#");

            double iInsuranceYearRes = iInsuranceFirstRes + iInsuranceSecondRes + iInsuranceThirdRes + iInsuranceFourthRes; //insurance of year
            InsuranceYearRes.Text = iInsuranceYearRes.ToString("#");
        }

        private void InformationButton_Click(object sender, RoutedEventArgs e) //button "справка"
        {
            MessageBox.Show("Срок уплаты налога за квартал \nдо 25 числа следующего месяца. \nЗа 4 квартал до 30 апреля.", "Справка", MessageBoxButton.OK);
        }

        private void TaxResultPrint(double result, TextBox TaxRes) //print result
        {
            if (result > 0)
                TaxRes.Text = result.ToString("#");
            else if (result <= 0)
                TaxRes.Text = "0";

        }
    }
}

