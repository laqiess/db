// @autor: �������� ������� ���-21


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
            Buyer f1 = new Buyer("�����", "��������", "����", "25");
            Assert.AreEqual("�����", f1.name_get());
            Assert.AreEqual("��������", f1.surname_get());
            Assert.AreEqual("����", f1.product_get());
            Assert.AreEqual("25", f1.price_get());

            Buyer f2 = new Buyer("����", "��������", "����", "108");
            Assert.AreEqual("����", f2.name_get());
            Assert.AreEqual("��������", f2.surname_get());
            Assert.AreEqual("����", f2.product_get());
            Assert.AreEqual("108", f2.price_get());

            Buyer f3 = new Buyer("�����", "�������", "��������", "349");
            Assert.AreEqual("�����", f3.name_get());
            Assert.AreEqual("�������", f3.surname_get());
            Assert.AreEqual("��������", f3.product_get());
            Assert.AreEqual("349", f3.price_get());
        }

        [TestMethod]
        public void TestMethod_set()
        {
            Buyer f1 = new Buyer();

            f1.name_set("�����");
            Assert.AreEqual("�����", f1.name_get());
            f1.surname_set("��������");
            Assert.AreEqual("��������", f1.surname_get());
            f1.product_set("����");
            Assert.AreEqual("����", f1.product_get());
            f1.price_set("25");
            Assert.AreEqual("25", f1.price_get());

            f1.name_set("����");
            Assert.AreEqual("����", f1.name_get());
            f1.surname_set("��������");
            Assert.AreEqual("��������", f1.surname_get());
            f1.product_set("����");
            Assert.AreEqual("����", f1.product_get());
            f1.price_set("108");
            Assert.AreEqual("108", f1.price_get());

            f1.name_set("�����");
            Assert.AreEqual("�����", f1.name_get());
            f1.surname_set("�������");
            Assert.AreEqual("�������", f1.surname_get());
            f1.product_set("��������");
            Assert.AreEqual("��������", f1.product_get());
            f1.price_set("349");
            Assert.AreEqual("349", f1.price_get());
        }
    }
}