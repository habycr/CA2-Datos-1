using Microsoft.VisualStudio.TestTools.UnitTesting;
using ListaDobleCircularNS;
using System;

namespace UnitTests
{
    [TestClass]
    public class CircularDoublyLinkedListTests
    {
        [TestMethod]
        public void TestInsertarAlInicio()
        {
            var lista = new CircularDoublyLinkedList();

            lista.InsertarAlInicio(10);
            lista.InsertarAlInicio(20);

            Assert.AreEqual(2, lista.ObtenerTama�o());
            Assert.AreEqual("20, 10", lista.ToString());
        }

        [TestMethod]
        public void TestInsertarAlFinal()
        {
            var lista = new CircularDoublyLinkedList();

            lista.InsertarAlFinal(10);
            lista.InsertarAlFinal(20);

            Assert.AreEqual(2, lista.ObtenerTama�o());
            Assert.AreEqual("10, 20", lista.ToString());
        }

        [TestMethod]
        public void TestInsertAt()
        {
            var lista = new CircularDoublyLinkedList();

            lista.InsertarAlInicio(10);
            lista.InsertarAlInicio(20);
            lista.InsertarAlFinal(5);

            lista.InsertAt(15, 1);

            Assert.AreEqual(4, lista.ObtenerTama�o());
            Assert.AreEqual("20, 15, 10, 5", lista.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInsertAt_IndexFueraDeRango()
        {
            var lista = new CircularDoublyLinkedList();
            lista.InsertAt(10, 1);  // Esto deber�a lanzar una excepci�n, ya que el �ndice es inv�lido
        }

        [TestMethod]
        public void TestEliminarAlInicio()
        {
            var lista = new CircularDoublyLinkedList();

            lista.InsertarAlInicio(10);
            lista.InsertarAlInicio(20);
            lista.EliminarAlInicio();

            Assert.AreEqual(1, lista.ObtenerTama�o());
            Assert.AreEqual("10", lista.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestEliminarAlInicio_LaListaEstaVacia()
        {
            var lista = new CircularDoublyLinkedList();
            lista.EliminarAlInicio();  // Esto deber�a lanzar una excepci�n, ya que la lista est� vac�a
        }

        [TestMethod]
        public void TestEliminarAlFinal()
        {
            var lista = new CircularDoublyLinkedList();

            lista.InsertarAlInicio(10);
            lista.InsertarAlInicio(20);
            lista.EliminarAlFinal();

            Assert.AreEqual(1, lista.ObtenerTama�o());
            Assert.AreEqual("20", lista.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestEliminarAlFinal_LaListaEstaVacia()
        {
            var lista = new CircularDoublyLinkedList();
            lista.EliminarAlFinal();  // Esto deber�a lanzar una excepci�n, ya que la lista est� vac�a
        }

        [TestMethod]
        public void TestRemoveAt()
        {
            var lista = new CircularDoublyLinkedList();

            lista.InsertarAlInicio(10);
            lista.InsertarAlInicio(20);
            lista.InsertarAlFinal(5);
            lista.RemoveAt(1);

            Assert.AreEqual(2, lista.ObtenerTama�o());
            Assert.AreEqual("20, 5", lista.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemoveAt_IndexFueraDeRango()
        {
            var lista = new CircularDoublyLinkedList();
            lista.RemoveAt(0);  // Esto deber�a lanzar una excepci�n, ya que el �ndice est� fuera de rango
        }

        [TestMethod]
        public void TestEstaVacia()
        {
            var lista = new CircularDoublyLinkedList();
            Assert.IsTrue(lista.EstaVacia());

            lista.InsertarAlInicio(10);
            Assert.IsFalse(lista.EstaVacia());
        }
    }
}
