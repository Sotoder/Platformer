using UnityEngine.Tilemaps;

namespace Platformer
{
    public class GeneratorLevelModel
    {
        private Tilemap _tilemap;
        private Tile _groundTile;
        private int _heightMap;
        private int _wightMap;
        private bool _isHaveBorders;
        private int _fillPercent;
        private int _factorSmooth;
        private int _xOffset;
        private int _yOffset;

        public int[,] Map;

        public Tilemap Tilemap { get => _tilemap; }
        public Tile GroundTile { get => _groundTile; }
        public int HeightMap { get => _heightMap; }
        public int WightMap { get => _wightMap; }
        public bool IsHaveBorders { get => _isHaveBorders; }
        public int FillPercent { get => _fillPercent; }
        public int FactorSmooth { get => _factorSmooth; }
        public int XOffset { get => _xOffset; }
        public int YOffset { get => _yOffset; }

        public GeneratorLevelModel(GeneratorLevelProtoModel generatorLevelProtoModel)
        {
            _tilemap = generatorLevelProtoModel.Tilemap;
            _groundTile = generatorLevelProtoModel.Groundtile;
            _heightMap = generatorLevelProtoModel.HeightMap;
            _wightMap = generatorLevelProtoModel.WightMap;
            _isHaveBorders = generatorLevelProtoModel.IsHaveBorders;
            _fillPercent = generatorLevelProtoModel.FillPercent;
            _factorSmooth = generatorLevelProtoModel.FactorSmooth;
            _xOffset = generatorLevelProtoModel.XOffset;
            _yOffset = generatorLevelProtoModel.YOffset;

            Map = new int[_wightMap, _heightMap];
        }
    }
}