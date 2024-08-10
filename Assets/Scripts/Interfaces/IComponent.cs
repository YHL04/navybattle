
using UnityEngine;

/**
 * IComponent represents basic variables which any component has.
 */
public interface IComponent
{
    Component component { get; }
    GameObject gameObject { get; }
    Transform transform { get; }
    bool enabled { get; set; }
}