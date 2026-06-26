# Flappy bird
Ten projekt jest klonem gry video flappy bird. Został on stworzony w ramach projektu zaliczeniowego na zajęcia Programowanie III C#. Wszystkie grafiki są autorskie (wykonane w **gimpie**, a dźwięki wykonane zostały w Online **8-bit sound makerze**. Domyślna rozdzielczość: 1152:648

## Technologie
Do stworzenia gry użyłem Godota C# w wersji 4.6.2. Jako framework do testów wybrałem Xunit. Jak wyżej wspomniałem, Używałem też gimpa i 8bit sound makera. No i oczywiście git jako system kontroli wersji.

## RELEASE
W razie gdyby linki nie działały to proszę dać znać. W linkach można pobrać grę (jest gotowa do uruchomienia, nie trzeba mieć godota u siebie na komputerze)

- Windows: [Gra na Windows](https://www.mediafire.com/file/h1d49tj2089uecm/gra.zip) - nietestowane, nie mam maszyny z Windowsem.
- Linux: [Gra na Linux](https://www.mediafire.com/file/331q98n86rx5h8n/gralin.zip/file) - testowane, działa

## Gameplay
W menu glównym mamy 3 przyciski - play, leaderboard i exit.
- play: odpala grę
- leaderboard: pokazuje top 15 wyników gracza na danym urządzeniu.
- exit: zamyka grę <br>
<img width="1143" height="641" alt="image" src="https://github.com/user-attachments/assets/282dbb56-0352-4fca-a81a-d39895e9bd17" />

<br>
<br>

**Gra:**
Celem gracza jest unikanie nadciągających z prawej strony rur, jednocześnie nie uderzając w sufit ani w podłogę. Skok odbywa się za pomocą lewego przycisku myszy, a opadanie nieklikaniem. Celem jest zdobycie jak największej liczby punktów. Kolizja przerywa grę i pokazuje ekran do restartu/wyjścia do menu <br>

<img width="1142" height="639" alt="image" src="https://github.com/user-attachments/assets/2ae9da5c-d9a0-402c-8dd2-d09caa841292" />

<br>
<br>

**Leaderboard:** Wyświetla top 15 wyników gracza na danym urządzeniu posortowane od największego. <br>

<img width="1134" height="633" alt="image" src="https://github.com/user-attachments/assets/f818e651-865c-4c83-877e-71369b65e411" />

## Struktura:
```
Flappy-bird/
├── assets/
│   ├── sounds/
│   │   ├── hitHurt.wav
│   │   ├── level.wav
│   │   ├── level10.wav
│   │   ├── synth.wav
│   │   └── synth.json
│   ├── button.png
│   ├── dol.png
│   ├── duck.png
│   ├── icon.png
│   ├── pillar.png
│   └── tlo.png
├── scenes/
│   ├── character.tscn
│   ├── game.tscn
│   ├── leaderboard.tscn
│   ├── main_menu.tscn
│   └── pipe.tscn
├── scripts/
│   └── gameplay/
│       ├── core/
│       │   └── RestartContainer.cs
│       ├── database/
│       │   ├── DbContext.cs
│       │   ├── Score.cs
│       │   └── ScoreEntry.cs
│       ├── leaderboard/
│       │   ├── LeaderboardManager.cs
│       │   └── MenuButton.cs
│       ├── menu/
│       │   ├── Button.cs
│       │   ├── ExitButton.cs
│       │   └── LeaderboardButton.cs
│       ├── Character.cs
│       ├── FloorCollision.cs
│       ├── GameManager.cs
│       ├── PipeCollision.cs
│       ├── PipeManager.cs
│       ├── PipeSpawner.cs
│       ├── ScoreCollision.cs
│       └── ScoreManager.cs
├── GameTests/
│   └── UnitTest1.cs
├── .editorconfig
├── .gitattributes
├── .gitignore
├── export_presets.cfg
├── project.godot
└── README.md
```

- assets: zdjęcia, dźwięki
- scenes: pliki .tscn (scen)
- database: obsługa bazy danych
- menu: obsługa sceny menu
- leaderboard: obsługa sceny leaderboard
- reszta w gameplay/: działanie gry (kolizje, liczenie wyniku itd)
- GameTests: folder do testów.

## Sceny:
- character: tytułowy ptak, ma kształt wielokąta. Jest umieszczany w innych scenach
- pipe: Rura, a dokładniej jedna z jej części. składowa sceny game, występuje zawsze parami (góra i dół). Kolizyjna z graczem.
- main menu: główne menu
- leaderboard: ranking graczy
- game: najważniejsza scena, zawiera w sobie resztę podscen takich jak character czy pipe. to tutaj odbywa się cała rozgrywka.

Przełączanie między scenami:
```C#
public void MenuOnClick()
    {
		GetTree().Paused = false;
        GetTree().ChangeSceneToFile("res://scenes/main_menu.tscn");
		this.Visible=false;
    }
```

## Baza danych:
W projekcie do przechowywania wyników użyłem bazy danych. Wybór padł na **SQLite** przez swoją kompaktowość (PostgreSQL byłby overkillem). Użyłem także **Entity Framework** wraz ze składnią **LINQ**.
Co robi baza danych?
- Dodawanie wyników gracza do bazy danych na sygnał kolizji gracza z przeszkodą
- Zwracanie top 15 wyników w **Score.cs**
- Usuwanie nadmiarowych wyników (przechowujemy w bazie max 15 wyników)

<br>

Wszystkie zapytania znajdują się w **Score.cs**
<br>
przykładowe użycie bazy danych: 
```C#
 public void SaveScore(int score)
    {
        GD.Print("sygnal savescore");
        try
        {
            GD.Print($"sc:{score}");
            using var db = new GameDb();
            db.Scores.Add(new ScoreEntry { Value = score, ScoreDate=DateTime.Now });
            db.SaveChanges();
            GD.Print("zapisano do db");
        }
        catch(Exception e)
        {
            GD.PrintErr($"Nie zapisano do db {e.Message}");
        }
    }
```
po sygnale
```C#
private void OnBodyEntered(Node2D body)
    {
        //HitSound.Play();
        //EmitSignal(SignalName.ShowRestart);

        EmitSignal(SignalName.SaveScore,ScoreManager.score);
		//GetTree().Paused = true;
        
    }
```
## Testy:
Jak wyżej wspomniałem do testów jednostkowych użylem frameworka Xunit. Stworzyłem 3 testy jednostkowe - test zapisu rekordu do bazy, test zwracania z bazy oraz sprawdzenie pustości bazy po stworzeniu. Testy znajdują się w projekcie **GameTests**
<br>
Uruchamianie testów:

```
cd GameTests
dotnet test
```
Przykładowy test: 
```C#
[Fact]
    public void GetTopScores_ReturnsHighestFirst()
    {
        var db = new GameDb(NewTestDbPath());
        db.Database.EnsureCreated();

        db.Scores.Add(new ScoreEntry { Value = 10, ScoreDate = DateTime.Now });
        db.Scores.Add(new ScoreEntry { Value = 99, ScoreDate = DateTime.Now });
        db.SaveChanges();

        var top = db.Scores.OrderByDescending(s => s.Value).First();

        Assert.Equal(99, top.Value);
    }
```
### Uwagi techniczne:
- W dbcontext ustawiamy ściezkę na user:// zamiast res:// bo inaczej baza danych może nam zniknąć przy pakowaniu projektu. 
- Z procesu kompilacji w .csproj wyłączyłem GameTests - inaczej dostajemy duplikaty.
- Score jest autoloadem, czyli można go wywoływać globalnie po Score.Instance:
```C#
public partial class LeaderboardManager : Node2D
{
	[Export] public VBoxContainer ScoreList;
	public override void _Ready()
    {
		ScoresView();
        Score.Instance.PrintScores();
    }
```
