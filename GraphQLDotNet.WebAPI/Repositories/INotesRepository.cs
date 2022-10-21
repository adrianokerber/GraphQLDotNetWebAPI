using GraphQLDotNet.WebAPI.Notes;

public interface INotesRepository
{
    Task<List<Note>> GetNotes();
    Task CreateNote(Note note);
    Task DeleteNote(Note note);
}