using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // MySql 사용 시

namespace testdbwinform
{
    public partial class Form2 : Form
    {
        Form1 parent;
        public Form2(Form1 p)
        {
            InitializeComponent();
            parent = p;
        }
        int deleveries; // 배달 건수
        int accident; // 무사고 확인
        string casecode; // 랜덤 난수로 설정.
        int commission; // 수수료 수익
        int commute; // 제시간에 퇴근 했는지 여부 확인
        int count = 0; // 입력이 됐었는지 아닌지 확인용도
        int instaffcode; // 사원 코드 
        string datenow; // 날짜
        //데이터 베이스 정보
        static string server = "localhost"; // local
        static string databaes = "mydb"; // db이름
        static string port = "3308"; // port 3308 사용
        static string user = "root"; // 사용자
        static string password = "!roottestdatabase23"; // password
        // 공통 db 설정
        //static string port = "3306";
        //static string user = "test";
        //static string password = "1234";
        // conn에 들어갈 정보
        static string connectionaddress = $"Server={server};Port={port};Database={databaes};Uid={user};Pwd={password}";
        // MySql db연동을 위해 필요
        MySqlConnection conn;
        // 쿼리문 설정, 실행
        MySqlCommand cmd;
        // 서버에서 데이터 가져올때 필요
        MySqlDataReader reader;
        //
        // 폼
        //
        private void Form2_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            conn = new MySqlConnection(connectionaddress); // 실행할 정보 셋팅
            conn.Open(); //MySql db 실행
            cmd = new MySqlCommand("", conn); // 쿼리문은 넣지 않고 일단 실행 -> 필요한 이벤트 처리기에서 쿼리문 설정.
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close(); //MySql db 연결 종료.
        }

        //
        // 이벤트 처리기
        //
        //사원 이름 입력 시 이벤트
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            // 무사고, 배달건수를 제외한 데이터는 모두 ReadOnly == 값 변경 불가.
            // 엔터키 이벤트
            try {
                if (e.KeyCode == Keys.Enter && String.IsNullOrWhiteSpace(textBox1.Text))
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[0]); // 해당되는 row 삭제
                    count = 0; // 텍스트 박스 공백 시 count = 0
                }
                else if (e.KeyCode == Keys.Enter && textBox1.Text.Length >= 3 && count == 0) // 텍스트 박스 길이가 3이 넘고 엔터를 쳐야지 실행됨.
                {
                    try
                    {
                        set_data(); //기본 데이터 셋팅
                    }
                    catch (Exception ex)
                    {
                        reader.Close(); // 셋팅 끝났으면 종료
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("해당하는 이름이 데이터베이스 내에 존재하지 않습니다.");
                        count = 0;
                    }
                }
                else if (e.KeyCode == Keys.Enter && count == 1)
                {
                    MessageBox.Show("텍스트 박스를 공백으로 해주세요");
                    count = 0;
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    MessageBox.Show("텍스트 박스를 확인해주세요");
                    count = 0;
                }
            }
            catch(Exception ex)
            {
                reader.Close(); // 셋팅 끝났으면 종료
                MessageBox.Show(ex.Message);
            }
        }
        //추가버튼 클릭 시 db에 data 전송
        private void button1_Click(object sender, EventArgs e)
        {
            int check = 0;
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (null == dataGridView1.Rows[0].Cells[i].Value)
                    {
                        check = 0;
                    }
                    else
                    {
                        check = 1;
                    }
                }
                if (check == 0)
                {
                    MessageBox.Show("셀이 비어있습니다. 값을 넣어주세요");
                }
                else if (check == 1)
                {
                    string staffcode = dataGridView1.Rows[0].Cells[0].Value.ToString();
                    input_data();
                    parent.setGridView(staffcode, casecode);

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        // datagridview 내의 데이터 변경이 어디서 됐는지 확인
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0) // datagridview의 값이 있을때.
            {
                if (null != e.ColumnIndex.ToString() && e.ColumnIndex == 5)
                {
                    try
                    {
                        deleveries = int.Parse(dataGridView1.Rows[0].Cells[5].Value.ToString()); // 배달 건수 int로 받음
                        if (40 < deleveries)
                        {
                            MessageBox.Show("비정상적으로 값이 높습니다. 관리자에게 확인해주세요");
                        }
                        else
                        {
                            commission = deleveries * 400; // 400은 고정 수수료 (건수 * 400 = 총수익)
                            dataGridView1.Rows[0].Cells[6].Value = commission; //수수료 수익 자동 셋팅
                        }
                    }
                    catch
                    {
                        MessageBox.Show("숫자를 입력해주세요");
                    }

                }
                else if (null != e.ColumnIndex.ToString() && e.ColumnIndex == 3)
                {
                    string s = dataGridView1.Rows[0].Cells[3].Value.ToString();
                    if ("X" != s && "O" != s && "사고발생" != s && "무사고" != s)
                    {
                        //dataGridView1.Rows[0].Cells[3].Value = "";
                        MessageBox.Show("O 나 X 를 입력해주세요.");
                    }
                    else
                    {
                        if ("X" == s) // x인 경우
                        {
                            accident = 0; // 무사고 bool값 0
                        }
                        else if ("O" == s) // o인 경우
                        {
                            accident = 1; // 무사고 bool값 1
                        }
                    }
                }
                if (accident == 0)
                    dataGridView1.Rows[0].Cells[3].Value = "무사고";
                else if (accident == 1)
                    dataGridView1.Rows[0].Cells[3].Value = "사고발생";
            }
        }
        // datafridview keydown enter 이벤트 시 다음 row로 이동하는 동작이 있음.
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int column = dataGridView1.CurrentCell.ColumnIndex;
                    int row = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.CurrentCell = dataGridView1[column, row];
                    e.Handled = true; // enter키 누를 시 동작 못함
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //
        // 커스텀 함수
        //
        private void set_data() //엔터키 누르면 정보 셋팅하는 함수.
        {
            try
            {
                string selectQuery = "SELECT * FROM sub_table_test where name = " + '"' + textBox1.Text + '"'; // textBox1과 일치하는 값을 가진 테이블 내 행만 가지고 옴. (sub 데이터 베이스의 name 필드)
                cmd.CommandText = selectQuery; // cmd에 쿼리 설정
                //데이터 read
                reader = cmd.ExecuteReader();
                reader.Read();
                dataGridView1.Rows.Add(reader["staffcode"], reader["name"]); //사원명이 있으면 사원명과 staff_code를 세팅 (사원명이 중복될 경우 데이터 처리도 해야됨)
                reader.Close(); // 셋팅 끝났으면 종료
                //db에 넣을 데이터
                Random randomObj = new Random();
                casecode = "caseNo" + randomObj.Next().ToString(); //next 시 10개의 int가 생성됨. casecode의 크기를 16으로 해놨음. 그래서 영문자 6개 더함.
                DateTime now = DateTime.Now;
                dataGridView1.Rows[0].Cells[4].Value = now.ToString("yyyy-MM-dd"); // 현재 날짜 셋팅 년,월,일
                datenow = dataGridView1.Rows[0].Cells[4].Value.ToString().Trim(); // 날짜 데이터 저장 시 사용
                dataGridView1.Rows[0].Cells[2].Value = now.Hour + ":" + now.Minute; // 현재시간 셋팅 시간+분

                CalcComm();
                MessageBox.Show("사원이 인증되었습니다.");
                count = 1;
            }
            catch (Exception ex)
            {
                reader.Close(); // 셋팅 끝났으면 종료
                MessageBox.Show("사원이 존재하지 않습니다.");
            }
        }
        private void CalcComm()
        {
            try
            {
                string DateNOw = dataGridView1.Rows[0].Cells[2].Value.ToString();
                string[] hour_minute = DateNOw.Split(':');
                int hour = int.Parse(hour_minute[0]);
                int minute = int.Parse(hour_minute[1]);

                // 00~8, 8~14, 14~00
                if (hour == 23 && minute >= 50 || hour == 0 && 10 <= minute || hour == 7 && minute >= 50 || hour == 8 && minute <= 10 || hour == 13 && minute >= 50 || hour == 14 && 10 <= minute)
                {
                    commute = 1; // 1은 tinyint의 true값
                }
                else
                {
                    commute = 0;// 1은 tinyint의 false값
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("계산");
            }
        }
        // 데이터 추가 함수
        public void input_data()
        {
            // casecode, accident_free(bool), case_number, date, revenue, commute(bool)
            string caseNum = dataGridView1.Rows[0].Cells[5].Value.ToString(); // case_number (배달건수)
            instaffcode = int.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString());
            //INSERT INTO 쿼리문으로 받아온 정보를 DB에 전송한다. date는 데이터베이스에서 설정함.
            string selectQuery = $"INSERT INTO main_table_test (table2_staffcode,casecode,accident_free,date,case_number,revenue,commute) VALUES  ({instaffcode},'{casecode}',{accident},'{datenow}','{caseNum}','{commission}',{commute})";

            //DB전송을 진행하고 실패시 에러메세지 출력
            try
            {
                cmd.CommandText = selectQuery; // 쿼리문 지정
                if (cmd.ExecuteNonQuery() != 1) //행의 수 반환(결과를 받을 필요가 없는 Query문에 많이 사용)
                    MessageBox.Show("데이터 넣기 실패");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
