using Microsoft.EntityFrameworkCore;
using NoteNote.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace NoteNote.DataContext
{
    public class NoteNoteContext: DbContext

    {
        public DbSet<User> Users { get; set; }

        public DbSet<Note> Notes { get; set; }

        // 커넥션 연결

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;database=Note;Persist Security Info=True;User ID=tmdds;Password=tiger1120;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
