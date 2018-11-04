using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace DroidCleaner.Apps
{
    class AppAdapterViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView Name { get; set; }
        public TextView CacheSize { get; set; }

        public AppAdapterViewHolder(View itemView) : base(itemView)
        {
            Image = itemView.FindViewById<ImageView>(Resource.Id.appImageView);
            Name = itemView.FindViewById<TextView>(Resource.Id.appNameTextView);
            CacheSize = itemView.FindViewById<TextView>(Resource.Id.cacheSizeTextView);
            
        }
    }
}