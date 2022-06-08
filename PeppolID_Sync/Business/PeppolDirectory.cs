using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;
using Newtonsoft.Json;
using PeppolID_Sync.Business;

namespace PeppolID_Sync.Business
{
   public class PeppolDirectory
    {
        // public string PeppolapiURI = ConfigurationSettings.AppSettings["PeppolDirectorySGAPI"].ToString();
        
        public async Task<string> GetPepoplDirectoryID(string strUEN, System.Windows.Forms.DataGridView CustomerGrid)
        {
            string strPeppolId = string.Empty;
            try
            {
                HttpClient client = new HttpClient();
                string url = ConfigParams.vPeppolDirectorySGAPI.Replace("{1}", strUEN);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    PeppolJSONConverter PeppolJSON = JsonConvert.DeserializeObject<PeppolJSONConverter>(content);
                    if (PeppolJSON.count > 0)
                        strPeppolId = PeppolJSON.participants[0].participantIdentifier.participantIdentifierTypeCode + ":" + PeppolJSON.participants[0].participantIdentifier.participantIdentifierValue;
                    else strPeppolId = "Not Found in Peppol Directory";
                }
                else
                {

                    string strErrorMessage = response.IsSuccessStatusCode + ":" + response.RequestMessage;
                    throw new Exception(strErrorMessage);
                }
                CustomerGrid.Refresh();
            } catch (Exception ex)
            {
               
                throw new Exception("GetPepoplDirectoryID :: " + ex.Message.ToString());
            }
            return strPeppolId;
        }

    }
}
