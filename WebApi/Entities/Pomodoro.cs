using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Pomodoro
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        public int DurationInMinutes { get; set; }
        public Boolean PauseInMinutes { get; set; }
        
        public int MinuteSetId { get; set;}
        public MinuteSet MinuteSet { get; set;}

        public int UserId { get; set; }
        public User User { get; set; }
    }
}