using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace efCoreSqlLiteInMemory.Tables
{
    [Table("FuelType", Schema = "dbo")]
    [Index("Bezeichnung", Name = "Key_Fueltype", IsUnique = true)]
    public partial class FuelType
    {
        public FuelType()
        {
            MotorArt = new HashSet<MotorArt>();
        }

        [Key]
        public int FuelTypeId { get; set; }
        [StringLength(255)]
        public string Bezeichnung { get; set; } = null!;

        public virtual ICollection<MotorArt> MotorArt { get; set; }
    }
}
