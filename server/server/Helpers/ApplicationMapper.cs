using AutoMapper;
using server.Data;
using server.Models;

namespace server.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Attachments, AttachmentsModel>().ReverseMap();
            CreateMap<Posts, PostsModel>().ReverseMap();
            CreateMap<User, SignupModel>();
            CreateMap<Comments, CommentsModel>();
            CreateMap<LikePostComments, LikePostCommentsModel>();
            CreateMap<Suggestions, SuggestionsModel>().ReverseMap();
        }

    }
}
