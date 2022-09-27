using Lesson7.Reporter;
using Lesson7.Reporter.Elements;

string path = @"C:\Users\dvshabanov\Desktop\Programming\DriveInfo.txt";
var reporter = new ReporterManager(path);
reporter.AddPart(new Header("DrivesInfo"));

DriveInfo[] allDrives = DriveInfo.GetDrives();
foreach (DriveInfo d in allDrives)
{
    reporter.AddPart(new Body($"Drive", d.Name))
            .AddPart(new Body($"Drive type", d.DriveType.ToString()));

    if (d.IsReady == true)
    {
        reporter.AddPart(new Body($"Volume label", d.VolumeLabel))
                .AddPart(new Body($"File system", d.DriveFormat))
                .AddPart(new Body($"Available space to current user (bytes)", d.AvailableFreeSpace.ToString()))
                .AddPart(new Body($"Total available space (bytes)", d.TotalFreeSpace.ToString()))
                .AddPart(new Body($"Total size of drive (bytes)", d.TotalSize.ToString()));
    }
}

reporter.Start();