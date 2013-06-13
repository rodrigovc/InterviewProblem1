﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RegisterClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Ocorre no início da aplicação.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //Cria visão da tela.
            var window = new MainView();
            //Cria o modelo de dados.
            var viewmodel = new MainViewModel();
            //Define o modelo de dados como contexto de dados da visão.BB
            window.DataContext = viewmodel;
            window.Show();
        }
    }
}


