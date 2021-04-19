using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace BilibiliDownLoadFileRename
{
    class Program
    {
        static void Main(string[] args)
        {

            DirectoryInfo folder = new DirectoryInfo(@"./");
            DirectoryInfo[] fileDirectories = folder.GetDirectories();

            if (!Directory.Exists("./重命名后的视频"))
            {
                Directory.CreateDirectory("./重命名后的视频/");
            }

            

            foreach (var item in fileDirectories)
            {
                if (item.Name == "重命名后的视频")
                {
                    continue;
                }
                DirectoryInfo childfolder = new DirectoryInfo(item.FullName);
                FileInfo[] files = childfolder.GetFiles();



                string info = "";
                foreach (var file in files)
                {
                    // 读取info文件获取文件名
                    
                    if (file.Extension == ".info")
                    {
                        info = File.ReadAllText(file.FullName);
                        JObject json = JObject.Parse(info);
                        info = json["PartName"].ToString()+".mp4";
                    }
                    // 复制视频文件到新的目录
                    if (file.Extension == ".mp4")
                    {
                        string targetDirectory = Path.GetFullPath("./重命名后的视频");
                        string sourceFile = Path.Combine(file.DirectoryName, file.Name);
                        string targetFile = Path.Combine(targetDirectory, info);
                        File.Copy(sourceFile, targetFile, true);
                    }

                }

            }

            
        }
    }
}
