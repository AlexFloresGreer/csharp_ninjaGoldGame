using Nancy;
using System;
using System.Collections.Generic;

namespace HelloNancy
{
    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
// _________________GET__________________
            Get("/", args =>
            {
                if ( Session["gold"] == null )
                {
                    Session["gold"] = 0;
                }

                ViewBag.gold = Session["gold"];
                ViewBag.activities = Session["activities"];
                return View["Hello"];
            });     
// _________________POST__________________

            Post("/process_money", args =>
            {
                Random earnedGold = new Random();
                string req = Request.Form.building;   
                DateTime date = DateTime.Now;

                if (req == "farm")
                {
                    int farmgold = (int)earnedGold.Next(10,21);
                    Session["gold"] = (int)Session["gold"] + farmgold;
                    Session["activities"] += $"<p>Earned {farmgold} golds from the farm! {date} </p>";
                    // return View["Hello"]; //redundant redirecting, must only redirect at the bottom since we have elseif statements
                }

                else if (req == "cave")
                {
                    int cavegold = (int)earnedGold.Next(10,21);
                    Session["gold"] = (int)Session["gold"] + cavegold;
                    Session["activities"] += $"<p>Earned {cavegold} golds from the cave! {date} </p>";

                }

                else if (req == "house")
                {
                    int housegold = (int)earnedGold.Next(10,21);
                    Session["gold"] = (int)Session["gold"] + housegold;
                    Session["activities"] += $"<p>Earned {housegold} golds from the house! {date} </p>";

                }

                else if (req == "casino")
                {
                    int casinogold = (int)earnedGold.Next(10,21);
                    Session["gold"] = (int)Session["gold"] + casinogold;
                    Session["activities"] += $"<p>Earned {casinogold} golds from the casino! {date} </p>";
                }
                
                else{
                    Console.WriteLine("Oops!");
                }

                return Response.AsRedirect("/");

            });  

            //  Post("/clear", args =>
            // {
            //     Session.DeleteAll();
            //     return Response.AsRedirect("/");
            // });
        }
    }
}