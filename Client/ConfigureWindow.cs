using System;
using System.Net;
using System.Windows.Forms;
using WaveTech.CMWatcher.Common;
using WaveTech.CMWatcher.Model;
using WaveTech.CMWatcher.Model.Interfaces.Services;

namespace WaveTech.CMWatcher.Client
{
	public partial class ConfigureWindow : Form
	{
		public ConfigureWindow()
		{
			InitializeComponent();
		}

		private void ConfigureWindow_Load(object sender, EventArgs e)
		{
			cboProfiles.SelectedItem = "Custom";

			IConfigurationOptionsService cos = ServiceLocator.GetInstance<IConfigurationOptionsService>();
			ConfigurationOptions co = cos.GetConfiguration();

			if (co != null)
			{
				txtModemIPAddress.Text = co.ModemIPAddress;
				txtLogPageUrl.Text = co.ModemLogPageUrl;
				txtModemPassword.Text = co.ModemPassword;
				txtSignalPageUrl.Text = co.ModemSignalPageUrl;
				txtModemUsername.Text = co.ModemUsername;
				txtMonitorAddress.Text = co.MonitorAddress;

				if (co.Profile == "Custom")
				{
					cboProfiles.SelectedIndex = 0;
				}
				else if (co.Profile == "Motorola Surfboard")
				{
					cboProfiles.SelectedIndex = 1;
					txtModemIPAddress.Enabled = false;
					txtSignalPageUrl.Enabled = false;
					txtLogPageUrl.Enabled = false;
					txtModemUsername.Enabled = false;
					txtModemPassword.Enabled = false;
				}
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (ValidateForm())
			{
				IConfigurationOptionsService cos = ServiceLocator.GetInstance<IConfigurationOptionsService>();
				ConfigurationOptions co = cos.GetConfiguration();

				if (co == null)
					co = new ConfigurationOptions();

				co.ModemIPAddress = txtModemIPAddress.Text;
				co.ModemLogPageUrl = txtLogPageUrl.Text;
				co.ModemPassword = txtModemPassword.Text;
				co.ModemSignalPageUrl = txtSignalPageUrl.Text;
				co.ModemUsername = txtModemUsername.Text;
				co.MonitorAddress = txtMonitorAddress.Text;
				co.Profile = cboProfiles.SelectedItem.ToString();

				cos.SaveConfiguration(co);
				Close();
			}
		}

		private bool ValidateForm()
		{
			int errors = 0;

			if (String.IsNullOrEmpty(txtModemIPAddress.Text))
			{
				lblV1.Visible = true;
				errors++;
			}
			else
			{
				try
				{
					IPAddress.Parse(txtModemIPAddress.Text);
					lblV1.Visible = false;
				}
				catch
				{
					MessageBox.Show("Invalid IP address entered. Please just enter an ip (xxx.xxx.xxx.xxx)");
					lblV1.Visible = true;
					errors++;
				}
			}

			if (String.IsNullOrEmpty(txtSignalPageUrl.Text))
			{
				lblV2.Visible = true;
				errors++;
			}
			else
			{
				if (StringHelpers.IsValidUrl(txtSignalPageUrl.Text) == false || txtSignalPageUrl.Text.EndsWith("/"))
				{
					MessageBox.Show("Invalid URL entered.");
					lblV2.Visible = true;
					errors++;
				}

				lblV2.Visible = false;
			}

			if (String.IsNullOrEmpty(txtLogPageUrl.Text))
			{
				lblV3.Visible = true;
				errors++;
			}
			else
			{
				if (StringHelpers.IsValidUrl(txtLogPageUrl.Text) == false || txtLogPageUrl.Text.EndsWith("/"))
				{
					MessageBox.Show("Invalid URL entered.");
					lblV3.Visible = true;
					errors++;
				}

				lblV3.Visible = false;
			}

			if (String.IsNullOrEmpty(txtMonitorAddress.Text))
			{
				lblV4.Visible = true;
				errors++;
			}
			else
			{
				try
				{
					IPAddress.Parse(txtMonitorAddress.Text);
					lblV4.Visible = false;
				}
				catch
				{
					MessageBox.Show("Invalid IP address entered. Please just enter an ip (xxx.xxx.xxx.xxx)");
					lblV4.Visible = true;
					errors++;
				}
			}

			if (String.IsNullOrEmpty(txtModemUsername.Text) == false && String.IsNullOrEmpty(txtModemPassword.Text))
			{
				lblV6.Visible = true;
				errors++;
			}
			else
			{
				lblV6.Visible = false;
			}

			if (String.IsNullOrEmpty(txtModemPassword.Text) == false && String.IsNullOrEmpty(txtModemUsername.Text))
			{
				lblV5.Visible = true;
				errors++;
			}
			else
			{
				lblV5.Visible = false;
			}

			if (errors > 0)
			{
				MessageBox.Show("Please fix the errors and save again.", "Form Errors", MessageBoxButtons.OK,
												MessageBoxIcon.Asterisk);

				return false;
			}

			return true;
		}

		private void cboProfiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			if ((string)((ComboBox)sender).SelectedItem == "Custom")
			{
				txtModemIPAddress.Text = "";
				txtSignalPageUrl.Text = "";
				txtLogPageUrl.Text = "";
				txtModemUsername.Text = "";
				txtModemPassword.Text = "";

				txtModemIPAddress.Enabled = true;
				txtSignalPageUrl.Enabled = true;
				txtLogPageUrl.Enabled = true;
				txtModemUsername.Enabled = true;
				txtModemPassword.Enabled = true;
			}
			else if ((string)((ComboBox)sender).SelectedItem == "Motorola Surfboard")
			{
				txtModemIPAddress.Text = "192.168.100.1";
				txtSignalPageUrl.Text = "http://192.168.100.1/cmSignal.htm";
				txtLogPageUrl.Text = "http://192.168.100.1/cmLogs.htm";
				txtModemUsername.Text = "";
				txtModemPassword.Text = "";

				txtModemIPAddress.Enabled = false;
				txtSignalPageUrl.Enabled = false;
				txtLogPageUrl.Enabled = false;
				txtModemUsername.Enabled = false;
				txtModemPassword.Enabled = false;
			}
		}
	}
}