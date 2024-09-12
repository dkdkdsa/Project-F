using System;

[Flags]
public enum Tags
{
    
    ItemGet = 1 << 0,
    Hit = 1 << 1,
    Damageable = 1 << 2,
    Ground = 1 << 3,
    Dieable = 1 << 4,
    KnockBackable = 1 << 5,
}
