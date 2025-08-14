using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICodeFrst_Ass1.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(8)]
       
        public String EmployeeCode { get; set; }
        [Required]
        [MaxLength(150)]
        public String FullName { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        [MaxLength(50)]   
        public String Designation { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public Decimal Salary { get; set; }
       
        public int ProjectId { get; set; }
        //Navigation property to Project
        [ForeignKey("ProjectId")]
        public Project? Project { get; set; }
    }
}
