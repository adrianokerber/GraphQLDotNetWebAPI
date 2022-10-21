using GraphQLDotNet.WebAPI.Notes;

public class NotesRepository : INotesRepository {
    private List<Note> _notes;
    public List<Note> Notes {
        get => _notes;
    }

    public NotesRepository()
    {
        _notes = new List<Note>();
    }

    public async Task<List<Note>> GetNotes() => _notes;
    public async Task CreateNote(Note note) => _notes.Add(note);
    public async Task DeleteNote(Note note) => _notes.Remove(note);
}