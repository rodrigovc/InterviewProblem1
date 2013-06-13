using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RegisterClientService
{
    /// <summary>
    /// Fluxo de dados para usuário em arquivo.
    /// </summary>
    public class UserFlow
    {

        #region Public Methods

        /// <summary>
        /// Insere o usuário em um arquivo.
        /// </summary>
        /// <param name="user"></param>
        public void InsertUser(User user)
        {
            //Cria o arquivo na pasta local do usuário corrente User\AppData\Local (pasta oculta no windows).
            using (StreamWriter sw = new StreamWriter(new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Users.txt", FileMode.Append, FileAccess.Write)))
            {
                sw.WriteLine(user.Name + " " + user.Email + " " + user.BirthDate.ToString() + " " + user.PhoneNumber + " " + user.MobilePhoneNumber);
            }
            using (var db = new RegisterClientContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        #endregion
    }
}