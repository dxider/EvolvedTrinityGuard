using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace pryEvolvedTrinityGuard.Classes
{
    
    public class SandboxServer : IDisposable
    {
        public delegate void OutputRead(string output);
        public event OutputRead CommandOutput;
        private Process _process;

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public void Execute(string filePath, string arguments){
            //if(_process==null)
            //{
            //    throw new Exception("Already watching process");
            //}
            _process= new Process();
            _process.Exited += new EventHandler(_process_Exited);
            _process.OutputDataReceived += new DataReceivedEventHandler(_process_OutputDataReceived);
            _process.StartInfo.FileName = filePath;
            _process.StartInfo.UseShellExecute = false;
            _process.StartInfo.RedirectStandardInput=true;
            _process.StartInfo.RedirectStandardOutput=true;
            _process.StartInfo.Arguments = arguments;
            
            _process.Start();
            _process.BeginOutputReadLine();
            System.Threading.Thread.Sleep(500);
            ShowWindow(_process.MainWindowHandle, 0);
        }

        private void _process_Exited(object sender, System.EventArgs e)
        {
            _process.Dispose();
            _process = null;
        }

        public SandboxServer()
        {
            
        }

        void _process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (_process != null)
            {
                if (_process.HasExited)
                {
                    _process.Dispose();
                    _process = null;
                }
            }
            CommandOutput(e.Data);
        }

        public void PostCommand(string command)
        {
            if (_process != null)
            {
                _process.StandardInput.WriteLine(command);
            }
        }

        private bool disposedValue = false;

        protected void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    if (_process != null)
                    {
                        _process.Kill();
                        _process.Dispose();
                        _process = null;
                    }
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            _process.Dispose();
            _process = null;
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}