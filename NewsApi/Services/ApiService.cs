using NewsApi.Entities;
using NewsApi.Helpers;
using NewsApi.Models.News;
using System;
using System.Collections.Generic;

namespace NewsApi.Services
{
    public interface IApiService {
        NewsListResponse SearchStories(int? page, int? pageSize, string keyword);
        NewsListResponse LatestStories(int? page, int? pageSize);
        NewsStoryResponse GetNewsStory(string id);
    }


    public class ApiService : IApiService
    {
        public NewsListResponse SearchStories(int? page, int? pageSize, string keyword)
        {
            string endpoint = "search";
            string[] fields = { "headline", "webUrl", "thumbnail", "webPublicationDate" };
            Dictionary<string, string> urlParams = new Dictionary<string, string>
            {
                { "format", "json"},
                { "q", keyword},
                { "query-fields", "headline,body,thumbnail"},
                { "show-fields", String.Join(',', fields)},
                { "order-by", "relevance"},
                {"page",  (page ?? 1).ToString()},
                {"page-size",  (pageSize ?? 10).ToString()},
            };

            dynamic dynamicData = ApiHelper.ApiGet(endpoint, urlParams);
            var results = dynamicData.response.results;
            var stories = new List<NewsListItem>();
            foreach (var result in results)
            {
                var story = new NewsListItem
                {
                    WebPublicationDate = result.webPublicationDate,
                    WebTitle = result.webTitle,
                    WebUrl = result.webUrl,
                    ImageUrl = result.fields.thumbnail
                };
                stories.Add(story);
            }

            NewsListResponse response = new NewsListResponse() 
            { 
                NewsItems = stories
            };
            return response;
        }

        public NewsListResponse LatestStories(int? page, int? pageSize)
        {
            string endpoint = "search";
            DateTime fromDate = DateTime.Today.AddDays(-1);
            string[] fields = { "headline", "webUrl", "thumbnail", "webPublicationDate" };
            Dictionary<string, string> urlParams = new Dictionary<string, string>
            {
                { "format", "json"},
                { "from-date", fromDate.ToString("yyyy-MM-dd")},
                { "show-fields", String.Join(',', fields)},
                { "order-by", "relevance"},
                {"page",  (page ?? 1).ToString()},
                {"page-size",  (pageSize ?? 10).ToString()},
            };

            dynamic dynamicData = ApiHelper.ApiGet(endpoint, urlParams);
            var results = dynamicData.response.results;
            var stories = new List<NewsListItem>();
            foreach (var result in results)
            {
                var story = new NewsListItem
                {
                    WebPublicationDate = result.webPublicationDate,
                    WebTitle = result.webTitle,
                    WebUrl = result.webUrl,
                    ImageUrl = result.fields.thumbnail
                };
                stories.Add(story);
            }

            NewsListResponse response = new NewsListResponse()
            {
                NewsItems = stories
            };
            return response;
        }

        public NewsStoryResponse GetNewsStory(string id)
        {
            string[] fields = { "headline", "webUrl", "thumbnail", "webPublicationDate", "body" };
            Dictionary<string, string> urlParams = new Dictionary<string, string>
            {
                { "format", "json"},
                { "show-fields", String.Join(',', fields)},
            };           

            dynamic dynamicData = ApiHelper.ApiGet(id, urlParams);
            var result = dynamicData.response.content;            
            var story = new NewsStory
            {
                WebPublicationDate = result.webPublicationDate,
                WebTitle = result.webTitle,
                WebUrl = result.webUrl,
                Body = result.fields.body,
                ImageUrl = result.fields.thumbnail
            };
            

            NewsStoryResponse response = new NewsStoryResponse()
            {
                NewsStory = story
            };
            return response;
        }
    }
}
