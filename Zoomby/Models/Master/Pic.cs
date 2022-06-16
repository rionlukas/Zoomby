using System.ComponentModel.DataAnnotations.Schema;

namespace Zoomby.Models.Master
{
    [Table("M_Pic")]
    public class Pic : Base
    {
        public string? Name { get; set; }

    }
}
