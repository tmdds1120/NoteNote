using System.ComponentModel.DataAnnotations;

namespace NoteNote.Models
{
    public class User
    {
        //xml 주석?  
        // 디버깅 모드 할 떄 xml 주석이 함께나온다
        ///<summary
        /// 

        ///</summary>
        [Key] // pk 설정 어노테이션
        public int UserNo { get; set; }

        [Required] // Not Null
        public string? UserName { get; set; }

        [Required]
        public string? UserId { get; set; }

        [Required]
        public string? UserPassword { get; set; }

        
    }
}
