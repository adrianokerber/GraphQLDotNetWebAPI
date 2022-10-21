using GraphQL.Types;

namespace GraphQLDotNet.WebAPI.Notes;

public class NotesQuery : ObjectGraphType
{
    private readonly INotesRepository _notesRepository;

    public NotesQuery(INotesRepository notesRepository)
    {
        _notesRepository = notesRepository;

        // Returns a static in-memory list
        Field<ListGraphType<NoteType>>("notes", resolve: context => new List<Note> {
            new Note { Id = Guid.NewGuid(), Message = "Hello World!" },
            new Note { Id = Guid.NewGuid(), Message = "Hello World! How are you?" }
        });

        Field<ListGraphType<NoteType>>("notesFromRepository", resolve: context => {
            var notes = _notesRepository.GetNotes()
                                        .GetAwaiter()
                                        .GetResult();
            return notes;
        });
    }
}