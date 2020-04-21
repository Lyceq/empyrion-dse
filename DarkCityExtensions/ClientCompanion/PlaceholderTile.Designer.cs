namespace ClientCompanion
{
    partial class PlaceholderTile
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PlaceholderTile
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DoubleBuffered = true;
            this.Name = "PlaceholderTile";
            this.Size = new System.Drawing.Size(381, 271);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.PlaceholderTile_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.PlaceholderTile_DragEnter);
            this.DragLeave += new System.EventHandler(this.PlaceholderTile_DragLeave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
