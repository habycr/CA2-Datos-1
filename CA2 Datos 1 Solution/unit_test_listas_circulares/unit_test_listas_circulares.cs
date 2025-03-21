using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ListaCircularNS;

namespace ListaCircularTest
{
    [TestClass]
    public class CircularSinglyLinkedListUnitTests
    {
        private CircularSinglyLinkedList list;

        // Configuraci�n inicial para cada prueba
        [TestInitialize]
        public void SetUp()
        {
            list = new CircularSinglyLinkedList();
        }

        // Prueba de insertar al inicio
        [TestMethod]
        public void InsertarAlInicio_ShouldIncreaseSizeAndContainElement()
        {
            list.InsertarAlInicio(10);
            list.InsertarAlInicio(20);

            Assert.AreEqual(2, list.ObtenerTama�o());
            Assert.IsTrue(list.ToString().Contains("10"));
            Assert.IsTrue(list.ToString().Contains("20"));
        }

        // Prueba de insertar al final
        [TestMethod]
        public void InsertarAlFinal_ShouldIncreaseSizeAndContainElement()
        {
            list.InsertarAlFinal(30);
            list.InsertarAlFinal(40);

            Assert.AreEqual(2, list.ObtenerTama�o());
            Assert.IsTrue(list.ToString().Contains("30"));
            Assert.IsTrue(list.ToString().Contains("40"));
        }

        // Prueba de insertar en una posici�n espec�fica
        [TestMethod]
        public void InsertarEnPosicion_ShouldInsertElementAtGivenPosition()
        {
            list.InsertarAlInicio(10);
            list.InsertarAlFinal(30);

            list.InsertarEnPosicion(20, 1);

            Assert.AreEqual(3, list.ObtenerTama�o());
            Assert.AreEqual("10, 20, 30", list.ToString());
        }

        // Prueba de eliminar al inicio
        [TestMethod]
        public void EliminarAlInicio_ShouldDecreaseSizeAndRemoveElement()
        {
            list.InsertarAlInicio(10);
            list.InsertarAlFinal(20);

            list.EliminarAlInicio();

            Assert.AreEqual(1, list.ObtenerTama�o());
            Assert.IsFalse(list.ToString().Contains("10"));
        }

        // Prueba de eliminar al final
        [TestMethod]
        public void EliminarAlFinal_ShouldDecreaseSizeAndRemoveElement()
        {
            list.InsertarAlInicio(10);
            list.InsertarAlFinal(20);

            list.EliminarAlFinal();

            Assert.AreEqual(1, list.ObtenerTama�o());
            Assert.IsFalse(list.ToString().Contains("20"));
        }

        // Prueba de eliminar en una posici�n espec�fica
        [TestMethod]
        public void EliminarEnPosicion_ShouldDeleteElementAtGivenPosition()
        {
            list.InsertarAlInicio(10);
            list.InsertarAlFinal(20);
            list.InsertarAlFinal(30);

            list.EliminarEnPosicion(1);

            Assert.AreEqual(2, list.ObtenerTama�o());
            Assert.AreEqual("10, 30", list.ToString());
        }

        // Prueba de obtener el tama�o de la lista
        [TestMethod]
        public void ObtenerTama�o_ShouldReturnCorrectSize()
        {
            Assert.AreEqual(0, list.ObtenerTama�o());
            list.InsertarAlInicio(5);
            list.InsertarAlFinal(15);
            Assert.AreEqual(2, list.ObtenerTama�o());
        }

        // Prueba de ToString cuando la lista est� vac�a
        [TestMethod]
        public void ToString_ListaVacia_ShouldReturnMessageEmptyList()
        {
            Assert.AreEqual("La lista est� vac�a", list.ToString());
        }

        // Prueba de comportamiento con elementos en la lista
        [TestMethod]
        public void ToString_ListaConElementos_ShouldReturnCorrectRepresentation()
        {
            list.InsertarAlInicio(5);
            list.InsertarAlFinal(10);
            list.InsertarAlFinal(20);

            Assert.AreEqual("5, 10, 20", list.ToString());
        }
    }
}