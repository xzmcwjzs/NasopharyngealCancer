﻿using MVC.Demo.SignalR.DesignPatterns.简单工厂模式;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MVC.Demo.SignalR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Chat()
        {
            ViewBag.Message = "Your SignalR page.";
            return View();
        }

        public ActionResult Demo()
        {
            ViewBag.Message = "Your Demo page.";
            return View();
        }
        public ActionResult WebApi()
        {
            ViewBag.Message = "Your WebApi page.";
            //客户端对象的创建与初始化
            using (HttpClient client = new HttpClient())
            {
                 client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //执行get操作
                HttpResponseMessage response = client.GetAsync("http://localhost:57398/api/Customer").Result;
                string temp = response.Content.ReadAsStringAsync().Result; 
                ViewBag.json = temp;
            }  
            return View();
        }

        #region 23中设计模式调用action
        public ActionResult DesignPattern()
        {
            ViewBag.Message = "Your DesignPattern page.";
            DesignPatterns.单例模式.MultiThread_Singleton singleton = DesignPatterns.单例模式.MultiThread_Singleton.Instance;
            var str = singleton.test();
            ViewBag.test = str;
            return View();
        }
        public ActionResult Singleton(string id)
        {
            DesignPatterns.单例模式.MultiThread_Singleton singleton = DesignPatterns.单例模式.MultiThread_Singleton.Instance;
            string str = singleton.test();
            return Content(str);
        } 

        public ActionResult SimpleFactory(string id)
        {
            Operation oper;
            oper = OperationFactory.CreateOperate("+");
            oper.NumberA = 5;
            oper.NumberB = 6;
            double result= oper.GetResult();
            return Content(result.ToString());
        }
        #endregion

        #region NoSql
        public ActionResult NoSql()
        {
            return View();
        } 
        public ActionResult Insert()
        {
            //string connStr = ConfigurationManager.AppSettings["MongoServerSettings"];
             
            return Content("ok");
        }
        #endregion


    }
}