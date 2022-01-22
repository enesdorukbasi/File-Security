using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSecurity.EL
{
    public enum SecurityModes
    {
        [Display(Name = "Gizli")]
        Hidden = 1,
        [Display(Name = "Şifreli")]
        Encrypted = 2,
        [Display(Name = "Güvenlik Durumu Yok")]
        Null = 3,
        [Display(Name = "Şifreli ve Gizli")]
        EncryptedAndHidden = 4
    }

    public enum Situations
    {
        [Display(Name = "Güvenli")]
        Safe = 1,
        [Display(Name = "Erişilebilir")]
        Accessible = 2
    }

    public enum FileOrFolders
    {
        [Display(Name = "Dosya")]
        File = 1,
        [Display(Name = "Klasör")]
        Folder = 2
    }

    [Table("tblFiles")]
    public class File
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FileName { get; set; }
        
        public string FilePath { get; set; }
        [Required]
        public SecurityModes SecurityMode { get; set; }
        [Required]
        public Situations Situation { get; set; }

        public FileOrFolders FileOrFolder { get; set; }

        public string EMail { get; set; }
        [ForeignKey("EMail")]
        public virtual User User { get; set; }
    }
}
