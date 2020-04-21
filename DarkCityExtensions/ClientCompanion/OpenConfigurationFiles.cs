using ClientCompanion.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Forms;

namespace ClientCompanion
{
    public partial class OpenConfigurationFiles : Form
    {
        public string ExampleFile { get; private set; }
        public string[] CustomFiles { get; private set; }

        public OpenConfigurationFiles()
        {
            InitializeComponent();

            this.txtExampleFile.Text = Settings.Default.MostRecentExampleFile;
            foreach (string item in Settings.Default.MostRecentCustomFiles)
                this.clbCustomFiles.Items.Add(item);

            int index = 0;
            bool select;
            foreach (string selected in Settings.Default.MostRecentCustomFilesSelected)
            {
                if (index >= this.clbCustomFiles.Items.Count) break;
                if (bool.TryParse(selected, out select))
                    this.clbCustomFiles.SetItemChecked(index, select);
            }
        }

        private void btnOpenExampleFile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtExampleFile.Text))
                this.openExampleFile.FileName = this.txtExampleFile.Text;

            DialogResult result = this.openExampleFile.ShowDialog(this);
            if (result == DialogResult.Cancel) return;

            this.txtExampleFile.Text = this.openExampleFile.FileName;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openCustomFile.ShowDialog(this);
            if (result == DialogResult.Cancel) return;

            string[] files = this.openCustomFile.FileNames;
            foreach (string file in files)
                if (!this.clbCustomFiles.Items.Contains(file))
                    this.clbCustomFiles.Items.Add(file);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (object item in this.clbCustomFiles.SelectedItems)
                this.clbCustomFiles.Items.Remove(item);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int index;
            object top = null;
            foreach (object item in this.clbCustomFiles.SelectedItems)
            {
                index = this.clbCustomFiles.Items.IndexOf(item);
                if (index == 0)
                {
                    top = item;
                }
                {
                    this.clbCustomFiles.Items.RemoveAt(index);
                    this.clbCustomFiles.Items.Insert(index - 1, item);
                }
            }

            if (top != null)
            {
                this.clbCustomFiles.Items.Remove(top);
                this.clbCustomFiles.Items.Insert(0, top);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            // List of files to load.
            List<string> selectedCustomFiles = new List<string>(this.clbCustomFiles.Items.Count);

            // List of files added to list. Save the list to re-use next time.
            StringCollection customFiles = new StringCollection();

            // List of files checked. Save the list to re-use next time.
            StringCollection selectedFiles = new StringCollection();

            for (int i = 0; i < this.clbCustomFiles.Items.Count; i++)
            {
                if (this.clbCustomFiles.GetItemChecked(i))
                    selectedCustomFiles.Add(this.clbCustomFiles.Items[i] as string);
                customFiles.Add(this.clbCustomFiles.Items[i] as string);
                selectedFiles.Add(this.clbCustomFiles.GetItemChecked(i).ToString());
            }

            Settings.Default.MostRecentExampleFile = this.txtExampleFile.Text;
            Settings.Default.MostRecentCustomFiles = customFiles;
            Settings.Default.MostRecentCustomFilesSelected = selectedFiles;
            Settings.Default.Save();

            this.ExampleFile = this.txtExampleFile.Text;
            this.CustomFiles = selectedCustomFiles.ToArray();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
