using Lib.Frame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient.Windows.Pops
{
    public partial class ViewPop<T> : Form 
        where T : MasterView, new()
    {
        MasterView View { get; }
        public ViewPop()
        {
            InitializeComponent();
            View = new T();
            View.Parent = panel_Base;
            View.Dock = DockStyle.Fill;
            View.Visible = true;
        }
    }
}
