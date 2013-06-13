using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
using System.Data.Entity;

namespace RegisterClientService
{
    /// <summary>
    /// Classe que define o usuário.
    /// </summary>
    public class User 
    {

        #region  Constructors

        /// <summary>
        /// Costrutor padrão.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="mobilephonenumber"></param>
        /// <param name="phonenumber"></param>
        /// <param name="birthdate"></param>
        public User(string name, string email, string mobilePhoneNumber, string phoneNumber, DateTime birthDate)
        {
            Name = name;
            Email = email;
            MobilePhoneNumber = mobilePhoneNumber;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Id do usuário.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do usuário.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email do usuário.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Telefone celular do usuário.
        /// </summary>
        public string MobilePhoneNumber { get; set; }

        /// <summary>
        /// Telefone do usuário.
        /// </summary>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// Data de nascimento.
        /// </summary>
        public DateTime BirthDate { get; set; }

        #endregion

    }
    
}