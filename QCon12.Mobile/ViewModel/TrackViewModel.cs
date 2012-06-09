using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using QCon12.Mobile.Models;

namespace QCon12.Mobile.ViewModel
{
    public class TrackViewModel : ViewModelBase
    {
        public TrackViewModel(bool isInDesignModeStatic)
        {
            Palestras = new ObservableCollection<Palestra>();
            
            if (isInDesignModeStatic)
            {
                Track = new Track("Desenvolvimento Mobile", "Durante muito tempo, os aplicativos Desktop dominaram o mercado tanto doméstico quando corporativo. Com o passar dos anos, a Web ganhou lugar de destaque e se tornou a famosa plataforma de aplicações que temos atualmente. Porém, engana-se quem pensa que essa evolução parou. O mercado de aplicativos mobile tem crescido cada vez mais e temos duas alternativas para desenvolver: o modelo nativo, programando para Android, iOS e Windows Mobile; e o modelo web, criando um site que tenha características de aplicação. Você vai aprender como o desenvolvimento mobile pode trazer ganhos para o seu negócio, com cases de sucesso do uso dessas poderosas plataformas, além de conhecer as últimas novidades, técnicas e tecnologias.")
                {
                    Logo = @"http://qconsp.com/images/tracks/mobile.png?1339080693"
                };
                
                var palestrante = new Palestrante("Elemar Jr", "http://qconsp.com/images/palestrantes/elemar-junior.jpg?1339080693");

                Palestras.Add(new Palestra
                {
                    Descricao = "Conteudo da palestra 1 que fala sobre alguma coisa que eu não sei mais o que escrever aqui",
                    Horario = new DateTime(2012, 08, 4, 12, 00, 00),
                    Nome = "Palestra 1",
                    Palestrante = palestrante,
                    Track = Track
                });

                Palestras.Add(new Palestra
                {
                    Descricao = "Conteudo da palestra 2 que fala sobre alguma coisa que eu não sei mais o que escrever aqui",
                    Horario = new DateTime(2012, 8, 5, 15, 00, 00),
                    Nome = "Palestra 2",
                    Palestrante = palestrante,
                    Track = Track
                });
            }    
        }

        public Track Track { get; set; }
        public ObservableCollection<Palestra> Palestras { get; set; }
    }
}