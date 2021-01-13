using System.Windows;
using System.Windows.Media;

namespace test_encoder_R4_UI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// test123
    /// </summary>
    public partial class MainWindow : Window
    {
        public Input input = new Input();
        public Output output = new Output();
        public Logic logic = new Logic();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void UpdateLogic(Input Input)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            output = logic.LogicR4(Input);
            watch.Stop();
            output.Speed = watch.Elapsed.TotalMilliseconds;
            UpdateUI();
        }

        public void UpdateUI()
        {
            if (output.Speed > output.SlowestSpeed)
            {
                output.SlowestSpeed = (1/output.Speed);
                VariableSlowestSpeed.Content = output.SlowestSpeed;
            }
            VariableSpeed.Content = 1/output.Speed/1000;
            VariableIndex.Content = output.IndexO;
            VariableCounter.Content = output.Counter;
            VariableDirection.Content = output.Direction;
        }

        private void LimitClose(object sender, RoutedEventArgs e)
        {
            if (input.LimitClose == 0)
            {
                input.LimitClose = 1;
                ButtonLimitClose.Background = Brushes.Green;
            }
            else
            {
                input.LimitClose = 0;
                ButtonLimitClose.Background = Brushes.Black;
            }
            UpdateLogic(input);
        }
        private void LimitOpen(object sender, RoutedEventArgs e)
        {
            if (input.LimitOpen == 0)
            {
                input.LimitOpen = 1;
                ButtonLimitOpen.Background = Brushes.Green;
            }
            else
            {
                input.LimitOpen = 0;
                ButtonLimitOpen.Background = Brushes.Black;
            }
            UpdateLogic(input);
        }
        private void Index(object sender, RoutedEventArgs e)
        {
            if (input.IndexI == 0)
            {
                input.IndexI = 1;
                ButtonIndex.Background = Brushes.Green;
            }
            else
            {
                input.IndexI = 0;
                ButtonIndex.Background = Brushes.Black;
            }
            UpdateLogic(input);
        }
        private void Pulse(object sender, RoutedEventArgs e)
        {
            if (input.Pulse == 0)
            {
                input.Pulse = 1;
                ButtonPulse.Background = Brushes.Green;
            }
            else
            {
                input.Pulse = 0;
                ButtonPulse.Background = Brushes.Black;
            }
            UpdateLogic(input);
        }
        private void BlackBox(object sender, RoutedEventArgs e)
        {
            if (input.BlackBox == 0)
            {
                input.BlackBox = 1;
                ButtonBlackBox.Background = Brushes.Green;
            }
            else
            {
                input.BlackBox = 0;
                ButtonBlackBox.Background = Brushes.Black;
            }
            UpdateLogic(input);
        }

        private void Restart(object sender, RoutedEventArgs e)
        {
            input.LimitClose = 0;
            ButtonLimitClose.Background = Brushes.Black;

            input.LimitOpen = 0;
            ButtonLimitOpen.Background = Brushes.Black;

            input.LimitOpen = 0;
            ButtonLimitOpen.Background = Brushes.Black;

            input.IndexI = 0;
            ButtonIndex.Background = Brushes.Black;

            input.Pulse = 0;
            ButtonPulse.Background = Brushes.Black;

            input.BlackBox = 0;
            ButtonBlackBox.Background = Brushes.Black;

            output.Speed = 0;
            VariableSpeed.Content = 0;

            output.SlowestSpeed = 0;
            VariableSlowestSpeed.Content = 0;

            output.IndexO = 0;
            VariableIndex.Content = 0;

            output.Counter = 0;
            VariableCounter.Content = 0;

            output.Direction = ' ';
            VariableDirection.Content = ' ';

            logic.logicMemory.Etat = 0;
            logic.logicMemory.Counter = 0;
            logic.logicMemory.IndexCounter = 0;
            logic.logicMemory.Direction = ' ';
        }
    }

    public class Input
    {
        public int LimitClose { get; set; }
        public int LimitOpen { get; set; }
        public int IndexI { get; set; }
        public int Pulse { get; set; }
        public int BlackBox { get; set; }
    }
    public class Output
    {
        public double Speed { get; set; }
        public double SlowestSpeed { get; set; }
        public int IndexO { get; set; }
        public int Counter { get; set; }
        public char Direction { get; set; }
    }

}
