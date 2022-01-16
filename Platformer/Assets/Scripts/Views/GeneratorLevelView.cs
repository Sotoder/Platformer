using UnityEngine;

namespace Platformer
{
    public class GeneratorLevelView
    {
        private GeneratorLevelModel _generatorLevelModel;

        public GeneratorLevelView (GeneratorLevelModel generatorLevelModel)
        {
            _generatorLevelModel = generatorLevelModel;
        }
        public void DrawTiles()
        {

            if (_generatorLevelModel.Map == null)
            {
                return;
            }

            for (int x = 0; x < _generatorLevelModel.WightMap; x++)
            {
                for (int y = 0; y < _generatorLevelModel.HeightMap; y++)
                {

                    Vector3Int tilePosition = new Vector3Int(-_generatorLevelModel.WightMap / 2 + x + _generatorLevelModel.XOffset, 
                                                             -_generatorLevelModel.HeightMap / 2 + y + _generatorLevelModel.YOffset, 0);
                    if (_generatorLevelModel.Map[x, y] == 1)
                    {
                        _generatorLevelModel.Tilemap.SetTile(tilePosition, _generatorLevelModel.GroundTile);
                    }
                }
            }
        }
    }
}
