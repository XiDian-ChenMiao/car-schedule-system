namespace CarScheduleSystem.DialogForms
{
    partial class BiggerRunQueueForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.waitQueueDataGridView = new System.Windows.Forms.DataGridView();
            this.runCarModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.runCarNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.runCarStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distanceToEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waitHeaderTxt = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.updateGridViewTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.waitQueueDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // waitQueueDataGridView
            // 
            this.waitQueueDataGridView.AllowUserToAddRows = false;
            this.waitQueueDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.waitQueueDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.waitQueueDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.waitQueueDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.waitQueueDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.waitQueueDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.waitQueueDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.runCarModel,
            this.runCarNumber,
            this.runCarStatus,
            this.distanceToEnd});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.waitQueueDataGridView.DefaultCellStyle = dataGridViewCellStyle7;
            this.waitQueueDataGridView.Location = new System.Drawing.Point(0, 40);
            this.waitQueueDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.waitQueueDataGridView.Name = "waitQueueDataGridView";
            this.waitQueueDataGridView.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.waitQueueDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.waitQueueDataGridView.RowHeadersWidth = 20;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.waitQueueDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.waitQueueDataGridView.RowTemplate.Height = 23;
            this.waitQueueDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.waitQueueDataGridView.Size = new System.Drawing.Size(385, 430);
            this.waitQueueDataGridView.TabIndex = 1;
            this.waitQueueDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.runQueueDataGridView_CellClick);
            // 
            // runCarModel
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.runCarModel.DefaultCellStyle = dataGridViewCellStyle3;
            this.runCarModel.HeaderText = "车辆型号";
            this.runCarModel.Name = "runCarModel";
            this.runCarModel.ReadOnly = true;
            this.runCarModel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.runCarModel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.runCarModel.Width = 90;
            // 
            // runCarNumber
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.runCarNumber.DefaultCellStyle = dataGridViewCellStyle4;
            this.runCarNumber.HeaderText = "车辆编号";
            this.runCarNumber.Name = "runCarNumber";
            this.runCarNumber.ReadOnly = true;
            this.runCarNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.runCarNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.runCarNumber.Width = 90;
            // 
            // runCarStatus
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.runCarStatus.DefaultCellStyle = dataGridViewCellStyle5;
            this.runCarStatus.HeaderText = "车辆状态";
            this.runCarStatus.Name = "runCarStatus";
            this.runCarStatus.ReadOnly = true;
            this.runCarStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.runCarStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // distanceToEnd
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.distanceToEnd.DefaultCellStyle = dataGridViewCellStyle6;
            this.distanceToEnd.HeaderText = "距离终点";
            this.distanceToEnd.Name = "distanceToEnd";
            this.distanceToEnd.ReadOnly = true;
            this.distanceToEnd.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.distanceToEnd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.distanceToEnd.Width = 85;
            // 
            // waitHeaderTxt
            // 
            this.waitHeaderTxt.AutoSize = true;
            this.waitHeaderTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.waitHeaderTxt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.waitHeaderTxt.ForeColor = System.Drawing.Color.White;
            this.waitHeaderTxt.Location = new System.Drawing.Point(140, 10);
            this.waitHeaderTxt.Name = "waitHeaderTxt";
            this.waitHeaderTxt.Size = new System.Drawing.Size(93, 20);
            this.waitHeaderTxt.TabIndex = 2;
            this.waitHeaderTxt.Text = "运行队列标题";
            this.waitHeaderTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.Location = new System.Drawing.Point(0, 470);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(385, 30);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = "关    闭";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // updateGridViewTimer
            // 
            this.updateGridViewTimer.Interval = 1000;
            this.updateGridViewTimer.Tick += new System.EventHandler(this.updateGridViewTimer_Tick);
            // 
            // BiggerRunQueueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(384, 500);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.waitHeaderTxt);
            this.Controls.Add(this.waitQueueDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BiggerRunQueueForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "运行窗体";
            ((System.ComponentModel.ISupportInitialize)(this.waitQueueDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region 字段声明
        protected System.Windows.Forms.DataGridView waitQueueDataGridView;
        protected System.Windows.Forms.Label waitHeaderTxt;
        protected System.Windows.Forms.Button closeBtn;
        protected System.Windows.Forms.Timer updateGridViewTimer;

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn runCarModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn runCarNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn runCarStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn distanceToEnd;
    }
}