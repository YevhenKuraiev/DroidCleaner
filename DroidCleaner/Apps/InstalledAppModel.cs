using Android.Graphics.Drawables;

namespace DroidCleaner.Apps
{
    class InstalledAppModel
    {
        public string AppName { get; set; }
        public string CacheSize { get; set; }
        public Drawable Icon { get; set; }
    }
}