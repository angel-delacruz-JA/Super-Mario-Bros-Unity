using UnityEngine;

public static class Extensions
{
    private static LayerMask layermask = LayerMask.GetMask("Default");
    public static bool Raycast(this Rigidbody2D rigidbody, Vector2 direccion)
    {
        if (rigidbody.isKinematic)
        {
            return false;
        }
        float radio = 0.25f;
        float distancia = 0.375f;
        RaycastHit2D hit = Physics2D.CircleCast(rigidbody.position, radio, direccion, distancia, layermask);
        return hit.collider != null && hit.rigidbody != rigidbody;
    }
}
