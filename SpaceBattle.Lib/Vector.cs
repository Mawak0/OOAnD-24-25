using System;

public interface IVector {
    int Length {set;}
    int[] Values {get; set;}
}


public class Vector: IVector
{
    private int[] elements;

    // Конструктор, принимающий размер вектора
    public Vector(int size)
    {
        elements = new int[size];
    }

    // Конструктор, принимающий массив значений
    public Vector(int[] values)
    {
        elements = new int[values.Length];
        values.CopyTo(elements, 0);
    }

    // Индексатор для доступа к элементам вектора
    public int this[int index]
    {
        get => elements[index];
        set => elements[index] = value;
    }

    // Свойство для получения длины вектора
    public int Length => elements.Length;

   // Доступ к значениям вектора для записи и вывода
    public int[] Values {
       get => elements;
       set => elements = value;
    }

    // Переопределение оператора сложения для векторов
    public static Vector operator +(Vector v1, Vector v2)
    {
        if (v1.Length != v2.Length)
            throw new ArgumentException("Vectors must be of the same length");

        int[] result = new int[v1.Length];
        for (int i = 0; i < v1.Length; i++)
        {
            result[i] = v1[i] + v2[i];
        }
        return new Vector(result);
    }

    // Метод для отображения вектора
    public override string ToString()
    {
        return $"[{string.Join(", ", elements)}]";
    }
}