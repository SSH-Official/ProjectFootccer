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

namespace FootccerClient.Windows.Pops
{
    public partial class PositionView : MasterView
    {
        public object result;
        public PositionView()
        {
            InitializeComponent();
            Initialize();
        }
        
        public void Initialize()
        {
            int x = 100;
            int y = 10;
            List<PositionDTO> PS = Footccer.App.Instance.DB.Position.getPositionList();
            foreach(var posDTO in PS)
            {
                string position = posDTO.position;
                if (position == "FW")
                {
                    for(int j = 0; j < 3; j++)
                    {
                        createLabel(x, y, position);
                        x += 150;
                    }
                    x = 100;
                    y += 150;
                }
                else if(position == "MF")
                {
                    for (int j = 0; j < 3; j++)
                    {
                        createLabel(x, y, position);
                        x += 150;
                    }
                    x = 25;
                    y += 150;
                }
                else if( position == "DF")
                {
                    for (int j = 0; j < 4; j++)
                    {
                        createLabel(x, y, position);
                        x += 150;
                    }
                    x = 250;
                    y += 150;
                }
                else if (position == "GK")
                {
                    createLabel(x, y, position);
                }
                
            }
        }
        public void createLabel(int x, int y, string position)
        {
            Label dynamicLabel = new Label();
            dynamicLabel.Location = new Point(x, y); // 위치 설정
            dynamicLabel.Size = new Size(100, 100);    // 크기 설정
            dynamicLabel.BackColor = Color.Red;
            dynamicLabel.Text = position;
            dynamicLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            dynamicLabel.TextAlign = ContentAlignment.MiddleCenter;
            dynamicLabel.Click += (sender, e) =>
            {
                MessageBox.Show("버튼이 클릭되었습니다.");
            };
            this.Controls.Add(dynamicLabel);
        }

    }
}
