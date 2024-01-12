using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
namespace ShapeDrawer
{
    internal class GameMethod
    {
        private Catnip _catnip;
        private List<Enemy> _enemies;
        private EffectObserver _effectObserver;
        private List<Projectile> _projectiles;
        private TrackKeyBoardStrategy _keyBoardStrategy;
        private DrawStrategy _drawStrategy;
        private bool _inGame;
        public GameMethod()
        {
            LoadResources();
            _inGame = false;
            _catnip = new Catnip();
            _enemies = new List<Enemy>();
            _effectObserver = new EffectObserver();
            EnemyFactory.Instance.EffectObserver = _effectObserver;
            _projectiles = new List<Projectile>();
            _drawStrategy = new DrawStart(this);
            _keyBoardStrategy = new KeyBoardStartGame(this);

        }
        public void LoadResources()
        {
            SplashKit.LoadBitmap("catnip", "Catnip.png");
            SplashKit.LoadBitmap("dog", "Dog.png");
            SplashKit.LoadBitmap("bullet", "Bullet.png");
            SplashKit.LoadBitmap("kunai", "Kunai.png");
            SplashKit.LoadBitmap("zombie", "Zombie.png");
            SplashKit.LoadBitmap("boss", "Boss.png");
        }
        public void Draw()
        {
            _drawStrategy.Draw();
            
            
        }
        public void DrawEnemy()
        {
            foreach (Enemy e in _enemies)
            {
                e.Draw();
            }
        }
        public void DrawProjectile()
        {
            foreach (Projectile p in _projectiles)
            {
                p.Draw();
            }
        }
        public void createEnemy()
        {
            Random random = new Random();
            double randomNumber = random.NextDouble();
            if(randomNumber > 0.999)
            {
                EnemyFactory  factory = EnemyFactory.Instance;
                _enemies.Add(factory.createRandomEnemy());
            }
        }
        public void Update()
        {
            _keyBoardStrategy.HandleKeyboard();
            if (InGame && !EndGame())
            {
                createEnemy();
                _enemies.RemoveAll(t => (t.OutMap() || t.Health <0));
                _projectiles.RemoveAll(t => t.OutMap());
                foreach (Enemy e in _enemies)
                {
                    e.Update(_catnip,_projectiles);
                }
                foreach (Projectile p in _projectiles)
                {
                    p.Update();
                }
                _effectObserver.Update(_catnip);
                AutomaticBulletCreate();
            }

        }
        public TrackKeyBoardStrategy KeyBoardStrategy
        {
            get
            {
                return _keyBoardStrategy;
            }
            set
            {
                _keyBoardStrategy = value;
            }
        }
        public bool InGame
        {
            get
            {
                return _inGame;
            }
            set
            {
                _inGame = value;
            }
        }
        public DrawStrategy DrawStrategy
        {
            get
            {
                return _drawStrategy;
            }
            set
            {
                _drawStrategy = value;
            }
        }
        public void AutomaticBulletCreate()
        {
            foreach (Enemy e in _enemies)
            {
                if (_catnip.Distance(e) < _catnip.DetectRange && _catnip.CanShoot())
                {
                    Projectile temp = _catnip.Shoot();
                    temp.RotateToPoint(e.Location);
                    _projectiles.Add(temp);
                }
            }
        }
        public Catnip Catnip
        {
            get { return _catnip; }
        }
        public void Reset()
        {
            _catnip.Health = _catnip.OriginalHealth;
            _enemies = new List<Enemy>();
            _projectiles = new List<Projectile>();
            _effectObserver = new EffectObserver();
        }
        public bool EndGame()
        {
            if(_catnip.Health <=0)
            {
                _keyBoardStrategy = new KeyBoardEndGame(this);
                _drawStrategy = new DrawEnd(this);
                return true;
            }
            
            return false;
        }
    }
}
