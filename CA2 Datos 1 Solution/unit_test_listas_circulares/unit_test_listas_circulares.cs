using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ListaCircularNS;

namespace ListaCircularTest
{
    [TestClass]
    public class CircularSinglyLinkedListUnitTests
    {
        private CircularSinglyLinkedList list;

        // Configuración inicial para cada prueba
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

            Assert.AreEqual(2, list.ObtenerTamaño());
            Assert.IsTrue(list.ToString().Contains("10"));
            Assert.IsTrue(list.ToString().Contains("20"));
        }

        // Prueba de insertar al final
        [TestMethod]
        public void InsertarAlFinal_ShouldIncreaseSizeAndContainElement()
        {
            list.InsertarAlFinal(30);
            list.InsertarAlFinal(40);

            Assert.AreEqual(2, list.ObtenerTamaño());
            Assert.IsTrue(list.ToString().Contains("30"));
            Assert.IsTrue(list.ToString().Contains("40"));
        }

        // Prueba de insertar en una posición específica
        [TestMethod]
        public void InsertarEnPosicion_ShouldInsertElementAtGivenPosition()
        {
            list.InsertarAlInicio(10);
            list.InsertarAlFinal(30);

            list.InsertarEnPosicion(20, 1);

            Assert.AreEqual(3, list.ObtenerTamaño());
            Assert.AreEqual("10, 20, 30", list.ToString());
        }

        // Prueba de eliminar al inicio
        [TestMethod]
        public void EliminarAlInicio_ShouldDecreaseSizeAndRemoveElement()
        {
            list.InsertarAlInicio(10);
            list.InsertarAlFinal(20);

            list.EliminarAlInicio();

            Assert.AreEqual(1, list.ObtenerTamaño());
            Assert.IsFalse(list.ToString().Contains("10"));
        }

        // Prueba de eliminar al final
        [TestMethod]
        public void EliminarAlFinal_ShouldDecreaseSizeAndRemoveElement()
        {
            list.InsertarAlInicio(10);
            list.InsertarAlFinal(20);

            list.EliminarAlFinal();

            Assert.AreEqual(1, list.ObtenerTamaño());
            Assert.IsFalse(list.ToString().Contains("20"));
        }

        // Prueba de eliminar en una posición específica
        [TestMethod]
        public void EliminarEnPosicion_ShouldDeleteElementAtGivenPosition()
        {
            list.InsertarAlInicio(10);
            list.InsertarAlFinal(20);
            list.InsertarAlFinal(30);

            list.EliminarEnPosicion(1);

            Assert.AreEqual(2, list.ObtenerTamaño());
            Assert.AreEqual("10, 30", list.ToString());
        }

        // Prueba de obtener el tamaño de la lista
        [TestMethod]
        public void ObtenerTamaño_ShouldReturnCorrectSize()
        {
            Assert.AreEqual(0, list.ObtenerTamaño());
            list.InsertarAlInicio(5);
            list.InsertarAlFinal(15);
            Assert.AreEqual(2, list.ObtenerTamaño());
        }

        // Prueba de ToString cuando la lista está vacía
        [TestMethod]
        public void ToString_ListaVacia_ShouldReturnMessageEmptyList()
        {
            Assert.AreEqual("La lista está vacía", list.ToString());
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