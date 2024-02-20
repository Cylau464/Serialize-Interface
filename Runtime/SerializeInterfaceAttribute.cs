using UnityEngine;

public class SerializeInterfaceAttribute : PropertyAttribute
{
    public System.Type SerializedType { get; private set; }

    public SerializeInterfaceAttribute(System.Type type)
    {
        SerializedType = type;
    }
}