using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZenestaMVC.Models
{
    public class PredictionForm
    {
        [StringLength(64)]
        [DisplayName("Batch Name")]
        public string BatchName { get; set; } = "";

        public List<IFormFile> Images { get; set; } = null!;
    }
}
