using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _8Queens
{
    public class Queens
    {
        //定義有多少個皇后
        static int qsum = 8;

        //Queen位置的結果
        static int[] queens = new int[qsum];

        //解法次數
        static int _count = 0;

        public void Run()
        {
            Queens.Check(0);
        }

        /// <summary>
        ///編寫方法放置第n個皇后
        /// </summary>
        /// <param name="n"></param>
        private static void Check(int n)
        {
            if (n == qsum) 
            {
                Print();
                return;
            }

            //依次放入皇后，並判斷是否有衝突
            for (int i = 0; i < qsum; i++)
            {
                //先把當前這個皇后n,放到該行的第1列
                queens[n] = i;

                //判斷當放置第n個皇后到i列時，是否衝突
                if (Judge(n))
                {
                    //如果不衝突，接著放n+1個皇后，即開始遞迴
                    Check(n + 1);
                }

                //衝突繼續執行arr[n]=i,即將第n個皇后，放置該行的後移的一個位置
            }
        }

        /// <summary>
        /// 檢視當我們放置第n個皇后，檢查該皇后是否和其他皇后衝突
        /// </summary>
        /// <param name="n">表示第n個皇后</param>
        /// <returns></returns>
        private static bool Judge(int n)
        {

            for (int i = 0; i < n; i++)
            {
                //數差K則abs(放置位置 - N層放置位置) = K。然而K為目前層數 - N
                if (queens[i] == queens[n] || Math.Abs(n - i) == Math.Abs(queens[n] - queens[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 皇后位置輸出
        /// </summary>
        private static void Print()
        {
            _count++;

            for (int i = 0; i < queens.Length; i++)
            {
                for (int k = 0; k < queens.Length; k++)
                {
                    if (queens[i] == k)
                    {
                        Console.Write("Q");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

    }
}
