using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CTeamWebAPI.Controllers
{
    public class CTEAMController : ApiController
    {
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// 發送訊息到指定群組
        /// </summary>
        /// <param name="account">帳號</param>
        /// <param name="apiKey">api key</param>
        /// <param name="chatSn">聊天室sn</param>
        /// <param name="message">訊息</param>
        /// <param name="url">api url</param>
        /// <returns></returns>
        [Route("SendMessage")]
        public string SendMessage(
            string account = "01002099",
            string apiKey = "41B9ED5D-6FA2-084F-17D7-55E1A7B899DC",
            string chatSn = "148",
            string message = "HelloWorld",
            string url = "https://temp.cathayholdings.com/API/IMService.ashx?ask=sendChatMessage")
        {
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("account", account);
            request.AddParameter("api_key", apiKey);
            request.AddParameter("chat_sn", chatSn);
            request.AddParameter("content_type", "1");
            request.AddParameter("msg_content", message);
            request.AddParameter("file_show_name", "");
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        /// <summary>
        /// 群組內發表文章
        /// </summary>
        /// <param name="account">帳號</param>
        /// <param name="apiKey">API KEY</param>
        /// <param name="teamSn">TEAM SN</param>
        /// <param name="content">內容</param>
        /// <param name="title">文章標題</param>
        /// <param name="url">API URL</param>
        /// <returns></returns>
        [Route("PostArticle")]
        public string PostArticle(
           string account = "va_9d0121af09134c5581",
           string apiKey = "866a9a4a-2d99-418f-99ba-b11a59a3249d",
           string teamSn = "63",
           string content = "DefaultPostContent",
           string title = "DefaultPostTitle",
           string url = "https://temp.cathayholdings.com/API/TeamService.ashx?ask=postMessage")
        {
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("account", account);
            request.AddParameter("api_key", apiKey);
            request.AddParameter("team_sn", teamSn);
            request.AddParameter("content_type", "1");
            request.AddParameter("text_content", content);
            request.AddParameter("file_show_name", "");
            request.AddParameter("media_content", "1");
            request.AddParameter("subject", title);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
    }
}