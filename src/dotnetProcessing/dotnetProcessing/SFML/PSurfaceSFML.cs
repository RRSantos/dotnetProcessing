using dotnetProcessing.Core;
using SFML.Graphics;
using SFML.Window;
using System;

namespace dotnetProcessing.SFML
{
    class PSurfaceSFML : IPSurface
    {
        private int width = IPSurface.MIN_WINDOW_WIDTH; 
        private int height = IPSurface.MIN_WINDOW_HEIGHT;
        private uint framerate = IPSurface.DEFAULT_FRAME_RATE;

        private bool isThreadStopped = true;
        private bool refreshPending = false;

        private RenderWindow window;
        
        private Sketch internalSketch;
        private readonly PGraphicsSFML graphicsSFML;

        private string title = "Untitled window";


        private void attachEventsToWindow()
        {
            window.Closed += Window_Closed;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            window.Close();
        }

        private void createWindow()
        {
            VideoMode video = new VideoMode((uint)width, (uint)height);
            window = new RenderWindow(video, title, Styles.Default);
            attachEventsToWindow();
            graphicsSFML.SetWindow(window);
            window.SetFramerateLimit(framerate);
        }

        public PSurfaceSFML(PGraphicsSFML graphicsSFML)
        {
            this.graphicsSFML = graphicsSFML;
            createWindow();
        }
        public object GetNative()
        {
            return window;
        }

        public void HideCursor()
        {
            throw new NotImplementedException();
        }

        public void InitFrame(Sketch sketch)
        {
            internalSketch = sketch;
        }

        public void InitOffscreen(Sketch sketch)
        {
            internalSketch = sketch;
        }

        public bool IsStopped()
        {
            return isThreadStopped;
        }

        public void PauseThread()
        {
            throw new NotImplementedException();
        }

        public void PlacePresent(int stopColor)
        {
            throw new NotImplementedException();
        }

        public void PlaceWindow(int[] location, int[] editorLocation)
        {
            throw new NotImplementedException();
        }

        public void ResumeThread()
        {
            throw new NotImplementedException();
        }

        public void SetAlwaysOnTop(bool alwaysOnTop)
        {
            throw new NotImplementedException();
        }

        public void SetCursor(int kind)
        {
            throw new NotImplementedException();
        }

        public void SetCursor(PImage image, int hotspotX, int hotspotY)
        {
            throw new NotImplementedException();
        }

        public void SetFrameRate(float fps)
        {
            window.SetFramerateLimit((uint)fps);
        }

        public void SetIcon(PImage icon)
        {
            throw new NotImplementedException();
        }

        public void SetLocation(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void SetResizable(bool resizable)
        {
            throw new NotImplementedException();
        }

        public void SetSize(int width, int height)
        {
            this.width = width;
            this.height = height;

            if (window != null)
            {
                window.Dispose();
            }

            createWindow();
            
        }

        public void SetTitle(string title)
        {
            this.title = title;
            if (window != null)
            {
                window.SetTitle(this.title);
            }
            
            
        }

        public void SetupExternalMessages()
        {
            throw new NotImplementedException();
        }

        public void SetVisible(bool visible)
        {
            window.SetVisible(visible);
        }

        public void ShowCursor()
        {   
            throw new NotImplementedException();
        }

        public void StartThread()
        {
            internalSketch.Setup();
            isThreadStopped = false;            

            while (!isThreadStopped && window.IsOpen)
            {
                window.DispatchEvents();
                graphicsSFML.BeginDraw();
                internalSketch.Draw();
                if (refreshPending)
                {
                    window.Display();
                    refreshPending = false;                    
                }
                graphicsSFML.EndDraw();
            }

        }

        public bool StopThread()
        {            
            isThreadStopped = true;
            return isThreadStopped;
        }

        public void RefreshNeeded()
        {
            refreshPending = true;
        }

        
    }
}
