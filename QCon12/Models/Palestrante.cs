namespace QCon12.Models
{
    public class Palestrante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Bio { get; set; }
        public string Twitter { get; set; }
        public string Foto { get; set; }
        public string Email { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Palestrante && ((Palestrante)obj).Id == Id;
        }
    }
}