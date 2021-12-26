namespace DAL1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CateId { get; set; }

        [StringLength(255)]
        public string Catename { get; set; }

        [StringLength(255)]
        public string CAddress { get; set; }
    }
}
