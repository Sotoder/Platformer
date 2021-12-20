
namespace Platformer
{
    public class PlayerModel
    {
        public readonly float Speed;
        public readonly float SprintModifier;
        public readonly float Force;
        public readonly float JumpForce;

        public int CurrentCountAirJumps;
        public IState CurentState;
        public bool IsOnGround;
        public bool IsSprint;

        private int _maxCountAirJumps;
        private int _coinsScore;
        public int MaxCountAirJumps { get => _maxCountAirJumps; }
        public int CoinsScore { get => _coinsScore; }

        public PlayerModel(PlayerModelConfig playerConfig)
        {
            Speed = playerConfig.Speed;
            SprintModifier = playerConfig.SprintModifier;
            Force = playerConfig.Force;
            JumpForce = playerConfig.JumpForce;
            _maxCountAirJumps = playerConfig.CountAirJumps;
            CurrentCountAirJumps = playerConfig.CountAirJumps;
        }

        public void AddCoinsScore()
        {
            _coinsScore++;
            UnityEngine.Debug.Log(_coinsScore);
        }
    }
}