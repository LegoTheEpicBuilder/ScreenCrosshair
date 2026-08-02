namespace ScreenCrosshair
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.RefreshesPerSecondNumericBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ControlsLabel = new System.Windows.Forms.Label();
            this.SettingsLabel = new System.Windows.Forms.Label();
            this.CrosshairRepositioningLabel = new System.Windows.Forms.Label();
            this.MoveUpLabel = new System.Windows.Forms.Label();
            this.MoveDownLabel = new System.Windows.Forms.Label();
            this.MoveLeftLabel = new System.Windows.Forms.Label();
            this.MoveRightLabel = new System.Windows.Forms.Label();
            this.ResetPositioningLabel = new System.Windows.Forms.Label();
            this.MoveUpKeybindButton = new System.Windows.Forms.Button();
            this.MoveDownKeybindButton = new System.Windows.Forms.Button();
            this.MoveRightKeybindButton = new System.Windows.Forms.Button();
            this.MoveLeftKeybindButton = new System.Windows.Forms.Button();
            this.ResetPositioningKeybindButton = new System.Windows.Forms.Button();
            this.ResetKeybindsButton = new System.Windows.Forms.Button();
            this.SaveKeybindsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshesPerSecondNumericBox)).BeginInit();
            this.SuspendLayout();
            // 
            // RefreshesPerSecondNumericBox
            // 
            this.RefreshesPerSecondNumericBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshesPerSecondNumericBox.Location = new System.Drawing.Point(302, 61);
            this.RefreshesPerSecondNumericBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.RefreshesPerSecondNumericBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RefreshesPerSecondNumericBox.Name = "RefreshesPerSecondNumericBox";
            this.RefreshesPerSecondNumericBox.Size = new System.Drawing.Size(110, 31);
            this.RefreshesPerSecondNumericBox.TabIndex = 0;
            this.RefreshesPerSecondNumericBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.RefreshesPerSecondNumericBox.ValueChanged += new System.EventHandler(this.RefreshesPerSecondNumericBox_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Crosshair refresh rate per second";
            // 
            // ControlsLabel
            // 
            this.ControlsLabel.AutoSize = true;
            this.ControlsLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControlsLabel.Location = new System.Drawing.Point(432, 19);
            this.ControlsLabel.Name = "ControlsLabel";
            this.ControlsLabel.Size = new System.Drawing.Size(91, 28);
            this.ControlsLabel.TabIndex = 2;
            this.ControlsLabel.Text = "Controls";
            // 
            // SettingsLabel
            // 
            this.SettingsLabel.AutoSize = true;
            this.SettingsLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsLabel.Location = new System.Drawing.Point(12, 19);
            this.SettingsLabel.Name = "SettingsLabel";
            this.SettingsLabel.Size = new System.Drawing.Size(89, 28);
            this.SettingsLabel.TabIndex = 3;
            this.SettingsLabel.Text = "Settings";
            // 
            // CrosshairRepositioningLabel
            // 
            this.CrosshairRepositioningLabel.AutoSize = true;
            this.CrosshairRepositioningLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CrosshairRepositioningLabel.Location = new System.Drawing.Point(432, 61);
            this.CrosshairRepositioningLabel.Name = "CrosshairRepositioningLabel";
            this.CrosshairRepositioningLabel.Size = new System.Drawing.Size(130, 25);
            this.CrosshairRepositioningLabel.TabIndex = 4;
            this.CrosshairRepositioningLabel.Text = "Repositioning";
            // 
            // MoveUpLabel
            // 
            this.MoveUpLabel.AutoSize = true;
            this.MoveUpLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveUpLabel.Location = new System.Drawing.Point(432, 102);
            this.MoveUpLabel.Name = "MoveUpLabel";
            this.MoveUpLabel.Size = new System.Drawing.Size(83, 25);
            this.MoveUpLabel.TabIndex = 5;
            this.MoveUpLabel.Text = "Move up";
            // 
            // MoveDownLabel
            // 
            this.MoveDownLabel.AutoSize = true;
            this.MoveDownLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveDownLabel.Location = new System.Drawing.Point(432, 142);
            this.MoveDownLabel.Name = "MoveDownLabel";
            this.MoveDownLabel.Size = new System.Drawing.Size(107, 25);
            this.MoveDownLabel.TabIndex = 6;
            this.MoveDownLabel.Text = "Move down";
            // 
            // MoveLeftLabel
            // 
            this.MoveLeftLabel.AutoSize = true;
            this.MoveLeftLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveLeftLabel.Location = new System.Drawing.Point(696, 102);
            this.MoveLeftLabel.Name = "MoveLeftLabel";
            this.MoveLeftLabel.Size = new System.Drawing.Size(87, 25);
            this.MoveLeftLabel.TabIndex = 7;
            this.MoveLeftLabel.Text = "Move left";
            // 
            // MoveRightLabel
            // 
            this.MoveRightLabel.AutoSize = true;
            this.MoveRightLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveRightLabel.Location = new System.Drawing.Point(696, 142);
            this.MoveRightLabel.Name = "MoveRightLabel";
            this.MoveRightLabel.Size = new System.Drawing.Size(99, 25);
            this.MoveRightLabel.TabIndex = 8;
            this.MoveRightLabel.Text = "Move right";
            // 
            // ResetPositioningLabel
            // 
            this.ResetPositioningLabel.AutoSize = true;
            this.ResetPositioningLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetPositioningLabel.Location = new System.Drawing.Point(432, 182);
            this.ResetPositioningLabel.Name = "ResetPositioningLabel";
            this.ResetPositioningLabel.Size = new System.Drawing.Size(149, 25);
            this.ResetPositioningLabel.TabIndex = 9;
            this.ResetPositioningLabel.Text = "Reset positioning";
            // 
            // MoveUpKeybindButton
            // 
            this.MoveUpKeybindButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveUpKeybindButton.Location = new System.Drawing.Point(545, 96);
            this.MoveUpKeybindButton.Name = "MoveUpKeybindButton";
            this.MoveUpKeybindButton.Size = new System.Drawing.Size(142, 35);
            this.MoveUpKeybindButton.TabIndex = 10;
            this.MoveUpKeybindButton.Text = "Arrow up";
            this.MoveUpKeybindButton.UseVisualStyleBackColor = true;
            this.MoveUpKeybindButton.Click += new System.EventHandler(this.MoveUpKeybindButton_Click);
            // 
            // MoveDownKeybindButton
            // 
            this.MoveDownKeybindButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveDownKeybindButton.Location = new System.Drawing.Point(545, 137);
            this.MoveDownKeybindButton.Name = "MoveDownKeybindButton";
            this.MoveDownKeybindButton.Size = new System.Drawing.Size(142, 35);
            this.MoveDownKeybindButton.TabIndex = 11;
            this.MoveDownKeybindButton.Text = "Arrow down";
            this.MoveDownKeybindButton.UseVisualStyleBackColor = true;
            this.MoveDownKeybindButton.Click += new System.EventHandler(this.MoveDownKeybindButton_Click);
            // 
            // MoveRightKeybindButton
            // 
            this.MoveRightKeybindButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveRightKeybindButton.Location = new System.Drawing.Point(793, 137);
            this.MoveRightKeybindButton.Name = "MoveRightKeybindButton";
            this.MoveRightKeybindButton.Size = new System.Drawing.Size(142, 35);
            this.MoveRightKeybindButton.TabIndex = 13;
            this.MoveRightKeybindButton.Text = "Arrow right";
            this.MoveRightKeybindButton.UseVisualStyleBackColor = true;
            this.MoveRightKeybindButton.Click += new System.EventHandler(this.MoveRightKeybindButton_Click);
            // 
            // MoveLeftKeybindButton
            // 
            this.MoveLeftKeybindButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveLeftKeybindButton.Location = new System.Drawing.Point(793, 96);
            this.MoveLeftKeybindButton.Name = "MoveLeftKeybindButton";
            this.MoveLeftKeybindButton.Size = new System.Drawing.Size(142, 35);
            this.MoveLeftKeybindButton.TabIndex = 12;
            this.MoveLeftKeybindButton.Text = "Arrow left";
            this.MoveLeftKeybindButton.UseVisualStyleBackColor = true;
            this.MoveLeftKeybindButton.Click += new System.EventHandler(this.MoveLeftKeybindButton_Click);
            // 
            // ResetPositioningKeybindButton
            // 
            this.ResetPositioningKeybindButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetPositioningKeybindButton.Location = new System.Drawing.Point(579, 177);
            this.ResetPositioningKeybindButton.Name = "ResetPositioningKeybindButton";
            this.ResetPositioningKeybindButton.Size = new System.Drawing.Size(142, 35);
            this.ResetPositioningKeybindButton.TabIndex = 14;
            this.ResetPositioningKeybindButton.Text = "Arrow down";
            this.ResetPositioningKeybindButton.UseVisualStyleBackColor = true;
            this.ResetPositioningKeybindButton.Click += new System.EventHandler(this.ResetPositioningKeybindButton_Click);
            // 
            // ResetKeybindsButton
            // 
            this.ResetKeybindsButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetKeybindsButton.Location = new System.Drawing.Point(786, 246);
            this.ResetKeybindsButton.Name = "ResetKeybindsButton";
            this.ResetKeybindsButton.Size = new System.Drawing.Size(168, 41);
            this.ResetKeybindsButton.TabIndex = 15;
            this.ResetKeybindsButton.Text = "Reset keybinds";
            this.ResetKeybindsButton.UseVisualStyleBackColor = true;
            this.ResetKeybindsButton.Click += new System.EventHandler(this.ResetControlsButton_Click);
            // 
            // SaveKeybindsButton
            // 
            this.SaveKeybindsButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveKeybindsButton.Location = new System.Drawing.Point(621, 246);
            this.SaveKeybindsButton.Name = "SaveKeybindsButton";
            this.SaveKeybindsButton.Size = new System.Drawing.Size(159, 41);
            this.SaveKeybindsButton.TabIndex = 16;
            this.SaveKeybindsButton.Text = "Save keybinds";
            this.SaveKeybindsButton.UseVisualStyleBackColor = true;
            this.SaveKeybindsButton.Click += new System.EventHandler(this.SaveKeybindsButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 299);
            this.Controls.Add(this.SaveKeybindsButton);
            this.Controls.Add(this.ResetKeybindsButton);
            this.Controls.Add(this.ResetPositioningKeybindButton);
            this.Controls.Add(this.MoveRightKeybindButton);
            this.Controls.Add(this.MoveLeftKeybindButton);
            this.Controls.Add(this.MoveDownKeybindButton);
            this.Controls.Add(this.MoveUpKeybindButton);
            this.Controls.Add(this.ResetPositioningLabel);
            this.Controls.Add(this.MoveRightLabel);
            this.Controls.Add(this.MoveLeftLabel);
            this.Controls.Add(this.MoveDownLabel);
            this.Controls.Add(this.MoveUpLabel);
            this.Controls.Add(this.CrosshairRepositioningLabel);
            this.Controls.Add(this.SettingsLabel);
            this.Controls.Add(this.ControlsLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RefreshesPerSecondNumericBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RefreshesPerSecondNumericBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown RefreshesPerSecondNumericBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ControlsLabel;
        private System.Windows.Forms.Label SettingsLabel;
        private System.Windows.Forms.Label CrosshairRepositioningLabel;
        private System.Windows.Forms.Label MoveUpLabel;
        private System.Windows.Forms.Label MoveDownLabel;
        private System.Windows.Forms.Label MoveLeftLabel;
        private System.Windows.Forms.Label MoveRightLabel;
        private System.Windows.Forms.Label ResetPositioningLabel;
        private System.Windows.Forms.Button MoveUpKeybindButton;
        private System.Windows.Forms.Button MoveDownKeybindButton;
        private System.Windows.Forms.Button MoveRightKeybindButton;
        private System.Windows.Forms.Button MoveLeftKeybindButton;
        private System.Windows.Forms.Button ResetPositioningKeybindButton;
        private System.Windows.Forms.Button ResetKeybindsButton;
        private System.Windows.Forms.Button SaveKeybindsButton;
    }
}