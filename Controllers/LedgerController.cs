using ASPNET7MVCCRUD.Data;
using ASPNET7MVCCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ASPNET7MVCCRUD.Controllers
{
    public class LedgerController : Controller
    {
        #region Dependency Injection
        /* เราจะทำการสร้าง object จาก ApplicationDBContext ซึ่งเป็นรูปแบบของ "Dependency Injection"
         * ซึ่งก็คือการสร้างตัวแทนของ database ขึ้นมาเพื่อที่จะนำมาใช้ใน controller นั่นเอง
         */
        private readonly ApplicationDBContext _dbContext;
        /* ซึ่ง _dbContext ตัวนี้มีการทำงานกับ database และก็มีตารางที่นำไปสร้าง database ก็คือ DbSet<> เป็น Entity ซึ่งใน <> เอาามาจาก Model ex.ApplicationDBContext.cs Line 28
         * ApplicationDBContext มีการตั้งค่าการทำงานใน program.cs คือระบุว่าจะใช้บริการของ SqlServer และเชื่อมต่อไปยัง ConnectionString ที่มีชื่อว่า DefaultConnection
         * ที่นี้การที่จะเรียกใช้งาน database พวกนี้มันมีความซับซ้อนก็คือถ้าเรียกใช้ผ่านตัว ApplicationDBContext เลยเราต้องมาตั้งค่าหลายอย่างมาก ก็เลยใช้ตัว  "Dependency Injection"
         * ก็คือสร้างตัวแทนของ database ขึ้นมาแล้วก็เรียกใช้งานใน controller ในตอนเริ่มต้นเลย ก้เลยมีการระบุ Object จาก ApplicationDBContext ในพื้นที่ของ LedgerController เลย
         */

        /* จากนั้นก็สร้าง constructor of Controller ขึ้นมาเพื่อบอกว่า controller  ตัวนี้เมื่อมีการ run ขึ้นมาจะให้กำหนดค่า ApplicationDBContext ลงไปดลยที่ตัวแปร _dbContext
         */
        public LedgerController(ApplicationDBContext db)
        {
            _dbContext = db;
        }
        /*นี่คือ structure of ApplicationDBContext ที่ถูกนำมาใช้ในพื้นที่ของ LedgerController ซึ่งเราเรียกส่วนนี้ว่า "Dependency Injection"
         * เพราะฉะนั่นเราก็เข้าถึงตารางที่อยู่ใน database ผ่านตัวแปร _dbContext ได้
         * ซึ่งตัวแปร _dbContext คือ object จาก ApplicationDBContext so ทำให้เราเข้ามาทำงานใน DbSet<> Entity ที่มีชื่อว่า Data ได้
        */
        #endregion

        #region Save Data
        /*การบันทึกข้อมูลตาม step: 
         * นำข้อมูลจาก form มาทำงานที่ตัว controller แล้วเรียกใช้ตัว model ที่เชื่อมต่อไปยัง Database
         * Step1: โยนข้อมูลจาก form มาที่ controller
         * Step2: แล้วก็นำข้อมูลดังกล่าวไปเก็บใน database ในตารางที่เชื่อมต่อกับ model นั่นเอง
         */
        #endregion

        public IActionResult Main()
        {
            //return Contec("Page Main");
            IEnumerable<Revenue_ExpenseModel> TableFinancial = _dbContext.Financial;
            return View(TableFinancial);        
        }

        public IActionResult Revenue() 
        {
            //return View();
            #region Example object from Revenue_Expense Model
            /*
            //ข้อมูลพวกนี้เป็น object from Revenue_ExpenseModel ที่มีการสร้างขึ้นมาใน function method of Revenue
            Revenue_ExpenseModel financial = new Revenue_ExpenseModel();
            financial.Id = 10001;
            financial.Date = DateTime.Now;
            financial.Item = "Coke";
            financial.Revenue = 0;
            financial.Expense = 20;

            Revenue_ExpenseModel financial_1 = new Revenue_ExpenseModel();
            financial_1.Id = 10000;
            financial_1.Date = DateTime.Now;
            financial_1.Item = "Dimsum";
            financial_1.Revenue = 0;
            financial_1.Expense = 129;

            //บรรจุ object ที่ถูกสร้างขึ้นจาก class Revenue_Expense เป็นรูปแบบ List
            List<Revenue_ExpenseModel> allFinancial = new List<Revenue_ExpenseModel>();
            allFinancial.Add(financial);
            allFinancial.Add(financial_1);
            

            return View(allFinancial);
            //next to import Model Revenue_Expense into view of Main
            */
            #endregion

            IEnumerable<Revenue_ExpenseModel> allFinancial = _dbContext.Financial; //Method ในการดึงข้อมูลจากตาราง Financial ทั้งหมดมาเก็บไว้ใน allFinancial
            //data มีมากกว่า 1 ชุดหรือมากกว่า 1 object จึงต้องใช้ IEumerable ในการรวมให้เป็นกลุ่ม object ที่ดึงมาจาก database แล้วนำมาใช้งาน
            return View(allFinancial);
        }
        #region HttpGET
        //Http Get
        public IActionResult CreateTable()
        {
            return View();
        }
        //Default is GET Method because เวลาที่เราเรียกใช้ action method CreateTable() ตัวนี้ให้แสดงผล View() ออกมา
        //สรุปคือ ไม่ได้มีการส่งข้อมูลมาระหว่างทางแต่ว่าจะรับหน้าที่ในการแสดงหน้าเว็ปเพจของเรา หรือแสดงผล View() นั่นเอง
        #endregion

        #region HttpPOST
        //แล้ว POST Method ล๊ะ? -> POST Method ต้องมีการระบุ parameter สำหรับรับค่าจาก form มาใช้งาน
        //สรุปคือ POST Method ทำหน้าที่รับข้อมูลจาก View() มาใช้งานในจัว Controller นั่นเอง
        //ถ้าส่งเป็น POST ก็จะมี [HttpPost] และมี [ValidateAntiForgeryToken] พ่วงมาด้วย
        [HttpPost]
        [ValidateAntiForgeryToken] //Attibute
        public IActionResult CreateTable(Revenue_ExpenseModel obj)
        {
            if (ModelState.IsValid) //คือ ตอนที่มีการบันทึกข้อมูลลงในฐานข้อมูลต้องมีการตรวจสอบด้วยนะครับว่า
                                    //"Model ของเรามีการตรวจสอบความถูกต้องของข้อมูลเรียบร้อยแล้ว" ซึ่งเอามาจาก object Revenue_ExpenseModel ก็คือ obj
                                    //จะช่วยในการตรวจสอบเงื่อนไขจาก Data Annotation
            {
                _dbContext.Add(obj);
                _dbContext.SaveChanges();
                return RedirectToAction("Main"); //ให้วิ่งกลับไปที่ action method ที่ชื่อว่า Main หลังจาก Save Data
            }
            return View(obj);//ถ้าทำงานไม่ถูกต้องให้ส่ง object กลับไปที่ form ซ้ำ
        }
        #endregion

        // int? (sign is ? หลัง int คือแปลว่าเป็นค่าว่างหรือการกำหนดให้เป็น null = optional parameter) 
        public IActionResult EditTable(int? id)
        {
            /*สิ่งที่เราต้องการคือ เมื่อมีการกดที่ปุ่ม Edit บนเว็ปวึ่งก็คือเป็นการส่ง id มายัง EditTable() method 
             * และนำไปค้นที่ database ว่ามี data ของ id นี้อยู่ไหมตามเลข id ที่ส่งมา 
             * ถ้าเจอก็ให้ส่งข้อมูลนั้นไปแสดงที่ EditTable.cshtml และ .cshtml จะรับหน้าที่ในการแสดงข้อมูลของ id นั้นออกมา
             */
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var Editobj = _dbContext.Financial.Find(id); //Find data in database by id

            if (Editobj == null)
            {
                return NotFound();
            }
            return View(Editobj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult EditTable(Revenue_ExpenseModel obj)
        {
            if (ModelState.IsValid) 
            {
                _dbContext.Update(obj); // update data of table
                _dbContext.SaveChanges();
                return RedirectToAction("Main"); 
            }
            return View(obj);//ถ้าทำงานไม่ถูกต้องให้ส่ง object กลับไปที่ form ซ้ำ
        }

        public IActionResult Delete(int? Id) 
        {
            if(Id == null || Id == 0) 
            { 
                return NotFound(); 
            }
            var DelObj = _dbContext.Financial.Find(Id); //ไปหาข้อมูลมาก่อนแล้วค่อยไป Delete Data
            if (DelObj == null) {
                return NotFound(); 
            } 
            _dbContext.Financial.Remove(DelObj); //ถ้าเจอข้อมูลมาได้ก็ให้ remove
            _dbContext.SaveChanges(); //แล้วก็ save
            return RedirectToAction("Main");

        }
    }
}
