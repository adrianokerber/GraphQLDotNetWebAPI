using GraphQL;
using GraphQL.Types;
using GraphQLDotNet.WebAPI.Notes;

public class NotesMutation : ObjectGraphType
{
    private readonly INotesRepository _notesRepository;

    public NotesMutation(INotesRepository notesRepository)
    {
        _notesRepository = notesRepository;

        Field<NoteType>(
            "createNote",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "message"}
            ),
            resolve: context =>
            {
                var message = context.GetArgument<string>("message");

                var note = new Note
                {
                    Message = message,
                };

                _notesRepository.CreateNote(note);

                return note;
            }
        );
    }
}