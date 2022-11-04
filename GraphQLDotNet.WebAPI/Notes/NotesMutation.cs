using GraphQL;
using GraphQL.Types;
using GraphQLDotNet.WebAPI.Notes;

public class NotesMutation : ObjectGraphType
{
    private readonly INotesRepository _notesRepository;

    public NotesMutation(INotesRepository notesRepository)
    {
        _notesRepository = notesRepository;

        Field<NoteType>("createNote")
            .Arguments(new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "message"}
            ))
            .Resolve(context =>
            {
                var message = context.GetArgument<string>("message") ?? string.Empty;

                var note = new Note
                {
                    Message = message,
                };

                _notesRepository.CreateNote(note);

                return note;
            });
    }
}