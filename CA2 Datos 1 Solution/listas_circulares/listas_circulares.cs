using System;

namespace ListaCircularNS
{

    public class Node
    {
        public int Value;
        public Node Next;

        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }

    public class CircularSinglyLinkedList
    {
        private Node tail;
        private int size;

        public CircularSinglyLinkedList()
        {
            tail = null;
            size = 0;
        }

        // Método que inserta un nuevo nodo al inicio de la lista.
        public void InsertarAlInicio(int value)
        {
            Node newNode = new Node(value);
            if (EstaVacia())
            {
                newNode.Next = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = tail.Next;
                tail.Next = newNode;
            }
            size++;
        }

        // Método que inserta un nuevo nodo al final de la lista.
        public void InsertarAlFinal(int value)
        {
            Node newNode = new Node(value);
            if (EstaVacia())
            {
                newNode.Next = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = tail.Next;
                tail.Next = newNode;
                tail = newNode;
            }
            size++;
        }

        // Método que inserta un nuevo nodo en una posición específica indicada por el índice, el índice empieza en 0.
        public void InsertarEnPosicion(int value, int index)
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
                current.Next = newNode;
                size++;
            }
        }

        // Método que elimina el primer nodo de la lista.
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
                tail.Next = tail.Next.Next;
            }
            size--;
        }

        // Método que elimina el último nodo de la lista.
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
                Node current = tail.Next;
                while (current.Next != tail)
                {
                    current = current.Next;
                }
                current.Next = tail.Next;
                tail = current;
            }
            size--;
        }

        // Método que elimina un nodo en una posición específica indicada por el índice, el índice empieza en 0.
        public void EliminarEnPosicion(int index)
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
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
                size--;
            }
        }

        // Método que retorna el tamaño de la lista.
        public int ObtenerTamaño()
        {
            return size;
        }

        // Método que retorna una representación de la lista como una cadena de texto con los valores separados por comas.
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

        // Método que verifica si la lista está vacía.
        public bool EstaVacia()
        {
            return size == 0;
        }
    }
}