using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPoolObjectView : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> _waterSpriteRenderers;

    public List<SpriteRenderer> WaterSpriteRenderers { get => _waterSpriteRenderers; }
}
