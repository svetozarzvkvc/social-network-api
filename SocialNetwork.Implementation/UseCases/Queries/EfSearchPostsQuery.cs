using SocialNetwork.Application.UseCases.Queries;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Application;
using SocialNetwork.Application.DTO;
using SocialNetwork.Application.UseCases.Queries.Posts;
using SocialNetwork.DataAccess;
using SocialNetwork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Implementation.UseCases.Queries
{
    public class EfSearchPostsQuery : ISearchPostsQuery
    {
        private SocialNetworkContext _context;

        public EfSearchPostsQuery(SocialNetworkContext context)
        {
            _context = context;
        }
        public int Id => 7;

        public string Name => "Search posts";

        public PagedResponse<SearchPostResult> Execute(PostsSearch search)
        {
            var query = _context.Posts.Include(x=>x.Author).Where(x => x.IsActive == true);



            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Title.ToLower().Contains(search.Keyword.ToLower()) ||
                                         x.Author.UserName.ToLower().Contains(search.Keyword.ToLower()));
            }

            if (search.DateFrom.HasValue)
            {
                query = query.Where(x => x.CreatedAt >= search.DateFrom);
            }

            if (search.DateTo.HasValue)
            {
                query = query.Where(x => x.CreatedAt <= search.DateTo);
            }
            if (search.HasComments.HasValue)
            {
                if(search.HasComments.Value == true)
                {
                    query = query.Where(x => x.Comments.Any());
                }
            }
            return Paginate(query, search);

        }

        protected virtual PagedResponse<SearchPostResult> Paginate(IQueryable<Post> query, PagedSearch search)
        {
            return query.AsPagedReponse(search, x => new SearchPostResult
            {
                Id = x.Id,
                Title = x.Title,
                Author = x.Author.UserName,
                Category = x.Category.Name,
                CommentsCount = x.Comments.Count,
                CreatedAt = x.CreatedAt
            });
        }

        public class AutomapperSearchPostsQuery : EfSearchPostsQuery
        {
            private readonly IMapper mapper;
            public AutomapperSearchPostsQuery(SocialNetworkContext context, IMapper mapper) : base(context)
            {
                this.mapper = mapper;
            }
            protected override PagedResponse<SearchPostResult> Paginate(IQueryable<Post> query, PagedSearch search)
            {
                return query.AsPagedReponse<Post, SearchPostResult>(search, mapper);
            }
        }
    }
}
