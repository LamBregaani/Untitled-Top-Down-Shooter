using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IdamageableByPlayer<T> 
{
    void TakeDamage(T damageTaken);

}
