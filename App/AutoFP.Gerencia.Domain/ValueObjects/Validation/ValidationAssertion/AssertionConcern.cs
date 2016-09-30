using System;
using System.Text.RegularExpressions;

namespace AutoFP.Gerencia.Domain.ValueObjects.Validation.ValidationAssertion
{
    public class AssertionConcern
    {
        public static bool AssertArgumentEmpty(string stringValue, ValidationResult vr, string message)
        {
            if (stringValue == null || stringValue.Trim().Length == 0)
            {
                vr.AddError(message);
                return true;
            }

            return false;
        }

        public static string OnlyNumbers(string toNormalize)
        {
            string resultString = string.Empty;
            Regex regexObj = new Regex(@"[^\d]");
            resultString = regexObj.Replace(toNormalize, "");
            return resultString;
        }

        public static bool AssertArgumentAllEmpty(string[] stringValue, ValidationResult vr, string message)
        {
            var i = 0;
            foreach (var str in stringValue)
            {
                if (!string.IsNullOrEmpty(str))
                    i++;
            }

            if (i != stringValue.Length) return true;

            vr.AddError(message);
            return false;
        }

        public static bool AssertArgumentNotEmptyAndGreaterZero(int[] objectArray, ValidationResult vr, string message)
        {
            if (objectArray != null && objectArray.Length > 0) return true;

            vr.AddError(message);
            return false;
        }

        public static bool AssertArgumentNotAllEmpty(string[] stringValue, ValidationResult vr, string message)
        {
            var i = 0;
            foreach (var str in stringValue)
            {
                if (string.IsNullOrEmpty(str))
                    i++;
            }

            if (i != stringValue.Length)
                return true;

            vr.AddError(message);
            return false;
        }

        public static bool AssertArgumentEquals(object object1, object object2, ValidationResult vr, string message)
        {
            if (object1.Equals(object2))
                return true;

            vr.AddError(message);
            return false;
        }

        public static bool AssertArgumentEqualsValues(int value, int compare, ValidationResult vr, string message)
        {
            if (value == compare)
                return true;

            vr.AddError(message);
            return false;
        }

        public static bool AssertArgumentLength(string stringValue, int minimum, int maximum, ValidationResult vr, string message)
        {
            if (AssertArgumentEmpty(stringValue, vr, message))
                return false;

            int length = stringValue.Trim().Length;
            if (length < minimum || length > maximum)
            {
                vr.AddError(message);
                return false;
            }

            return true;
        }

        public static bool AssertArgumentNotNull(object object1, ValidationResult vr, string message)
        {
            if (object1 != null)
                return true;

            vr.AddError(message);
            return false;
        }

        public static bool AssertArgumentLength(string stringValue, int maximum, ValidationResult vr, string message)
        {
            int length = stringValue.Trim().Length;
            if (length > maximum)
            {
                vr.AddError(message);
                return false;
            }

            return true;
        }

        public static bool AssertArgumentGreater(decimal valueReference, decimal valueCompare, ValidationResult vr, string message)
        {
            if (valueReference > valueCompare)
                return true;

            vr.AddError(message);
            return false;
        }

        public static bool AssertArgumentRangeNumeric(int value, int min, int max, ValidationResult vr, string message)
        {
            if (value >= min && value <= max)
                return true;

            vr.AddError(message);
            return false;
        }

        public static bool AssertArgumentTimeSpan(string time, out TimeSpan timeSpan, ValidationResult vr, string message)
        {
            if (TimeSpan.TryParse(time, out timeSpan))
                return true;

            vr.AddError(message);
            return false;
        }

        public static bool AssertArgumentDateTime(string date, out DateTime dataNascimento, ValidationResult vr, string message)
        {
            if (DateTime.TryParse(date, out dataNascimento))
                return true;

            vr.AddError(message);
            return false;
        }

        public static bool AssertArgumentYear(int year, ValidationResult vr, string message)
        {
            if (year > 1900 || year < DateTime.Now.Year + 2)
                return true;

            vr.AddError(message);
            return false;
        }

        public static bool AssertArgumentIsTrue(bool value, ValidationResult vr, string message)
        {
            if (value) return true;

            vr.AddError(message);
            return false;
        }
    }
}