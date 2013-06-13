using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RegisterClient
{
    /// <summary>
    /// Modelo de dados para view do projeto.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {

        #region Local Variables
        private string _name;
        private string _email;
        private string _mobilePhoneNumber;
        private string _phoneNumber;
        private string _birthDate;
        private string _message;
        

        private System.Windows.Input.ICommand _resgisterClientCommand;
        private RegisterClientProxy.RegisterClientServiceClient _registerClientProxy = new RegisterClientProxy.RegisterClientServiceClient();

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Commando que registra o usuário.
        /// </summary>
        public System.Windows.Input.ICommand RegisterClientCommand
        {
            get
            { 
                if (_resgisterClientCommand == null)
                    _resgisterClientCommand = new DelegateCommand(RegisterClient);
                return _resgisterClientCommand;
            }
        }

        /// <summary>
        /// Nome do usuário.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                    OnPropertyChanged("CanRegisterClient");
                }
            }
        }

        /// <summary>
        /// Email do usuário.
        /// </summary>
        public string Email 
        {
            get { return _email; }
            set 
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged("Email");
                    OnPropertyChanged("CanRegisterClient");
                }
            }
        }

        /// <summary>
        /// Telefone celular do usuário.
        /// </summary>
        public string MobilePhoneNumber
        {
            get { return _mobilePhoneNumber; }
            set
            {
                if (_mobilePhoneNumber != value)
                {
                    _mobilePhoneNumber = value;
                    OnPropertyChanged("MobilePhoneNumber");
                }
            }
        }

        /// <summary>
        /// Telefone do usuário.
        /// </summary>
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    OnPropertyChanged("PhoneNumber");
                    OnPropertyChanged("CanRegisterClient");
                }
            }
        }

        /// <summary>
        /// Data de nascimento.
        /// </summary>
        public string BirthDate
        {
            get { return _birthDate; }
            set
            {
                if (_birthDate != value)
                {
                    _birthDate = value;
                    OnPropertyChanged("BirthDate");
                    OnPropertyChanged("CanRegisterClient");
                }
            }
        }

        /// <summary>
        /// Mensagem de erro.
        /// </summary>
        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged("Message");
                }
                
            }
        }

        /// <summary>
        /// Define se o comando de registra o cliente pode ser executado.
        /// </summary>
        public bool CanRegisterClient
        {
            get
            { 
                return !string.IsNullOrEmpty(Name)
                && !string.IsNullOrEmpty(Email)
                && !string.IsNullOrEmpty(MobilePhoneNumber)
                && !string.IsNullOrEmpty(PhoneNumber)
                && !string.IsNullOrEmpty(BirthDate);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Faz a noticação que as propriedades foram alteradas para o controle de tela.
        /// </summary>
        /// <param name="property">Propriedade alterada.</param>
        protected void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        /// <summary>
        /// Registra o cliente.
        /// </summary>
        private void RegisterClient()
        {
            Message = _registerClientProxy.RegisterUser(Name, Email, MobilePhoneNumber, PhoneNumber, BirthDate);
        }

        #endregion

    }

    /// <summary>
    /// Cria um comando que delega a execução para um delegate.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        #region Local Variables

        public delegate void ExecuteMethod();
        private ExecuteMethod _meth;

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Constructors

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        /// <param name="exec"></param>
        /// <param name="cmeth"></param>
        public DelegateCommand(ExecuteMethod exec)
        {
            _meth = exec;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Define se pode executar um comando.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Executa o comando.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _meth();
        }

        #endregion

    }
}
