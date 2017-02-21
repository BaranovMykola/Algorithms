using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteString
{
    class CompleteString
    {
        public static bool isCompletable(string A, string B)
        {
            if (B.Length > A.Length)
            {
                return false;
            }
            for(int i=0;i<B.Length;++i)
            {
                int count = 0;
                for(int j=0;j<A.Length;++j)
                {
                    if (B[i] == A[j])
                    {
                        if (j < i)
                        {
                            break;
                        }
                        ++count;
                    }

                }
                for(int j=0;j<A.Length;++j)
                {
                    if(A[j] == B[i])
                    {
                        if(--count < 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            bool a = isCompletable("abcd", "ba");
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}
