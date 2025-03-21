using System;

namespace ListaDobleCircularNS
{
    public class Node
    {
        public int Value;
        public Node Next;
        public Node Prev;

        public Node(int value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }
    }

    public class CircularDoublyLinkedList
    {
        private Node tail;
        private int size;

        public CircularDoublyLinkedList()
        {
            tail = null;
            size = 0;
        }

        public void InsertarAlInicio(int value)
        {
            Node newNode = new Node(value);
            if (EstaVacia())
            {
                newNode.Next = newNode;
                newNode.Prev = newNode;
                tail = newNode;
            }
            else
            {
                Node head = tail.Next;
                newNode.Next = head;
                newNode.Prev = tail;
                head.Prev = newNode;
                tail.Next = newNode;
            }
            size++;
        }

        public void InsertarAlFinal(int value)
        {
            InsertarAlInicio(value);
            tail = tail.Next;
        }

        public void InsertAt(int value, int index)
        {
            if (index < 0 || index > size)
            {
                throw new ArgumentOutOfRangeException("Índice fuera de rango");
            }

            if (index == 0)
            {
                InsertarAlInicio(value);
            }
            else if (index == size)
            {
                InsertarAlFinal(value);
            }
            else
            {
                Node newNode = new Node(value);
                Node current = tail.Next;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                newNode.Next = current.Next;
                newNode.Prev = current;
                current.Next.Prev = newNode;
                current.Next = newNode;
                size++;
            }
        }

        public void EliminarAlInicio()
        {
            if (EstaVacia())
            {
                throw new InvalidOperationException("La lista está vacía");
            }

            if (size == 1)
            {
                tail = null;
            }
            else
            {
                Node head = tail.Next;
                tail.Next = head.Next;
                head.Next.Prev = tail;
            }
            size--;
        }

        public void EliminarAlFinal()
        {
            if (EstaVacia())
            {
                throw new InvalidOperationException("La lista está vacía");
            }

            if (size == 1)
            {
                tail = null;
            }
            else
            {
                Node prevTail = tail.Prev;
                prevTail.Next = tail.Next;
                tail.Next.Prev = prevTail;
                tail = prevTail;
            }
            size--;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new ArgumentOutOfRangeException("Índice fuera de rango");
            }

            if (index == 0)
            {
                EliminarAlInicio();
            }
            else if (index == size - 1)
            {
                EliminarAlFinal();
            }
            else
            {
                Node current = tail.Next;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                current.Prev.Next = current.Next;
                current.Next.Prev = current.Prev;
                size--;
            }
        }

        public int ObtenerTamaño()
        {
            return size;
        }

        public override string ToString()
        {
            if (EstaVacia())
            {
                return "La lista está vacía";
            }

            Node current = tail.Next;
            string result = "";
            do
            {
                result += current.Value;
                if (current.Next != tail.Next)
                {
                    result += ", ";
                }
                current = current.Next;
            } while (current != tail.Next);

            return result;
        }

        public bool EstaVacia()
        {
            return size == 0;
        }

        static void Main()
        {
            CircularDoublyLinkedList lista = new CircularDoublyLinkedList();
            lista.InsertarAlInicio(10);
            lista.InsertarAlInicio(20);
            lista.InsertarAlFinal(5);

            Console.WriteLine("Lista después de inserciones: " + lista);
            lista.EliminarAlInicio();
            Console.WriteLine("Lista después de eliminar el inicio: " + lista);
        }
    }
}
