using DarkCity.Configuration;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DarkCity.Tiles
{
    public partial class ConfigurationTile : UserControl
    {
        protected Localization localization = null;
        public Localization Localization
        {
            get { return this.localization; }
            set
            {
                if (this.localization != null)
                    this.localization.LanguageChanged -= Localization_LanguageChanged;
                this.localization = value;
                if (this.localization != null)
                    this.localization.LanguageChanged += Localization_LanguageChanged;
            }
        }

        private EmpyrionConfiguration configuration = null;
        public EmpyrionConfiguration Configuration
        {
            get { return this.configuration; }
            set
            {
                this.configuration = value;
                this.Update();
            }
        }

        public ConfigurationTile()
        {
            InitializeComponent();
            this.treeEmpyrionObjects.TreeViewNodeSorter = new NaturalTreeNodeSorter();
        }

        public ConfigurationTile(Localization localization) : this()
        {
            this.Localization = localization;
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

        private TreeNode CreateEmpyrionObjectTreeNode(EmpyrionObject obj)
        {
            int imageIndex = this.imagesConfigurationObjects.Images.IndexOfKey(obj.Type.ToString());
            TreeNode node = new TreeNode(GetObjectDisplayName(obj), imageIndex, imageIndex);
            node.Tag = obj;
            foreach (EmpyrionObject child in obj.Children)
                node.Nodes.Add(this.CreateEmpyrionObjectTreeNode(child));
            return node;
        }

        private TreeNode CreateRootTreeNode(string name, int imageIndex, IEnumerable<EmpyrionObject> objects)
        {
            TreeNode root = new TreeNode(name, imageIndex, imageIndex);
            foreach (EmpyrionObject obj in objects)
                root.Nodes.Add(this.CreateEmpyrionObjectTreeNode(obj));
            return root;
        }

        public void UpdateConfiguration()
        {
            this.treeEmpyrionObjects.BeginUpdate();
            try
            {
                this.treeEmpyrionObjects.Nodes.Clear();

                if (this.Configuration == null) return;

                this.treeEmpyrionObjects.Nodes.Add(this.CreateRootTreeNode("Blocks", this.imagesConfigurationObjects.Images.IndexOfKey("Block"), this.Configuration.BlocksByID.Values));
                this.treeEmpyrionObjects.Nodes.Add(this.CreateRootTreeNode("Entities", this.imagesConfigurationObjects.Images.IndexOfKey("Entity"), this.Configuration.EntitiesByName.Values));
                this.treeEmpyrionObjects.Nodes.Add(this.CreateRootTreeNode("Items", this.imagesConfigurationObjects.Images.IndexOfKey("Items"), this.Configuration.ItemsByID.Values));
                this.treeEmpyrionObjects.Nodes.Add(this.CreateRootTreeNode("Loot Groups", this.imagesConfigurationObjects.Images.IndexOfKey("LootGroup"), this.Configuration.LootGroupsByName.Values));
                this.treeEmpyrionObjects.Nodes.Add(this.CreateRootTreeNode("Templates", this.imagesConfigurationObjects.Images.IndexOfKey("Template"), this.Configuration.TemplatesByName.Values));
            }
            finally
            {
                this.treeEmpyrionObjects.Sort();
                this.treeEmpyrionObjects.EndUpdate();
            }
        }

        private void Localization_LanguageChanged(object sender, string e)
        {
            this.Update();
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
    }
}
