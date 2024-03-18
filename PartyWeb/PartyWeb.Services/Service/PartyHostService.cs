using AutoMapper;
using ModelViews.ModelView;
using Reponsitories.Interface;
using Services.Interface;

namespace Services.Service
{
    public class PartyHostService : IFeedbackService
    {
        private readonly IPartyHostRepository _repo;
        private readonly IMapper _mapper;

        public PartyHostService(IPartyHostRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }

        public Task<bool> AddNewFeedbackModel(FeedbackModel feedback)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFeedbackModel(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FeedbackModel> GetFeedbackModelById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateFeedbackModel(FeedbackModel feedback)
        {
            throw new NotImplementedException();
        }
    }
}
