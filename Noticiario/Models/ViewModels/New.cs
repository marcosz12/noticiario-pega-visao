using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Noticiario.Models.ViewModels
{
    public class New
    {
        public int Id { get; set; }
        [Display(Name = "Título")]
        public string Title { get; set; }
        [Display(Name ="Categoria")]
        public string Category { get; set; }
        [Display(Name ="Data")]
        public DateTime Date { get; set; }
        [Display(Name = "Local")]
        public string Location { get; set; }

        public New()
        {

        }

        public New(int id, string title, string category, DateTime date, string location)
        {
            Id = id;
            Title = title;
            Category = category;
            Date = date;
            Location = location;
        }
    }
}
