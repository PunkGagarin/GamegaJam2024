using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "abilities", fileName = "new AbilityDatabase")]
public class AbilityController : ScriptableObject
{

    private List<Ability> _abilities;
}


[CreateAssetMenu(menuName = "abilities", fileName = "New Ability")]
public abstract class Ability : ScriptableObject
{
    public abstract void Use();
}