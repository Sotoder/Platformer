using UnityEngine;

namespace Platformer
{
    internal class PlayerGroundDetector
    {
        private PlayerModel _playerModel;
        private PlayerView _playerView;
        //private ContactPoint2D[] _contacts = new ContactPoint2D[10];

        public PlayerGroundDetector(PlayerModel playerModel, PlayerView playerView)
        {
            _playerModel = playerModel;
            _playerView = playerView;
        }

        public void Update()
        {
            //_playerModel.IsOnGround = false;
            //var contactsCount = _playerView.Collider2D.GetContacts(_contacts);

            //for (int i = 0; i < contactsCount; i++)
            //{
            //    if (_contacts[i].normal.y > 0)
            //    {
            //        _playerModel.IsOnGround = true;
            //    }
            //}

            // Сделал методом с урока, также через отслеживание скорости по Y и через оверлап, все метды работают, но через контакты и скорость нет нет происходит косяк с анимацией
            // на переходах, искал причину, не нашел.
            // Блоки стоят ровненько. Также при движении по диоганали вниз, также происходит короткий глюк по анимации, так как нормаль падает, причем в 0, так как проверку делал на > 0.
            // Вобщем для красоты оставил свой. Оверлап срабатывает только в те моменты, когда персонаж падает или подпрыгивает

            if (_playerView.Rigidbody2D.velocity.y != 0) // Проверка для исключения лишних вызовов Оверлапа
            {
                if (Time.frameCount % 2 == 0) // Вызов Оверлапа каждый второй кадр, для снижения нагрузки.
                {
                    if(Physics2D.OverlapCircle(_playerView.GroundDetector.transform.position, _playerView.GroundDetectorRadius, _playerView.GroundMask))
                    {
                        _playerModel.IsOnGround = true;
                        _playerModel.CurrentCountAirJumps = _playerModel.MaxCountAirJumps;
                    }
                    else
                    {
                        _playerModel.IsOnGround = false;
                    }
                    
                }
            }
            else // Небольшой костыль для смены анимации при загрузке уровня, не могу понять почему не отрабатывает Оверлап
            {
                if (!_playerModel.IsOnGround)
                {
                    _playerModel.IsOnGround = true;
                    _playerModel.CurrentCountAirJumps = _playerModel.MaxCountAirJumps;
                }
            }
        }
    }
}