using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XenNodify.MVVM.ViewModel;
using XenNodify.MVVM.ViewModel.NodesType.RectangleConfiguration;

namespace PlaygroundNodifyWpf
{
    public partial class MainVM : ObservableObject
    {
        public EditorViewModel Editor { get; } = new();
        [ObservableProperty]
        ObservableCollection<MyNodeViewModel> _clusterUiNode = new();
        public event Action<MyNodeViewModel>? RequestAddClusterNode;
        public event Action<RectangleNodeViewModel>? RequestAddRectangleNode;
        public bool IsUpdating { get; set; }

        [ObservableProperty]
        private Point _mousePosition;

        public IAsyncRelayCommand AddNodeCommand { get; }
        public IAsyncRelayCommand AddRectangleNodeCommand { get; }
        public IAsyncRelayCommand DeleteNodeCommand { get; }

        public MainVM()
        {
            AddNodeCommand = new CommunityToolkit.Mvvm.Input.AsyncRelayCommand(CreateNewNode, CanCreateNode);
            AddRectangleNodeCommand = new CommunityToolkit.Mvvm.Input.AsyncRelayCommand(CreateNewRectangleNode, CanCreateNode);
            DeleteNodeCommand = new CommunityToolkit.Mvvm.Input.AsyncRelayCommand(DeleteNodes, CanDeleteNodes);

            Editor.SelectedNodes.CollectionChanged += (_, __) =>
            {
                DeleteNodeCommand.NotifyCanExecuteChanged();
                
            };
        }
        private bool CanCreateNode()
        {
            return true;
        }
        private bool CanDeleteNodes()
        {
            return Editor.SelectedNodes.Any();
        }
        public async Task CreateNewNode()
        {
            var node = new MyNodeViewModel
            {
                Title = "new node",
                Location = new Point(MousePosition.X, MousePosition.Y),
                ClusterId = 1,
            };
            node.Input.Add(new ConnectorViewModel
            {
                Title = "In"
            });
            node.Output.Add(new ConnectorViewModel
            {
                Title = "Out"
            });

            ClusterUiNode.Add(node);
            RequestAddClusterNode?.Invoke(node);
        }
        public async Task CreateNewRectangleNode()
        {
            var node = new RectangleNodeViewModel
            {
                Title = "new node",
                Location = new Point(MousePosition.X, MousePosition.Y),
                //ClusterId = 1,
            };
            //node.Input.Add(new ConnectorViewModel
            //{
            //    Title = "In"
            //});
            //node.Output.Add(new ConnectorViewModel
            //{
            //    Title = "Out"
            //});

            //ClusterUiNode.Add(node);
            RequestAddRectangleNode?.Invoke(node);
        }
        public async Task DeleteNodes()
        {

        }
    }
}
