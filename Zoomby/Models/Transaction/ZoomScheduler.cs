using System;
using System.ComponentModel.DataAnnotations.Schema;
using Zoomby.Models.Master;

namespace Zoomby.Models.Transaction
{
    [Table("T_ZoomScheduler")]
    public class ZoomScheduler : Base
    {
        public string Agenda { get; set; }
        public string LinkAddress { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // join
        public virtual Pic? Pic{ get; set; }
        public int PicId { get; set; }
        public virtual ZoomAccount? ZoomAccount { get; set; }
        public int ZoomAccountId { get; set; }
    }
}
