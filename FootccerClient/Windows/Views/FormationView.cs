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
    public partial class FormationView : MasterView
    {
        public FormationDTO formationDTO { get; set; }
        private List<int> positionList = new List<int>();
        private List<TableLayoutPanel> tableLayouts = new List<TableLayoutPanel>();
        private List<Button> buttons = new List<Button>();//버튼 태그들을 검색하기 위해 만들어 둔 버튼배열입니다.
        public int selectedPositionIndex { get; set; }//버튼 클릭 할때 마다 해당 인덱스로 바뀌는 변수 입니다. List테이블에 position값 넣으실때 이 값을 가져가시면 됩니다. 0~10 까지 값을 가집니다.
        private int buttonsIndex = 0;

        List<NumericUpDown> numericUpDownList = new List<NumericUpDown>();

        //기본 생성자에는 컨트롤을 생성하는 매서드가 없습니다.
        //파티 참가에 쓰실 경우 panel7의 visible항목을 false로 해주세요. (panel7에는 FormationDTO를 수정 하는 컨트롤들이 있습니다.)
        public FormationView()
        {
            InitializeComponent();
            selectedPositionIndex = -1;
        }
        /*public override void Refresh_View()
        {
            placeFormation();
        }*/
        public FormationView(FormationDTO formationDTO, List<int> positionList) : this()
        {
            panel7.Visible = false;
            this.formationDTO = formationDTO;
            this.positionList = positionList;
            initializeNumeric();
            placeFormation();
            updatePartyPosition();
        }
        public FormationView(char side) : this()
        {
            this.formationDTO = new FormationDTO(side, Int32.Parse(numer_FW.Value.ToString()), Int32.Parse(numer_MF.Value.ToString()), Int32.Parse(numer_DF.Value.ToString()), Int32.Parse(numer_GK.Value.ToString()));
            initializeNumeric();
            placeFormation();
        }
        public void placeFormation()
        {
            if (formationDTO.maxFW + formationDTO.maxMF + formationDTO.maxDF + formationDTO.maxGK == 11)
            {
                if (tableLayouts.Count > 0)
                {
                    disposeControls<TableLayoutPanel>(tableLayouts);
                    disposeControls<Button>(buttons);
                }
                selectedPositionIndex = -1;
                createTableLayout(formationDTO.maxGK);
                createTableLayout(formationDTO.maxDF);
                createTableLayout(formationDTO.maxMF);
                createTableLayout(formationDTO.maxFW);
            }
        }
        private void disposeControls<T>(List<T> list)
        {
            foreach (var item in list)
            {
                if (item is TableLayoutPanel)
                {
                    (item as TableLayoutPanel).Dispose();
                }
                else if (item is Button)
                {
                    (item as Button).Dispose();
                }
            }
            list.Clear();
        }
        public void placeFormation(int v1, int v2, int v3, int v4)
        {
            formationDTO.maxFW = v1;
            formationDTO.maxMF = v2;
            formationDTO.maxDF = v3;
            formationDTO.maxGK = v4;
            placeFormation();
        }
        public void placeFormation(FormationDTO formationDTO)
        {
            this.formationDTO = formationDTO;
            placeFormation();
        }
        public void btn_click(object sender, EventArgs e)
        {
            updateBtnImage(Int32.Parse((sender as Button).Tag.ToString()));
            selectedPositionIndex = Int32.Parse((sender as Button).Tag.ToString());
        }
        //버튼 이미지를 갱신 해주는 메서드입니다.
        private void updateBtnImage(int position)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                if (Int32.Parse(buttons[i].Tag.ToString()) == position)
                {
                    buttons[i].BackgroundImage = App.Instance.Image.GetImageFromURL("https://cdn-icons-png.flaticon.com/128/1452/1452087.png");
                    buttons[i].Enabled = false;
                    initBtnImage();
                    break;
                }
            }
        }
        private void initBtnImage()
        {
            if (selectedPositionIndex != -1)
            {
                buttons[selectedPositionIndex].BackgroundImage = App.Instance.Image.GetImageFromURL("https://cdn-icons-png.flaticon.com/128/1452/1452036.png");
                buttons[selectedPositionIndex].Enabled = true;
            }
        }
        //이미 자리가 있는 포지션 갱신 해주는 메서드 입니다 positionList에 값 넣으시고 사용하시면 됩니다. 버튼을 클릭하고 나서 이 메서드가 실행 된다면 의도와 다르게 흘러 갈 수도....
        public void updatePartyPosition()
        {
            for (int i = 0; i < positionList.Count; i++)
            {
                updateBtnImage(positionList[i]);
            }
        }
        private void initializeNumeric()
        {
            numericUpDownList.Add(numer_FW);
            numericUpDownList.Add(numer_MF);
            numericUpDownList.Add(numer_DF);
            numericUpDownList.Add(numer_GK);
            foreach (var item in numericUpDownList)
            {
                item.ValueChanged += (sender, e) =>
                {
                    if (judgeCount11())
                    {
                        saveFormationDTO();
                        placeFormation();
                    }
                };
            }
        }
        private void saveFormationDTO()
        {
            formationDTO.maxFW = Int32.Parse(numer_FW.Value.ToString());
            formationDTO.maxMF = Int32.Parse(numer_MF.Value.ToString());
            formationDTO.maxDF = Int32.Parse(numer_DF.Value.ToString());
            formationDTO.maxGK = Int32.Parse(numer_GK.Value.ToString());
        }
        private bool judgeCount11()
        {
            int maxFW = Int32.Parse(numer_FW.Value.ToString());
            int maxMF = Int32.Parse(numer_MF.Value.ToString());
            int maxDF = Int32.Parse(numer_DF.Value.ToString());
            int maxGK = Int32.Parse(numer_GK.Value.ToString());
            if (maxFW + maxMF + maxDF + maxGK == 11)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void initSelectedPositionIndex()
        {
            if (selectedPositionIndex != -1)
            {
                buttons[selectedPositionIndex].BackgroundImage = App.Instance.Image.GetImageFromURL("https://cdn-icons-png.flaticon.com/128/1452/1452036.png");
                buttons[selectedPositionIndex].Enabled = true;
                selectedPositionIndex = -1;
            }
        }

        #region 컨트롤들을 생성/리사이즈 하는 메서드입니다.
        private void createTableLayout(int maxCount)
        {
            int cellHeight = (int)(panel.Height / 4);
            int cellWidth = this.panel.Width / 6;
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Top;
            tableLayoutPanel.Height = cellHeight;
            tableLayoutPanel.Width = this.Width;
            tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            panel.Controls.Add(tableLayoutPanel);
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            tableLayoutPanel.ColumnCount = maxCount + 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            for (int i = 0; i < maxCount; i++)
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
            button.Tag = buttonsIndex++ % 11;
            button.Click += btn_click;
            buttons.Add(button);
            return button;
        }
        private void panel_Resize(object sender, EventArgs e)
        {
            resizeTableLayout(formationDTO.maxGK, 0);
            resizeTableLayout(formationDTO.maxDF, 1);
            resizeTableLayout(formationDTO.maxMF, 2);
            resizeTableLayout(formationDTO.maxFW, 3);
        }
        private void resizeTableLayout(int maxCount, int idx)
        {
            int height = panel.Height / 4;
            int width = panel.Width / 6;
            tableLayouts[idx].Height = height;
            tableLayouts[idx].Width = panel.Width;
            tableLayouts[idx].RowStyles[0] = new RowStyle(SizeType.Absolute, height);
            tableLayouts[idx].ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 10);
            for (int i = 0; i < maxCount; i++)
            {
                tableLayouts[idx].ColumnStyles[i + 1] = new ColumnStyle(SizeType.Absolute, width);
            }
            tableLayouts[idx].ColumnStyles[tableLayouts[idx].ColumnCount - 1] = new ColumnStyle(SizeType.Percent, 10);
        }
        #endregion
    }
}
