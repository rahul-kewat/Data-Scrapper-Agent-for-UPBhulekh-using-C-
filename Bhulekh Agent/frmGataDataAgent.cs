using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using HtmlAgilityPack;
using System.Data.SqlClient;
using CefSharp;
using CefSharp.WinForms;

namespace Bhulekh_Agent
{
    public partial class frmGataDataAgent : Form
    {
        public frmGataDataAgent()
        {
            InitializeComponent();
            InitBrowser();
        }

        String url = ""; String DistrictCode = ""; String DistrictName = ""; String TehsilCode = ""; String TehsilName = ""; String VillageCode = ""; String VillageName = ""; String ParganaName = ""; String ParganaCode = "";
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
        //-----------------------------------------------------------------------------//
        //-----------------------------------------------------------------------------//
        //-----------------------------------------------------------------------------//
        // Starting chromium browser


        public ChromiumWebBrowser browser;
        public void InitBrowser()
        {
            try
            {
                Cef.Initialize(new CefSettings());
            }
            catch (Exception ae) { }
            
            browser = new ChromiumWebBrowser("https://social.msdn.microsoft.com/Forums/vstudio/en-US/ba6701b9-5b91-4749-ab4b-7a65cd29e0bb/help-picturebox-and-graphicsdrawimage?forum=vbgeneral");
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
            browser.LoadingStateChanged += browser_LoadingStateChanged;
           
        }

        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
             
            throw new NotImplementedException();
        }

        private async void browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (e.IsLoading == false)
            {
                string html = await Task.Run(browser.GetSourceAsync);
                if (InvokeRequired)
                {
                   
                    this.Invoke(new MethodInvoker(delegate
                    {
                        textBox1.Text = html;

                        Bitmap bitmap = new Bitmap(500, 500);
                        browser.DrawToBitmap(bitmap, new Rectangle(0, 0,500, 500));
                        pictureBox1.Image = bitmap;
                    }));
                }
                else
                {
                    textBox1.Text = html;
                }
                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                HtmlNode datascr3 = doc.DocumentNode.SelectSingleNode("//img");
                {
                    String xxxx = datascr3.Attributes["src"].Value;

                }

            }
        }


        //-----------------------------------------------------------------------------//
        //-----------------------------------------------------------------------------//
        //-----------------------------------------------------------------------------//

        DataTable table = new DataTable();
        void getalldatavillagewise()
        {
            string[] arr = new string[6];
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            int failure = 0;
            for (int i = 1; i <= 1000; i++)
            {

                int x = i.ToString().Length;
                String xx = "";
                for (int j = 0; j < 5 - x; j++)
                    xx = xx + "0";
                xx = xx + i.ToString();
                String dataloaded = "";
                url = url.Substring(0, url.IndexOf("=") + 1) + xx + url.Substring(url.IndexOf("&"));
                doc = web.Load(url);
                HtmlNodeCollection datascrcheck = doc.DocumentNode.SelectNodes("//tbody//tr[4]//td//b");
                String[] summaryinfo = new String[6];
                int loopvar = 0;
                String Fasli = ""; String Bhag = "";
                HtmlNode faslidata = doc.DocumentNode.SelectSingleNode("//thead//tr[2]//th[1]//div[5]");
                {
                    Fasli = faslidata.InnerText.ToString().Replace("फसली वर्ष :", "").Trim();
                }
                HtmlNode bhagdata = doc.DocumentNode.SelectSingleNode("//thead//tr[2]//th[1]//div[6]");
                {
                    Bhag = bhagdata.InnerText.ToString().Replace(" भाग :", "").Trim();
                }
                try
                {
                    foreach (HtmlNode summarynode in datascrcheck)
                    {
                        summaryinfo[loopvar] = summarynode.InnerHtml.ToString().Replace("&nbsp;", "").Trim();
                        loopvar++;
                    }

                }
                catch
                {
                    summaryinfo[1] = 0.ToString();
                    HtmlNodeCollection datascr1 = doc.DocumentNode.SelectNodes("//tbody//tr[3]//th//center//div");
                    foreach (HtmlNode node in datascr1)
                    {
                        table.Rows.Add(xx, node.InnerText.ToString().Trim().Replace("&nbsp;", ""), "", "", "", "", "", "", "", "", "", "");
                    }
                }
                if (summaryinfo[1] != "0")
                {
                    HtmlNodeCollection datascr = doc.DocumentNode.SelectNodes("//tbody//tr[3]//td");
                    int count = 0;
                    failure = 0;
                    foreach (HtmlNode node in datascr)
                    {
                        try { arr[count] = node.FirstChild.FirstChild.InnerHtml.ToString().Replace("&nbsp;", "").Trim(); }
                        catch
                        {
                            arr[count] = "";
                        } // if in the case there occurs an error due to null value
                        if (count == 1)
                        {
                            try
                            {
                                String code = node.InnerText.ToString().Trim();
                                int noofgata = code.Length / 17;
                                String GataNo = code.Substring(code.IndexOf('(') + 1, 17);
                            }
                            catch (Exception ae)
                            {

                            }

                        }
                        count++;
                    }
                    String category = "";
                    HtmlNode datascr3 = doc.DocumentNode.SelectSingleNode("//tbody//tr[2]/td");
                    {
                        category = datascr3.InnerText.ToString().Replace("&nbsp;", "").Trim();
                    }
                    table.Rows.Add(xx, category, arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], summaryinfo[1], summaryinfo[2], summaryinfo[3], Bhag, Fasli);
                    if (Convert.ToInt32(xx) % 20 == 0)
                    {
                        try
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {

                                dataFetchedView.DataSource = "";
                                dataFetchedView.DataSource = table;
                                lblDataFetched.Text = dataFetchedView.Rows.Count.ToString();
                                foreach (DataGridViewRow row in dataFetchedView.Rows)
                                {

                                    if (row.Cells[1].Value != null && row.Cells[2].Value.ToString().Trim() == "" && row.Cells[3].Value.ToString().Trim() == "" && row.Cells[4].Value.ToString().Trim() == "" && row.Cells[5].Value.ToString().Trim() == "" && row.Cells[6].Value.ToString().Trim() == "")
                                    {
                                        row.DefaultCellStyle.BackColor = Color.Brown;
                                        row.DefaultCellStyle.ForeColor = Color.White;
                                    }
                                }



                            }));
                        }
                        catch (Exception ae) { }
                    }

                }
                else
                {
                    failure++;
                    if (failure == 5)
                        break;

                }
            }
            try
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    dataFetchedView.DataSource = "";
                    dataFetchedView.DataSource = table;
                    lblDataFetched.Text = dataFetchedView.Rows.Count.ToString();
                    this.progressBar1.Visible = false;
                    this.progressBar1.MarqueeAnimationSpeed = 0;
                    this.progressBar1.Style = ProgressBarStyle.Marquee;
                    foreach (DataGridViewRow row in dataFetchedView.Rows)
                    {

                        if (row.Cells[1].Value != null && row.Cells[2].Value.ToString().Trim() == "" && row.Cells[3].Value.ToString().Trim() == "" && row.Cells[4].Value.ToString().Trim() == "" && row.Cells[5].Value.ToString().Trim() == "" && row.Cells[6].Value.ToString().Trim() == "")
                        {


                            row.DefaultCellStyle.BackColor = Color.Brown;
                            row.DefaultCellStyle.ForeColor = Color.White;

                        }
                    }

                }));
            }
            catch (Exception ae) { }

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
        public static int CountStringOccurrences(string text, string pattern)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }
        private void frmGataDataAgent_Load(object sender, EventArgs e)
        {
            gettingData();
            
            

            

            table.Columns.Add("Khata No", typeof(String));
            table.Columns.Add("Category", typeof(String));
            table.Columns.Add("Khatedar Detail", typeof(String));
            table.Columns.Add("Bhukhand/Gata No", typeof(String));
            table.Columns.Add("Bhukhand/Gata Wise Area(Hect.)", typeof(String));
            table.Columns.Add("Khatedar Ansh Area(Hect.)", typeof(String));
            table.Columns.Add("Aadesh", typeof(String));
            table.Columns.Add("Tippadi", typeof(String));
            table.Columns.Add("Total No of Gata Codes", typeof(String));
            table.Columns.Add("Total Bhukhand Area", typeof(String));
            table.Columns.Add("Total Khatedar Ansh Bhukhand Area", typeof(String));
            table.Columns.Add("FasliYear", typeof(String));
            table.Columns.Add("Bhag", typeof(String));
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                this.progressBar1.Visible = true;
                this.progressBar1.MarqueeAnimationSpeed = 10;
                this.progressBar1.Style = ProgressBarStyle.Marquee;

            }));
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DU76VKH\\SQLEXPRESS1;Initial Catalog=Rayedox_UPBhulekh_Agent;Integrated Security=True");
            conn.Open();
            foreach (DataGridViewRow drow in dataFetchedView.Rows)
            {
                if (!(drow.Cells[0].Value == null))
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        this.lblDataFetched.Text = drow.Index.ToString();
                    }));
                    String Khatano = drow.Cells[0].Value.ToString();
                    String KhatedarDetails = drow.Cells[2].Value.ToString().Replace("<br>", "");
                    int noofrecords = CountStringOccurrences(KhatedarDetails, "<br>");
                    List<string> KhatedarName = new List<string>();
                    List<string> KhatedarFatherName = new List<string>();
                    List<string> KhatedarNiwas = new List<string>();
                    List<string> KhatedarAadhar = new List<string>();
                    while (KhatedarDetails.Length > 0)
                    {
                        KhatedarName.Add(KhatedarDetails.Substring(0, KhatedarDetails.IndexOf("/")).Trim());
                        KhatedarDetails = KhatedarDetails.Substring(KhatedarDetails.IndexOf("/") + 1).Trim();
                        KhatedarFatherName.Add(KhatedarDetails.Substring(0, KhatedarDetails.IndexOf("/")).Trim());
                        KhatedarDetails = KhatedarDetails.Substring(KhatedarDetails.IndexOf("/") + 1).Trim();
                        KhatedarNiwas.Add(KhatedarDetails.Substring(0, KhatedarDetails.IndexOf("/")).Trim());
                        KhatedarDetails = KhatedarDetails.Substring(KhatedarDetails.IndexOf("/") + 1).Trim();
                        try { KhatedarAadhar.Add(KhatedarDetails.Substring(0, KhatedarDetails.IndexOf("-")).Trim()); } catch (Exception) { KhatedarAadhar.Add(KhatedarDetails.Substring(0).Trim()); KhatedarDetails = ""; }
                        KhatedarDetails = KhatedarDetails.Substring(KhatedarDetails.IndexOf("-") + 1).Trim();
                    }

                    String GataNoString = drow.Cells[3].Value.ToString().Replace("<br>", "");
                    List<string> GataNoArray = new List<string>();
                    List<string> BhukhandNoArray = new List<string>();
                    List<string> GataArea = new List<string>();
                    List<string> AnshGataArea = new List<string>();
                    while (GataNoString.Length > 1)
                    {
                        GataNoArray.Add(GataNoString.Trim().Substring(0, GataNoString.IndexOf('('))); // Adding Computed Bhukhand No 
                        GataNoString = GataNoString.Trim().Substring(GataNoString.IndexOf('(') + 1).Trim();
                        BhukhandNoArray.Add(GataNoString.Trim().Substring(0, GataNoString.IndexOf(')'))); // Adding Computed Gata No
                        GataNoString = GataNoString.Trim().Substring(GataNoString.IndexOf(')') + 1).Trim();
                    }

                    String BhukhandArea = drow.Cells[4].Value.ToString();
                    String AnshBhukhandArea = drow.Cells[5].Value.ToString();
                    List<string> BhukhandAreaArr = new List<string>();
                    List<string> AnshBhukhandAreaArr = new List<string>();
                    while (BhukhandArea.Length > 1 || AnshBhukhandArea.Length > 1)
                    {
                        try { BhukhandAreaArr.Add(BhukhandArea.Trim().Substring(0, BhukhandArea.IndexOf("<br>"))); } catch { }// Adding Computed Bhukhand No 
                        try { BhukhandArea = BhukhandArea.Trim().Substring(BhukhandArea.IndexOf("<br>") + 4).Trim(); } catch { }
                        try { AnshBhukhandAreaArr.Add(AnshBhukhandArea.Trim().Substring(0, AnshBhukhandArea.IndexOf("<br>"))); } catch { } // Adding Computed Gata No
                        try { AnshBhukhandArea = AnshBhukhandArea.Trim().Substring(AnshBhukhandArea.IndexOf("<br>") + 4).Trim(); } catch { }
                    }
                    int count = GataNoArray.Count;
                    if (count == 0) count = count + 1;
                    int firstcount = 0;
                    while (firstcount < count)
                    {
                        String temp = "";
                        try { temp = KhatedarName.ElementAt(firstcount); } catch (Exception) { KhatedarName.Add(""); }
                        try { temp = KhatedarFatherName.ElementAt(firstcount); } catch (Exception) { KhatedarFatherName.Add(""); }
                        try { temp = KhatedarNiwas.ElementAt(firstcount); } catch (Exception) { KhatedarNiwas.Add(""); }
                        try { temp = KhatedarAadhar.ElementAt(firstcount); } catch (Exception) { KhatedarAadhar.Add(""); }
                        try { temp = GataNoArray.ElementAt(firstcount); } catch (Exception) { GataNoArray.Add(""); }
                        try { temp = BhukhandNoArray.ElementAt(firstcount); } catch (Exception) { BhukhandNoArray.Add(""); }
                        try { temp = GataArea.ElementAt(firstcount); } catch (Exception) { GataArea.Add(""); }
                        try { temp = AnshGataArea.ElementAt(firstcount); } catch (Exception) { AnshGataArea.Add(""); }
                        try { temp = BhukhandAreaArr.ElementAt(firstcount); } catch (Exception) { BhukhandAreaArr.Add(""); }
                        try { temp = AnshBhukhandAreaArr.ElementAt(firstcount); } catch (Exception) { AnshBhukhandAreaArr.Add(""); }
                        firstcount++;
                    }
                    count = count - 1;
                    while (count >= 0)
                    {

                        SqlCommand cmd = new SqlCommand(@"insert into AnshAgentScrappedData(Gram_Name,Pargana_Name,Tehsil_Name,District_Name,Fasli_Year,Bhag,Khata_No,Khatedar_Owner,Khatedar_Name,Khatedar_Father_Name,Khatedar_Living_Place,Khatedar_Aadhar_No,Bhukhand_Code,Gata_No,BhukhandOrGata_Area,Khatedar_Ansh_Area,Aadesh,Tippadi,BhukhandOrGata_Total_Area,Khatedar_Ansh_Total_Area,Total_Gata_Code,Category) values(N'" + VillageName + "',N'" + ParganaName + "',N'" + TehsilName + "',N'" + DistrictName + "',N'" + drow.Cells[12].Value.ToString() + "',N'" + drow.Cells[11].Value.ToString() + "', N'" + Khatano + "', N'" + drow.Cells[2].Value.ToString().Replace("<br>", "").Trim() + "',  N'" + KhatedarName.ElementAt(count).ToString() + "', N'" + KhatedarFatherName.ElementAt(count).ToString() + "', N'" + KhatedarNiwas.ElementAt(count).ToString() + "', N'" + KhatedarAadhar.ElementAt(count).ToString() + "', N'" + BhukhandNoArray.ElementAt(count).ToString() + "', N'" + GataNoArray.ElementAt(count).ToString() + "', N'" + BhukhandAreaArr.ElementAt(count).ToString() + "', N'" + AnshBhukhandAreaArr.ElementAt(count).ToString() + "', N'" + drow.Cells[6].Value.ToString().Replace("<br>", "") + "', N'" + drow.Cells[7].Value.ToString().Replace("<br>", "") + "', N'" + drow.Cells[9].Value.ToString() + "', N'" + drow.Cells[10].Value.ToString() + "', N'" + drow.Cells[8].Value.ToString() + "', N'" + drow.Cells[1].Value.ToString() + "')", conn);
                        int k = cmd.ExecuteNonQuery();
                        if (k == 0)
                            MessageBox.Show("Somwething went wrong");
                        cmd.Dispose();
                        count--;
                    }

                }

            }
            conn.Close();
            this.Invoke(new MethodInvoker(delegate ()
            {
                this.progressBar1.Visible = false;
                this.progressBar1.MarqueeAnimationSpeed = 0;
                this.progressBar1.Style = ProgressBarStyle.Marquee;

            }));
            MessageBox.Show("Data Successfully Processed and Saved. Now you can generate your report");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.progressBar1.Visible = true;
            this.progressBar1.MarqueeAnimationSpeed = 30;
            this.progressBar1.Style = ProgressBarStyle.Marquee;
            Task.Run(() => getalldatavillagewise());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
