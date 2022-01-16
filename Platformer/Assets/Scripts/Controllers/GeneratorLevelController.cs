using UnityEngine;

namespace Platformer
{
    public class GeneratorLevelController
    {
        private GeneratorLevelModel _generatorLevelModel;
        private GeneratorLevelView _generatorLevelView;

        private int CountWall = 4;

        public GeneratorLevelController(GeneratorLevelProtoModel generatorLevelProtoModel)
        {
            _generatorLevelModel = new GeneratorLevelModel(generatorLevelProtoModel);
            _generatorLevelView = new GeneratorLevelView(_generatorLevelModel);

            Init();
        }

        public void Init()
        {
            FillMap();
            SmoothMap();
            _generatorLevelView.DrawTiles();
        }

        private void FillMap()
        {
            for (int x = 0; x < _generatorLevelModel.WightMap; x++)
            {
                for (int y = 0; y < _generatorLevelModel.HeightMap; y++)
                {
                    if (x == 0 || x == _generatorLevelModel.WightMap - 1 || y == 0 || y == _generatorLevelModel.HeightMap - 1)
                    {
                        if (_generatorLevelModel.IsHaveBorders)
                        {
                            _generatorLevelModel.Map[x, y] = 1;
                        }
                    }
                    else
                    {
                        _generatorLevelModel.Map[x, y] = Random.Range(0, 100) < _generatorLevelModel.FillPercent ? 1 : 0;
                    }
                }
            }
        }


        private void SmoothMap()
        {
            for (int x = 0; x < _generatorLevelModel.WightMap; x++)
            {
                for (int y = 0; y < _generatorLevelModel.HeightMap; y++)
                {
                    int neighbour = GetNeighbour(x, y);

                    if (neighbour > CountWall)
                    {
                        _generatorLevelModel.Map[x, y] = 1;
                    }
                    else if (neighbour < CountWall)
                    {
                        _generatorLevelModel.Map[x, y] = 0;
                    }

                }
            }
        }


        private int GetNeighbour(int x, int y)
        {
            int neighbourCounter = 0;

            for (int gridX = x - 1; gridX <= x + 1; gridX++)
            {
                for (int gridY = y - 1; gridY <= y + 1; gridY++)
                {
                    if (gridX >= 0 && gridX < _generatorLevelModel.WightMap && gridY >= 0 && gridY < _generatorLevelModel.HeightMap)
                    {
                        if (gridX != x || gridY != y)
                        {
                            neighbourCounter += _generatorLevelModel.Map[gridX, gridY];
                        }
                    }
                    else
                    {
                        neighbourCounter++;
                    }
                }
            }

            return neighbourCounter;
        }
    }
}