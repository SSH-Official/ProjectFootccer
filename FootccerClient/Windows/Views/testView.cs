using FootccerClient.Footccer;
using FootccerClient.Footccer.DTO;
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

namespace FootccerClient.Windows.Views
{
    public partial class testView : MasterView
    {
        private FormationDTO formationDTO;
        private List<int> positionList = new List<int>();
        private List<Control> controls = new List<Control>();
        private List<Button> buttons = new List<Button>();
        private int buttonsIndex = 1;
        public testView(Size? ViewSpaceSize = null)
        {
            InitializeComponent();
            panel.Size = (Size)(ViewSpaceSize ??  panel.Size);
            placeFormation();
            /*switch (모드)
            {
                case Mode.join:
                    //DB연결 해서 formationDTO, positionList 받아 오세요
                    break;
                case Mode.createParty:
                    //formationDTO값 받아올 인풋창 생성하세요
                    break;
                default:
                    throw new Exception("오류");
            }*/
        }
        /*void func() 
        {
            new testView(testView.Mode.join);
        }*/
        public enum Mode
        {
            createParty, join
        }
        private void placeFormation()
        {
            if(controls.Count > 0)
            {
                for(int i = 0; i < controls.Count; i++)
                {
                    controls[i].Dispose();
                }                
            }                
            controls.Clear();
            //(수정필요)
            createTableLayout(1);//(formationDTO.maxGK);
            createTableLayout(4);//(formationDTO.maxDF);
            createTableLayout(3);//(formationDTO.maxMF);
            createTableLayout(3);//(formationDTO.maxFW);
            //buttonsIndex = 0;
        }
        private void createTableLayout(int maxCount)
        {
            int cellHeight = (int)(panel.Height / 4);
            int cellWidth = this.Width / 5;
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Top;
            tableLayoutPanel.Height = cellHeight;
            panel.Controls.Add(tableLayoutPanel);
            //tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            tableLayoutPanel.RowCount = 1;
            
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            //tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, cellHeight));
            tableLayoutPanel.ColumnCount = maxCount + 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            for(int i = 0; i < maxCount; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, cellWidth));
                tableLayoutPanel.Controls.Add(createButton(), i + 1, 0);
            }
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            controls.Add(tableLayoutPanel);
        }
        public Button createButton()
        {
            Button button = new Button();
            button.BackgroundImage = App.Instance.Image.GetImageFromURL("https://w7.pngwing.com/pngs/634/945/png-transparent-t-shirt-jersey-basketball-uniform-computer-icons-basketball-uniform-text-sport-orange.png");
                //Properties.Resources.uniform;
            button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button.BackColor = Color.Transparent;
            button.ForeColor = Color.Transparent;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Dock = DockStyle.Fill;
            button.Tag = buttonsIndex++;
            button.Click += btn_click;
            controls.Add(button);
            return button;
        }
        public void btn_click(object sender, EventArgs e)
        {
            //클릭시 이포지션을 선택 하였다고 표시
            MessageBox.Show((sender as Button).Tag.ToString());
        }

    }
}
