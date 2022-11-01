using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_NetCore_MongoDB.Models;
using Project_NetCore_MongoDB.Services;
using Project_NetCore_MongoDB.Services.Interface;
using Project_NetCore_MongoDB.Dto;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project_NetCore_MongoDB.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;
        private readonly IUsersService _usersService;
        private readonly IArticlesService _articlesService;

        public CommentsController(ICommentsService commentsService, IUsersService usersService, IArticlesService articlesService)
        {
            _commentsService = commentsService;
            _articlesService = articlesService;
            _usersService = usersService;
        }
        // GET: api/<ArticlesController>
        //[Authorize(Policy = "AdminPolicy")]
        [HttpGet]
        public async Task<IActionResult> GetAll(string author)
        {
            var articleId = await _articlesService.GetByIdAsync(author);

           //var idData = articleId.AuthorId;

            //string ids = articleId.ToString();

            if (articleId == null){
                return BadRequest($"Articles is not found");
            }

            var getAllComment = await _commentsService.GetAllCommentId(articleId.ToString());

            return Ok(getAllComment);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var comments = await _commentsService.GetByIdAsync(id).ConfigureAwait(false);

            if (comments == null)
            {
                return NotFound($"Comments is not found!");
            } 
           
            comments.Articles = await _articlesService.GetByIdAsync(comments.ArticlesId);
            comments.Users = await _usersService.GetByIdAsync(comments.AuthorId);

            return Ok(comments);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentsDto comments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var articles = await _articlesService.GetByIdAsync(comments.ArticlesId).ConfigureAwait(false);
            if(articles == null)
            {
                return BadRequest($"Articles is not found");
            }

            var userTokenId = HttpContext.User.Claims.First(i => i.Type == "id").Value; ;
            comments.AuthorId = userTokenId;

            var commentData = await _commentsService.CreateAsync(comments);

            return CreatedAtAction(nameof(Get), new { id = commentData.Id }, commentData);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, CommentsDto comments)
        {
            var data = await _commentsService.GetByIdAsync(id);

            if (data == null)
            {
                return NotFound($"Comments is not found!");
            }

            var userIdToken = HttpContext.User.Claims.First(i => i.Type == "id").Value;
            //check Id author in artiles vs id token login user. If worng then error. True continue
            if (userIdToken != data.AuthorId)
            {
                return BadRequest(new { message = "Not authorized to update this comments" });
            }

            await _commentsService.UpdateAsync(id, comments);

            return CreatedAtAction(nameof(Get), new { id = comments.Id }, comments);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var comments = await _commentsService.GetByIdAsync(id);

            if (comments == null)
            {
                return NotFound($"Comments is not found!");
            }

            var userIdToken = HttpContext.User.Claims.First(i => i.Type == "id").Value;
            //check Id author in artiles vs id token login user. If worng then error. True continue
            if (userIdToken != comments.AuthorId)
            {
                return BadRequest(new { message = "Not authorized to delete this comments" });
            }

            await _commentsService.DeleteAsync(id).ConfigureAwait(false);

            return Ok($"Comments with Id = {id} is deleted");
        }
    }
}
