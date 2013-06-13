using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RegisterClientService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IRegisterClientService
    {
        /// <summary>
        /// Registra e válida um usuário.
        /// </summary>
        /// <param name="name">Nome do usuário.</param>
        /// <param name="email">Email do usuário.</param>
        /// <param name="mobilephonenumber">Telefone celular do usuário.</param>
        /// <param name="phonenumber">Telefone do usuário.</param>
        /// <param name="birthdate">Data de nascimento.</param>
        /// <returns>Retorna mensagem em caso de erro de validação e nulo caso contrário.</returns>
        [OperationContract]
        string RegisterUser(string name, string email, string mobilephonenumber, string phonenumber, string birthdate);

    }
}
