using UnicamParadigmi.Application.Abstraction.Services;
using UnicamParadigmi.Models.Entities;
using UnicamParadigmi.Models.Repositories;

namespace UnicamParadigmi.Application.Services
{
    public class UtenteService : IUtenteService
    {
        private readonly UtenteRepository _utenteRepository;

        public UtenteService(UtenteRepository utenteRepository)
        {
            _utenteRepository = utenteRepository;
        }

        public void AddUtente(Utente utente)
        {
            _utenteRepository.Aggiungi(utente);
            _utenteRepository.Salvataggio();
        }
    }
}
