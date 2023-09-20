using Lib.Frame;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FootccerClient.Windows.Views
{     
    public partial class PartyJoinView : MasterView
    {
  
        string _server = "localhost"; //DB 서버 주소, 로컬일 경우 localhost
        int _port = 3308; //DB 서버 포트
        string _database = "new_schema"; //DB 이름
        string _id = "root"; //계정 아이디
        string _pw = "root"; //계정 비밀번호
        string _connectionAddress = "";

        public PartyJoinView() {
            InitializeComponent();
            //MySQL 연결을 위한 주소 형식
            _connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", _server, _port, _database, _id, _pw);
        }

        private void selectTable() {
            try {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress)) {
                    mysql.Open();
                    //accounts_table의 전체 데이터를 조회합니다.            
                    string selectQuery = string.Format("SELECT * FROM accounts_table");

                    MySqlCommand command = new MySqlCommand(selectQuery, mysql);
                    MySqlDataReader table = command.ExecuteReader();

                    pgrid.Items.Clear();

                    while (table.Read()) {
                        ListViewItem item = new ListViewItem();
                        item.Text = table["id"].ToString();
                        item.SubItems.Add(table["name"].ToString());
                        item.SubItems.Add(table["phone"].ToString());

                        pgrid.Items.Add(item);
                    }

                    table.Close();
                }
            }
            catch (Exception exc) {
                MessageBox.Show(exc.Message);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void pgrid_SelectionChanged(object sender, EventArgs e) {

        }
    }
}
