using Lesson2;

try
{
    var f = new SimpleThreadPool(5);
    for (int i = 0; i < 50; i++) {
        var arg = i;
        f.AddTask(() => Console.WriteLine(arg));
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
