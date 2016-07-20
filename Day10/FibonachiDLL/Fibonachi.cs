using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonachiDLL
{
    public static class Fibonachi
    {
        private static int _a;
        private static int _b;
        public static int Evaluate(int number)
        {
            _a = 1;
            _b = 1;
            int ret = 0;
            IEnumerator < int > iterator = GetNumber(number);
            while(iterator.MoveNext())
            {
                ret += iterator.Current;
            }
            return ret;
        }
        public static int GetFibonachiNumber(int number)
        {
            _a = 1;
            _b = 1;
            int ret = 0;
            IEnumerator<int> iterator = GetNumber(number);
            while (number!=0)
            {
                iterator.MoveNext();
                number--;
            }
            return ret = iterator.Current;
        }
        private static IEnumerator<int> GetNumber(int number)
        {
            if (number > 0)
            {
                number--;
                yield return 0;
            }
            if (number > 0)
            {
                number--;
                yield return 1;
            }
            while (number > 0)
            {
                int temp = _a;
                _a = _b;
                _b = temp + _b;
                number--;
                yield return _a;
            }
        }
    }
}
