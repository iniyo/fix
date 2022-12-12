
using System.Drawing;

namespace testdbwinform
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
       
        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.casecode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table2_staffcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staffname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accident_free = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.case_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.revenue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.table2_staffcode2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staffname2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accident = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commute2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.revenue2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button1.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(29, 106);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 42);
            this.button1.TabIndex = 3;
            this.button1.Text = "실적추가";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(25, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "날짜";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(134, 106);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 42);
            this.button2.TabIndex = 5;
            this.button2.Text = "실적삭제";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.casecode,
            this.table2_staffcode,
            this.staffname,
            this.accident_free,
            this.case_number,
            this.date,
            this.commute,
            this.revenue});
            this.dataGridView1.Location = new System.Drawing.Point(29, 165);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(563, 171);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // casecode
            // 
            this.casecode.HeaderText = "code";
            this.casecode.MinimumWidth = 8;
            this.casecode.Name = "casecode";
            this.casecode.Width = 150;
            // 
            // table2_staffcode
            // 
            this.table2_staffcode.HeaderText = "staffcode";
            this.table2_staffcode.MinimumWidth = 8;
            this.table2_staffcode.Name = "table2_staffcode";
            this.table2_staffcode.Width = 150;
            // 
            // staffname
            // 
            this.staffname.HeaderText = "사원명";
            this.staffname.MinimumWidth = 8;
            this.staffname.Name = "staffname";
            this.staffname.Width = 150;
            // 
            // accident_free
            // 
            this.accident_free.HeaderText = "무사고 여부";
            this.accident_free.MinimumWidth = 8;
            this.accident_free.Name = "accident_free";
            this.accident_free.Width = 150;
            // 
            // case_number
            // 
            this.case_number.HeaderText = "배달건수";
            this.case_number.MinimumWidth = 8;
            this.case_number.Name = "case_number";
            this.case_number.Width = 150;
            // 
            // date
            // 
            this.date.HeaderText = "날짜";
            this.date.MinimumWidth = 8;
            this.date.Name = "date";
            this.date.Width = 150;
            // 
            // commute
            // 
            this.commute.HeaderText = " 출/퇴근";
            this.commute.MinimumWidth = 8;
            this.commute.Name = "commute";
            this.commute.Width = 150;
            // 
            // revenue
            // 
            this.revenue.HeaderText = "총수익";
            this.revenue.MinimumWidth = 8;
            this.revenue.Name = "revenue";
            this.revenue.Width = 150;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.table2_staffcode2,
            this.staffname2,
            this.tel,
            this.addr,
            this.accident,
            this.caseNo,
            this.commute2,
            this.revenue2});
            this.dataGridView2.Location = new System.Drawing.Point(29, 373);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(563, 62);
            this.dataGridView2.TabIndex = 14;
            // 
            // table2_staffcode2
            // 
            this.table2_staffcode2.HeaderText = "staffcode";
            this.table2_staffcode2.MinimumWidth = 8;
            this.table2_staffcode2.Name = "table2_staffcode2";
            this.table2_staffcode2.ReadOnly = true;
            this.table2_staffcode2.Width = 150;
            // 
            // staffname2
            // 
            this.staffname2.HeaderText = "사원명";
            this.staffname2.MinimumWidth = 8;
            this.staffname2.Name = "staffname2";
            this.staffname2.ReadOnly = true;
            this.staffname2.Width = 150;
            // 
            // tel
            // 
            this.tel.HeaderText = "전화번호";
            this.tel.MinimumWidth = 8;
            this.tel.Name = "tel";
            this.tel.ReadOnly = true;
            this.tel.Width = 150;
            // 
            // addr
            // 
            this.addr.HeaderText = "주소";
            this.addr.MinimumWidth = 8;
            this.addr.Name = "addr";
            this.addr.ReadOnly = true;
            this.addr.Width = 150;
            // 
            // accident
            // 
            this.accident.HeaderText = "무사고 여부";
            this.accident.MinimumWidth = 8;
            this.accident.Name = "accident";
            this.accident.ReadOnly = true;
            this.accident.Width = 150;
            // 
            // caseNo
            // 
            this.caseNo.HeaderText = "배달건수";
            this.caseNo.MinimumWidth = 8;
            this.caseNo.Name = "caseNo";
            this.caseNo.ReadOnly = true;
            this.caseNo.Width = 150;
            // 
            // commute2
            // 
            this.commute2.HeaderText = "출/퇴근";
            this.commute2.MinimumWidth = 8;
            this.commute2.Name = "commute2";
            this.commute2.ReadOnly = true;
            this.commute2.Width = 150;
            // 
            // revenue2
            // 
            this.revenue2.HeaderText = "총수익";
            this.revenue2.MinimumWidth = 8;
            this.revenue2.Name = "revenue2";
            this.revenue2.ReadOnly = true;
            this.revenue2.Width = 150;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox1.Location = new System.Drawing.Point(584, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(278, 21);
            this.textBox1.TabIndex = 15;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(497, 59);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(48, 21);
            this.label3.TabIndex = 16;
            this.label3.Text = "검색 :";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button5.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(244, 106);
            this.button5.Margin = new System.Windows.Forms.Padding(0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(82, 42);
            this.button5.TabIndex = 17;
            this.button5.Text = "사원추가";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(639, 165);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.YValuesPerPoint = 2;
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(223, 270);
            this.chart1.TabIndex = 18;
            this.chart1.Text = "사원정보";
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.Font = new System.Drawing.Font("굴림", 11F);
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "staffcode",
            "무사고여부",
            "배달건수",
            "출/퇴근",
            "수익률"});
            this.comboBox4.Location = new System.Drawing.Point(639, 125);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(106, 23);
            this.comboBox4.TabIndex = 19;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.Font = new System.Drawing.Font("굴림", 11F);
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "Line",
            "Column",
            "Point",
            "Pie",
            "Doughnut"});
            this.comboBox5.Location = new System.Drawing.Point(756, 125);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(106, 23);
            this.comboBox5.TabIndex = 20;
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(83, 58);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 21;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "사건번호",
            "사원코드",
            "사원명",
            "무사고 여부",
            "배달건수",
            "출/퇴근",
            "수익"});
            this.comboBox1.Location = new System.Drawing.Point(584, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(86, 20);
            this.comboBox1.TabIndex = 22;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(353, 106);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 42);
            this.button3.TabIndex = 23;
            this.button3.Text = "사원삭제";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::testdbwinform.Properties.Resources.background2;
            this.ClientSize = new System.Drawing.Size(884, 481);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "사원 근태 및 실적관리 프로그램";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridViewTextBoxColumn casecode;
        private System.Windows.Forms.DataGridViewTextBoxColumn table2_staffcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn staffname;
        private System.Windows.Forms.DataGridViewTextBoxColumn accident_free;
        private System.Windows.Forms.DataGridViewTextBoxColumn case_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn commute;
        private System.Windows.Forms.DataGridViewTextBoxColumn revenue;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn table2_staffcode2;
        private System.Windows.Forms.DataGridViewTextBoxColumn staffname2;
        private System.Windows.Forms.DataGridViewTextBoxColumn tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn addr;
        private System.Windows.Forms.DataGridViewTextBoxColumn accident;
        private System.Windows.Forms.DataGridViewTextBoxColumn caseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn commute2;
        private System.Windows.Forms.DataGridViewTextBoxColumn revenue2;
    }
}

