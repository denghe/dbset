using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SLClient {
    public partial class WaitWindow : FloatableWindow {
        public WaitWindow() {
            InitializeComponent();
        }
        private Action _cancelAction = null;
        public WaitWindow(string title = null, Action cancelAction = null)
            : this() {
            if (title != null) this.Title = title;
            if (cancelAction == null) {
                this.CancelButton.Visibility = System.Windows.Visibility.Collapsed;
            } else {
                _cancelAction = cancelAction;
            }
        }

        //private void OKButton_Click(object sender, RoutedEventArgs e) {
        //    this.DialogResult = true;
        //}

        private void CancelButton_Click(object sender, RoutedEventArgs e) {
            if (_cancelAction != null) _cancelAction();
            this.DialogResult = false;
        }
    }
}

