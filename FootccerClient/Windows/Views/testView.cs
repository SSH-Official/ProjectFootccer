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
        private List<TableLayoutPanel> tableLayouts = new List<TableLayoutPanel>();
        private List<Button> buttons = new List<Button>();//버튼 태그들을 검색하기 위해 만들어 둔 버튼배열입니다.
        public int selectedPositionIndex { get; private set; }//버튼 클릭 할때 마다 해당 인덱스로 바뀌는 변수 입니다. List테이블에 position값 넣으실때 이 값을 가져가시면 됩니다.
        private int buttonsIndex = 1;
        public testView()
        {
            InitializeComponent();
            selectedPositionIndex = -1;
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
            if(tableLayouts.Count > 0)
            {
                for(int i = 0; i < tableLayouts.Count; i++)
                {
                    tableLayouts[i].Dispose();
                }                
            }                
            tableLayouts.Clear();
            //(수정필요)
            createTableLayout(1);//(formationDTO.maxGK);
            createTableLayout(4);//(formationDTO.maxDF);
            createTableLayout(3);//(formationDTO.maxMF);
            createTableLayout(3);//(formationDTO.maxFW);
        }
        private void createTableLayout(int maxCount)
        {
            int cellHeight = (int)(panel.Height / 4);
            int cellWidth = this.Width / 5;
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Top;
            tableLayoutPanel.Height = cellHeight;
            panel.Controls.Add(tableLayoutPanel);
            tableLayoutPanel.RowCount = 1;
            
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            tableLayoutPanel.ColumnCount = maxCount + 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            for(int i = 0; i < maxCount; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, cellWidth));
                tableLayoutPanel.Controls.Add(createButton(), i + 1, 0);
            }
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            tableLayouts.Add(tableLayoutPanel);
        }
        public Button createButton()
        {
            Button button = new Button();
            button.BackgroundImage = App.Instance.Image.GetImageFromURL("https://cdn-icons-png.flaticon.com/128/1452/1452036.png");
            //https://cdn-icons-png.flaticon.com/128/1452/1452087.png
            button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button.BackColor = Color.Transparent;
            button.ForeColor = Color.Transparent;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Dock = DockStyle.Fill;
            button.Tag = buttonsIndex++;
            button.Click += btn_click;
            buttons.Add(button);
            return button;
        }
        public void btn_click(object sender, EventArgs e)
        {
            updateBtnImage(Int32.Parse((sender as Button).Tag.ToString()));
            selectedPositionIndex = Int32.Parse((sender as Button).Tag.ToString());
        }
        //버튼 이미지를 갱신 해주는 메서드입니다. for문으로 가져오신 position리스트만큼 돌리시면 됩니다.
        private void updateBtnImage(int position)
        {
            for(int i = 0; i < buttons.Count; i++)
            {
                if (Int32.Parse(buttons[i].Tag.ToString()) == position)
                {
                    buttons[i].BackgroundImage = App.Instance.Image.GetImageFromURL("https://cdn-icons-png.flaticon.com/128/1452/1452087.png");
                    buttons[i].Enabled = false;
                }
                else
                {
                    buttons[i].BackgroundImage = App.Instance.Image.GetImageFromURL("https://cdn-icons-png.flaticon.com/128/1452/1452036.png");
                    buttons[i].Enabled = true;
                }
            }
        }

        private void panel_Resize(object sender, EventArgs e)
        {
            //(수정)
            resizeTableLayout(1/*formationDTO.maxGK*/, 0);
            resizeTableLayout(4/*formationDTO.maxDF*/, 1);
            resizeTableLayout(3/*formationDTO.maxMF*/, 2);
            resizeTableLayout(3/*formationDTO.maxFW*/, 3);
        }

        private void resizeTableLayout(int maxCount, int idx)
        {
            int height = panel.Height / 4;
            int width = panel.Width / 5;
            tableLayouts[idx].Height = height;
            tableLayouts[idx].Width = panel.Width;
            tableLayouts[idx].RowStyles[0] = new RowStyle(SizeType.AutoSize, height);
            tableLayouts[idx].ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 10);
            for(int  i = 0; i < maxCount; i++)
            {
                tableLayouts[idx].ColumnStyles[i+1] = new ColumnStyle(SizeType.Absolute, width);
            }
            tableLayouts[idx].ColumnStyles[tableLayouts[idx].ColumnCount - 1] = new ColumnStyle(SizeType.Percent, 10);

        }
    }
}
