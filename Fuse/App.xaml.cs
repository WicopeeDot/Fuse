﻿using System.Windows;

namespace Fuse
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal App()
        {
            FuseClient client = new FuseClient();
            client.Start();
        }
    }
}