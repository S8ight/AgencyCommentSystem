using AgencyProjectFourth.DbContext;
using AgencyProjectFourth.Models;

namespace AgencyProjectFourth.GraphQL;

public class Query
{
    [UseDbContext(typeof(AgencyDbContext))]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("Represent a method that returns all comments from the table ")]
    public IQueryable<Comment> GetComments([ScopedService] AgencyDbContext context)
    {
        var result =  context.Comments;
        return result;
    }
    
    [UseDbContext(typeof(AgencyDbContext))]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("Represent a method that returns comment by Id")]
    public IQueryable<Comment> GetCommentById(int id, [ScopedService] AgencyDbContext context)
    {
        return context.Comments.Where(c => c.Id==id);
    }
    
    [UseDbContext(typeof(AgencyDbContext))]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("Represent a method that returns all comments for advert")]
    public IQueryable<Comment> GetCommentsOfAdvert(int id, [ScopedService] AgencyDbContext context)
    {
        return context.Comments.Where(c => c.AdvertId==id.ToString());
    }
    
    
}