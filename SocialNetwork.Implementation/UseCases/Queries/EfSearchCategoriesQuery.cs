using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Application.DTO;
using SocialNetwork.Application.UseCases.Queries.Categories;
using SocialNetwork.DataAccess;
using SocialNetwork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Implementation.UseCases.Queries
{
    public class EfSearchCategoriesQuery : ISearchCategoriesQuery
    {
        private SocialNetworkContext _context;

        public EfSearchCategoriesQuery(SocialNetworkContext context)
        {
            _context = context;
        }
        public int Id => 8;

        public string Name => "Search posts by category";

        public PagedResponse<SearchCategoriesResult> Execute(CategoriesSearch search)
        {
            var query = _context.Categories.Include(x => x.Posts).Where(x => x.IsActive == true);



            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            return Paginate(query, search);
        }

        protected virtual PagedResponse<SearchCategoriesResult> Paginate(IQueryable<Category> query, PagedSearch search)
        {
            return query.AsPagedReponse(search, x => new SearchCategoriesResult
            {
                Id = x.Id,
                Name = x.Name,
                Posts = x.Posts.Select(x=> x.Title)
            });
        }

        public class AutomapperSearchPostsQuery : EfSearchCategoriesQuery
        {
            private readonly IMapper mapper;
            public AutomapperSearchPostsQuery(SocialNetworkContext context, IMapper mapper) : base(context)
            {
                this.mapper = mapper;
            }
            protected override PagedResponse<SearchCategoriesResult> Paginate(IQueryable<Category> query, PagedSearch search)
            {
                return query.AsPagedReponse<Category, SearchCategoriesResult>(search, mapper);
            }
        }
    }
}
