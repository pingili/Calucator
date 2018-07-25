using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        List<string> review = new List<string>();
        public ActionResult Index()
        {
            {
                if (Request["txt"] != null)
                {
                    if (Request["txt"][Request["txt"].Length - 1] == '+' || Request["txt"][Request["txt"].Length - 1] == '-' || Request["txt"][Request["txt"].Length - 1] == '*' || Request["txt"][Request["txt"].Length - 1] == '/')
                    {
                        ViewBag.flag = 0;
                        ViewBag.result = Request["txt"];
                    }
                    else
                    {
                        var result = GetResult(Request["txt"]);
                        ViewBag.result = result;
                        if (TempData["review"] != null)
                        {
                            review = TempData.Peek("review") as List<string>;
                        }
                        if (review != null && review.Count <= 3)
                            review.Add(Request["txt"]);
                        TempData["review"] = review;
                        ViewBag.flag = 1;
                    }
                }
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        public string GetResult(string str)
        {
            List<string> review = new List<string>();
            List<char> symbleList = new List<char>();
            char[] charSymble = { '+', '-', '*', '/' };
            string[] st = str.Split(charSymble);
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '+' || str[i] == '-' || str[i] == '*' || str[i] == '/')
                {
                    symbleList.Add(str[i]);
                }
            }
            double result = Convert.ToDouble(st[0]);
            for (int i = 1; i < st.Length; i++)
            {
                double num = Convert.ToDouble(st[i]);
                int j = i - 1;
                switch (symbleList[j])
                {
                    case '+':
                        result = result + num;
                        break;
                    case '-':
                        result = result - num;
                        break;
                    case '*':
                        result = result * num;
                        break;
                    case '/':
                        result = result / num;
                        break;
                    default:
                        result = 0.0;
                        break;
                }
            }


            return result.ToString();
        }
    }
}