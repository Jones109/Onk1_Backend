using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public partial class Vaerktoej
    {
        [Key]
        public Guid VTId { get; set; }
        public DateTime VTAnskaffet { get; set; }
        public string VTFabrikat { get; set; }
        public string VTModel { get; set; }
        public string VTSerienr { get; set; }
        public string VTType { get; set; }
        public Guid? LiggerIvtk { get; set; }

        public Vaerktoejskasse LiggerIvtkNavigation { get; set; }
    }
}