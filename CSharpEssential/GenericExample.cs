using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEssential;

internal class GenericExample
{
    public T Echo<T>(T input)
    {
        return input;
    }

    public T Echo2<T, Q>(T input1, Q input2) where T : INumber<T>
    {
        return input1;
    }

    public T GetMax<T>(T a, T b) where T : IComparable<T>
    {
        return a.CompareTo(b) > 0 ? a : b;
    }
}


