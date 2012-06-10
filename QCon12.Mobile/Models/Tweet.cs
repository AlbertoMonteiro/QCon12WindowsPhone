using System;
using GalaSoft.MvvmLight;

namespace QCon12.Mobile.Models
{
    public class Tweet : ViewModelBase
    {
        public DateTime created_at { get; set; }
        public string source { get; set; }
        public string text { get; set; }
        public string ElapsedTime
        {
            get
            {
                var now = DateTime.Now;
                var diff = now.Subtract(created_at);
                string retorno;
                if (diff.TotalSeconds < 60)
                    retorno = string.Format("{0:00} segundo(s)", diff.TotalSeconds);
                else if (diff.TotalMinutes < 60)
                    retorno = string.Format("{0:00} minuto(s)", diff.TotalMinutes);
                else if (diff.TotalHours < 24)
                    retorno = string.Format("{0:00} hora(s)", diff.TotalHours);
                else
                    retorno = string.Format("{0:00} dia(s)", diff.TotalDays);
                return retorno;
            }
        }

        public override string ToString()
        {
            return text;
        }
    }
}