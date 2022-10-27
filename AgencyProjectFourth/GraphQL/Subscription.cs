using AgencyProjectFourth.Models;

namespace AgencyProjectFourth.GraphQL;

public class Subscription
{
    [Subscribe]
    [Topic]
    public Comment OnCommentAdded([EventMessage] Comment comment)
    {
        return comment;
    }
}