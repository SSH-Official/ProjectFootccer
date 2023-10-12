using Lib.Frame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient
{
    partial class MainForm
    {
        public void ShowView(MasterView view)
        {
            HideAllView();
            view.Parent = panel_ViewSpace;
            view.Dock = DockStyle.Fill;
            view.Visible = true;
            view.Refresh_View();
        }

        public void ShowView<T>()
        {
            ShowView(typeof(T));
        }

        public DialogResult ShowPop<T>(ePopMode aPopMode = ePopMode.None, object aParam = null)
        {
            return ShowPop(typeof(T), aPopMode, aParam);
        }

        public MasterView GetView<T>()
        {
            return GetView(typeof(T));
        }


        private void ShowView(Type aType)
        {
            HideAllView();
            GetView(aType).Visible = true;
            GetView(aType).Refresh_View();
        }
        private void HideAllView()
        {
            foreach (MasterView view in this.Views)
            { view.Visible = false; }
        }
        private MasterView GetView(Type aType)
        {
            foreach (MasterView view in this.Views)
            {
                if (view.GetType() == aType)
                { return view; }
            }
            return null;
        }

        private DialogResult ShowPop(Type PopType, ePopMode aPopMode = ePopMode.None, object aParam = null)
        {
            dynamic CurrentPop = Activator.CreateInstance(PopType);
            return CurrentPop.ShowPop(aPopMode, aParam);
        }

        private void SelectMenu(Label label)
        {
            foreach (Label lab in MenuControls)
            {
                lab.BackColor = Color.Transparent;
            }

            label.BackColor = SystemColors.Control;
            label.Invalidate();
        }
    }
}
