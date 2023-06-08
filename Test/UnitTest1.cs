// @autor: �������� ������� ���-21.


using bd;
using System.Xml.Linq;

namespace DBTest
{
    [TestClass]
    public class ContactTest
    {
        // ������������ �������� � �������� ���� ���
        [TestMethod]
        public void TestMethodGetName()
        {
            Buyer f1 = new Buyer();

            Assert.AreEqual("", f1.Name);

            f1.Name = "����";
            Assert.AreEqual("����", f1.Name);

            f1.Name = "�����";
            Assert.AreEqual("�����", f1.Name);

            f1.Name = "";
            Assert.AreEqual("", f1.Name);
        }


        [TestMethod]
        public void TestMethodGetSurname()
        {
            Buyer f1 = new Buyer();

            Assert.AreEqual("", f1.Surname);

            f1.Surname = "������";
            Assert.AreEqual("������", f1.Surname);

            f1.Surname = "�������";
            Assert.AreEqual("�������", f1.Surname);

            f1.Surname = "";
            Assert.AreEqual("", f1.Surname);

        }


        [TestMethod]
        public void TestMethodGetproduct()
        {
            Buyer f1 = new Buyer();

            Assert.AreEqual("", f1.Product);

            f1.Product = "����";
            Assert.AreEqual("����", f1.Product);

            f1.Product = "����";
            Assert.AreEqual("����", f1.Product);

            f1.Product = "";
            Assert.AreEqual("", f1.Product);

        }


        // ������������ �������� � �������� ���� ����� ������
        [TestMethod]
        public void TestMethodGetPrice()
        {
            Buyer f1 = new Buyer();

            Assert.AreEqual(0, f1.Price);

            f1.Price = 785;
            Assert.AreEqual(785, f1.Price);

            f1.Price = 6987.5;
            Assert.AreEqual(6987.5, f1.Price);

            // �������� �������������� ����������
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

        // ������������ ������������ � �����������
        [TestMethod]
        public void TestMethodConstructor()
        {
            Buyer f1 = new Buyer("ϸ��", "������", "����", 5500.56);

            Assert.AreEqual("ϸ��", f1.Name);
            Assert.AreEqual("������", f1.Surname);
            Assert.AreEqual("����", f1.Product);
            Assert.AreEqual(5500.56, f1.Price);

            // �������� �������������� ����������
            string s = "";
            try
            {
                Buyer f3 = new Buyer("ϸ��", "������", "����", -125);
            }
            catch (Exception ex)
            {
                s = ex.Message;
            }
            Assert.AreEqual(s, "Price can't be negative");

        }
    }
}