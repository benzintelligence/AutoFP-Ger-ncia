using System.Text.RegularExpressions;

namespace AutoFP.Gerencia.Domain.ValueObjects.Validation.ValidationAssertion
{
    public static class EmailAssertionConcern
    {
        public static bool AssertIsValid(string email, ValidationResult vr, string message)
        {
            if (AssertIsValid(email)) return true;

            vr.AddError(message);
            return false;
        }

        public static bool AssertIsValid(string email)
        {
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
    }
}