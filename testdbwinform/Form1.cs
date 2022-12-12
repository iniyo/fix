using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // 윈폼
using MySql.Data.MySqlClient; // MySql 사용 시
using System.Collections; //ArrayLIst 클래스 사용 시 
using Google.Protobuf.WellKnownTypes;
using System.Runtime.InteropServices;

namespace testdbwinform
{
    public partial class Form1 : Form
    {
        int rowselect; //datagridview 선택
        //데이터 베이스 정보
        static string server = "localhost";
        static string databaes = "mydb";
        static string port = "3308";
        //static string user = "root";
        //static string password = "!roottestdatabase23";
        // 공통 db 설정
        //static string port = "3306";
        // 공통 db 설정
        static string user = "test";
        static string password = "1234";

        static string connectionaddress = $"Server={server};Port={port};Database={databaes};Uid={user};Pwd={password}";
        // mysql db 연결 시 필요한 것들
        MySqlConnection conn; // MySql db연동을 위해 필요
        MySqlCommand cmd; // 쿼리문 설정, 실행
        MySqlDataReader mainreader; // 서버에서 데이터 가져오기 설정
        MySqlDataReader subreader; // 서버에서 데이터 가져오기 설정

        public Form1()
        {
            InitializeComponent();
        }
        /////폼 동작

        // 폼이 시작되며 DB를 연결 시킨다.
        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connectionaddress); // 실행할 정보 셋팅
            conn.Open(); //MySql db 실행
            dataGridView1.ReadOnly = true; // 메인 datagridview읽기만 가능하도록 설정 
            cmd = new MySqlCommand("", conn); // 쿼리문은 넣지 않고 일단 실행 -> 필요한 이벤트 처리기에서 쿼리문 설정.
            Main_ListView_items_Reader(DateTime.Now.ToString("yyyy-MM-dd")); //화면 메인 리스트 뷰에 데이터 받아오기
            comboBox1.SelectedIndex = 0;
        }
        //
        //폼 동작
        //
        // 폼 동작 끝날때 db연결 해제
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close(); //MySql db 연결 종료.
        }
        // 항목 내의 셀 두번 클릭 시
        //
        // 이벤트 처리기
        //
        // 검색 텍스트 박스 keydown 이벤트
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (String.IsNullOrEmpty(textBox1.Text))
                    {
                        MessageBox.Show("값을 입력해주세요", "검색 실패!");
                    }
                    else
                    {
                        Search(textBox1.Text); //화면 메인 리스트 뷰에 데이터 받아오기
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e) //추가버튼 클릭시 이동 이벤트
        {
            Form2 form2 = new Form2(this);
            form2.ShowDialog(); // 모달방식
        }
        String delcode;
        private void button2_Click(object sender, EventArgs e) //삭제버튼 클릭시 이벤트
        {
            try
            {
                // 행 선택 안됐을 경우
                if (delcode == null)
                {
                    MessageBox.Show("삭제를 원하는 행을 선택해주십시요", "삭제실패");
                }
                else
                {
                    if (MessageBox.Show("정말 삭제하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        dataGridView1.Rows.Remove(dataGridView1.Rows[rowselect]); // 해당되는 row 삭제
                                                                                  //dataGridView2.Rows.Remove(dataGridView1.Rows[0]);// row 하나밖에 없으므로 0번째 행 삭제
                        DeleteDB(delcode); // 삭제 진행
                        Main_ListView_items_Reader(dateTimePicker1.Value.ToString("yyyy-MM-dd")); // 삭제 후 테이블 띄우기
                        dataGridView2.Rows.Clear();
                    }
                }
            }
            catch
            {
                MessageBox.Show("삭제를 원하는 행을 재선택 해주십시요", "삭제실패");
            }
        }
        //사원추가 버튼
        private void button5_Click_1(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show(); // 모달방식
        }

        //datafridview1 행 클릭시 datafridview2에 데이터 추가됨.
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            rowselect = e.RowIndex;

            // 선택한 행의 데이터들을 넣을 값
            string[] s = new string[8];

            if (dataGridView2.RowCount > 0) // 이미 있는 경우는 삭제
            {
                dataGridView2.Rows.Remove(dataGridView2.Rows[0]); // 해당되는 row 삭제
            }

            subquery(); // 사원 테이블

            while (subreader.Read()) // 데이터 읽어와서 chart에 부착
            {
                if (dataGridView1.Rows[rowselect].Cells[1].Value.ToString() == subreader["staffcode"].ToString()) {
                    // 스태프 코드가 같으면
                    s[0] = subreader["staffcode"].ToString();
                    s[1] = subreader["name"].ToString();
                    s[2] = subreader["tel"].ToString();
                    s[3] = subreader["addr"].ToString();
                }
            }

            subreader.Close();
            // 데이터 가져와서 DataGridView에 설정

            string selectQuery = "SELECT * FROM main_table_test where table2_staffcode= " + "'" + s[0] + "'"; // 전체 항목 읽어오기
            cmd.CommandText = selectQuery; // cmd에 쿼리 설정
            mainreader = cmd.ExecuteReader();

            // sttafcode와 일치하는 모든 데이터의 값을 더해서 보여줌
            int sum1 = 0; // 배달건수 합계
            int sum2 = 0; // 합계 도
            int b = 3;
            while (mainreader.Read()) {
                // 무사고 여부
                if ("1" == mainreader["accident_free"].ToString()) {
                    s[4] = "사고";
                } else {
                    s[4] = "무사고";
                }
                // 배달건수 
                b += 3;
                sum1 += int.Parse(mainreader["case_number"].ToString());
                s[5] = sum1.ToString();
                // 츨/퇴근
                if ("1" == mainreader["commute"].ToString()) {
                    s[6] = "정상";
                } else {
                    s[6] = "시간초과";
                }
                // 총 수익
                sum2 = int.Parse(mainreader["revenue"].ToString());
                sum2 += sum2;
                s[7] = sum2.ToString();
                mainreader["revenue"].ToString();
            }

            mainreader.Close();
            dataGridView2.Rows.Add(s[0], s[1], s[2], s[3], s[4], s[5], s[6], s[7]);
            delcode = dataGridView1.Rows[rowselect].Cells[0].Value.ToString(); // datagridview 1의 선택된 행의 caseNo를 담음
        }

        //datafrideview1 클릭 이벤트 (delete처리)
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //delete키 누르면 싫행.
            if (e.KeyCode == Keys.Delete)
            {

                if (MessageBox.Show("정말 삭제하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[rowselect]); // 해당되는 row 삭제
                }
                else
                {
                    MessageBox.Show("행이 선택되어있는지 확인해주세요");
                }
            }
        }
        // chart 콤보박스1 변경 시 이벤트 (
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            chart1.Series["Series1"].Points.Clear();
            // 무사고 여부 클릭시 사고 여부 보임.
            if ("사고여부" == comboBox4.SelectedItem.ToString()) {
                mainquery(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                while (mainreader.Read()) 
                {
                    chart1.Series[0].Points.AddXY(mainreader["table2_staffcode"].ToString(), mainreader["accident_free"]);
                }
                mainreader.Close(); // 항상 사용 후 종료
            } 
            
            else if ("배달건수" == comboBox4.SelectedItem.ToString())
            {
                mainquery(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                while (mainreader.Read()) 
                {
                    chart1.Series[0].Points.AddXY(mainreader["table2_staffcode"].ToString(), mainreader["case_number"]);
                }
                mainreader.Close(); // 항상 사용 후 종료
            }
           
            else if ("출/퇴근" == comboBox4.SelectedItem.ToString())
            {
                mainquery(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                while (mainreader.Read()) 
                {
                    chart1.Series[0].Points.AddXY(mainreader["table2_staffcode"].ToString(), mainreader["commute"]); 
                }
                mainreader.Close(); // 항상 사용 후 종료
            }
            
            else if ("총수익" == comboBox4.SelectedItem.ToString())
            {
                mainquery(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                while (mainreader.Read())
                {
                    chart1.Series[0].Points.AddXY(mainreader["table2_staffcode"].ToString(), mainreader["revenue"]); 
                }
                mainreader.Close(); // 항상 사용 후 종료
            }
        }
        //
        //커스텀 함수
        // today => 원하는 날짜(선택된 날짜)
        private void mainquery(String today)
        {
            // 데이터 가져와서 DataGridView에 설정
            string selectQuery = "SELECT * FROM main_table_test where date= " + "'" + today + "'"; // 전체 항목 읽어오기
            cmd.CommandText = selectQuery; // cmd에 쿼리 설정
            mainreader = cmd.ExecuteReader();
        }
        private void subquery()
        {
            string selectQuery = "SELECT * FROM sub_table_test"; // 전체 항목 읽어오기
            cmd.CommandText = selectQuery; // cmd에 쿼리 설정
            subreader = cmd.ExecuteReader();
        }
        private void searchquery(String field, String data)
        {
            // 데이터 가져와서 DataGridView에 설정
            string selectQuery = "SELECT * FROM main_table_test where " + field + "= " + "'" + data + "'";
            cmd.CommandText = selectQuery; // cmd에 쿼리 설정
            mainreader = cmd.ExecuteReader();
        }
        private void searchnamequery(String field, List<String> data)
        {
            String syntex = "";
            // 데이터 가져와서 DataGridView에 설정
            for (int i = 0; i < data.Count; i++)
            {
                if (i == data.Count - 1)
                {
                    syntex += data[i];
                }
                else
                {
                    syntex += data[i] + " or ";
                }
            }
            string selectQuery = "SELECT * FROM main_table_test where " + field + "= " + syntex;
            cmd.CommandText = selectQuery; // cmd에 쿼리 설정
            mainreader = cmd.ExecuteReader();
        }
        private List<String> searchname(String data)
        {
            // 데이터 가져와서 DataGridView에 설정
            string selectQuery = "SELECT * FROM sub_table_test where name= " + "'" + data + "'";
            cmd.CommandText = selectQuery; // cmd에 쿼리 설정
            subreader = cmd.ExecuteReader();
            List<String> namelist = new List<String>();
            while (subreader.Read())
            {
                namelist.Add(subreader["staffcode"].ToString());
            }
            subreader.Close();
            return namelist;
        }
        // 메인 리스트 뷰에 전체 데이터 표시 (데이터 읽어오기)
        private void Main_ListView_items_Reader(String today)
        {
            dataGridView1.Rows.Clear(); // 데이터 그리드 뷰 초기화
            if (textBox1.Text == "")
            {
                mainquery(today);
                while (mainreader.Read())
                {
                    string[] date = new string[dataGridView1.RowCount];
                    date = mainreader["date"].ToString().Split(' ');
                    dataGridView1.Rows.Add(mainreader["casecode"], mainreader["table2_staffcode"], "", mainreader["accident_free"], mainreader["case_number"], date[0], mainreader["commute"], mainreader["revenue"]);
                }
                mainreader.Close();
                for (int i = 0; i < dataGridView1.RowCount; i++) //Row개수 만큼 동작
                {
                    if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "0")
                        dataGridView1.Rows[i].Cells[3].Value = "무사고";
                    else if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "1")
                        dataGridView1.Rows[i].Cells[3].Value = "사고발생";
                    if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "1")
                        dataGridView1.Rows[i].Cells[6].Value = "정상퇴근";
                    else if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "0")
                        dataGridView1.Rows[i].Cells[6].Value = "시간초과";

                }
                // 가져온 staffcode와 일치하면 이름을 위치에 넣음
                // subreader

                // 비교문을 돌려서 staffcode와 일치하면 이름을 가져와서 적용함.
                for (int i = 0; i < dataGridView1.RowCount; i++) //Row개수 만큼 동작
                {
                    subquery();
                    while (subreader.Read())
                    {
                        if (dataGridView1.Rows[i].Cells[1].Value.ToString() == subreader["staffcode"].ToString())
                        {
                            dataGridView1.Rows[i].Cells[2].Value = subreader["name"];
                        }
                    }
                    subreader.Close();
                }
            }
            else
            {
                // 검색창 텍스트 박스에 내용이 입력 되면 해당 텍스트 박스내용에 있는 행을 보여줌. (현재 staff_code로 한정되어있음)
                string selectQuery = "SELECT * FROM main_table_test where table2_staffcode = '" + textBox1.Text + " '";
                cmd.CommandText = selectQuery;
                mainreader = cmd.ExecuteReader();
                try
                {
                    while (mainreader.Read())
                    {
                        // 해당되는 항목이 들어있는 행을 전부 가지고 옴.
                        dataGridView1.Rows.Add(mainreader["casecode"], mainreader["table2_staffcode"], "", mainreader["accident_free"], mainreader["case_number"], mainreader["date"], mainreader["revenue"], mainreader["commute"]);
                    }
                    mainreader.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message); // 에러 메시지 출력
                }
            }
        }
        // 폼 통신용
        public void setGridView(string staffcode, string caseNo)
        {
            bool t = false; // datagridview에 아무것도 없는 경우
            for (int i = 0; i < dataGridView1.RowCount; i++) //Row개수 만큼 동작
            {
                if (dataGridView1.Rows[i].Cells[1].Value.ToString() == staffcode)
                {
                    t = true;
                    break;
                }
                else
                {
                    t = false;
                }
            }
            if (t)
            {
                DeleteDB(caseNo); // 삭제 진행
                MessageBox.Show("오늘은 이미 실적추가를 했습니다.");
            }
            else
            {
                MessageBox.Show("전송완료");
                Main_ListView_items_Reader(dateTimePicker1.Value.ToString("yyyy-MM-dd")); // 테이블 띄우기
            }

        }
        private void SearchData(String field, String data)
        {
            // 이름필드 - 테이블이 달라서 따로 서치
            if (field == "name")
            {
                field = "table2_staffcode";
                searchnamequery(field, searchname(data));
            }
            else
            {
                searchquery(field, data);
            }

            while (mainreader.Read())
            {
                string[] date = new string[dataGridView1.RowCount];
                date = mainreader["date"].ToString().Split(' ');
                dataGridView1.Rows.Add(mainreader["casecode"], mainreader["table2_staffcode"], "", mainreader["accident_free"], mainreader["case_number"], date[0], mainreader["commute"], mainreader["revenue"]);
            }
            mainreader.Close();
            for (int i = 0; i < dataGridView1.RowCount; i++) //Row개수 만큼 동작
            {
                if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "0")
                    dataGridView1.Rows[i].Cells[3].Value = "무사고";
                else if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "1")
                    dataGridView1.Rows[i].Cells[3].Value = "사고발생";
                if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "1")
                    dataGridView1.Rows[i].Cells[6].Value = "정상퇴근";
                else if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "0")
                    dataGridView1.Rows[i].Cells[6].Value = "시간초과";
            }
            // 가져온 staffcode와 일치하면 이름을 위치에 넣음
            // subreader

            // 비교문을 돌려서 staffcode와 일치하면 이름을 가져와서 적용함.
            for (int i = 0; i < dataGridView1.RowCount; i++) //Row개수 만큼 동작
            {
                subquery();
                while (subreader.Read())
                {
                    if (dataGridView1.Rows[i].Cells[1].Value.ToString() == subreader["staffcode"].ToString())
                    {
                        dataGridView1.Rows[i].Cells[2].Value = subreader["name"];
                    }
                }
                subreader.Close();
            }
        }

        // 검색
        private void Search(String data)
        {
            dataGridView1.Rows.Clear(); // 데이터 그리드 뷰 초기화
            String selectdata = comboBox1.SelectedItem.ToString();

            if (data == null)
            {
                return;
            }
            // 사건번호
            else if (selectdata.Equals("사건번호"))
            {
                selectdata = "casecode";
                SearchData(selectdata, data);

            }
            // 사원코드
            else if (selectdata.Equals("사원코드"))
            {
                selectdata = "table2_staffcode";
                SearchData(selectdata, data);
            }
            // 사원명
            else if (selectdata.Equals("사원명"))
            {
                selectdata = "name";
                SearchData(selectdata, data);
            }
            // 무사고 여부
            else if (selectdata.Equals("무사고 여부"))
            {
                selectdata = "accident_free";
                if (data == "무사고")
                {
                    data = "0";
                }
                else if (data == "사고")
                {
                    data = "1";
                }
                SearchData(selectdata, data);
            }
            // 배달건수
            else if (selectdata.Equals("배달건수"))
            {
                selectdata = "case_number";
                SearchData(selectdata, data);
            }
            // 출퇴근
            else if (selectdata.Equals("출/퇴근"))
            {
                selectdata = "commute";
                if (data == "정상퇴근")
                {
                    data = "1";
                }
                else if (data == "시간초과")
                {
                    data = "0";
                }
                SearchData(selectdata, data);
            }
            // 수익
            else if (selectdata.Equals("수익"))
            {
                selectdata = "revenue";
                SearchData(selectdata, data);
            }
        }

        //UPDATE처리
        public void UpdateDB()
        {
            string sql = "Update user Set name ='홍길동2' where id = 1";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        //DELETE처리
        public void DeleteDB(String code)
        {
            string sql = "DELETE FROM main_table_test where casecode = '" + code + "'"; // datagridview 값이 필요.
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
        // Delete 사원
        public void DeleteSubDB(String code)
        {
            string sql = "DELETE FROM sub_table_test where staffcode = '" + code + "'"; // datagridview 값이 필요.
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        // 날짜 선택 데이터
        int year;
        int month;
        int day;
        String dateSet;


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime SelectDate = dateTimePicker1.Value;
            dateSet = SelectDate.ToString("yyyy-MM-dd");
            year = SelectDate.Year;
            month = SelectDate.Month;
            day = SelectDate.Day;

            //MessageBox.Show(SelectDate.ToString());
            textBox1.Text = "";
            Main_ListView_items_Reader(dateSet);
        }

        // 사원 삭제
        private void button3_Click(object sender, EventArgs e)
        {

            String staffcode = "?";
            if (InputBox("사원코드 입력 - 삭제", "staffcode를 입력해주세요", ref staffcode) == DialogResult.OK)
            {
                try
                {
                    string selectQuery = "SELECT * FROM sub_table_test where staffcode= " + "'" + staffcode + "'";
                    cmd.CommandText = selectQuery; // cmd에 쿼리 설정
                    subreader = cmd.ExecuteReader();
                    List<String> codeList = new List<String>();
                    while (subreader.Read())
                    {
                        codeList.Add(subreader["staffcode"].ToString());
                    }
                    subreader.Close();
                    if(codeList.Count == 0)
                    {
                        MessageBox.Show("존재하지 않는 회원입니다.", "삭제 실패");
                    }
                    else
                    {
                        DeleteSubDB(staffcode);
                        MessageBox.Show("삭제되었습니다", "삭제 성공");
                    }
                }
                catch
                {
                    MessageBox.Show("존재하지 않는 회원입니다.", "삭제 실패");
                }
            }
        }
        // 오픈소스 - https://076923.github.io/exercise/C-inputbox/
        public static DialogResult InputBox(string title, string content, ref string value)
        {
            Form form = new Form();

            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.ClientSize = new Size(300, 100);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            form.Text = title;
            label.Text = content;
            textBox.Text = value;
            buttonOk.Text = "확인";
            buttonCancel.Text = "취소";

            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;
            label.SetBounds(25, 17, 200, 20);
            textBox.SetBounds(25, 40, 220, 20);
            buttonOk.SetBounds(95, 70, 70, 20);
            buttonCancel.SetBounds(175, 70, 70, 20);

            DialogResult dialogResult = form.ShowDialog();

            value = textBox.Text;
            return dialogResult;
        }
    }
}
