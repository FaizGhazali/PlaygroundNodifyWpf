using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using XenNodify.MVVM.ViewModel;
using XenNodify.MVVM.ViewModel.NodesType;

namespace PlaygroundNodifyWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainVM vm = new();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;

            vm.RequestAddClusterNode += OnAddClusterNode;
            vm.RequestAddRectangleNode +=OnAddRectangleNode;
            vm.RequestAddCircleNode +=OnAddCircleNode;


            Unloaded += OnUnloaded;
            //Loaded += OnLoaded;
        }

        private void xenNodify_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainVM vm)
            {
                vm.RequestAddClusterNode -= OnAddClusterNode;

                //vm.PropertyChanged -= OnVmPropertyChanged;
                //OnVmPropertyHandled = false;
            }

            
        }
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainVM vm)
            {
                
                vm.RequestAddClusterNode += OnAddClusterNode;
                //vm.ReassignSelectedService();

                //if (!OnVmPropertyHandled)
                //{
                //    vm.PropertyChanged += OnVmPropertyChanged;
                //    OnVmPropertyHandled = true;
                //}
                
            }


            //DataContextChanged += OnDataContextChanged;


            //Unloaded += OnUnloaded;
        }
        private void OnAddClusterNode(MyNodeViewModel node)
        {
            if (this.DataContext is MainVM vm)
            {
                vm.Editor.Nodes.Add(node);
            }
        }
        private void OnAddRectangleNode(RectangleNodeViewModel node)
        {
            if (this.DataContext is MainVM vm)
            {
                vm.Editor.Nodes.Add(node);
            }
        }
        private void OnAddCircleNode(CircleNodeViewModel node)
        {
            if (this.DataContext is MainVM vm)
            {
                vm.Editor.Nodes.Add(node);
            }
        }
    }
}