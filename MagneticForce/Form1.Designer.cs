namespace MagneticForce
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.randomPlacementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.particleNumLabel = new System.Windows.Forms.Label();
            this.Canvas = new System.Windows.Forms.Panel();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.minKill = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.soulAccel = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.soulSpeed = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maxKill = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.attractivePower = new System.Windows.Forms.NumericUpDown();
            this.allDispersalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.Canvas.SuspendLayout();
            this.controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minKill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soulAccel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soulSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxKill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attractivePower)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 33;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.randomPlacementToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.allDispersalToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1204, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // randomPlacementToolStripMenuItem
            // 
            this.randomPlacementToolStripMenuItem.Name = "randomPlacementToolStripMenuItem";
            this.randomPlacementToolStripMenuItem.Size = new System.Drawing.Size(73, 22);
            this.randomPlacementToolStripMenuItem.Text = "Dispersal";
            this.randomPlacementToolStripMenuItem.Click += new System.EventHandler(this.randomPlacementToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(47, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // particleNumLabel
            // 
            this.particleNumLabel.AutoSize = true;
            this.particleNumLabel.Location = new System.Drawing.Point(1038, 8);
            this.particleNumLabel.Name = "particleNumLabel";
            this.particleNumLabel.Size = new System.Drawing.Size(35, 12);
            this.particleNumLabel.TabIndex = 1;
            this.particleNumLabel.Text = "label1";
            // 
            // Canvas
            // 
            this.Canvas.Controls.Add(this.particleNumLabel);
            this.Canvas.Location = new System.Drawing.Point(2, 24);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(1079, 702);
            this.Canvas.TabIndex = 2;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            this.Canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseClick);
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.minKill);
            this.controlPanel.Controls.Add(this.label5);
            this.controlPanel.Controls.Add(this.soulAccel);
            this.controlPanel.Controls.Add(this.label4);
            this.controlPanel.Controls.Add(this.soulSpeed);
            this.controlPanel.Controls.Add(this.label3);
            this.controlPanel.Controls.Add(this.label2);
            this.controlPanel.Controls.Add(this.maxKill);
            this.controlPanel.Controls.Add(this.label1);
            this.controlPanel.Controls.Add(this.attractivePower);
            this.controlPanel.Location = new System.Drawing.Point(1088, 29);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(116, 697);
            this.controlPanel.TabIndex = 3;
            // 
            // minKill
            // 
            this.minKill.Location = new System.Drawing.Point(57, 77);
            this.minKill.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minKill.Name = "minKill";
            this.minKill.Size = new System.Drawing.Size(56, 19);
            this.minKill.TabIndex = 9;
            this.minKill.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minKill.ValueChanged += new System.EventHandler(this.minKill_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "最少キル";
            // 
            // soulAccel
            // 
            this.soulAccel.Location = new System.Drawing.Point(42, 234);
            this.soulAccel.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.soulAccel.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.soulAccel.Name = "soulAccel";
            this.soulAccel.Size = new System.Drawing.Size(71, 19);
            this.soulAccel.TabIndex = 7;
            this.soulAccel.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.soulAccel.ValueChanged += new System.EventHandler(this.soulAccel_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "魂加速度";
            // 
            // soulSpeed
            // 
            this.soulSpeed.Location = new System.Drawing.Point(42, 166);
            this.soulSpeed.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.soulSpeed.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.soulSpeed.Name = "soulSpeed";
            this.soulSpeed.Size = new System.Drawing.Size(71, 19);
            this.soulSpeed.TabIndex = 5;
            this.soulSpeed.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "魂速度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "最大キル";
            // 
            // maxKill
            // 
            this.maxKill.Location = new System.Drawing.Point(57, 115);
            this.maxKill.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxKill.Name = "maxKill";
            this.maxKill.Size = new System.Drawing.Size(56, 19);
            this.maxKill.TabIndex = 2;
            this.maxKill.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxKill.ValueChanged += new System.EventHandler(this.maxKill_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "引力";
            // 
            // attractivePower
            // 
            this.attractivePower.Location = new System.Drawing.Point(57, 17);
            this.attractivePower.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.attractivePower.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.attractivePower.Name = "attractivePower";
            this.attractivePower.Size = new System.Drawing.Size(56, 19);
            this.attractivePower.TabIndex = 0;
            this.attractivePower.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // allDispersalToolStripMenuItem
            // 
            this.allDispersalToolStripMenuItem.Name = "allDispersalToolStripMenuItem";
            this.allDispersalToolStripMenuItem.Size = new System.Drawing.Size(87, 22);
            this.allDispersalToolStripMenuItem.Text = "AllDispersal";
            this.allDispersalToolStripMenuItem.Click += new System.EventHandler(this.allDispersalToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 737);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Canvas.ResumeLayout(false);
            this.Canvas.PerformLayout();
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minKill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soulAccel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soulSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxKill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attractivePower)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem randomPlacementToolStripMenuItem;
        private System.Windows.Forms.Label particleNumLabel;
        private System.Windows.Forms.Panel Canvas;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown attractivePower;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown soulSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown maxKill;
        private System.Windows.Forms.NumericUpDown soulAccel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown minKill;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem allDispersalToolStripMenuItem;
    }
}

