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
        [HttpGet("AllCommentArticleId")]
        public async Task<IActionResult> GetAllCommentArticles(string articlesId)
        {
            var getAllComment = await _commentsService.GetAllCommentId(articlesId);
            if(getAllComment == null)
            {
                return BadRequest($"Comment in articles is not found");
            } 

            return Ok(getAllComment);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllComment()
        {
            var getAllComment = await _commentsService.GetAllAsync();

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

        [Authorize(Policy = "UserPolicy")]
        [HttpPost]
        public async Task<IActionResult> Create(CommentsDto comments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userTokenId = HttpContext.User.Claims.First(i => i.Type == "id").Value; ;
            //check kiem tra _id cua user va authorId khi nhap gia tri tao, neu khong khop tra ve loi
            if (userTokenId == null)
            {
                return BadRequest(new { message = "Not authorized to create this articles" });
            }

            var artclie = await _articlesService.GetByIdAsync(comments.ArticlesId);
            if(artclie == null) return BadRequest(new { message = "Articles is not found" });

            comments.AuthorId = userTokenId;
            var commentData = await _commentsService.CreateAsync(comments);

            return CreatedAtAction(nameof(Get), new { id = commentData.Id }, commentData);
        }

        [Authorize(Policy = "UserPolicy")]
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

        [Authorize(Policy = "UserPolicy")]
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
