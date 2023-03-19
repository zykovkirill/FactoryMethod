// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

Movie[] movies = new Movie[3];

FilmStudio actionStudio = new ActionStudio("Голивуд");
var action = actionStudio.Create("Перестрелка под забором");
action.PimiereDate = DateTime.Now;
movies[0] = action;

FilmStudio horrorStudio = new HorrorStudio("Хиты тут");
var horror = horrorStudio.Create("Днем темнее");
horror.PimiereDate = DateTime.Now - TimeSpan.FromDays(90);
movies[1] = horror;

var horror2 = horrorStudio.Create("23 часа ночи");
horror2.PimiereDate = DateTime.Now;
movies[2] = horror2;

foreach (var movie in movies.Where(m => m.PimiereDate >= DateTime.Now - TimeSpan.FromMinutes(1)))
{
    Console.WriteLine(movie.Title);
}

Console.ReadLine();

abstract class Movie
{
    private string _title;

    public DateTime PimiereDate { get; set; }
    
    public Movie(string title)
    {
        _title = title;
    }

    public string Title
    {
        get
        {
            return _title;
        }
        set
        {
            _title = value;
        }
    }
}

class Horror : Movie
{
    public Horror(string title) : base(title)
    {
    }
}

class Action : Movie
{
    public Action(string title) : base(title)
    {
    }
}

abstract class FilmStudio
{
    private string _studioName;
    public FilmStudio(string name)
    {
        _studioName = name;
    }

    public string StudioName
    {
        get
        {
            return _studioName;
        }
        set
        {
            _studioName = value;
        }
    }

    abstract public Movie Create(string name);

}

class HorrorStudio : FilmStudio
{
    public HorrorStudio(string name) : base(name)
    {
    }

    public override Movie Create(string name)
    {
        return new Horror(name);
    }
}

class ActionStudio : FilmStudio
{
    public ActionStudio(string name) : base(name)
    {
    }

    public override Movie Create(string name)
    {
       return new Action(name);
    }
}