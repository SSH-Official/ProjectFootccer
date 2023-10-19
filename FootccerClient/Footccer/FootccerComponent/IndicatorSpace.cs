using FootccerClient.Footccer.DTO;
using FootccerClient.Windows.Views;
using Org.BouncyCastle.Crypto.Operators;
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
    public partial class IndicatorSpace : UserControl
    {
        public Size itemSize { get; set; }
        public Point Count { get; private set; }
        public Padding itemPadding { get; set; }
        
        private Random random { get; set; } = new Random();

        private PartyIndicatorContext Context { get; set; }
        public void UpdateContext(PartyIndicatorContext context) => Context = context;
        private List<(PartyDTO, bool)> partyData { get; set; } = null;
        public List<(PartyDTO, bool)> PartyListData 
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
        
        private int _currentPage { get; set; }
        private int _maxPage { get; set; }
        public int PageCursor 
        {
            get => _currentPage;
            set
            {
                if (value <= 0 || value > _maxPage)
                {
                    throw new ArgumentOutOfRangeException($"value {value} is Out Of Range [0, {_maxPage}]");
                }
                _currentPage = value;
                ShowPage(_currentPage);
            }
        }

        private List<Control> madeControls { get; set; } = new List<Control>();

        private void ShowPage(int currentPage)
        {
            int length = madeControls.Count;
            int startIndex_thisPage = (currentPage - 1) * Count.X * Count.Y;
            for (int i = 0; i < length; i++)
            {
                if (! (madeControls[i] is PartyIndicatorItem)
                    || i >= PartyListData.Count) continue;
                var control = (madeControls[i] as PartyIndicatorItem);
                control.UpdateInfo(PartyListData[i + startIndex_thisPage].Item1);
                control.UpdateContext(this.Context);
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
        /// DockStype.Fill을 사용하므로 표시할 영역(parent)가 전제되지 않을 경우 예외를 던집니다. </br>
        /// images는 풋살, 축구 표시 테두리 순입니다.
        /// </summary>
        /// <param name="horizontalCount"></param>
        /// <param name="verticalCount"></param>
        /// <param name="parent"></param>
        /// <param name="itemPadding"></param>
        /// <param name="images"></param>
        /// <exception cref="Exception"></exception>
        public IndicatorSpace(int horizontalCount, int verticalCount, Control parent, int itemPadding = 5, 
            List<Image> images = null, List<(PartyDTO, bool)> myPartyList = null, PartyIndicatorContext context = PartyIndicatorContext.NotFound)
        {
            InitializeComponent();
            

            if (parent == null) throw new Exception("표시할 영역이 지정되지 않았습니다.");
            if (myPartyList == null) partyData = new List<(PartyDTO,bool)>();

            this.Dock = DockStyle.Fill;
            parent.Controls.Add(this);

            SetMemberParameters();
            CreateNewItems_ForCount();
            ResizeItems();

            if (_maxPage > 0) PageCursor = 1;



            void SetMemberParameters()
            {
                this.itemPadding = new Padding(itemPadding);
                flowLayoutPanel_Base.Padding = new Padding(itemPadding);
                Count = new Point(horizontalCount, verticalCount);
                this.partyData = myPartyList;
                this.Context = context;
            }
        }

        private void CreateNewItems_ForCount()
        {
            if (Count.X == 0 || Count.Y == 0) return;

            int ActualWidth = Parent.Size.Width - ((Count.X * 2) * itemPadding.Horizontal);
            int ActualHeight = Parent.Size.Height - ((Count.Y * 2) * itemPadding.Vertical);
            double width = (ActualWidth / Count.X);
            double height = (ActualHeight / Count.Y);

            int sizeXY = (int)Math.Min(width, height);
            itemSize = new Size((int)width, (int)height);

            for (int y = 0; y < Count.Y; y++)
            {
                for (int x = 0; x < Count.X; x++)
                {
                    var control = CreateNewItem_AsPresetParameters<PartyIndicatorItem>();
                    madeControls.Add(control);
                    flowLayoutPanel_Base.Controls.Add(control);
                }
            }


            foreach (Control item in flowLayoutPanel_Base.Controls)
            {
                item.Size = itemSize;
            }
        }        
        private T CreateNewItem_AsPresetParameters<T>() where T : Control, new()
        {
            Control newItem = new T();
            newItem.Size = itemSize;
            newItem.Margin = itemPadding;

            return newItem as T;
        }
        private bool IsValidImageList(List<Image> images) => images != null && images.Count >= 2;
        private void ResizeItems()
        {
            if (Count.X == 0 || Count.Y == 0) return;
            if (Parent == null) return;

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
