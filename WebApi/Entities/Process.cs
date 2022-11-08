using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Process
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public int MinuteTypeId { get; set;}
        public MinuteType MinuteType { get; set;}
        public int MinuteSetId { get; set;}
        public MinuteSet MinuteSet { get; set;}
        public Boolean IsCompleted  { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}