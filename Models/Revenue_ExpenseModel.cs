using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPNET7MVCCRUD.Models
{
    public class Revenue_ExpenseModel
    {
        //สร้าง Model Revenus_Expense
        //Crate class because I would like to design space for collect data
        //but collection data will crate object to use it  (แต่การสร้างข้อมูลจริงๆดราจะสร้างที่เรียกว่า object มาใช้)

        //SSMS = tools for manage ฐานข้อมูล server
        //Data Annotation = Defind structure of table ที่อยู่ในฐานข้อมูล (กำหนดพวก Primary key: 1 Model = 1 Table)
        //ConnectionString = Enviroment Variable (ชื่อตัวแปรๆตัวหนึ่งสำหรับนำไปใช้งานใน ASP.Net Core MVC)

        #region Data Annotaion
        /* 
           Data Annotaion
           Model name is table name.
           Property name is column name each table.
           Key is Primary Key
           Required คือห้ามเป็นค่าว่าง ต้องมีค่าเท่านั้น (ค่าที่ส่งมาให้ต้องไม่เป็นค่าว่าง)
           DisplayName คือการกำหนดข้อความกำกับช่อง
           Range คือการระบุช่วงจำนวนของตัวเลข
        */
        #endregion

        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        //[Required]
        [Required(ErrorMessage = "Please Input Item!!!")]
        [DisplayName("Product Name")]
        public string? Item { get; set; }

        [DisplayName("Income")]
        [Required(ErrorMessage = "Insert 0 - 999,999 only!!!")]
        [Range(0,999999)]
        public int Revenue { get; set;}

        
        [DisplayName("expenditure")]
        [Required(ErrorMessage = "Insert 0 - 999,999 only!!!!")]
        [Range(0,999999)]
        public int Expense { get; set; }
    }
}
