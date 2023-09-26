﻿using FootccerClient.Footccer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            App.Instance.LoginForm = new LoginForm();
            App.Instance.MainForm = new MainForm();
            Application.Run(App.Instance.LoginForm);
        }
    }
}
