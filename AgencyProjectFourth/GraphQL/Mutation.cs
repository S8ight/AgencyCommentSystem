using AgencyProjectFourth.DbContext;
using AgencyProjectFourth.GraphQL.Comments;
using AgencyProjectFourth.GraphQL.Exceptions;
using AgencyProjectFourth.Models;
using HotChocolate.Subscriptions;
using Microsoft.EntityFrameworkCore;

namespace AgencyProjectFourth.GraphQL;

public class Mutation
{
    [UseDbContext(typeof(AgencyDbContext))]
    [GraphQLDescription("Represent a method that adds a new comment to the table")]
    public async Task<AddCommentPayload> AddCommentAsync(AddCommentInput input, [ScopedService] AgencyDbContext context,[Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
    {
        var comment = new Comment
        {
            commentContents = input.CommentContents,
            UserId = input.UserId,
            AdvertId = input.AdvertId,
            Created = DateTime.Now,
            Likes = 0
        };
        context.Comments.Add(comment);
        await context.SaveChangesAsync(cancellationToken);
        await eventSender.SendAsync(nameof(Subscription.OnCommentAdded), comment, cancellationToken);
        
        return new AddCommentPayload(comment);
    }
    
    [UseDbContext(typeof(AgencyDbContext))]
    [GraphQLDescription("Represent a method that deletes comment from the table")]
    public async Task<int> DeleteCommentAsync(int id, [ScopedService] AgencyDbContext context, CancellationToken cancellationToken)
    {
       var result =  await context.Comments.Where(c =>c.Id==id).ExecuteDeleteAsync(cancellationToken);
       await context.SaveChangesAsync(cancellationToken);
       if (result == 0)
       {
           throw new NotFoundException($"Comments with id: {id} not found");
       }

       return result;
    }
}