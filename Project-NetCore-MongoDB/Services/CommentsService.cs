using Project_NetCore_MongoDB.Models;
using Project_NetCore_MongoDB.Repository.Interface;
using Project_NetCore_MongoDB.Services.Interface;
using Project_NetCore_MongoDB.Dto;
using AutoMapper;

namespace Project_NetCore_MongoDB.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;
        private readonly IMapper _mapper;
        public CommentsService(ICommentsRepository commentsRepository, IMapper mapper)
        {
            _commentsRepository = commentsRepository;
            _mapper = mapper;
        }

        public Task<List<Comments>> GetAllAsync()
        {
            return _commentsRepository.GetAllAsync();
        }

        public Task<List<Comments>> GetAllCommentId(string author)
        {
            return _commentsRepository.GetAllCommentId(author);
        }


        public Task<Comments> GetByIdAsync(string id)
        {
            return _commentsRepository.GetByIdAsync(id);
        }

        public Task<Comments> CreateAsync(CommentsDto comments)
        {
            var dataMapper = _mapper.Map<Comments>(comments);

            var dataComments = _commentsRepository.CreateAsync(dataMapper);

            return dataComments;
        }

        public Task UpdateAsync(string id, CommentsDto comments)
        {
            var dataMapper = _mapper.Map<Comments>(comments);

            return _commentsRepository.UpdateAsync(id, dataMapper);
        }

        public Task DeleteAsync(string id)
        {
            return _commentsRepository.DeleteAsync(id);
        }
    }
}
