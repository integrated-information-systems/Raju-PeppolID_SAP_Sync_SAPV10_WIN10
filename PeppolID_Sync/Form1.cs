using PeppolID_Sync.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeppolID_Sync
{
    public partial class Form1 : Form
    {
        DataSet ds = new DataSet();
        OCRD oCRD = new OCRD();
        int pageNum = 1;
        int pageSize = 0;
        DataTable dtPage;
        string strDataBaseName = "";
        string strCompanyDB = "";

        public Form1()
        {
            try
            {
               
                InitializeComponent();                       

                Common.ReadConfigParams();

                strCompanyDB = lblCompanyAndDB.Text;

                string[] strDBArray = ConfigParams.vSAPDB_DataBaseName.ToString().Split(',');
                foreach (string strAD in strDBArray)
                {
                    cmbDatabase.Items.Add(strAD);
                }
                this.cmbDatabase.SelectedIndex = 0;
                strDataBaseName = this.cmbDatabase.Text;
                            

                LoadFromDataBase();

            } catch (Exception ex)
            {
                WriteLog(ex.Message.ToString());
                lblError.Text = ex.Message.ToString();                               

            }
            
        }



        private void LoadFromDataBase()
        {
            try
            {
                pageNum = 1;
                lblError.Text = "";
                bttnSync.Enabled = false;
                txtCustomerCode.Text = "";
                ds = new DataSet();

                strDataBaseName = this.cmbDatabase.Text;
                Common.CompanyDBName = strDataBaseName;
                string strCompanyDBContent = strCompanyDB.Replace("<CompanySever>", ConfigParams.vCompany_Server).Replace("<DatabaseName>", strDataBaseName);
                lblCompanyAndDB.Text = strCompanyDBContent;                             
                pageSize = Convert.ToInt32(ConfigParams.vGrid_PageSize);

                string strPageSizeMsg = lblPageSizeMsg.Text;
                strPageSizeMsg = strPageSizeMsg.Replace("<PageSize>", ConfigParams.vGrid_PageSize);
                lblPageSizeMsg.Text = strPageSizeMsg;
                


                bool isRecrodsFound = false;
                ds = oCRD.GetAllUENForCustomers(strDataBaseName);
                if (ds != null)
                    if (ds.Tables[0] != null)
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            dtPage = ds.Tables[0].Rows.Cast<System.Data.DataRow>().Skip((pageNum - 1) * pageSize).Take(pageSize).CopyToDataTable();
                            if (dtPage.Rows.Count > 0)
                            {
                                CustomerGrid.DataSource = dtPage;
                                bttnSync.Enabled = true;
                                isRecrodsFound = true;
                            }

                        }

                if (!isRecrodsFound)
                {
                    WriteLog("No records found for PeoppolID updation required customers in Database.");
                    lblError.Text = "No records found for PeoppolID updation required customers in Database.";
                    bttnSync.Enabled = false;
                    CustomerGrid.DataSource = null;
                }
                else
                {
                    bttnSync.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message.ToString());
                lblError.Text = ex.Message.ToString();
                CustomerGrid.DataSource = null;
                bttnSync.Enabled = false;
                ds = null;
            }

        }

        private void bttnSync_Click(object sender, EventArgs e)
        {

            try
            {
                bttnGetNextCustomers.Enabled = false;
                PeppolDirectory obj = new PeppolDirectory();

                bool isPeppolIDFoundMinOne = false;
                DataRow[] drDataRows = dtPage.Select("isnull(U_custpeppolid,'') NOT LIKE 'Not Found%' AND isnull(U_peppol,'')<>'Y'");
                if (drDataRows.Length >0)
                {
                    foreach (DataRow data in dtPage.Rows)
                    {
                        Task<string> PeppolId = obj.GetPepoplDirectoryID(data["lictradnum"].ToString(), CustomerGrid);
                        string strPeppolId = PeppolId.Result.ToString();
                        if (!strPeppolId.Contains("Not Found"))
                            isPeppolIDFoundMinOne = true;
                        data["U_custpeppolid"] = strPeppolId;
                    }
                    dtPage.AcceptChanges();
                    if (isPeppolIDFoundMinOne)
                        oCRD.UpdateSAPCustomerWithPeppolID(ref dtPage, ref ds);

                    MessageBox.Show("Peppol ID SAP Sync has been completed for the Grid records", "PeoppolIDSAP",MessageBoxButtons.OK);

                }
                else
                {
                    WriteLog("Already Grid records have been processed");
                    lblError.Text = "Already Grid records have been processed";
                }
                

                bttnGetNextCustomers.Enabled = true;
                bttnSync.Enabled = false;
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message.ToString());
                lblError.Text = ex.Message.ToString();
                bttnGetNextCustomers.Enabled = true;
            }
                                                    

        }

        private void bttnbttnGetNextCustomers_Click(object sender, EventArgs e)
        {

            try
            {
                pageNum = pageNum + 1;
                lblError.Text = "";
                bool isRecrodsFound = false;
                //ds = oCRD.GetAllUENForCustomers();  
                txtCustomerCode.Text = "";
                if (ds != null)
                    if (ds.Tables[0] != null)
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                           if(ds.Tables[0].Rows.Cast<System.Data.DataRow>().Skip((pageNum - 1) * pageSize).Take(pageSize).Count() > 0)
                            {
                                dtPage = ds.Tables[0].Rows.Cast<System.Data.DataRow>().Skip((pageNum - 1) * pageSize).Take(pageSize).CopyToDataTable();
                                if (dtPage.Rows.Count > 0)
                                {
                                    CustomerGrid.DataSource = dtPage;
                                    isRecrodsFound = true;
                                }
                            }
                            
                          
                        }

                if (!isRecrodsFound)
                {
                    WriteLog("No records found for searchig customer code");
                    lblError.Text = "No records found for searchig customer code";
                    bttnSync.Enabled = false;

                    pageNum = 0;
                    CustomerGrid.DataSource = "";
                    
                }
                else
                {
                    
                    bttnSync.Enabled = true;
                }
                    

            }
            catch (Exception ex)
            {
                WriteLog(ex.Message.ToString());
                lblError.Text = ex.Message.ToString();

            }
            
        }

        private void bttnGOSearch_Click(object sender, EventArgs e)
        {
            try
            {
                pageNum = 1;
                lblError.Text = "";
                bool isRecrodsFound = false;

                string CustomerCode = txtCustomerCode.Text;
                CustomerCode = CustomerCode.ToUpper().Trim();
                if(CustomerCode!="")
                if (ds != null)
                    if (ds.Tables[0] != null)
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string expression = "CardCode ='" + CustomerCode + "'";                          

                            if (ds.Tables[0].Select(expression).Count() > 0)
                            {
                                dtPage = ds.Tables[0].Select(expression).CopyToDataTable();
                                if (dtPage.Rows.Count > 0)
                                {
                                    CustomerGrid.DataSource = dtPage;
                                    isRecrodsFound = true;
                                }
                            }


                        }

                if (!isRecrodsFound)
                {
                    WriteLog("No records found. Click again Get Next Customers button, It will provide First page records again");
                    lblError.Text = "No records found. Click again Get Next Customers button, It will provide First page records again";
                    bttnSync.Enabled = false;

                    pageNum = 0;
                    CustomerGrid.DataSource = null;
                    

                }
                else
                {

                    bttnSync.Enabled = true;
                }
                pageNum = 0;
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message.ToString());
                lblError.Text = ex.Message.ToString();
                pageNum = 0;

            }

        }

        private void bttnRefreshFromDB_Click(object sender, EventArgs e)
        {
            try
            {
                LoadFromDataBase();
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message.ToString());
                lblError.Text = ex.Message.ToString();
                pageNum = 0;

            }

        }

        private void cmbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                LoadFromDataBase();
            }
            catch (Exception ex)
            {
                
                WriteLog(ex.Message.ToString());
                lblError.Text = ex.Message.ToString();
                pageNum = 0;
                CustomerGrid.DataSource = null;

            }

        }

        private void WriteLog(string Message)
        {
            try
            {
                var programDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var logDirectory = programDirectory + @"\LOG";

                if (!Directory.Exists(logDirectory))
                {
                    DirectoryInfo di = Directory.CreateDirectory(logDirectory);
                }

                var dateFormat = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
                var dateTime = String.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);

                Message = dateTime + " :: " + Message + System.Environment.NewLine;

                var fileName = "log_" + dateFormat + ".txt";

                var path = Path.Combine(logDirectory, fileName);
                File.AppendAllText(path, Message);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();               

            }


        }




    }
}
