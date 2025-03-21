using ListaCircularNS;
public class Program
{
    public static void Main(string[] args)
    {
        CircularSinglyLinkedList list = new CircularSinglyLinkedList();

        // Insertar elementos
        list.InsertarAlFinal(10);
        list.InsertarAlFinal(20);
        list.InsertarAlFinal(30);
        list.InsertarAlInicio(5);
        list.InsertarEnPosicion(15, 2);

        Console.WriteLine("Lista Circular: " + list.ToString());
        Console.WriteLine("Tamaño de la lista: " + list.ObtenerTamaño());

        // Eliminar elementos
        list.EliminarAlInicio();
        list.EliminarAlFinal();
        list.EliminarEnPosicion(1);

        Console.WriteLine("Lista Circular después de eliminaciones: " + list.ToString());
        Console.WriteLine("Tamaño de la lista: " + list.ObtenerTamaño());
    }
}