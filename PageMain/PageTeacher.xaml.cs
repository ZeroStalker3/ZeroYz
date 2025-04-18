﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZeroYz.DataFilesApp;
using ZeroYz.Teacher;

namespace ZeroYz.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageTeacher.xaml
    /// </summary>
    public partial class PageTeacher : Page
    {
        public PageTeacher()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageAddStudent());
        }

        private void BtnAddEvaluation_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageEvaluation());
        }

        private void BtnListStudent_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageListStudent());
        }

        private void EditEval_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageEditEval());
        }

        private void BtnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageDeleteStudent());
        }

        private void MVC_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new ZeroYz.MVC.PageMVC());   
        }
    }
}
