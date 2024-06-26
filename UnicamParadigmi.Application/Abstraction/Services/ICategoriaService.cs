﻿using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Application.Abstraction.Services
{
    public interface ICategoriaService
    {
        void AddCategoria(Categoria categoria);

         void DeleteCategoria(Categoria categoria);
        
        bool ValidateCategoria(Categoria categoria);

        bool ValidateEliminazione(Categoria categoria);
    }
}
