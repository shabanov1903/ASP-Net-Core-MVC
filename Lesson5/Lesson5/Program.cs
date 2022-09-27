using Lesson5.Scaner;

string file = @"D:\Programming\Testing\test.txt";
string path = @"D:\Programming\Testing\TestSirectory";

var scanner = new ScannerManager(new ScanToHtml(new Scanner()));
scanner.StartScan(file, path);

