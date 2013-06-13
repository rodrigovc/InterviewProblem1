using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RegisterClientService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class RegisterClientService : IRegisterClientService
    {

        #region Public Properties

        /// <summary>
        /// Registra e válida um usuário.
        /// </summary>
        /// <param name="name">Nome do usuário.</param>
        /// <param name="email">Email do usuário.</param>
        /// <param name="mobilephonenumber">Telefone celular do usuário.</param>
        /// <param name="phonenumber">Telefone do usuário.</param>
        /// <param name="birthdate">Data de nascimento.</param>
        /// <returns>Retorna mensagem em caso de erro de validação e nulo caso contrário.</returns>
        public string RegisterUser(string name, string email, string mobilephonenumber, string phonenumber, string birthdate)
        {
            var birth = Validator.ValidateDate(birthdate);
            if (birth == null)
                return "Ocorreu um erro na validação da data de nascimento.";
            if (!Validator.ValidateEmail(email))
                return "Ocorreu um erro na validação do email";
            var user = new User(name, email, mobilephonenumber, phonenumber, birth.Value);
            var userFlow = new UserFlow();
            userFlow.InsertUser(user);
            return "Usuário foi inserido com sucesso";
        }

        #endregion

    }
}
