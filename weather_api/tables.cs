using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final__test
{
public class main_table
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int my_id { get; set; }
        
    }
}
