﻿using Fuse.Models;
using SteamKit2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Fuse.Controls
{
    /// <summary>
    /// Interaction logic for FriendControl.xaml
    /// </summary>
    public partial class FriendControl : UserControl
    {
        private Dictionary<EPersonaState, SolidColorBrush> StateColors = new Dictionary<EPersonaState, SolidColorBrush>
        {
            [EPersonaState.Offline]        = Brushes.Gray,
            [EPersonaState.Online]         = Brushes.DodgerBlue,
            [EPersonaState.Away]           = Brushes.DarkOrange,
            [EPersonaState.Busy]           = Brushes.IndianRed,
            [EPersonaState.LookingToPlay]  = Brushes.DodgerBlue,
            [EPersonaState.LookingToTrade] = Brushes.DodgerBlue,
            [EPersonaState.Max]            = Brushes.DodgerBlue,
            [EPersonaState.Snooze]         = Brushes.DarkOrange,
        };

        internal FriendControl()
        {
            this.InitializeComponent();
        }

        internal void Update(Friend friend)
        {
            string name = friend.Name;
            EPersonaState state = friend.State;
            string game = friend.Game;
            BitmapImage source = friend.Avatar;

            this.IMAvatar.Source = source;

            name = name.Length >= 15 ? name.Substring(0, 15) + "..." : name;
            this.TBName.Text = name;
            if (game != null)
            {
                game = game.Length >= 20 ? game.Substring(0, 20) + "..." : game;
                this.TBState.Text = $"Playing {game}";
                this.RCState.Fill = Brushes.Green;
            }
            else
            {
                this.TBState.Text = state.ToString();
                this.RCState.Fill = StateColors[state];
            }
        }
    }
}
