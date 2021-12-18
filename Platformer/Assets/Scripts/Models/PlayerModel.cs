
namespace Platformer
{
    public class PlayerModel
    {
        public float Speed;
        public float Force;
        public float JumpForce;
        public int CurrentCountAirJumps;
        public float AnimationSpeed;

        public IState CurentState;
        public bool IsOnGround;

        private int _maxCountAirJumps;
        public int MaxCountAirJumps { get => _maxCountAirJumps; }

        public PlayerModel(PlayerModelConfig playerConfig)
        {
            Speed = playerConfig.Speed;
            Force = playerConfig.Force;
            JumpForce = playerConfig.JumpForce;
            AnimationSpeed = playerConfig.AnimationSpeed;
            _maxCountAirJumps = playerConfig.CountAirJumps;
            CurrentCountAirJumps = playerConfig.CountAirJumps;
        }
    }
}