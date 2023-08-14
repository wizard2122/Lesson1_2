using UnityEngine;

public class RandomCoin : Coin
{
    [SerializeField, Range(0, 50)] private int _maxValue;
    [SerializeField, Range(0, 50)] private int _minValue;

    protected override void AddCoins(ICoinPicker coinPicker) => coinPicker.Add(Random.Range(_minValue, _maxValue));
}
