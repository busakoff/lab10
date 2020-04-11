using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebApplication3.Controllers
{
    public class HelloController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
        
                    
        [HttpPost]
        public IActionResult Index(string name, string surname, int day, int month, int year, int group)
        {
            
            /*Генерация ID Происходит следующим образом первые две цифры это год поступления студента 
             Затем инициалы фамилии и имени 
             Затем последние две цифры рождения
             И в самом конце две цифры порядковый номер группы*/
            
            StringBuilder id = new StringBuilder(" ");
            StringBuilder data = new StringBuilder(" ");

            char[] n = name.ToUpper().ToCharArray();
            char[] s = surname.ToUpper().ToCharArray();
            char[] y = year.ToString().ToCharArray();
            char[] g = group.ToString().ToCharArray();
                
            id.Append(g[0]);
            id.Append(g[1]);
            id.Append(s[0]);
            id.Append(n[0]);

            id.Append(y[2]);
            id.Append(y[3]);
            id.Append(g[2]);
            id.Append(g[3]);
            
            string ID = id.ToString();
            
            data.Append(surname);
            data.Append(" ");
            data.Append(name);
            data.Append(", ");
            data.Append(day);
            data.Append(".");
            data.Append(month);
            data.Append(".");
            data.Append(year);
            data.Append(", ");
            data.Append(group);
            data.Append(", ");
            data.Append(ID);
            data.Append('\n');
            
            string Data = data.ToString();

            ViewData["ID"] = ID;
            ViewData["Data"] = Data;
            
            return View();
        }
    }
}