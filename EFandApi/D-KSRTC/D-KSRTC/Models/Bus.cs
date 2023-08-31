using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace D_KSRTC.Models;

public class Bus
{
    [Key]
    public int BusId { get; set; }
    //Hemce no need of configuration files
    [Required]
    [MaxLength(100)]
    public string BusName { get; set; } = string.Empty;

    [Required]
    public int TCId { get; set; }

    [ForeignKey("TCId")]
    public BusTypeCategory? TCIdNavigation { get; set; }

    public int TotalSeats { get; set; }
}

