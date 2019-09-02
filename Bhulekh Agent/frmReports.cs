using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using HtmlAgilityPack;

namespace Bhulekh_Agent
{
    public partial class frmReports : Form
    {
        
        public frmReports()
        {
            
            InitializeComponent();
        }
        String url = ""; String DistrictCode = ""; String DistrictName = ""; String TehsilCode = ""; String TehsilName = ""; String VillageCode = ""; String VillageName = ""; String ParganaName = ""; String ParganaCode = "";
        private void frmReports_Load(object sender, EventArgs e)
        {
            gettingData();
        }

        private void  villageWiseAnshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmbSelectDistrict.Text == "" || cmbSelectTehsil.Text == "" || cmbSelectGram.Text == "")
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DU76VKH\\SQLEXPRESS1;Initial Catalog=Rayedox_UPBhulekh_Agent;Integrated Security=True");
                SqlCommand cmd;
                if (cmbCategory.Text.Trim() == "")
                    cmd = new SqlCommand("select * from AnshAgentScrappedData where District_Name=" + cmbSelectDistrict.Text + " and Tehsil_Name=" + cmbSelectTehsil.Text + " and Gram_Name=" + cmbSelectGram + "", conn);
                else
                    cmd = new SqlCommand("select * from AnshAgentScrappedData where District_Name=" + cmbSelectDistrict.Text + " and Tehsil_Name=" + cmbSelectTehsil.Text + " and Gram_Name=" + cmbSelectGram + "and Category=" + cmbCategory.Text + "", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet1 ds = new DataSet1();
                da.Fill(ds.dsAnshAgentScrappedData);
                cmd.Dispose();
                da.Dispose();

                fetchedDataReport rpt = new fetchedDataReport();
                rpt.SetDataSource(ds);
                this.Invoke(new MethodInvoker(delegate ()
                {
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.RefreshReport();
                }));
            }
            else
                MessageBox.Show("Please select District Name, Tehsil Name and Gram Name");
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void gettingData()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc = web.Load("http://upbhulekh.gov.in/public/public_ror/action/public_action.jsp?act=fillDistrict");
            String json = doc.ParsedText.ToString();
            json = json.Replace("{", "").Replace("}", "").Replace("[", "").Replace("]", "").Replace("\"", "").Replace("district_name_english", "").Replace("district_name", "").Replace("district_code_census", "").Replace(":", "");

            var fooArray = json.Split(','); // now we have an array
            for (int i = 0; i < fooArray.Length;)
            {
                cmbSelectDistrict.Items.Add("(" + fooArray[i + 1].Trim() + ")  " + fooArray[i].Trim() + " - " + fooArray[i + 2].Trim());
                i = i + 3;
            }
        }
        public void gettingData1(String districtcode)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc = web.Load("http://upbhulekh.gov.in/public/public_ror/action/public_action.jsp?act=fillTehsil&district_code=" + districtcode + "");
            String json = doc.ParsedText.ToString();
            json = json.Replace("{", "").Replace("}", "").Replace("[", "").Replace("]", "").Replace("\"", "").Replace("tehsil_name_english", "").Replace("tehsil_name", "").Replace("tehsil_code_census", "").Replace(":", "");

            var fooArray = json.Split(','); // now we have an array
            for (int i = 0; i < fooArray.Length;)
            {
                cmbSelectTehsil.Items.Add("(" + fooArray[i + 1].Trim() + ")  " + fooArray[i].Trim() + " - " + fooArray[i + 2].Trim());
                i = i + 3;
            }
        }

        public void gettingData2(String districtcode, String tehsilcode)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc = web.Load("http://upbhulekh.gov.in/public/public_ror/action/public_action.jsp?act=fillVillage&district_code=" + districtcode + "&tehsil_code=" + tehsilcode + "");
            String json = doc.ParsedText.ToString();
            json = json.Replace("{", "").Replace("}", "").Replace("[", "").Replace("]", "").Replace("\"", "").Replace("vname_eng", "").Replace("village_code_census", "").Replace("vname", "").Replace("pname", "").Replace("flg_chakbandi", "").Replace("flg_survey", "").Replace("pargana_code_new", "").Replace(",", "").Substring(1);
            hiddenDetails.Items.Clear();
            var fooArray = json.Split(':'); // now we have an array
            for (int i = 0; i < fooArray.Length;)
            {
                cmbSelectGram.Items.Add("(" + fooArray[i + 1].Trim() + ")  " + fooArray[i].Trim() + " - " + fooArray[i + 2].Trim());
                hiddenDetails.Items.Add(fooArray[i + 1] + "," + fooArray[i] + "," + fooArray[i + 2] + "," + fooArray[i + 3] + "," + fooArray[i + 4] + "," + fooArray[i + 5] + "," + fooArray[i + 6]);
                i = i + 7;
            }
        }

        private void cmbSelectDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            int startindex = cmbSelectDistrict.Text.IndexOf("(") + 1;
            int endindex = cmbSelectDistrict.Text.IndexOf(")") - 1; //means length of the string
            cmbSelectTehsil.Items.Clear();
            DistrictCode = cmbSelectDistrict.Text.Substring(startindex, endindex); // District Code
            DistrictName = cmbSelectDistrict.Text.Substring(cmbSelectDistrict.Text.IndexOf(")") + 1, cmbSelectDistrict.Text.IndexOf("-") - cmbSelectDistrict.Text.IndexOf(")") - 1).Trim();
            gettingData1(DistrictCode);
        }

        private void cmbSelectTehsil_SelectedIndexChanged(object sender, EventArgs e)
        {

            int startindex1 = cmbSelectDistrict.Text.IndexOf("(") + 1;
            int endindex1 = cmbSelectDistrict.Text.IndexOf(")") - 1; //means length of the string
            cmbSelectGram.Items.Clear();
            int startindex = cmbSelectTehsil.Text.IndexOf("(") + 1;
            int endindex = cmbSelectTehsil.Text.IndexOf(")") - 1; //means length of the string
            TehsilCode = cmbSelectTehsil.Text.Substring(startindex, endindex); // District Code
            TehsilName = cmbSelectTehsil.Text.Substring(cmbSelectTehsil.Text.IndexOf(")") + 1, cmbSelectTehsil.Text.IndexOf("-") - cmbSelectTehsil.Text.IndexOf(")") - 1).Trim();
            gettingData2(cmbSelectDistrict.Text.Substring(startindex1, endindex1), cmbSelectTehsil.Text.Substring(startindex, endindex));
        }

        private void cmbSelectGram_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = hiddenDetails.Items.IndexOf(cmbSelectGram.SelectedIndex);
            hiddenDetails.SetSelected(cmbSelectGram.SelectedIndex, true);
            var villagedata = hiddenDetails.SelectedItem.ToString().Split(',');
            VillageCode = villagedata[0].ToString();
            VillageName = villagedata[1].ToString();
            ParganaName = villagedata[3].ToString();
            ParganaCode = villagedata[6].ToString();
            url = "http://upbhulekh.gov.in/public/public_ror/public_ror_report_ansh.jsp?khata_number=00000&district_name=" + DistrictName + "&district_code=" + DistrictCode + "&tehsil_name=" + TehsilName + "&tehsil_code=" + TehsilCode + "&village_name=" + VillageName + "&village_code=" + VillageCode + "&pargana_name=+(" + ParganaName + ")&pargana_code=" + ParganaCode + "&fasli_code=999&fasli_name=वर्तमान+फसली";
        }

        private void villageWiseAnshWithoutAadeshAndTippadiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmbSelectDistrict.Text != "" && cmbSelectTehsil.Text != "" && cmbSelectGram.Text != "")
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DU76VKH\\SQLEXPRESS1;Initial Catalog=Rayedox_UPBhulekh_Agent;Integrated Security=True");
                SqlCommand cmd;
                if (cmbCategory.Text.Trim() == "")
                    cmd = new SqlCommand("select * from AnshAgentScrappedData where District_Name=N'" + DistrictName+ "' and Tehsil_Name=N'" + TehsilName+ "' and Gram_Name=N'" + VillageName + "'", conn);
                else
                    cmd = new SqlCommand("select * from AnshAgentScrappedData where District_Name=N'" + DistrictName + "' and Tehsil_Name=N'" + TehsilName+ "' and Gram_Name=N'" + VillageName + "' and Category=N'" + cmbCategory.Text + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet1 ds = new DataSet1();
                da.Fill(ds.dsAnshAgentScrappedData);
                cmd.Dispose();
                da.Dispose();

                rptCustomVillageWiseAnshDetailsWithoutAadeshAndTippadi rpt = new rptCustomVillageWiseAnshDetailsWithoutAadeshAndTippadi();
                rpt.SetDataSource(ds);
                this.Invoke(new MethodInvoker(delegate ()
                {
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.RefreshReport();
                }));
            }
            else
                MessageBox.Show("Please select District Name, Tehsil Name and Gram Name");

        }
    }
}
