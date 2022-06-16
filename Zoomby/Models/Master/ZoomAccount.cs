using System.ComponentModel.DataAnnotations.Schema;

namespace Zoomby.Models.Master
{
    [Table("M_ZoomAccount")]
    public class ZoomAccount : Base
    {
        public string Name { get; set; }
    }
}
