using FootccerClient.Footccer.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace FootccerClient.Footccer.FootccerComponent
{
    public partial class IncidatorSpace : UserControl
    {
        public Size itemSize { get; set; }
        public Point Count { get; private set; }
        public Padding itemPadding { get; set; }
        private Random random { get; set; } = new Random();

        private List<PartyDTO> partyData { get; set; } = null;
        public List<PartyDTO> PartyList 
        {
            get
            {
                return partyData;
            }
            set
            {
                partyData = value;
                int PageShowCount = Count.X * Count.Y;
                
                _maxPage = PageShowCount == 0? 0 :
                    (1 + (partyData.Count - 1) / PageShowCount);
            }
        }
        
        private int _currentPage;
        private int _maxPage;
        public int PageCursor 
        {
            get
            {
                return _currentPage;
            }

            set
            {
                if (value <= 0 || value > _maxPage)
                {
                    throw new ArgumentOutOfRangeException($"value Out Of Range [0,{_maxPage}]");
                }
                _currentPage = value;
                ShowPage(_currentPage);
            }
        }

        private ControlCollection CustomControls { get { return flowLayoutPanel_Base.Controls; } }

        private void ShowPage(int currentPage)
        {
            int length = CustomControls.Count;
            int startIndex_thisPage = (currentPage - 1) * Count.X * Count.Y;
            for (int i = 0; i < length; i++)
            {
                if (! (CustomControls[i] is PartyIndicatorItem)) continue;
                var control = (CustomControls[i] as PartyIndicatorItem);
                control.UpdateInfo(PartyList[i + startIndex_thisPage]);
            }
        }

        public void ShowDebugLog()
        {
            string log = GetLog();
            MessageBox.Show(log);
        }

        private string GetLog()
        {
            return 
                $"CurrentPage : {_currentPage}\r\n" +
                $"MaxPage : {_maxPage}\r\n" +
                $"Count : {partyData.Count}";
        }

        private string GetSizeLog()
        {
            return $"itemSize = {itemSize}\r\n" +
                $"Count = {Count}\r\n" +
                $"itemPadding = {itemPadding}\r\n" +
                $"ParentSize = {Parent.Size} (this : {this.Size})\r\n" +
                $"UsingSize = {new Size(itemSize.Width * Count.X, itemSize.Height * Count.Y)}\r\n" +
                $"FLPPadding = {flowLayoutPanel_Base.Padding} / {flowLayoutPanel_Base.Margin}";
        }

        /// <summary>
        /// DockStype.Fill을 사용하므로 표시할 영역(parent)가 전제되지 않을 경우 예외를 던집니다.
        /// </summary>
        /// <param name="horizontalCount"></param>
        /// <param name="verticalCount"></param>
        /// <param name="parent"></param>
        /// <param name="itemPadding"></param>
        /// <exception cref="Exception"></exception>
        public IncidatorSpace(int horizontalCount, int verticalCount, Control parent, int itemPadding = 5)
        {
            InitializeComponent();

            if (parent == null) throw new Exception("표시할 영역이 지정되지 않았습니다.");

            this.Dock = DockStyle.Fill;
            parent.Controls.Add(this);

            SetMemberParameters(horizontalCount, verticalCount, itemPadding);
            CreateNewLabels_ForCount(horizontalCount, verticalCount);

            ResizeItems();
            
        }
        private void SetMemberParameters(int horizontalCount, int verticalCount, int itemPadding)
        {
            this.itemPadding = new Padding(itemPadding);
            flowLayoutPanel_Base.Padding = new Padding(itemPadding);
            Count = new Point(horizontalCount, verticalCount);
        }
        private void CreateNewLabels_ForCount(int horizontalCount, int verticalCount)
        {
            for (int y = 0; y < verticalCount; y++)
            {
                for (int x = 0; x < horizontalCount; x++)
                {   
                    var newItem = CreateNewItem_AsPresetParameters<Label>();
                    flowLayoutPanel_Base.Controls.Add(newItem);
                }
            }
            
        }

        private T CreateNewItem_AsPresetParameters<T>() where T : Control
        {
            Control newItem = new PartyIndicatorItem();
            newItem.Size = itemSize;
            newItem.Margin = itemPadding;

            Label newLabel = new Label();
            newLabel.TextAlign = ContentAlignment.MiddleCenter;
            int sizeValue = Math.Min(itemSize.Width, itemSize.Height);
            newLabel.Size = new Size(sizeValue, sizeValue);

            newLabel.Margin = itemPadding;

            if (random.Next(0, 2) == 0)
            {
                newLabel.Text = "축구";
                newLabel.BackColor = Color.DarkGoldenrod;
            }
            else
            {
                newLabel.Text = "풋살";
                newLabel.BackColor = Color.DarkCyan;
            }

            return newLabel as T;
        }

        private void ResizeItems()
        {
            if (Count.X == 0 || Count.Y == 0) return;

            int ActualWidth = Parent.Size.Width - ((Count.X * 2) * itemPadding.Horizontal);
            int ActualHeight = Parent.Size.Height - ((Count.Y * 2) * itemPadding.Vertical);
            double width = (ActualWidth / Count.X);
            double height = (ActualHeight / Count.Y);

            int sizeXY = (int)Math.Min(width, height);
            itemSize = new Size((int)width, (int)height);

            foreach (Control item in flowLayoutPanel_Base.Controls)
            {
                item.Size = itemSize;
            }
        }


        private void IncidatorSpace_SizeChanged(object sender, EventArgs e)
        {
            timer_Resize.Stop();
            timer_Resize.Start();
        }

        private void timer_Resize_Tick(object sender, EventArgs e)
        {
            ResizeItems();
            (sender as Timer).Stop();
        }


    }
}
