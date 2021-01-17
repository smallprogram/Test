using Blazor_NPOI_Excel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blazor_NPOI_Excel.Services
{
    public class HzxxServices
    {
        private readonly IHttpClientFactory httpClientFactory;

        public HzxxServices(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<List<HS_HZXX>> Get_hzxx()
        {
            var httpclient = httpClientFactory.CreateClient();
            httpclient.DefaultRequestHeaders.Clear();
            httpclient.DefaultRequestHeaders.Add("Accept", "application/json, text/javascript, */*; q=0.01");
            httpclient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            httpclient.DefaultRequestHeaders.Add("Accept-Language", "keep-alive");
            //httpclient.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            httpclient.DefaultRequestHeaders.Add("Host", "www.bjzhenyuankeji.com:8115");
            //httpclient.DefaultRequestHeaders.Accept.Add



            var requestbody = new requestBody
            {
                sign = "GetHsryxxByYyid",
                yyid = "16",
                btime = "2021-01-17 00:00:00",
                etime = "2021-01-17 23:59:59"
            };


            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://www.bjzhenyuankeji.com:8115/CTL/UserBind.ashx");
            //var body = JsonSerializer.Serialize(requestbody);
            //request.Content = new StringContent(body, Encoding.UTF8, "application/x-www-form-urlencoded");

            //request.Headers.Host = "www.bjzhenyuankeji.com:8115";
            //request.Headers.Accept = "application/json, text/javascript, */*; q=0.01";

            //request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
            //request.Headers.Host = "www.bjzhenyuankeji.com:8115";

            var requestContent = new StringContent(JsonSerializer.Serialize(requestbody), Encoding.UTF8, "application/x-www-form-urlencoded");


            //var response = await httpclient.SendAsync(request);
            var response = await httpclient.PostAsync("https://www.bjzhenyuankeji.com:8115/CTL/UserBind.ashx", requestContent);

            string result = await response.Content.ReadAsStringAsync();

            List<HS_HZXX> hS_HZXXes = JsonSerializer.Deserialize<List<HS_HZXX>>(result);
            return hS_HZXXes;

        }
    }


    public class requestBody
    {
        public string sign { get; set; }
        public string yyid { get; set; }
        public string btime { get; set; }
        public string etime { get; set; }
    }
}
