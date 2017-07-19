namespace CarScheduleSystem.DialogForms
{
    partial class BiggerWaitQueueForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.waitQueueDataGridView = new System.Windows.Forms.DataGridView();
            this.bj2xnWaitCarModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bj2xnWaitCarNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bj2xnWaitCarStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.bj2xnWaitCarModel,
            this.bj2xnWaitCarNumber,
            this.bj2xnWaitCarStartTime});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.waitQueueDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.waitQueueDataGridView.Location = new System.Drawing.Point(0, 40);
            this.waitQueueDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.waitQueueDataGridView.Name = "waitQueueDataGridView";
            this.waitQueueDataGridView.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.waitQueueDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.waitQueueDataGridView.RowHeadersWidth = 20;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.waitQueueDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.waitQueueDataGridView.RowTemplate.Height = 23;
            this.waitQueueDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.waitQueueDataGridView.Size = new System.Drawing.Size(300, 430);
            this.waitQueueDataGridView.TabIndex = 1;
            this.waitQueueDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.waitQueueDataGridView_CellClick);
            // 
            // bj2xnWaitCarModel
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bj2xnWaitCarModel.DefaultCellStyle = dataGridViewCellStyle3;
            this.bj2xnWaitCarModel.HeaderText = "车辆型号";
            this.bj2xnWaitCarModel.Name = "bj2xnWaitCarModel";
            this.bj2xnWaitCarModel.ReadOnly = true;
            this.bj2xnWaitCarModel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.bj2xnWaitCarModel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.bj2xnWaitCarModel.Width = 90;
            // 
            // bj2xnWaitCarNumber
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bj2xnWaitCarNumber.DefaultCellStyle = dataGridViewCellStyle4;
            this.bj2xnWaitCarNumber.HeaderText = "车辆编号";
            this.bj2xnWaitCarNumber.Name = "bj2xnWaitCarNumber";
            this.bj2xnWaitCarNumber.ReadOnly = true;
            this.bj2xnWaitCarNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.bj2xnWaitCarNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.bj2xnWaitCarNumber.Width = 90;
            // 
            // bj2xnWaitCarStartTime
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bj2xnWaitCarStartTime.DefaultCellStyle = dataGridViewCellStyle5;
            this.bj2xnWaitCarStartTime.HeaderText = "发车时间";
            this.bj2xnWaitCarStartTime.Name = "bj2xnWaitCarStartTime";
            this.bj2xnWaitCarStartTime.ReadOnly = true;
            this.bj2xnWaitCarStartTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.bj2xnWaitCarStartTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // waitHeaderTxt
            // 
            this.waitHeaderTxt.AutoSize = true;
            this.waitHeaderTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.waitHeaderTxt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.waitHeaderTxt.ForeColor = System.Drawing.Color.White;
            this.waitHeaderTxt.Location = new System.Drawing.Point(93, 10);
            this.waitHeaderTxt.Name = "waitHeaderTxt";
            this.waitHeaderTxt.Size = new System.Drawing.Size(93, 20);
            this.waitHeaderTxt.TabIndex = 2;
            this.waitHeaderTxt.Text = "等待队列标题";
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
            this.closeBtn.Size = new System.Drawing.Size(300, 30);
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
            // BiggerWaitQueueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(300, 500);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.waitHeaderTxt);
            this.Controls.Add(this.waitQueueDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BiggerWaitQueueForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "等待窗体";
            this.Load += new System.EventHandler(this.BiggerWaitQueueForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.waitQueueDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region 字段声明
        protected System.Windows.Forms.DataGridView waitQueueDataGridView;
        protected System.Windows.Forms.Label waitHeaderTxt;
        protected System.Windows.Forms.DataGridViewTextBoxColumn bj2xnWaitCarModel;
        protected System.Windows.Forms.DataGridViewTextBoxColumn bj2xnWaitCarNumber;
        protected System.Windows.Forms.DataGridViewTextBoxColumn bj2xnWaitCarStartTime;
        protected System.Windows.Forms.Button closeBtn;
        protected System.Windows.Forms.Timer updateGridViewTimer;

        #endregion
    }
}