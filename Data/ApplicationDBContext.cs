using ASPNET7MVCCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNET7MVCCRUD.Data
{
    #region ApplicationDBContext
    /*
     * Model เป็นตัวแทนของข้อมูลที่จะนำไปเก็บในฐานข้อมูล
     * Application Dbcontext เป็นตัวแทนของฐานข้อมูลที่จะถูกนำมาใช้งานในโปรเจค ASP.Net core 
     * โดยการสร้าง class ซึ่งทำงานด้วยกันกับ Connection String ในการที่จะติดต่อกับ Database
     * DbContext -> connection String -> Database (it will create table follow model)
     */
     #endregion

    /* การที่ project จะสามารถติดต่อกับ database ได้จะดำเนินการผ่าน EntityFrameworkCore
     * โดยให้ class ApplicationDBContext สืบทอดคุณสมบัติมาจาก class DbContex*/

    public class ApplicationDBContext:DbContext
    {
        #region Options
        // DbContextOptions = เลือกว่าจะคุยกับ database แบบใดเพราะมี database หลายอันให้เลือกใช้ เช่น MySQL,PostgresSQL
        // มีการระบุ DBContextOption ในรูปแบบ ApplicationDBContext(อันนี้คือ class ของ ApplicationDBContext) โดยมีชื่อว่า options
        // แล้วโยน options ไปยัง class แม่ซึ่งก็คือ DbContext ผ่านการเรียกใช้ construtor class แม่ก็คือ base = :base(options)
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options) { 
        }
        #endregion

        #region DbSet<> Entity
        // Data คือชื่อ model และ Data คือตัวแทนของ model 
        // DbSet<Entity or Model> => DbSet<Revenue_Expense>
        // สรุป: Model Revenue_Expense เอาไปสร้างเป็นตารางเก็บไว้ในฐานข้อมูล แล้วให้ DbSet ที่มีชื่อว่า Data เป็นตัวแทนตารางที่เก็บข้อมูลของ Revenue_Expense
        // หรือถ้าพูดอีกนัยหนึ่ง: Model Revenue_Expense จะถูกนำไปสร้างตารางที่ชื่อว่า Data เก็บใน database
        // เป็นการสร้าง property ในรูปแบบ DbSet โดยตั้งชื่อว่า Data
        public DbSet<Revenue_ExpenseModel> Financial { get; set; }
        /*
         * Step 1: ApplicationDBcontext by setting DbSet Entity ที่มีชื่อว่า Data
         * Step 2: ApplicationDBcontext was use by Program.cs is create one services,
         *         In services call on UseSqlServer()  by connect via ConnectionString ที่มีชื่อว่า DefaultConnection
         *         
         */
        #endregion

    }
}
