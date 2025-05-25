using UnityEngine;

public class SoundManager : SaiSingleton<SoundManager>
{
    [SerializeField] protected SoundName bgName = SoundName.Narco;
    [SerializeField] protected MusicCtrl bgMusic;
    [SerializeField] protected SoundSpawnerCtrl ctrl;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    protected override void Start()
    {
        base.Start();
        //this.StartMusicBackground();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSoundSpawnerCtrl();
    }

    protected virtual void LoadSoundSpawnerCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = GameObject.FindAnyObjectByType<SoundSpawnerCtrl>();
        Debug.Log(transform.name + ": LoadSoundSpawnerCtrl", gameObject);
    }

    public virtual void StartMusicBackground()
    {
        if (this.bgMusic == null) this.bgMusic = this.CreateBackgroundMusic();
        this.bgMusic.gameObject.SetActive(true);
    }

    protected virtual MusicCtrl CreateBackgroundMusic()
    {
        MusicCtrl musicPrefab = (MusicCtrl)this.ctrl.Prefabs.GetByName(this.bgName.ToString());
        return (MusicCtrl)this.ctrl.Spawner.Spawn(musicPrefab, Vector3.zero);
        //Phương thức GetByName() có thể trả về một đối tượng có kiểu dữ liệu cơ bản (base type), nhưng ta cần sử dụng các tính năng đặc thù của MusicCtrl. Việc ép kiểu giúp ta có thể truy cập các phương thức và thuộc tính riêng của MusicCtrl.
        // Tương tự, phương thức Spawn() có thể trả về một đối tượng có kiểu dữ liệu cơ bản, nhưng ta cần đảm bảo rằng đối tượng được tạo ra là một MusicCtrl để có thể sử dụng các chức năng đặc thù của nó.
    }

    public virtual void ToggleMusic()
    {
        if (this.bgMusic == null)
        {
            this.StartMusicBackground();
            return;
        }

        bool status = this.bgMusic.gameObject.activeSelf;
        this.bgMusic.gameObject.SetActive(!status);
    }
}
