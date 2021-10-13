using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace AvaloniaMinimized
{
    public class App : Application
    {
        public App()
        {
            DataContext = this;
        }
        
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            // if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            // {
            //     desktop.MainWindow = new MainWindow();
            // }

            base.OnFrameworkInitializationCompleted();
        }

        private int count = 0;
        
        public void ToggleShowCommand()
        {
            count++;
            if (count == 2)
            {
                count = 0;
                return;
            }

            ToggleShow();
        }

        private void ToggleShow()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                if (desktop.MainWindow is null)
                {
                    desktop.MainWindow = new MainWindow();
                    desktop.MainWindow.WindowState = WindowState.Normal;
                    desktop.MainWindow.Show();
                    return;
                }

                if (desktop.MainWindow.WindowState == WindowState.Minimized)
                {
                    desktop.MainWindow.WindowState = WindowState.Normal;
                    desktop.MainWindow.Show();
                }
                else
                {
                    desktop.MainWindow.WindowState = WindowState.Minimized;
                    desktop.MainWindow.Hide();
                }
            }
        }
        
        private void TrayIcon_OnClicked(object? sender, EventArgs e)
        {
            ToggleShow();
        }
    }
}