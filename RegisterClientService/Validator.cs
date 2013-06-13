using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace RegisterClientService
{
    /// <summary>
    /// Classe estática com métodos de validação.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Válida um texto em uma data válida.
        /// </summary>
        /// <param name="date">Texto da data válida.</param>
        /// <returns>Data ou nulo caso não seja válida.</returns>
        public static DateTime? ValidateDate(string date)
        {
            DateTime validatedDate;
            if (DateTime.TryParse(date, out validatedDate))
                return validatedDate;
            else
                return null;
        }

        public static bool ValidateEmail(string email)
        {
            if (Regex.IsMatch(email,
                @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                RegexOptions.IgnoreCase))
                return true;
            else
                return false;
        }

    }
}