using DarkCity;
using DarkCity.Configuration;
using DseTesting.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DseTesting
{
    public partial class formDseTesting : Form
    {
        public EmpyrionConfiguration Configuration { get; private set; }

        public Localization Localization { get; private set; }

        public formDseTesting()
        {
            InitializeComponent();

            this.treeEmpyrionObjects.TreeViewNodeSorter = new NaturalTreeNodeSorter();

            try
            {
                this.Configuration = new EmpyrionConfiguration(Settings.Default.EmpyrionConfigurationFile);
            }
            catch { this.Configuration = null; }

            try
            {
                this.Localization = new Localization(Settings.Default.EmpyrionLocalizationFile);
                this.Localization.SelectLanguage(Settings.Default.LocalizationLanguage);
            } catch { this.Localization = null; }

            this.ReloadLocalizedUI();
        }

        public void UpdateConfigurationTab()
        {
            this.treeEmpyrionObjects.BeginUpdate();
            try
            {
                this.treeEmpyrionObjects.Nodes.Clear();

                if (this.Configuration == null) return;

                int imageIndex = this.imagesConfigurationObjects.Images.IndexOfKey("Block");
                TreeNode root = new TreeNode("Blocks", imageIndex, imageIndex);
                foreach (Block block in this.Configuration.BlocksByID.Values)
                    root.Nodes.Add(this.CreateEmpyrionObjectTreeNode(block));
                this.treeEmpyrionObjects.Nodes.Add(root);

                imageIndex = this.imagesConfigurationObjects.Images.IndexOfKey("Container");
                root = new TreeNode("Containers", imageIndex, imageIndex);
                foreach (EmpyrionObject container in this.Configuration.ContainersByID.Values)
                    root.Nodes.Add(this.CreateEmpyrionObjectTreeNode(container));
                this.treeEmpyrionObjects.Nodes.Add(root);

                imageIndex = this.imagesConfigurationObjects.Images.IndexOfKey("Entity");
                root = new TreeNode("Entities", imageIndex, imageIndex);
                foreach (EmpyrionObject entity in this.Configuration.EntitiesByName.Values)
                    root.Nodes.Add(this.CreateEmpyrionObjectTreeNode(entity));
                this.treeEmpyrionObjects.Nodes.Add(root);

                imageIndex = this.imagesConfigurationObjects.Images.IndexOfKey("Item");
                root = new TreeNode("Items", imageIndex, imageIndex);
                foreach (EmpyrionObject item in this.Configuration.ItemsByID.Values)
                    root.Nodes.Add(this.CreateEmpyrionObjectTreeNode(item));
                this.treeEmpyrionObjects.Nodes.Add(root);

                imageIndex = this.imagesConfigurationObjects.Images.IndexOfKey("LootGroup");
                root = new TreeNode("Loot Groups", imageIndex, imageIndex);
                foreach (EmpyrionObject group in this.Configuration.LootGroupsByName.Values)
                    root.Nodes.Add(this.CreateEmpyrionObjectTreeNode(group));
                this.treeEmpyrionObjects.Nodes.Add(root);

                imageIndex = this.imagesConfigurationObjects.Images.IndexOfKey("Template");
                root = new TreeNode("Templates", imageIndex, imageIndex);
                foreach (CraftingTemplate template in this.Configuration.TemplatesByName.Values)
                    root.Nodes.Add(this.CreateEmpyrionObjectTreeNode(template));
                this.treeEmpyrionObjects.Nodes.Add(root);
            }
            finally
            {
                this.treeEmpyrionObjects.Sort();
                this.treeEmpyrionObjects.EndUpdate();
            }
        }

        private TreeNode CreateEmpyrionObjectTreeNode(EmpyrionObject obj)
        {
            int imageIndex = this.imagesConfigurationObjects.Images.IndexOfKey(obj.Type.ToString());
            TreeNode node = new TreeNode(GetObjectDisplayName(obj), imageIndex, imageIndex);
            node.Tag = obj;
            foreach (EmpyrionObject child in obj.Children)
                node.Nodes.Add(this.CreateEmpyrionObjectTreeNode(child));
            return node;
        }

        public string GetObjectDisplayName(EmpyrionObject obj)
        {
            string localizedName = null;
            if (!string.IsNullOrWhiteSpace(obj.Name) && (this.Localization != null) && this.Localization.SelectedLanguage.ContainsKey(obj.Name))
                localizedName = this.Localization[obj.Name];

            if (!string.IsNullOrWhiteSpace(localizedName))
            {
                if (obj.ID != null)
                    return $"{localizedName} - {obj.Name} [{obj.ID}]";
                return $"{localizedName} - {obj.Name}";
            }
            else if (!string.IsNullOrWhiteSpace(obj.Name))
            {
                if (obj.ID != null)
                    return $"{obj.Name} [{obj.ID.ToString()}]";
                return obj.Name;
            }
            else if (obj.ID != null)
            {
                return obj.ID.ToString();
            }
            else if (obj.Properties.ContainsKey("radialtext"))
            {
                if (this.Localization == null)
                    return obj.Properties["radialtext"]?.Value;
                else
                    return this.Localization[obj.Properties["radialtext"].Value];
            }

            return null;
        }

        public void ReloadLocalizedUI()
        {
            this.UpdateConfigurationTab();

            // Update language menu items.
            if (this.Localization == null)
            {
                // Clear language menu.
                foreach (ToolStripMenuItem item in this.menuLanguage.DropDownItems)
                {
                    if (item == menuLanguageNotLoaded)
                        item.Visible = true;
                    else
                        this.menuLanguage.DropDownItems.Remove(item);
                }
            }
            else
            {
                // Create menu items for each language.
                this.menuLanguage.DropDownItems.Clear();
                this.menuLanguage.DropDownItems.Add(this.menuLanguageNotLoaded);
                this.menuLanguageNotLoaded.Visible = false;

                foreach (string language in this.Localization.Languages)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(language, null, new EventHandler(menuLanguageLocalized_Click));
                    item.Name = "menuLangugae" + language;
                    item.Tag = language;
                    item.Checked = (language == this.Localization.SelectedLanguageName);
                    this.menuLanguage.DropDownItems.Add(item);
                }
            }
        }

        private void menuFileOpenConfiguration_Click(object sender, EventArgs e)
        {
            this.openConfigurationFile.FileName = Settings.Default.EmpyrionConfigurationFile;
            DialogResult openResult = this.openConfigurationFile.ShowDialog();
            if (openResult == DialogResult.Cancel) return;

            if (!File.Exists(this.openConfigurationFile.FileName))
            {
                MessageBox.Show($"The file '{this.openConfigurationFile.FileName}' does not exist.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.Configuration != null)
            {
                DialogResult mergeOption = MessageBox.Show(
                    "A configuration has alread been loaded. Do you want to clear the previous configuration first? Not clearing will merge the new configuration into the existing one.",
                    "Existing Configuration", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (mergeOption == DialogResult.Cancel) return;
                if (mergeOption == DialogResult.Yes) this.Configuration = null;
            }

            if (this.Configuration == null)
                this.Configuration = new EmpyrionConfiguration();

            try
            {
                this.Configuration.Load(this.openConfigurationFile.FileName);
                Settings.Default.EmpyrionConfigurationFile = this.openConfigurationFile.FileName;
                Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to parse the configuration file '{this.openConfigurationFile.FileName}'. Existing configuration will be cleared." + Environment.NewLine +
                    $"Reason: {ex.Message}", "Configuration File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Configuration = null;
            }

            this.UpdateConfigurationTab();
        }

        private void treeEmpyrionObjects_AfterSelect(object sender, TreeViewEventArgs e)
        {
            object obj = e?.Node?.Tag;
            EmpyrionObject eObj = null;
            if (obj is EmpyrionObject)
                eObj = (EmpyrionObject)obj;

            this.txtRawObject.Text = obj?.ToString() ?? "";
            this.txtResolvedObject.Text = eObj?.ToString(true) ?? "";
            splitObjectViews.Panel2Collapsed = string.IsNullOrWhiteSpace(this.txtResolvedObject.Text) || ((eObj?.GetReference()) == null);
        }

        private void menuFileOpenLocalization_Click(object sender, EventArgs e)
        {
            this.openLocalizationFile.FileName = Settings.Default.EmpyrionLocalizationFile;
            DialogResult result = this.openLocalizationFile.ShowDialog();
            if (result == DialogResult.Cancel) return;

            if (!File.Exists(this.openLocalizationFile.FileName))
            {
                MessageBox.Show($"The file '{this.openConfigurationFile.FileName}' does not exist.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                this.Localization = new Localization(this.openLocalizationFile.FileName);
                this.Localization.SelectLanguage(Settings.Default.LocalizationLanguage);
                Settings.Default.EmpyrionLocalizationFile = this.openLocalizationFile.FileName;
                Settings.Default.Save();                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to parse the localization file '{this.openLocalizationFile.FileName}'." + Environment.NewLine +
    $"Reason: {ex.Message}", "Localization File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Localization = null;
            }

            this.ReloadLocalizedUI();
        }

        private void menuLanguageLocalized_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                string language = (string)((ToolStripMenuItem)(sender)).Tag;
                this.Localization.SelectLanguage(language);
                Settings.Default.LocalizationLanguage = language;
                Settings.Default.Save();
                this.ReloadLocalizedUI();
            }
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
