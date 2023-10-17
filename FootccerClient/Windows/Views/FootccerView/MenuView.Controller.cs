using FootccerClient.Footccer;
using Lib.Frame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient.Windows.Views.FootccerView
{
    partial class MenuView
    {
        private List<MasterView> Views { get; set; } = new List<MasterView>();
        private MasterView _CurrentView { get; set; }
        private MasterView CurrentView
        {
            get => _CurrentView;
            set
            {
                HideAllView();
                value.Visible = true;
                value.Refresh_View();
                _CurrentView = value;
            }
        }

        public MasterView GetView<T>() where T : MasterView, new()
        {
            foreach (MasterView view in this.Views)
            {
                if (view.GetType() == typeof(T))
                { return view; }
            }

            MasterView newview = new T();
            Views.Add(newview);
            InitializeView(newview);
            return newview;
        }

        private void HideAllView()
        {
            foreach (MasterView view in this.Views)
            { view.Visible = false; }
        }

        private void InitializeView(MasterView view)
        {
            view.Parent = panel_ViewSpace;
            view.Dock = DockStyle.Fill;
            view.Visible = false;
        }
    }
}
