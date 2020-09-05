using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;

namespace enFinalExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Item> myList = new List<Item>();

        int totalCost = 0;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void buyItemsBtn_Click(object sender, RoutedEventArgs e)
        {
            MakeOrderInvisible();
            MakeBuyMenuVisibile();
            MakeTireInvisible();
            MakeBatteryInvisible();
            MakeWindInvisible();
        }

        private void tireBtn_Click(object sender, RoutedEventArgs e)
        {
            MakeBuyMenuInvisibile();
            MakeTireVisible();
            MakeOrderInvisible();
            MakeBatteryInvisible();
            MakeWindInvisible();
        }

        private void BatteryBtn_Click(object sender, RoutedEventArgs e)
        {
            MakeBuyMenuInvisibile();
            MakeTireInvisible();
            MakeOrderInvisible();
            MakeBatteryVisible();
            MakeWindInvisible();
            checkShipItem.Visibility = Visibility.Visible;
        }

        private void WindBtn_Click(object sender, RoutedEventArgs e)
        {
            MakeBuyMenuInvisibile();
            MakeTireInvisible();
            MakeOrderInvisible();
            MakeBatteryInvisible();
            MakeWindVisible();
        }

        private void orderTireBtn_Click(object sender, RoutedEventArgs e)
        {
            int diameter = 0;
            if (int.TryParse(diameterNameTxt.Text.ToString(), out diameter) && itemNameTxt.Text != "" && tireNameTxt.Text != "")
            {
               
               
                Tire tire = new Tire(itemNameTxt.Text, tireNameTxt.Text, diameter, Convert.ToInt32(numberItemTireLbl.Content), (CheckString(costItemTireLbl.Content.ToString())), CheckString(weightItemTireLbl.Content.ToString()), Convert.ToInt32(quantityTxt.Text));
                myList.Add(tire);
                totalCost = totalCost + (CheckString(costItemTireLbl.Content.ToString()) * Convert.ToInt32(quantityTxt.Text));
                
               
                MessageBox.Show("Item added to order");
            }
            else
            {
                MessageBox.Show("Something went wrong, try again.");
            }
        }

        private void orderBatteryBtn_Click(object sender, RoutedEventArgs e)
        {
            int voltage = 0;
            if (int.TryParse(voltageNameTxt.Text.ToString(), out voltage) && itemNameBatteryTxt.Text != "")
            {

                
                Battery battery = new Battery(itemNameBatteryTxt.Text, voltage, Convert.ToInt32(numberItemBatteryLbl.Content), CheckString(costItemBatteryLbl.Content.ToString()), CheckString(weightItemBatteryLbl.Content.ToString()), Convert.ToInt32(quantityBatteryTxt.Text));
                myList.Add(battery);
                totalCost = totalCost + (CheckString(costItemBatteryLbl.Content.ToString()) * Convert.ToInt32(quantityBatteryTxt.Text));

                if (checkShipItem.IsChecked == true)
                {
                    bool value = checkShipItem.IsEnabled;
                    Ship ship = new Ship(value);
                    totalCost = totalCost - 30;
                }
                else
                {
                    Ship ship = new Ship(checkShipItem.IsChecked == false);
                }

                MessageBox.Show("Item added to order");
                checkShipItem.IsChecked = false;
            }
            else
            {
                MessageBox.Show("Something went wrong, try again.");
            }
        }

        

        private void orderWindBtn_Click(object sender, RoutedEventArgs e)
        {
            int wiper = 0;
            if (int.TryParse(wiperNameTxt.Text.ToString(), out wiper) && itemNameWindTxt.Text != "")
            {
                Wind wind = new Wind(itemNameWindTxt.Text, wiper, Convert.ToInt32(numberItemWindLbl.Content), CheckString(costItemWindLbl.Content.ToString()), CheckString(weightItemWindLbl.Content.ToString()), Convert.ToInt32(quantityWindTxt.Text));
                myList.Add(wind);
                totalCost = totalCost + (CheckString(costItemWindLbl.Content.ToString()) * Convert.ToInt32(quantityWindTxt.Text));

                if (checkShipItem.IsChecked == true)
                {
                    bool value = checkShipItem.IsEnabled;
                    Ship ship = new Ship(value);
                    totalCost = totalCost - 10;
                }
                else
                {
                    Ship ship = new Ship(checkShipItem.IsChecked == false);
                }

                MessageBox.Show("Item added to order");
                checkShipItem.IsChecked = false;
            }
            else
            {
                MessageBox.Show("Something went wrong, try again.");
            }
        }

        private void myOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            MakeOrderVisible();
            MakeBuyMenuInvisibile();
            MakeTireInvisible();
            MakeBatteryInvisible();
            MakeWindInvisible();

            var listQuery = myList.OrderByDescending(list => list.Quantity).GroupBy(item => new { item.Quantity, item.NumberItem, item.WeightItem, item.NameItem, item.CostItem })
                .Select(y => new Item()
                {
                    Quantity = y.Key.Quantity,
                    NumberItem = y.Key.NumberItem,
                    NameItem = y.Key.NameItem,
                    WeightItem = y.Key.WeightItem,
                    CostItem = y.Key.CostItem
                    
                });
            foreach (var item in listQuery)
            {
                dataGrid1.ItemsSource = listQuery.ToList();
            }
           
           
            totalLbl.Content = totalCost.ToString();
            
        }

       



        private void MakeTireVisible()
        {
            quantityLbl.Visibility = Visibility.Visible;
            quantityTxt.Visibility = Visibility.Visible;
            tireTitleLbl.Visibility = Visibility.Visible;
            tireNameLbl.Visibility = Visibility.Visible;
            tireNameTxt.Visibility = Visibility.Visible;
            itemNameLbl.Visibility = Visibility.Visible;
            itemNameTxt.Visibility = Visibility.Visible;
            diameterNameTxt.Visibility = Visibility.Visible;
            diameterNamelbl.Visibility = Visibility.Visible;
            orderTireBtn.Visibility = Visibility.Visible;
            itemNumberLbl.Visibility = Visibility.Visible;
            numberItemTireLbl.Visibility = Visibility.Visible;
            priceLbl.Visibility = Visibility.Visible;
            costItemTireLbl.Visibility = Visibility.Visible;
            weightLbl.Visibility = Visibility.Visible;
            weightItemTireLbl.Visibility = Visibility.Visible;
           
           
        }

        private void MakeTireInvisible()
        {
            quantityLbl.Visibility = Visibility.Hidden;
            quantityTxt.Visibility = Visibility.Hidden;
            tireTitleLbl.Visibility = Visibility.Hidden;
            tireNameTxt.Visibility = Visibility.Hidden;
            tireNameLbl.Visibility = Visibility.Hidden;
            itemNameLbl.Visibility = Visibility.Hidden;
            itemNameTxt.Visibility = Visibility.Hidden;
            diameterNameTxt.Visibility = Visibility.Hidden;
            diameterNamelbl.Visibility = Visibility.Hidden;
            orderTireBtn.Visibility = Visibility.Hidden;
            itemNumberLbl.Visibility = Visibility.Hidden;
            numberItemTireLbl.Visibility = Visibility.Hidden;
            priceLbl.Visibility = Visibility.Hidden;
            costItemTireLbl.Visibility = Visibility.Hidden;
            weightLbl.Visibility = Visibility.Hidden;
            weightItemTireLbl.Visibility = Visibility.Hidden;
  
        }
        
        private void MakeOrderVisible()
        {
            totalLbl.Visibility = Visibility.Visible;
            dataGrid1.Visibility = Visibility.Visible;
            totalNameLbl.Visibility = Visibility.Visible;
            btnSave.Visibility = Visibility.Visible;
            btnLoad.Visibility = Visibility.Visible;
        }

        private void MakeOrderInvisible()
        {
            totalLbl.Visibility = Visibility.Hidden;
            dataGrid1.Visibility = Visibility.Hidden;
            totalNameLbl.Visibility = Visibility.Hidden;
            btnSave.Visibility = Visibility.Hidden;
            btnLoad.Visibility = Visibility.Hidden;
        }

        private void MakeBuyMenuVisibile()
        {
            tireBtn.Visibility = Visibility.Visible;
            batteryBtn.Visibility = Visibility.Visible;
            windBtn.Visibility = Visibility.Visible;
        }

        private void MakeBuyMenuInvisibile()
        {
            tireBtn.Visibility = Visibility.Hidden;
            batteryBtn.Visibility = Visibility.Hidden;
            windBtn.Visibility = Visibility.Hidden;
        }

        private void MakeBatteryVisible()
        {
            itemNameBatteryTxt.Visibility = Visibility.Visible;
            voltageNameTxt.Visibility = Visibility.Visible;
            numberItemBatteryLbl.Visibility = Visibility.Visible;
            costItemBatteryLbl.Visibility = Visibility.Visible;
            weightItemBatteryLbl.Visibility = Visibility.Visible;
            orderBatteryBtn.Visibility = Visibility.Visible;
            itemNameBatteryLbl.Visibility = Visibility.Visible;
            voltageNamelbl.Visibility = Visibility.Visible;
            itemNumberBatteryLbl.Visibility = Visibility.Visible;
            priceBatteryLbl.Visibility = Visibility.Visible;
            weightBatteryLbl.Visibility = Visibility.Visible;
            batteryTitleLbl.Visibility = Visibility.Visible;
            quantityBatteryLbl.Visibility = Visibility.Visible;
            quantityBatteryTxt.Visibility = Visibility.Visible;
            

        }

        private void MakeBatteryInvisible()
        {
            itemNameBatteryTxt.Visibility = Visibility.Hidden;
            voltageNameTxt.Visibility = Visibility.Hidden;
            numberItemBatteryLbl.Visibility = Visibility.Hidden;
            costItemBatteryLbl.Visibility = Visibility.Hidden;
            weightItemBatteryLbl.Visibility = Visibility.Hidden;
            orderBatteryBtn.Visibility = Visibility.Hidden;
            itemNameBatteryLbl.Visibility = Visibility.Hidden;
            voltageNamelbl.Visibility = Visibility.Hidden;
            itemNumberBatteryLbl.Visibility = Visibility.Hidden;
            priceBatteryLbl.Visibility = Visibility.Hidden;
            weightBatteryLbl.Visibility = Visibility.Hidden;
            batteryTitleLbl.Visibility = Visibility.Hidden;
            quantityBatteryLbl.Visibility = Visibility.Hidden;
            quantityBatteryTxt.Visibility = Visibility.Hidden;
            checkShipItem.Visibility = Visibility.Hidden;

        }

        private void MakeWindVisible()
        {
            itemNameWindTxt.Visibility = Visibility.Visible;
            wiperNameTxt.Visibility = Visibility.Visible;
            numberItemWindLbl.Visibility = Visibility.Visible;
            costItemWindLbl.Visibility = Visibility.Visible;
            weightItemWindLbl.Visibility = Visibility.Visible;
            orderWindBtn.Visibility = Visibility.Visible;
            itemNameWindLbl.Visibility = Visibility.Visible;
            wiperNamelbl.Visibility = Visibility.Visible;
            itemNumberWindLbl.Visibility = Visibility.Visible;
            priceWindLbl.Visibility = Visibility.Visible;
            weightWindLbl.Visibility = Visibility.Visible;
            windTitleLbl.Visibility = Visibility.Visible;
            quantityWindLbl.Visibility = Visibility.Visible;
            quantityWindTxt.Visibility = Visibility.Visible;
            checkShipItem.Visibility = Visibility.Visible;
        }

        private void MakeWindInvisible()
        {
            itemNameWindTxt.Visibility = Visibility.Hidden;
            wiperNameTxt.Visibility = Visibility.Hidden;
            numberItemWindLbl.Visibility = Visibility.Hidden;
            costItemWindLbl.Visibility = Visibility.Hidden;
            weightItemWindLbl.Visibility = Visibility.Hidden;
            orderWindBtn.Visibility = Visibility.Hidden;
            itemNameWindLbl.Visibility = Visibility.Hidden;
            wiperNamelbl.Visibility = Visibility.Hidden;
            itemNumberWindLbl.Visibility = Visibility.Hidden;
            priceWindLbl.Visibility = Visibility.Hidden;
            weightWindLbl.Visibility = Visibility.Hidden;
            windTitleLbl.Visibility = Visibility.Hidden;
            quantityWindLbl.Visibility = Visibility.Hidden;
            quantityWindTxt.Visibility = Visibility.Hidden;
            checkShipItem.Visibility = Visibility.Hidden;

        }



        private int CheckString(string parse)
        {
            int i = 0;
            string[] numbers = Regex.Split(parse.ToString(), @"\D+");
            foreach (string value in numbers)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    i = int.Parse(value);
                }
            }
            return i;
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var stream = new FileStream("test.xml", FileMode.Create))
                {
                    var XML = new XmlSerializer(myList.GetType(), new[] { typeof(Tire), typeof(Battery), typeof(Wind) });
                    XML.Serialize(stream, myList);
                    MessageBox.Show("XML file serialized!");
                    stream.Close();
                }
            }
            catch (IOException)
            {
            }
        }

        private void Btn_Load_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                XmlSerializer serializer = new XmlSerializer(myList.GetType(), new[] { typeof(Tire), typeof(Battery), typeof(Wind) });
                XmlReader reader = XmlReader.Create("test.xml");
                myList = (List<Item>)serializer.Deserialize(reader);
                MessageBox.Show("XML file deserialized!");
                dataGrid1.ItemsSource = myList.ToList();
                reader.Close();

            }
            catch (IOException)
            {
            }
        }






        private void diameterName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void quantityBatteryTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



    }
}
