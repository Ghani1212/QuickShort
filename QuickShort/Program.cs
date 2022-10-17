using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        //array of interger to hold values
        private int[] arr = new int[20];
        private int cmp_count = 0; // number of comprasion
        private int mov_count = 0; // number of data movements

        // Number od elements in array 
        private int n;

        void read()
        {
            while (true)
            {
                Console.Write("Enter The number of elemnts in the array :");
                string s = Console.ReadLine();
                n = Int32.Parse(s);
                if (n <= 20)
                    break;
                else
                    Console.WriteLine("\n Array can have maximum 30 elements \n ");
            }
            Console.WriteLine("\n=====================");
            Console.WriteLine(" Enter Array Elements");
            Console.WriteLine("\n=====================");

            // get array elements 
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("<" + (i + 1) + ">");
                string s1 = Console.ReadLine();
                arr[i] = Int32.Parse(s1);
            }

        }
        //swaps the elements at index x with the element at index y
        void swap(int x, int y)
        {
            int temp;

            temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }
        public void q_sort(int low, int high)
        {
            int pivot, i, j;
            if (low > high)
                return;
            // partition the list into two parts :
            // one containing elementas less that or equal to pivot
            // outher containing elements greather than pivot

            i = low + 1;
            j = high;

            pivot = arr[low];

            while (i <= j)
            {
                //Search for an elements greater than pivot
                while ((arr[i] <= pivot) && (i <= high))
                {
                    i++;
                    cmp_count++;
                }
                cmp_count++;

                //Search for an elements less than or equal pivot
                while ((arr[j] <= pivot) && (j >= low))
                {
                    j--;
                    cmp_count++;
                }
                cmp_count++;

                if (i < j) //if the greater elements is on the left of the element
                {
                    //swap the element at index i with the element at index
                    swap(i, j);
                    mov_count++;
                }
            }
            // j now contains the index of the last element in the sorted list

            if (low < j)
            {
                // move the pivot to its correct position in the list
                swap(low, j);
                mov_count++;
            }
            //sort the list on the left of pivot using quick sort
            q_sort(low, j - 1);

            //sort the list on the right of pivot using quick sort
            q_sort(j + 1, high);
        }

        void display()
        {
            Console.WriteLine("\n---------------------");
            Console.WriteLine(" Sorted array elements ");
            Console.WriteLine("-----------------------");

            for (int j = 0; j < n; j++)
            {
                Console.WriteLine(arr[j]);
            }
            Console.WriteLine("\nNumber of comparisons: " + cmp_count);
            Console.WriteLine("\nNumber of data movements: " + mov_count);
        }
        int getSize()
        {
            return (n);
        }
        static void Main(string[] args)
        {
            //declaring the object of the class
            Program myList = new Program();
            //Accept array elements
            myList.read();
            //Calling the sorting function
            //first call to quick sort algorithm
            myList.q_sort(0, myList.getSize() - 1);
            //display sorted array
            myList.display();
            //to exit from the console
            Console.WriteLine("\n\nPress Enter To Exit.");
            Console.Read();
        }
    }

}

