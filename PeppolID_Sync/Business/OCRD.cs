using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeppolID_Sync.Business
{
    public class OCRD
    {
        SAPbobsCOM.Company oCompany = new SAPbobsCOM.Company();

        public DataSet GetAllUENForCustomers(string strDataBaseName)
        {
            DataSet ds = new DataSet();
            try
            {

                string strSAP_DB_ConnectionString = ConfigParams.vSAP_DB_ConnectionString;
                strSAP_DB_ConnectionString = strSAP_DB_ConnectionString.Replace("$SAPDB_DataBaseName$", strDataBaseName);

                string strDataBaseQuery = @"
                                                Select ROW_NUMBER() OVER (ORDER BY CardCode) AS [SeqNum],CardCode,CardName,lictradnum,U_custpeppolid,U_peppol 
                                                From OCRD 
                                                where isnull(lictradnum,'')<> ''
                                                and isnull(U_custpeppolid,'')= '' 
                                            ";


                using (var sqlCon = new SqlConnection())
                {
                    using (var sqlCom = new SqlCommand())
                    {
                        sqlCon.ConnectionString = strSAP_DB_ConnectionString;
                        sqlCom.Connection = sqlCon;
                        sqlCom.CommandText = strDataBaseQuery;
                        sqlCom.CommandType = CommandType.Text;
                        using (var sqlData = new SqlDataAdapter())
                        {
                            sqlData.SelectCommand = sqlCom;
                            sqlData.Fill(ds);

                        }
                                      

                        sqlCon.Close();
                    }
                }                                            

            }
            catch (Exception ex)
            {
                
                throw new Exception("GetAllUENForCustomers :: " + ex.Message.ToString());
                
            }                                                             
            
            return ds;
        }

        private void ConnectToSAP()
        {

            try
            {
                oCompany.Server = ConfigParams.vCompany_Server;
                oCompany.UserName = ConfigParams.vCompany_Username;
                oCompany.Password = ConfigParams.vCompany_Password;
                oCompany.CompanyDB = Common.CompanyDBName;
                oCompany.DbUserName = ConfigParams.vSAPDB_Username;
                oCompany.DbPassword = ConfigParams.vSAPDB_Password;
                oCompany.language = SAPbobsCOM.BoSuppLangs.ln_English;
                

                string MSSQLVersion = ConfigParams.vMSSQLVersion;
               // oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;               

                switch (MSSQLVersion)
                {
                    case "SAPbobsCOM.BoDataServerTypes.dst_MSSQL2005":
                        oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2005;
                        break;
                    case "SAPbobsCOM.BoDataServerTypes.dst_MSSQL2008":
                        oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2008;
                        break;
                    case "SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012":
                        oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
                        break;
                    case "SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014":
                        oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014;
                        break;
                    case "SAPbobsCOM.BoDataServerTypes.dst_MSSQL2016":
                        oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2016;
                        break;
                    case "SAPbobsCOM.BoDataServerTypes.dst_MSSQL2017":
                        oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2017;
                        break;
                    //case "SAPbobsCOM.BoDataServerTypes.dst_MSSQL2019":
                    //  SAPCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2019;
                    // break;

                    default:
                        oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2017;
                        break;
                }




                // // Connecting to a company DB
                int SAPConnectionStatus;
                string sErrMsg = string.Empty;
                int sErr = 0;
                if (oCompany.Connected == false)
                {
                    SAPConnectionStatus = oCompany.Connect();
                    if (SAPConnectionStatus != 0)
                    {
                        sErrMsg = oCompany.GetLastErrorDescription();
                        oCompany.GetLastError(out sErr, out sErrMsg);                        
                        string strErrorMessage = sErr + ":" + sErrMsg;
                        throw new Exception(strErrorMessage);
                    }

                }               

            }
            catch (Exception ex)
            {
                throw new Exception("ConnectToSAP :: " + ex.Message.ToString());
            }
                                           

        }

        public void UpdateSAPCustomerWithPeppolID(ref DataTable dtPage, ref DataSet ds)
        {

            try
            {

                ConnectToSAP();
                SAPbobsCOM.BusinessPartners tblOCRD;
                tblOCRD = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBusinessPartners);

                DataRow[] drDataRows = dtPage.Select("U_custpeppolid NOT LIKE 'Not Found%' AND isnull(U_peppol,'')<>'Y'");
                foreach (DataRow data in drDataRows)
                {
                    string strCardCode = data["CardCode"].ToString();
                    string strPeppolID = data["U_custpeppolid"].ToString();
                    tblOCRD.GetByKey(strCardCode);
                    tblOCRD.UserFields.Fields.Item("U_custpeppolid").Value = strPeppolID;
                    tblOCRD.UserFields.Fields.Item("U_peppol").Value = "Y";
                    tblOCRD.Update();
                    data["U_peppol"] = "Y";
                    dtPage.AcceptChanges();

                    string expression = "CardCode ='" + strCardCode + "'";
                    DataRow[] drDataRowsDS = ds.Tables[0].Select(expression);
                    foreach (DataRow dataDS in drDataRowsDS)
                    {
                        dataDS["U_custpeppolid"] = strPeppolID;
                        dataDS["U_peppol"] = "Y";
                    }
                    ds.AcceptChanges();
                }
                //CustomerGrid.DataSource = dtPage;
                               
                oCompany.Disconnect();

            }
            catch (Exception ex)
            {
               
                throw new Exception("UpdateSAPCustomerWithPeppolID :: " + ex.Message.ToString());
            }
            finally
            {
                if (oCompany.Connected == true)                
                    oCompany.Disconnect();
                

            }
        }



        

    }
   
}
