using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public enum PickUpEnum
{
    Apple,
    Steak,
    WholeBird,
    Drumstick,
    BreadRoll,
    Ham,
    Onion,
    Carrot,
    BreadLoaf,
    Cheese,
    Any
}
    
public static class PickUpValueProvider
{
    private class PickUpValue
    {
        public PickUpEnum Type { get; }
        public int Value { get; }

        public PickUpValue(PickUpEnum type, int value)
        {
            Type = type;
            Value = value;
        }
    }

    private static readonly IReadOnlyCollection<PickUpValue> _pickUpValues = new PickUpValue[]
    {
        new PickUpValue(PickUpEnum.Apple, 5),
        new PickUpValue(PickUpEnum.BreadLoaf, 7),
        new PickUpValue(PickUpEnum.Carrot, 4),
        new PickUpValue(PickUpEnum.Drumstick, 16),
        new PickUpValue(PickUpEnum.Ham, 40),
        new PickUpValue(PickUpEnum.Onion, 1),
        new PickUpValue(PickUpEnum.BreadRoll, 12),
        new PickUpValue(PickUpEnum.WholeBird, 20),
        new PickUpValue(PickUpEnum.Cheese,18),
        new PickUpValue(PickUpEnum.Steak, 25)
    };


    public static int GetValue(PickUpEnum type)
    {
        return _pickUpValues.First(p => p.Type == type).Value;
    }

    public static int GetRandomPickUpEnum()
    {
        var pickUpArray = Enum.GetValues(typeof(PickUpEnum));
        var random = Random.Range(0, pickUpArray.Length - 1);
        return random;
    }
}