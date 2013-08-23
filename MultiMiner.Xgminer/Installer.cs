﻿using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace MultiMiner.Xgminer
{
    public static class Installer
    {

        public static void InstallMiner(MinerBackend minerBackend, string destinationFolder)
        {
            //support Windows and OS X for now, we'll go for Linux in the future
            if (OSVersionPlatform.GetConcretePlatform() == PlatformID.Unix)
                throw new NotImplementedException();

            string minerUrl = GetMinerDownloadUrl(minerBackend);

            if (!String.IsNullOrEmpty(minerUrl))
            {
                string minerDownloadFile = Path.Combine(Path.GetTempPath(), "miner.zip");
                File.Delete(minerDownloadFile);

                new WebClient().DownloadFile(new Uri(minerUrl), minerDownloadFile);
                try
                {
                    UnzipFileToFolder(minerDownloadFile, destinationFolder);
                }
                finally
                {
                    File.Delete(minerDownloadFile);
                }
            }
        }

        public static string GetAvailableMinerVerison(MinerBackend minerBackend)
        {
            string version = String.Empty;

            string minerDownloadUrl = GetMinerDownloadUrl(minerBackend);            
            const string pattern = @".+/.+-(.+)-.+\..+$";
            Match match = Regex.Match(minerDownloadUrl, pattern);
            if (match.Success)
                version = match.Groups[1].Value;

            return version;
        }

        public static string GetInstalledMinerVerison(MinerBackend minerBackend, string executablePath)
        {
            string version = String.Empty;

            ProcessStartInfo startInfo = new ProcessStartInfo(executablePath, "--version");

            startInfo.UseShellExecute = false;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;

            startInfo.Arguments = startInfo.Arguments + " --disable-gpu";

            if (minerBackend == MinerBackend.Cgminer)
            {
                //otherwise it still requires OpenCL.dll - not an issue with bfgminer
                if (OSVersionPlatform.GetConcretePlatform() == PlatformID.Unix)
                    startInfo.FileName = startInfo.FileName + "-nogpu";
                else
                    startInfo.FileName = executablePath.Replace("cgminer.exe", "cgminer-nogpu.exe");
            }

            Process process = Process.Start(startInfo);

            string processOutput = process.StandardOutput.ReadToEnd();

            string pattern = String.Format(@"^.+ (.+\..+){0}", Environment.NewLine);
            Match match = Regex.Match(processOutput, pattern);
            if (match.Success)
                version = match.Groups[1].Value;

            return version;
        }

        private static string GetMinerDownloadUrl(MinerBackend minerBackend)
        {
            string result = String.Empty;

            if (minerBackend == MinerBackend.Cgminer)
                result = GetCgminerDownloadUrl();
            else if (minerBackend == MinerBackend.Bfgminer)
                result = GetBfgminerDownloadUrl();

            return result;
        }

        private static string GetBfgminerDownloadUrl()
        {
            if (OSVersionPlatform.GetConcretePlatform() == PlatformID.MacOSX)
                return GetBfgminerMacOSXDownloadUrl();
            else
                return GetBfgminerWindowsDownloadUrl();
        }

        private static string GetBfgminerWindowsDownloadUrl()
        {
            string downloadRoot = GetMinerDownloadRoot(MinerBackend.Bfgminer);
            const string downloadPath = "/programs/bitcoin/files/bfgminer/testing/";
            string availableDownloadsHtml = new WebClient().DownloadString(String.Format("{0}{1}", downloadRoot, downloadPath));
            const string pattern = @".*<a href=""(bfgminer-.+?-win32.zip)";
            Match match = Regex.Match(availableDownloadsHtml, pattern);
            if (match.Success)
            {
                string minerFileName = match.Groups[1].Value;
                string minerUrl = String.Format("{0}{1}{2}", downloadRoot, downloadPath, minerFileName);
                return minerUrl;
            }

            return "";
        }
        
        private static string GetBfgminerMacOSXDownloadUrl()
        {
            return GetXgminerDownloadUrl("bfgminer");
        }

        private static string GetXgminerDownloadUrl(string minerName)
        {
            string downloadUrl = String.Empty;

            string downloadRoot = GetMinerDownloadRoot(MinerBackend.Bfgminer);
            const string downloadPath = "/releases/";
            string availableDownloadsHtml = new WebClient().DownloadString(String.Format("{0}{1}", downloadRoot, downloadPath));
            string pattern = String.Format(@".*<a href="".+/xgminer-osx/releases/(.+/{0}-.+?-osx64.tar.gz)", minerName);
            Match match = Regex.Match(availableDownloadsHtml, pattern);
            if (match.Success)
            {
                string minerFileName = match.Groups[1].Value;
                downloadUrl = String.Format("{0}{1}{2}", downloadRoot, downloadPath, minerFileName);
            }

            return downloadUrl;
        }

        private static string GetCgminerDownloadUrl()
        {
            if (OSVersionPlatform.GetConcretePlatform() == PlatformID.MacOSX)
                return GetCgminerMacOSXDownloadUrl();
            else
                return GetCgminerWindowsDownloadUrl();
        }

        public static string GetMinerDownloadRoot(MinerBackend minerBackend)
        {
            if (OSVersionPlatform.GetConcretePlatform() == PlatformID.MacOSX)
                return "http://github.com/nwoolls/xgminer-osx";
            else
            {
                if (minerBackend == MinerBackend.Bfgminer)
                    return "http://eligius.st/~luke-jr";
                else
                    return "http://ck.kolivas.org";
            }
        }

        private static string GetCgminerMacOSXDownloadUrl()
        {
            return GetXgminerDownloadUrl("cgminer");
        }

        private static string GetCgminerWindowsDownloadUrl()
        {
            string downloadRoot = GetMinerDownloadRoot(MinerBackend.Cgminer);
            const string downloadPath = "/apps/cgminer/";
            string availableDownloadsHtml = new WebClient().DownloadString(String.Format("{0}{1}", downloadRoot, downloadPath));
            const string pattern = @".*<a href=""(cgminer-.+?-windows.zip)";
            Match match = Regex.Match(availableDownloadsHtml, pattern);
            if (match.Success)
            {
                string minerFileName = match.Groups[1].Value;
                string minerUrl = String.Format("{0}{1}{2}", downloadRoot, downloadPath, minerFileName);
                return minerUrl;
            }

            return "";
        }

        private static void UnzipFileToFolder(string zipFilePath, string destionationFolder)
        {
            Directory.CreateDirectory(destionationFolder);

            if (OSVersionPlatform.GetGenericPlatform() == PlatformID.Unix)
                UnzipFileToFolderUnix(zipFilePath, destionationFolder);
            else
                UnzipFileToFolderWindows(zipFilePath, destionationFolder);
        }

        private static void UnzipFileToFolderUnix(string zipFilePath, string destionationFolder)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "tar";
            startInfo.Arguments = String.Format("-xzvf \"{0}\" -C \"{1}\" --strip-components=1", zipFilePath, destionationFolder);
            
            Process process = Process.Start(startInfo);
            process.WaitForExit();
        }

        private static void UnzipFileToFolderWindows(string zipFilePath, string destionationFolder)
        {
            const bool showProgress = false;
            const bool yesToAll = true;

            Shell32.Folder sourceFolder = GetShell32NameSpace(zipFilePath);
            Directory.CreateDirectory(destionationFolder);
            Shell32.Folder destinationFolder = GetShell32NameSpace(destionationFolder);
            Shell32.FolderItems sourceFolderItems = sourceFolder.Items();
            Shell32.FolderItem rootItem = sourceFolderItems.Item(0);

            int options = 0;
            if (!showProgress)
                options += 4;
            if (yesToAll)
                options += 16;

            destinationFolder.CopyHere(((Shell32.Folder)rootItem.GetFolder).Items(), options);
        }

        //used instead of shellClass.NameSpace() for compatibility with various Windows OS's
        //http://techitongue.blogspot.com/2012/06/shell32-code-compiled-on-windows-7.html
        public static Shell32.Folder GetShell32NameSpace(Object folder)
        {
            Type shellAppType = Type.GetTypeFromProgID("Shell.Application");
            Object shell = Activator.CreateInstance(shellAppType);
            return (Shell32.Folder)shellAppType.InvokeMember("NameSpace", System.Reflection.BindingFlags.InvokeMethod, null, shell, new object[] { folder });
        }
    }
}