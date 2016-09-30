using System.Collections.Generic;
using System.Linq;

namespace AutoFP.Gerencia.Domain.ValueObjects.Validation
{
    public class ValidationResult
    {
        private readonly List<string> _errors = new List<string>();

        public bool IsValid => _errors.Count == 0;

        public IEnumerable<string> Errors => _errors;

        public void AddError(string error)
        {
            _errors.Add(error);
        }

        public void AddError(params ValidationResult[] validationResults)
        {
            if (validationResults == null) return;

            foreach (var vr in validationResults.Where(result => result != null))
                _errors.AddRange(vr.Errors);
        }
    }
}