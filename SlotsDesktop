using System.Text;
using System.Windows;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;

namespace DescApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary> partial describe ui elements 
    public partial class MainWindow : Window
    {
        private readonly Random random = new Random();
        private bool isSpining = false;
        private long balance = 500;

        private readonly List<string> photos = new List<string>
        {
            "https://cdn4.iconfinder.com/data/icons/glands/3500/banana_slot_gambling_casino-512.png",
            "https://cdn1.iconfinder.com/data/icons/casino-smooth-vol-2/256/WATERMELON-512.png",
            "https://thumbs.dreamstime.com/b/lemon-slot-color-line-icon-gambling-casino-pictogram-web-page-mobile-app-promo-259843338.jpg",
            "https://img.freepik.com/premium-vector/creative-number-7-logo-with-geometric-shapes-creative-education-colorful-graphics-vector_396016-3389.jpg?w=360",
            "https://gimgs2.nohat.cc/thumb/f/640/slot-machine-online-casino-fruit-shopping-game-others-transparent-background-png-clipart--comhiclipartiddwm.jpg",
        };

        private void ShowBalance()
        {
            ResultText.Text = $"Ваш баланс {balance}";
        }
        public MainWindow()
        {
            InitializeComponent(); // very major
            Spin();
        }

        private async  void Btn_Slots(object sender, RoutedEventArgs e)
        {
            int bet = 50;
            int loseMoney = 50;

            balance += bet;
            balance -= bet;

            var random = new Random();
            bool win = random.Next(0, 2) == 1; // 40% шанса
            bool lost = random.Next(0,2) == 1;

            if (win)
            {
                int prize = 200;
                balance += prize;
                MessageBox.Show($"you won {prize}");
            }
            else
            {
                MessageBox.Show("u lost");
            }
            if (isSpining) return;
            isSpining = true;

            ResultText.Text = "Spining ... ";
            await Task.Delay(6000);
            Spin(); // агар одам кнопкани босса кегин Spin() функция ишлайди у узи перебирать килади
            isSpining = false;
            ShowBalance();
        }
        

        private void Spin()
        {
            // бутта биз на рандом танлаймиз 
            try
            {
                //for(int i = 0; i < 5;i++)
                //{
                //    MessageBox.Show($"{photos[random.Next(photos.Count)]} {photos[random.Next(photos.Count)]} {photos[random.Next(photos.Count)]}");
                //}

                int img1 = random.Next(photos.Count);
                int img2 = random.Next(photos.Count);
                int img3 = random.Next(photos.Count);


                Slot1.Source = LoadImg(photos[1]);
                Slot2.Source = LoadImg(photos[2]);
                Slot3.Source = LoadImg(photos[3]);

                if (img1 == img2 || img2 == img3)
                {
                    ResultText.Text = "🎉 Джекпот!";
                }
                else if (img1 == img2 || img2 == img3 || img1 == img3 )
                {
                    ResultText.Text = "почти совпали";
                }
                else
                {
                    ResultText.Text = "Good luck for next time => Status {defeat}";
                }
            }
            catch(Exception err)
            {
                MessageBox.Show($"error loading images  {err.Message}");
            }
        }


        public BitmapImage LoadImg(string host)
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(host , UriKind.Absolute);
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
            return bitmapImage;
        } 
    }
}

// one more input , make calc  // change window
