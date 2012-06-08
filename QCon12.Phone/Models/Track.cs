using Caliburn.Micro;

namespace QCon12.Phone.Models
{
    public class Track : PropertyChangedBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Bio { get; set; }
    }
}