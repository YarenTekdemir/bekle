using bekle.Services.Data;
using bekle.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Web.Mvc;
using System.IO;
using System.Diagnostics;

namespace bekle.Controllers
{
    public class AttackController : Controller


    {
        static string userName = Environment.UserName; //bilgisayar adını alıyor

    public List<Attackaccount> GetAttacks() //db den attack bilgisini alıyor listeye koyup fonksiyona yolluyo.
        {
            AttackdtaController getData = new AttackdtaController();
            List<Attackaccount> attacks = new List<Attackaccount>(); 
            attacks.Add(getData.getAttack("T1056"));
            attacks.Add(getData.getAttack("T1217"));
           
            return attacks;
        } 

        public ActionResult Index()     
                    
        {
            ViewBag.attacks = GetAttacks(); //controllerda viewa veri yollamaya yarıyo
            return View("Attack");

        }


        public ActionResult Download(string ID)
        {
           

                AttackdtaController attackData = new AttackdtaController();
                Attackaccount attack = attackData.getAttack(ID);
                string file = attack.test_location;
                string contentType = "application/exe";
                return File(file, contentType, Path.GetFileName(file));
           

        }
        public ActionResult runAttack(string ID)
        {
            AttackdtaController attackData = new AttackdtaController();
            Attackaccount attack = attackData.getAttack(ID);
            string location = "C:\\Users\\" + userName + "\\Downloads\\" + attack.test_id + ".exe";
                  if (System.IO.File.Exists(location))
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = location;
                info.Arguments = "";
                info.WindowStyle = ProcessWindowStyle.Normal;
                info.WorkingDirectory = Path.GetDirectoryName(location);
                Process p = Process.Start(info);
                p.StartInfo.UseShellExecute = false;
                ViewBag.ErrorMessage = "";
                string resultLocation;
               
                resultLocation = "C:\\Users\\"+userName+ "\\Mitre Attack\\" + attack.test_id +"\\Results.txt";


                string attackResult;
                do
                {
                    try
                    {
                        attackResult = System.IO.File.ReadAllText(resultLocation, Encoding.UTF8);
                        break;
                    }
                    catch
                    {
                        continue;
                    }
                } while (true);
               
                attackData.insertTest(attack, attackResult);

            }
            else
            {

            }

            ViewBag.attacks = GetAttacks();
            return View("Attack");
        }
    }
}
