using System.Text.RegularExpressions;

namespace AutoFP.Gerencia.Domain.ValueObjects.Validation.ValidationAssertion
{
    public static class DocumentAssertionConcern
    {
        public static bool AssertArgumentCpf(string cpf, ValidationResult vr, string message)
        {
            if (IsCpf(cpf))
                return true;

            vr.AddError(message);
            return false;
        }

        public static bool AssertArgumentCnpj(string cnpj, ValidationResult vr, string message)
        {
            if (IsCnpj(cnpj))
                return true;

            vr.AddError(message);
            return false;
        }

        public static bool AssertArgumentCep(string cep, ValidationResult vr, string message)
        {
            if (ValidateCep(cep))
                return true;

            vr.AddError(message);
            return false;
        }

        private static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma, resto;
            string digito, tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            digito = digito + resto;
            return cnpj.EndsWith(digito);
        }

        private static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf, digito;
            int soma, resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            digito = digito + resto;
            return cpf.EndsWith(digito);
        }

        private static bool ValidateCep(string cep)
        {
            return Regex.IsMatch(cep, "[0-9]{5}[0-9]{3}");
        }
    }
}