using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace efCoreSqlLiteInMemory.Tables
{
    [Table("MotorArt", Schema = "Bib")]
    public partial class MotorArt
    {
        public MotorArt()
        {
            FuelType = new HashSet<FuelType>();
            MotorBauArt = new HashSet<MotorBauart>();
        }

        [Key]
        public int MotorArtId { get; set; }
        [StringLength(255)]

        
        [ForeignKey("MotorArtId")]
        [InverseProperty("MotorArt")]
        public virtual ICollection<FuelType> FuelType { get; set; }
        [ForeignKey("MotorArtId")]
        [InverseProperty("MotorArt")]
        public virtual ICollection<MotorBauart> MotorBauArt { get; set; }
    }
}
