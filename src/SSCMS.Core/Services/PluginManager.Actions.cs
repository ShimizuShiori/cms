﻿using SSCMS.Core.Plugins;
using SSCMS.Utils;

namespace SSCMS.Core.Services
{
    public partial class PluginManager
    {
        public void Install(string pluginId, string version)
        {
            var packagesPath = PathUtils.Combine(_settingsManager.ContentRootPath, DirectoryUtils.Packages);
            var pluginPath = PathUtils.Combine(_directoryPath, pluginId);

            var zipFilePath = CloudUtils.Dl.DownloadPlugin(packagesPath, pluginId, version);
            ZipUtils.ExtractZip(zipFilePath, pluginPath);
        }

        public void UnInstall(string pluginId)
        {
            var pluginPath = PathUtils.Combine(_directoryPath, pluginId);
            try
            {
                DirectoryUtils.DeleteDirectoryIfExists(pluginPath);
            }
            catch
            {
                DirectoryUtils.DeleteDirectoryIfExists(pluginPath);
            }
        }
    }
}
