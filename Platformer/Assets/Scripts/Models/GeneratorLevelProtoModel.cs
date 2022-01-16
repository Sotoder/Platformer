using System;
using UnityEngine.Tilemaps;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public class GeneratorLevelProtoModel
    {
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private Tile _groundTile;
        [SerializeField] private Tile _grassTile;
        [SerializeField] private int _heightMap;
        [SerializeField] private int _wightMap;
        [SerializeField] private bool _isHaveBorders;
        [SerializeField][Range(0,100)] private int _fillPercent;
        [SerializeField][Range(0, 10)] private int _factorSmooth;
        [SerializeField] private int _xOffset;
        [SerializeField] private int _yOffset;

        public Tilemap Tilemap { get => _tilemap; }
        public Tile GroundTile { get => _groundTile; }
        public Tile GrassTile { get => _grassTile; }
        public int HeightMap { get => _heightMap; }
        public int WightMap { get => _wightMap; }
        public bool IsHaveBorders { get => _isHaveBorders; }
        public int FillPercent { get => _fillPercent; }
        public int FactorSmooth { get => _factorSmooth; }
        public int XOffset { get => _xOffset; }
        public int YOffset { get => _yOffset; }
    }
}