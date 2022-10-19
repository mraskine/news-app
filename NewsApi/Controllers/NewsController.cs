using Microsoft.AspNetCore.Mvc;
using NewsApi.Models.News;
using NewsApi.Services;
using System;

namespace NewsApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewsController : BaseController
    {
        private readonly IApiService _guardianApiService;
        public NewsController(IApiService guardianApiService) : base()
        {
            _guardianApiService = guardianApiService;
        }

        [HttpPost]
        public IActionResult LatestNewsList([FromBody] NewsListRequest request)
        {
            try
            {
                var response = _guardianApiService.SearchStories(request.Page, request.PageSize);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ReturnError(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult NewsStory([FromBody] NewsStoryRequest request)
        {
            try
            {
                var response = _guardianApiService.GetNewsStory(request.Id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ReturnError(ex.Message);
            }
        }
    }
}
