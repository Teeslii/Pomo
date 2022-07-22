using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class MinuteSet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public int Minute { get; set; }

        public ICollection<Pomodoro> Pomodoros { get; set; }
    }
}