
namespace Save_Editor_1
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.save = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.box_money = new System.Windows.Forms.NumericUpDown();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMario = new System.Windows.Forms.TabPage();
            this.tabLuigi = new System.Windows.Forms.TabPage();
            this.tabInventory = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.box_money)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabInventory.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.save,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // save
            // 
            this.save.Enabled = false;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(103, 22);
            this.save.Text = "Save";
            this.save.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // box_money
            // 
            this.box_money.Location = new System.Drawing.Point(481, 78);
            this.box_money.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.box_money.Name = "box_money";
            this.box_money.ReadOnly = true;
            this.box_money.Size = new System.Drawing.Size(245, 20);
            this.box_money.TabIndex = 2;
            this.box_money.ValueChanged += new System.EventHandler(this.box_money_ValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMario);
            this.tabControl1.Controls.Add(this.tabLuigi);
            this.tabControl1.Controls.Add(this.tabInventory);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 263);
            this.tabControl1.TabIndex = 3;
            // 
            // tabMario
            // 
            this.tabMario.Location = new System.Drawing.Point(4, 22);
            this.tabMario.Name = "tabMario";
            this.tabMario.Padding = new System.Windows.Forms.Padding(3);
            this.tabMario.Size = new System.Drawing.Size(792, 237);
            this.tabMario.TabIndex = 0;
            this.tabMario.Text = "Mario";
            this.tabMario.UseVisualStyleBackColor = true;
            // 
            // tabLuigi
            // 
            this.tabLuigi.Location = new System.Drawing.Point(4, 22);
            this.tabLuigi.Name = "tabLuigi";
            this.tabLuigi.Padding = new System.Windows.Forms.Padding(3);
            this.tabLuigi.Size = new System.Drawing.Size(792, 237);
            this.tabLuigi.TabIndex = 1;
            this.tabLuigi.Text = "Luigi";
            this.tabLuigi.UseVisualStyleBackColor = true;
            // 
            // tabInventory
            // 
            this.tabInventory.Controls.Add(this.box_money);
            this.tabInventory.Location = new System.Drawing.Point(4, 22);
            this.tabInventory.Name = "tabInventory";
            this.tabInventory.Padding = new System.Windows.Forms.Padding(3);
            this.tabInventory.Size = new System.Drawing.Size(792, 237);
            this.tabInventory.TabIndex = 2;
            this.tabInventory.Text = "Inventory";
            this.tabInventory.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.box_money)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabInventory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem save;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown box_money;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMario;
        private System.Windows.Forms.TabPage tabLuigi;
        private System.Windows.Forms.TabPage tabInventory;
    }
}

