using GraphQL.Types;

namespace GraphQLDotNet.WebAPI.Notes;

public class NotesQuery : ObjectGraphType
{
    private readonly INotesRepository _notesRepository;

    public NotesQuery(INotesRepository notesRepository)
    {
        _notesRepository = notesRepository;

        // Returns a static in-memory list
        Field<ListGraphType<NoteType>>("notes")
            .Resolve(context => new List<Note> {
                new Note { Id = Guid.NewGuid(), Message = "Hello World!" },
                new Note { Id = Guid.NewGuid(), Message = "Hello! How are you?" }
            });

        Field<ListGraphType<NoteType>>("notesFromRepository")
            .Resolve(context => {
                var notes = _notesRepository.GetNotes()
                                            .GetAwaiter()
                                            .GetResult();
                return notes;
            });
    }
}