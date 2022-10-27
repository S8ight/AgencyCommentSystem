using AgencyProjectFourth.Models;

namespace AgencyProjectFourth.GraphQL.Comments;

public class CommentType : ObjectType<Comment>
{   
    protected override void Configure(IObjectTypeDescriptor<Comment> descriptor)
    {
        descriptor.Description("Represents any comments for the advert.");

        descriptor
            .Field(p => p.Id)
            .Description("Represents the unique ID for the comment.");

        descriptor
            .Field(p => p.commentContents)
            .Description("Represents the contents of comment.");

        descriptor
            .Field(p => p.Created)
            .Description("Represent date and time when the comment was created");
        
        descriptor
            .Field(p => p.Likes)
            .Description("Represent the quantity of likes for comment");
        
        descriptor
            .Field(p => p.UserId)
            .Description("Represent userId that wrote comment");
        
        descriptor
            .Field(p => p.AdvertId)
            .Description("Represent the advert to which a comment was written");
    }
    
    public class Resolvers
    {
        
    }
    
}