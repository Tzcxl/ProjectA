using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

[SerializeField]
public  class BaseStats
{
    public  string CharName { get; set; }
    public  float Speed { get; set; }
    public  float Damage { get; set; }
    public  float HealthPoint { get; set; }
    public  float currentHealthPoint { get; set; }

}
