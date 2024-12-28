using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Orleans;
using System;
using System.Threading.Tasks;
using taskProject;

public class CalcGrain : Grain, ICalcGrain
{
    private int _currentValue = 0;
    public Task<int> Add(int x)
    {
        _currentValue = x + _currentValue;
        return Task.FromResult(_currentValue + x);
    }

    public Task<int> Minus(int x)
    {
        _currentValue = _currentValue - x;
        return Task.FromResult(_currentValue - x);
    }

    public Task<int> GetNum()
    {
        return Task.FromResult(_currentValue);
    }
}
