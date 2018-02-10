// Лабораторная работа №1. 
// Использование языка С# для математических расчётов.
// Определить число отрицательных элементов, расположенных перед наибольшим положительным элементом одномерного массива, размер которого М. 
// Студент группы 464, Греков Кирилл Дмитриевич. 2018 год.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Программа определяет наибольшее положительное число в массиве и считает кол-во отрицательных числе перед ним.");
      Console.WriteLine("Программу написал Греков Кирилл, студент группы 464.");
      for(; ;) // Зацикливает работу программы
      {
        Input Input1 = new Input();
        Calculation Resolve = new Calculation();
        double[] array = Resolve.Calc(Input1.InputArray());
        if (array[0] <= 0) // Проверяет, есть ли в массиве хотя бы одно положительное число
        {
          Console.WriteLine("В массиве нет положительных чисел. Попробуйте ввести другой массив.");
        }
        else
        {
          Console.WriteLine("Наибольший положительный элемент массива равен: " + array[0]);
          Console.WriteLine("Перед наибольшим положительным элементом массива расположено " + array[1] + " отрицательных элементов");
        }
      }
    }
  }

  /// <summary>
  /// Класс отвечающий за заполнение массива
  /// </summary>
  public class Input
  {
    public double[] InputArray()
    {
      Double[] Arr; //Массив, который вернет функция, после того как пользователь его корректно заполнит
      Console.WriteLine("Введите целое натуральное число элементов массива.");
      while (true)
      {
        try
        {
          int ArraySize = Convert.ToInt32(Console.ReadLine());
          Arr = new Double[ArraySize];
          break;
        }
        catch (FormatException) // Ошибка на случай, если пользователь введет символ
        {
          Console.WriteLine("Вы ввели не число. Попробуйте снова.");
          continue;
        }
        catch (OverflowException) // Ошибка на случай, если пользователь введет отрицательное число
        {
          Console.WriteLine("Вы ввели неверное число. Попробуйте снова.");
        }
      }
      Console.WriteLine("Введите элементы массива.");
      while (true)
      {
        try
        {
          for (int i = 0; i < Arr.Length; i++)
          Arr[i] = Convert.ToDouble(Console.ReadLine());
          break;
        }
        catch (FormatException) // Ошибка на случай, если пользователь введет символ
        {
          Console.WriteLine("Элементами массива могут быть только числа. Попробуйте снова.");
          continue;
        }
      }
      Array.Reverse(Arr); // Введенный массив переворачивается, для удобства вычислений
      return Arr;
    }
  }

  /// <summary>
  /// Класс отвечающий за нахождение наибольшего члена массива и подсчет кол-ва отрицательных чисел перед ним
  /// </summary>
  public class Calculation
  {
    public double[] Calc(double[] array )
    {
      Double MaxElement = 0; // В этой переменной хранится наибольший элемент массива
      int MaxElementNumber = 1; // В этой переменное хранится индекс наибольшего элемента
      for (int i = 0; i < array.Length; i++)
        if (array[i] > MaxElement)
        {
          MaxElement = array[i];
          MaxElementNumber = i;
        }
      int count = 0; // Счетчик отрицательных чисел после наибольшего члена. По условию нужно считать числа до, а не после, но массив заранее был перевернут.
      do
      {
        if (array[MaxElementNumber] < 0)
        {
          count++;
        }
        MaxElementNumber++;
      }
      while (MaxElementNumber < array.Length);
      double[] result = { MaxElement, count };
      return result;
    }
  }
}