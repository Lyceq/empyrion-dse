using System;
using System.Net;
using System.Windows.Forms;

namespace ClientCompanion
{
    public partial class OpenRemoteHost : Form
    {
        public IPAddress Address { get; private set; } = null;

        public int Port { get => (int)this.nudPort.Value; set => this.nudPort.Value = value; }

        public OpenRemoteHost()
        {
            InitializeComponent();
            lblStatus.Visible = false;
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress[] addresses = Dns.GetHostAddresses(this.txtHost.Text);
                if ((addresses?.Length ?? 0) < 1) throw new Exception("Cannot find an IP address for host.");
                lblStatus.Text = "Connection will be made to " + addresses[0].ToString();
                this.Address = addresses[0];
            } catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }

            lblStatus.Visible = true;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            this.btnValidate_Click(this.btnValidate, EventArgs.Empty);
            if (this.Address != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
