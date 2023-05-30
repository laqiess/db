// @autor: Ключерев Артемий ИВТ-21


using bd;
using System.Xml.Linq;

namespace DBTest
{
    [TestClass]
    public class ContactTest
    {
        [TestMethod]
        public void TestMethod_Constructor()
        {
            Buyer f1 = new Buyer("Артем", "Ключерев", "хлеб", "25");
            Assert.AreEqual("Артем", f1.name_get());
            Assert.AreEqual("Ключерев", f1.surname_get());
            Assert.AreEqual("хлеб", f1.product_get());
            Assert.AreEqual("25", f1.price_get());

            Buyer f2 = new Buyer("Саша", "Шерпаева", "яйца", "108");
            Assert.AreEqual("Саша", f2.name_get());
            Assert.AreEqual("Шерпаева", f2.surname_get());
            Assert.AreEqual("яйца", f2.product_get());
            Assert.AreEqual("108", f2.price_get());

            Buyer f3 = new Buyer("Артем", "Харасов", "пельмени", "349");
            Assert.AreEqual("Артем", f3.name_get());
            Assert.AreEqual("Харасов", f3.surname_get());
            Assert.AreEqual("пельмени", f3.product_get());
            Assert.AreEqual("349", f3.price_get());
        }

        [TestMethod]
        public void TestMethod_set()
        {
            Buyer f1 = new Buyer();

            f1.name_set("Артем");
            Assert.AreEqual("Артем", f1.name_get());
            f1.surname_set("Ключерев");
            Assert.AreEqual("Ключерев", f1.surname_get());
            f1.product_set("хлеб");
            Assert.AreEqual("хлеб", f1.product_get());
            f1.price_set("25");
            Assert.AreEqual("25", f1.price_get());

            f1.name_set("Саша");
            Assert.AreEqual("Саша", f1.name_get());
            f1.surname_set("Шерпаева");
            Assert.AreEqual("Шерпаева", f1.surname_get());
            f1.product_set("яйца");
            Assert.AreEqual("яйца", f1.product_get());
            f1.price_set("108");
            Assert.AreEqual("108", f1.price_get());

            f1.name_set("Артем");
            Assert.AreEqual("Артем", f1.name_get());
            f1.surname_set("Харасов");
            Assert.AreEqual("Харасов", f1.surname_get());
            f1.product_set("пельмени");
            Assert.AreEqual("пельмени", f1.product_get());
            f1.price_set("349");
            Assert.AreEqual("349", f1.price_get());
        }
    }
}