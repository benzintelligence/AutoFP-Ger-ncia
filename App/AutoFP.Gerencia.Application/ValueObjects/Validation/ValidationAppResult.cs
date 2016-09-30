using System.Collections.Generic;
using AutoFP.Gerencia.Domain.ValueObjects.Validation;

namespace AutoFP.Gerencia.Application.ValueObjects.Validation
{
    public class ValidationAppResult
    {
        private readonly List<string> _erros = new List<string>();

        public bool IsValid => _erros.Count == 0;

        public ICollection<string> Errors => _erros;

        public void AddErrors(ValidationResult error)
        {
            _erros.AddRange(error.Errors);
        }
    }
}