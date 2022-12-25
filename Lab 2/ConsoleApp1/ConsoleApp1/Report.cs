using Microsoft.EntityFrameworkCore;
namespace ConsoleApp1;
public class Report
{
   public  DataBase database { get; set; }
   public void WriteAllReport()
   {
       var z7 = database.Cars.Include(p => p.Stock).ToList();
       Directory.CreateDirectory("Report");
       string str = DateTime.Now.ToString("yy.MM.dd HH.mm.ss");
       string path = $@"Report\Report {str}.txt";
       using (StreamWriter stream = new StreamWriter(path, true))
       {
           stream.WriteLine("Список машин на складах");
           foreach (var p in z7)
           {
               stream.WriteLine($"{p.Name} цена:{p.Cost}");
           }
       }
   }
}