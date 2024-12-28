using Orleans;
using Orleans.Runtime;
using System;
using System.Threading.Tasks;

public interface ICalcGrain : IGrainWithIntegerKey
{
    Task<int> Add(int x);
    Task <int>GetNum();
    Task<int> Minus(int x);
}