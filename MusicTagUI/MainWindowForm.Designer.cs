﻿namespace MusicTagUI
{
    partial class MainWindowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindowForm));
            this.loadFileButton = new System.Windows.Forms.Button();
            this.runMusictagButton = new System.Windows.Forms.Button();
            this.progressStatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loadFileButton
            // 
            this.loadFileButton.Location = new System.Drawing.Point(170, 170);
            this.loadFileButton.Name = "loadFileButton";
            this.loadFileButton.Size = new System.Drawing.Size(144, 45);
            this.loadFileButton.TabIndex = 1;
            this.loadFileButton.Text = "Load File";
            this.loadFileButton.UseVisualStyleBackColor = true;
            this.loadFileButton.Click += new System.EventHandler(this.loadFileButton_Click);
            // 
            // runMusictagButton
            // 
            this.runMusictagButton.Enabled = false;
            this.runMusictagButton.Location = new System.Drawing.Point(150, 270);
            this.runMusictagButton.Name = "runMusictagButton";
            this.runMusictagButton.Size = new System.Drawing.Size(184, 75);
            this.runMusictagButton.TabIndex = 2;
            this.runMusictagButton.Text = "Run MusicTag !";
            this.runMusictagButton.UseVisualStyleBackColor = true;
            this.runMusictagButton.Click += new System.EventHandler(this.runMusictagButton_Click);
            // 
            // progressStatusLabel
            // 
            this.progressStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.progressStatusLabel.Location = new System.Drawing.Point(-1, 227);
            this.progressStatusLabel.Name = "progressStatusLabel";
            this.progressStatusLabel.Size = new System.Drawing.Size(482, 30);
            this.progressStatusLabel.TabIndex = 3;
            this.progressStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.progressStatusLabel.UseMnemonic = false;
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(481, 471);
            this.Controls.Add(this.progressStatusLabel);
            this.Controls.Add(this.runMusictagButton);
            this.Controls.Add(this.loadFileButton);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "MainWindowForm";
            this.Text = "Music Tag";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadFileButton;
        private System.Windows.Forms.Button runMusictagButton;
        private System.Windows.Forms.Label progressStatusLabel;
    }
}

