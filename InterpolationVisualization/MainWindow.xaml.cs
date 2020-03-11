using System.Windows;

namespace InterpolationVisualization
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }
    }
}
