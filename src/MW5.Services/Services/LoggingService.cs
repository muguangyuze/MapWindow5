﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using MW5.Services.Services.Abstract;

namespace MW5.Services.Services
{
    internal class LoggingService: ILoggingService
    {
        private readonly IAppContext _context;

        public LoggingService(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        void Api.Interfaces.IApplicationCallback.Error(string tagOfSender, string errorMsg)
        {
            Debug.Print("Error reported: " + errorMsg);
        }

        void Api.Interfaces.IApplicationCallback.Progress(string tagOfSender, int percent, string message)
        {
            _context.StatusBar.ShowProgress(message, percent);
        }

        public void ClearProgress()
        {
            _context.StatusBar.HideProgress();
        }
    }
}
