﻿using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Application.Abstraction.Services
{
    public interface IUtenteService
    {
        void AddUtente(Utente utente);

        string CreateToken(Utente utente);

        bool CheckUtente(Utente utente);

        bool CheckEmail(Utente utente);
    }
}
