// @autor: Ключерев Артемий ИВТ-21.


using bd;
using System.Xml.Linq;

namespace DBTest
{
    [TestClass]
    public class ContactTest
    {
        // тестирование геттеров и сеттеров поля Имя
        [TestMethod]
        public void TestMethodGetName()
        {
            Buyer f1 = new Buyer();

            Assert.AreEqual("", f1.Name);

            f1.Name = "Иван";
            Assert.AreEqual("Иван", f1.Name);

            f1.Name = "Денис";
            Assert.AreEqual("Денис", f1.Name);

            f1.Name = "";
            Assert.AreEqual("", f1.Name);
        }


        [TestMethod]
        public void TestMethodGetSurname()
        {
            Buyer f1 = new Buyer();

            Assert.AreEqual("", f1.Surname);

            f1.Surname = "Иванов";
            Assert.AreEqual("Иванов", f1.Surname);

            f1.Surname = "Сахоров";
            Assert.AreEqual("Сахоров", f1.Surname);

            f1.Surname = "";
            Assert.AreEqual("", f1.Surname);

        }


        [TestMethod]
        public void TestMethodGetproduct()
        {
            Buyer f1 = new Buyer();

            Assert.AreEqual("", f1.Product);

            f1.Product = "соль";
            Assert.AreEqual("соль", f1.Product);

            f1.Product = "хлеб";
            Assert.AreEqual("хлеб", f1.Product);

            f1.Product = "";
            Assert.AreEqual("", f1.Product);

        }


        // тестирование геттеров и сеттеров поля Сумма оплаты
        [TestMethod]
        public void TestMethodGetPrice()
        {
            Buyer f1 = new Buyer();

            Assert.AreEqual(0, f1.Price);

            f1.Price = 785;
            Assert.AreEqual(785, f1.Price);

            f1.Price = 6987.5;
            Assert.AreEqual(6987.5, f1.Price);

            // проверка выбрасываемого исключения
            string s = "";
            try
            {
                f1.Price = -854.245;
            }
            catch (Exception ex)
            {
                s = ex.Message;
            }
            Assert.AreEqual(s, "Price can't be negative");
        }

        // тестирование конструктора с параметрами
        [TestMethod]
        public void TestMethodConstructor()
        {
            Buyer f1 = new Buyer("Пётр", "Иванов", "хлеб", 5500.56);

            Assert.AreEqual("Пётр", f1.Name);
            Assert.AreEqual("Иванов", f1.Surname);
            Assert.AreEqual("хлеб", f1.Product);
            Assert.AreEqual(5500.56, f1.Price);

            // проверка выбрасываемого исключения
            string s = "";
            try
            {
                Buyer f3 = new Buyer("Пётр", "Иванов", "соль", -125);
            }
            catch (Exception ex)
            {
                s = ex.Message;
            }
            Assert.AreEqual(s, "Price can't be negative");

        }
    }
}