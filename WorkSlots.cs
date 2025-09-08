using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;


// before using this code u will need a xaml file 
namespace DescApp
{
    public partial class MainWindow : Window
    {
        private readonly List<string> slotImages = new List<string>
        {

            "https://cdn4.iconfinder.com/data/icons/glands/3500/banana_slot_gambling_casino-512.png",
            "https://cdn1.iconfinder.com/data/icons/casino-smooth-vol-2/256/WATERMELON-512.png",
            "https://thumbs.dreamstime.com/b/lemon-slot-color-line-icon-gambling-casino-pictogram-web-page-mobile-app-promo-259843338.jpg",
            "https://img.freepik.com/premium-vector/creative-number-7-logo-with-geometric-shapes-creative-education-colorful-graphics-vector_396016-3389.jpg?w=360",
            "https://gimgs2.nohat.cc/thumb/f/640/slot-machine-online-casino-fruit-shopping-game-others-transparent-background-png-clipart--comhiclipartiddwm.jpg",



         
        };

        private readonly Random random = new Random();
        private int balance = 200;

        public MainWindow()
        {
            InitializeComponent();
            UpdateBalance();
        }

        private async void Btn_Slots(object sender, RoutedEventArgs e)
        {
            var btn = (System.Windows.Controls.Button)sender;
            btn.IsEnabled = false;

            if (balance <= 0)
            {
                ShowResult("💀 Баланс исчерпан! Игра окончена.", Colors.Red);
                btn.IsEnabled = false;
                return;
            }

            ResultText.Text = "";
            ResultText.Opacity = 0;

            int slot1 = await SpinSlot(Slot1 , 1000);
            int slot2 = await SpinSlot(Slot2 , 1200); // 900
            int slot3 = await SpinSlot(Slot3 , 1100);

            if (slot1 == slot2 && slot2 == slot3)
            {
                balance += 600;
                ShowResult($"🎉 JACKPOT! Выигрыш  🎉", Colors.Black);
            }
            else if (slot1 == slot2 || slot2 == slot3 || slot1 == slot3)
            {
                balance -= 100;
                ShowResult($"🔥 Почти! 2 совпадения 🔥", Colors.Black);
            }
            else if(slot1 != slot2 || slot2 != slot3 || slot1 != slot3)
            {
                balance += 20;
                ShowResult(" Попробуйте снова", Colors.Black);
            }
            UpdateBalance();
            btn.IsEnabled = true;
        }


        private void ShowResult(string text, System.Windows.Media.Color color)
        {
            ResultText.Text = text;
            ResultText.Foreground = new System.Windows.Media.SolidColorBrush(color);

            var fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(1));
            ResultText.BeginAnimation(OpacityProperty, fadeIn);

            var scale = new ScaleTransform(1, 1);
            ResultText.RenderTransform = scale;
            ResultText.RenderTransformOrigin = new Point(0.5, 0.5); // 0.5 0.5

            var pulse = new DoubleAnimation(1, 1.3, TimeSpan.FromSeconds(1.4)) // 
            {
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(6)// 3
            };

            scale.BeginAnimation(ScaleTransform.ScaleXProperty, pulse);
            scale.BeginAnimation(ScaleTransform.ScaleYProperty, pulse);
        }



        private async Task<int> SpinSlot(System.Windows.Controls.Image slot , int duration)
        {
            int finalIndex = random.Next(slotImages.Count);
            for (int i = 0; i < 15; i++) 
            {
                int index = random.Next(slotImages.Count);
                slot.Source = new BitmapImage(new Uri(slotImages[index]));
                await Task.Delay(duration / 15); // duration / 15
            }

            slot.Source = new BitmapImage(new Uri(slotImages[finalIndex]));

            return finalIndex;

        }


        public void UpdateBalance()
        {
            BalanceText.Text = "current Balance ->  " + $" {balance} $" + Colors.Orange;
        }

        public void ReturnRegistr(object sender , RoutedEventArgs e)
        {
            var registrPage = new RegisterPage();
            registrPage.Show();
            this.Close();
        }

    }
}
