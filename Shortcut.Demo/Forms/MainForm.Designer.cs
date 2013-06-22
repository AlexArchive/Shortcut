namespace Shortcut.Demo.Forms
{
    partial class MainForm
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
            this.buttonRemoveHotkeyBinding = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonRemoveHotkeyBinding
            // 
            this.buttonRemoveHotkeyBinding.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveHotkeyBinding.Location = new System.Drawing.Point(12, 12);
            this.buttonRemoveHotkeyBinding.Name = "buttonRemoveHotkeyBinding";
            this.buttonRemoveHotkeyBinding.Size = new System.Drawing.Size(390, 46);
            this.buttonRemoveHotkeyBinding.TabIndex = 0;
            this.buttonRemoveHotkeyBinding.Text = "Remove Hotkey Binding";
            this.buttonRemoveHotkeyBinding.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 329);
            this.Controls.Add(this.buttonRemoveHotkeyBinding);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Shortcut Demo";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRemoveHotkeyBinding;
    }
}

