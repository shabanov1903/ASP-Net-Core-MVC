using Autofac;
using Lesson6.Scaner;

string file = @"D:\Programming\Testing\test.txt";
string path = @"D:\Programming\Testing\TestDirectory";

var builder = new ContainerBuilder();
builder.RegisterType<Scanner>().As<IScanning>();
builder.RegisterType<ScanToTxt>().Keyed<ISaver>("txt");
builder.RegisterType<ScanToHtml>().Keyed<ISaver>("html");
builder.RegisterType<ScanToRtf>().Keyed<ISaver>("rtf");

IContainer container = builder.Build();

var saver = container.ResolveKeyed<ISaver>("rtf");

var scanner = new ScannerManager(saver);
scanner.StartScan(file, path);
