using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NepseWatcher
{
    public partial class SectorsForm : Form
    {
        public delegate void AllowedSectorsChangedHandler(object src, AllowedSectorsChangedEventArgs args);
        public event AllowedSectorsChangedHandler AllowedSectorsChanged;
        public SectorsForm()
        {
            InitializeComponent();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (AllowedSectorsChanged != null) //if there's at least one subscriber to this event
            {
                List<string> allowedSectors = MakeListOfAllowedSectors();
                AllowedSectorsChangedEventArgs args = new AllowedSectorsChangedEventArgs(allowedSectors);
                AllowedSectorsChanged(this, args);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            buttonApply_Click(sender, e);
            Hide();
        }

        /// <summary>
        /// Makes a list of sectors according to the checkboxes. It will appear as is in the combobox of the main form.
        /// </summary>
        /// <returns></returns>
        private List<string> MakeListOfAllowedSectors()
        {
            List<string> items = new List<string>();
            items.Add("All"); //first item in the combobox is gonna be "All" regardless of the selected sectors

            if (checkBoxHydropower.Checked)
                items.Add("Hydro Power");
            if (checkBoxCommercialBanks.Checked)
                items.Add("Commercial Banks");
            if (checkBoxFinance.Checked)
                items.Add("Finance");
            if (checkBoxTradings.Checked)
                items.Add("Tradings");
            if (checkBoxMicroFinance.Checked)
                items.Add("Microfinance");
            if (checkBoxDevelopmentBanks.Checked)
                items.Add("Development Banks");
            if (checkBoxLifeInsurance.Checked)
                items.Add("Insurance");
            if (checkBoxNonLifeInsurance.Checked)
                items.Add("Non Life Insurance");
            if (checkBoxManufacturingAndProcessing.Checked)
                items.Add("Manufacturing and Processing");
            if (checkBoxHotels.Checked)
                items.Add("Hotels");
            if (checkBoxMutualFunds.Checked)
                items.Add("Mutual Fund");
            if (checkBoxCorporateDebenture.Checked)
                items.Add("Corporate Debenture");
            if (checkBoxPromoterShare.Checked)
                items.Add("Promotor Share");
            if (checkBoxOthers.Checked)
                items.Add("Others");

            return items;
        }

        private void SectorsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide(); //don't die. just hide the form.
        }


    }

    public class AllowedSectorsChangedEventArgs : EventArgs
    {
        public List<string> AllowedSectors { get; set; }
        public AllowedSectorsChangedEventArgs(List<string> allowedSectors) { AllowedSectors = allowedSectors; }
    }
}
