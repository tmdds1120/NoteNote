using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteNote.Models
{
    public class Note
    {

        /// <summary>
        /// 게시물 번호
        /// </summary>
        [Key]
        public int NoteID { get; set; }

        /// <summary>
        /// 게시물 제목
        /// </summary>
        [Required]
        public string? NoteTitle { get; set; }
       
        /// <summary>
        /// 게시물 내용
        /// </summary>
        [Required]
        public string? NoteContents { get; set; }

        [Required]// 사용자 번호, 유저 no 
        public int UserNo { get; set; }

        [ForeignKey("UserNo")]
        public virtual User? User { get; set; }
        // Lazy Loading 
    }
}
