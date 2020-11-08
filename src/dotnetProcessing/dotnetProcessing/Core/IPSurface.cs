using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetProcessing.Core
{
    public interface IPSurface
    {
        static int MIN_WINDOW_WIDTH = 128;
        static int MIN_WINDOW_HEIGHT = 128;
        static uint DEFAULT_FRAME_RATE = 60;
        static string DEFAULT_WINDOW_TITLE = "Untitled window";

        void InitOffscreen(Sketch sketch);

        void InitFrame(Sketch sketch);

        object GetNative();

        void SetTitle(string title);

        void SetVisible(bool visible);

        void SetResizable(bool resizable);

        void SetAlwaysOnTop(bool alwaysOnTop);

        void SetIcon(PImage icon);

        void PlaceWindow(int[] location, int[] editorLocation);
        
        void PlacePresent(int stopColor);
        
        void SetupExternalMessages();

        void SetLocation(int x, int y);

        void SetSize(int width, int height);

        void SetFrameRate(float fps);

        void SetCursor(int kind);

        void SetCursor(PImage image, int hotspotX, int hotspotY);

        void ShowCursor();

        void StartThread();

        void HideCursor();

        void PauseThread();

        void ResumeThread();
        
        bool StopThread();

        bool IsStopped();

        void RefreshNeeded();
        
    }
}
