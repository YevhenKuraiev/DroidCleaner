using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.App.Usage;
using Android.Content.PM;

namespace DroidCleaner.Apps
{
    class AppsService
    {
        private List<InstalledAppModel> _installedApps;

        public Task<List<InstalledAppModel>> GetInstalledApps(PackageManager packageManager, StorageStatsManager storageStatsManager)
        {
            return Task.Run(() =>
            {
                var apps = Application.Context.PackageManager.GetInstalledApplications(PackageInfoFlags.MetaData);
                _installedApps = new List<InstalledAppModel>();
                if (apps?.Count > 0)
                {
                    for (int i = 0; i < apps.Count; i++)
                    {
                        var info = packageManager.GetPackageInfo(apps[i].PackageName, 0);
                        if (isSystemPackage(info) == false)
                        {
                            ApplicationInfo ai = packageManager.GetApplicationInfo(apps[i].PackageName, 0);
                            StorageStats storageStats = storageStatsManager.QueryStatsForUid(ai.StorageUuid, ai.Uid);
                            var installapps = new InstalledAppModel
                            {
                                AppName = apps[i].LoadLabel(Application.Context.PackageManager),
                                CacheSize = (storageStats.CacheBytes / 1024).ToString(),
                                Icon = apps[i].LoadIcon(Application.Context.PackageManager)
                            };
                            _installedApps.Add(installapps);
                        }
                    }
                }
                return _installedApps;
            });
        }

        private bool isSystemPackage(PackageInfo pkgInfo)
        {
            return (pkgInfo.ApplicationInfo.Flags & ApplicationInfoFlags.System) != 0;
        }


    }
}