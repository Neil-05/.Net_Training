using System;
class Jagged
{
    public static void Main()
    {
        int[][] ar=new int[5][];
        ar[0]=new int[]{1,2,3};
        ar[1]=new int[]{4,5,6,7};
        ar[2]=new int[]{1,2,3,4,5,6,7,8,9};
        ar[3]=new int[]{10,20};
        ar[4]=new int[]{100,200,300,400,500};
        for(int i=0;i<ar.Length;i++)
        {
            for(int j=0;j<ar[i].Length;j++)
            {
                Console.Write(ar[i][j]+" ");
            }
            Console.WriteLine();
        }
    }
}