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

using DAL;
using SqlLib;
//using db = DAL.Database.Tables.dbo;
//using qu = DAL.Queries.Tables.dbo;

namespace SLClient {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();

            //_ww = new WaitWindow { ParentLayoutRoot = this.LayoutRoot };
            //_wcf = new WCF1.MyServiceClient();
            //_wcf.Get_dbo_t3_Query_TSqlCompleted += new EventHandler<WCF1.Get_dbo_t3_Query_TSqlCompletedEventArgs>(_wcf_Get_dbo_t3_Query_TSqlCompleted);
            //_wcf.GetDataCompleted += new EventHandler<WCF1.GetDataCompletedEventArgs>(_wcf_GetDataCompleted);
        }

        //void _wcf_GetDataCompleted(object sender, WCF1.GetDataCompletedEventArgs e) {
        //    _ww.Close();
        //    var rows = e.Result.ToList<db.t3>();
        //    dataGrid1.ItemsSource = rows;
        //}

        //void _wcf_Get_dbo_t3_Query_TSqlCompleted(object sender, WCF1.Get_dbo_t3_Query_TSqlCompletedEventArgs e) {
        //    _ww.Close();
        //    textBox1.Text = e.Result;
        //}

        //private WCF1.MyServiceClient _wcf = null;
        //private WaitWindow _ww = null;

        //private void button1_Click(object sender, RoutedEventArgs e) {
        //    _ww.ShowDialog();
        //    var q = qu.t3.New(where: o => o.c1.Equal(1));
        //    _wcf.Get_dbo_t3_Query_TSqlAsync(q.GetBytes());
        //}

        //private void button2_Click(object sender, RoutedEventArgs e) {
        //    _ww.ShowDialog();
        //    _wcf.GetDataAsync(null);
        //}

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
