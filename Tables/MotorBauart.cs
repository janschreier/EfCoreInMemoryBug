using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace efCoreSqlLiteInMemory.Tables
{
    [Table("MotorBauart", Schema = "Bib")]
    public partial class MotorBauart
    {
        public MotorBauart()
        {
            MotorArt = new HashSet<MotorArt>();
        }

        [Key]
        public int MotorBauartId { get; set; }
        
        public virtual ICollection<MotorArt> MotorArt { get; set; }
    }
}
