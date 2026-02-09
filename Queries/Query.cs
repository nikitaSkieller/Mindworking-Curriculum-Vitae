public class Query
{
    [GraphQLName("hello")]
    public string GetHello() => "Hello, GraphQL!";
}