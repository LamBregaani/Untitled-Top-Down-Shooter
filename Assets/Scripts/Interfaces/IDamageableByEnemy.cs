using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IdamageableByEnemy<T>
{
    void TakeDamage(T damageTaken);

}
