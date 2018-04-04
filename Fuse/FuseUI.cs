﻿using Fuse.Windows;

namespace Fuse
{
    internal class FuseUI
    {
        private ClientWindow _Window;
        private FuseClient _Client;

        internal FuseUI(FuseClient client)
        {
            this._Client = client;
            this._Window = new ClientWindow(client);
        }

        internal void ShowLogin(string user=null,string pass=null)
        {
            LoginWindow win = new LoginWindow(this._Client);
            win.TBUserName.Text = user;
            win.PBPassword.Password = pass;
            win.Show();
        }

        internal void ShowException(string msg)
        {
            ExceptionWindow ewin = new ExceptionWindow(msg);
            ewin.ShowDialog();
        }

        internal ClientWindow ClientWindow { get => _Window; }
    }
}
