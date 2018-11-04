using System.Collections.Generic;
using Android.App;
using Android.Support.V7.Widget;
using Android.Views;

namespace DroidCleaner.Apps
{
    class AppsAdapter : RecyclerView.Adapter
    {
        List<InstalledAppModel> _apps;
        Activity _activity;

        public AppsAdapter(Activity activity, List<InstalledAppModel> apps)
        {
            _apps = apps;
            _activity = activity;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var id = Resource.Layout.app_recycler_view_item;
            var itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);
            return new AppAdapterViewHolder(itemView);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = _apps[position];
            var holder = viewHolder as AppAdapterViewHolder;
            if (holder != null)
            {
                holder.Name.Text = item.AppName;
                holder.CacheSize.Text = item.CacheSize;
                holder.Image.SetImageDrawable(item.Icon);
            }
        }

        public override int ItemCount => _apps.Count;
    }
}