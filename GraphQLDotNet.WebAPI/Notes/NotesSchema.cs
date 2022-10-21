using GraphQL.Types;

namespace GraphQLDotNet.WebAPI.Notes;

public class NotesSchema : Schema
{
  public NotesSchema(IServiceProvider serviceProvider) : base(serviceProvider)
  {
    Query = serviceProvider.GetRequiredService<NotesQuery>();
    Mutation = serviceProvider.GetRequiredService<NotesMutation>();
  }
}