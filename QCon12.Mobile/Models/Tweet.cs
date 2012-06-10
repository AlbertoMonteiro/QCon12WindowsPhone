using System;
using GalaSoft.MvvmLight;

namespace QCon12.Mobile.Models
{
    public class Tweet : ViewModelBase
    {
        public DateTime created_at { get; set; }
        public string source { get; set; }
        public string text { get; set; }
    }
}